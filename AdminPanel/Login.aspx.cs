using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBook2ConnectionString"].ConnectionString);

        #region Local Variables

        SqlString strUserName = SqlString.Null;
        SqlString strPassword = SqlString.Null;

        #endregion Local Variables

        try
        {
            #region Server Side Validation

            String strError = "";
            if (txtUserName.Text.Trim() == String.Empty)
            {
                strError += "- Enter UserName <br/>";
            }

            if (txtPassword.Text.Trim() == String.Empty)
            {
                strError += "- Enter Password <br />";
            }

            if (strError != "")
            {
                lblMsg.Text += "Kindly Solve following Error(s) <br />" + strError;
                return;
            }

            #endregion Server Side Validation

            #region Assign the Value

            if (txtUserName.Text.Trim() != "")
            {
                strUserName = txtUserName.Text.Trim();
            }

            if (txtPassword.Text.Trim() != "")
            {
                strPassword = txtPassword.Text.Trim();
            }

            #endregion Assign the Value

            if (objCon.State == ConnectionState.Closed)
            {
                objCon.Open();
            }

            SqlCommand objCmd = objCon.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_User_SelectByUserNamePassword";

            objCmd.Parameters.AddWithValue("@UserName", strUserName);
            objCmd.Parameters.AddWithValue("@Password", strPassword);

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {

                while (objSDR.Read())
                {
                    if (!objSDR["UserID"].Equals(DBNull.Value))
                    {
                        Session["UserID"] = objSDR["UserID"].ToString().Trim();
                    }
                    if (!objSDR["DisplayName"].Equals(DBNull.Value))
                    {
                        Session["DisplayName"] = objSDR["DisplayName"].ToString().Trim();
                    }
                    break;
                }
                Response.Redirect("~/AdminPanel/Default.aspx", true);
            }
            else
            {
                lblMsg.Text = "Invalid UserName or Password!!";
            }
            objCon.Close();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
        finally
        {
            if (objCon.State != ConnectionState.Closed)
            {
                objCon.Close();
            }
        }
    }
    protected void btnSignIn_Click(object sender, EventArgs e)
    {
            Response.Redirect("~/AdminPanel/SignIn.aspx");
    }
}