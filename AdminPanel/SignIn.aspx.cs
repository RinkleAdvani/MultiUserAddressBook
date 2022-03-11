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

public partial class AdminPanel_SignIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBook2ConnectionString"].ConnectionString);

        //Local Variables

        SqlString strUsername = SqlString.Null;
        SqlString strName = SqlString.Null;
        SqlString strMobileNo = SqlString.Null;
        SqlString strEmail = SqlString.Null;
        SqlString strPassword = SqlString.Null;
        SqlString strConfirmPassword = SqlString.Null;

        try
        {
            string strError = "";

            if (txtUserName.Text.Trim() == "")
            {
                strError += "- Enter Username <br/>";
            }

            if (txtName.Text.Trim() == "")
            {
                strError += "- Enter Name <br/>";
            }

            if (txtPassword.Text.Trim() == "")
            {
                strError += "- Enter Password <br/>";
            }

            if (txtConfirmPassword.Text.Trim() == "")
            {
                strError += "- Enter Confirm Password <br/>";
            }

            if (strError != "")
            {
                lblMsg.Text += "Kindly Solve following Error(s) <br />" + strError;
                return;
            }

            //Gather Information

            if (txtName.Text.Trim() != "")
            {
                strName = txtName.Text.Trim();
            }

            if (txtUserName.Text.Trim() != "")
            {
                strUsername = txtUserName.Text.Trim();
            }

            if (txtMobileNo.Text.Trim() != "")
            {
                strMobileNo = txtMobileNo.Text.Trim();
            }

            if (txtEmail.Text.Trim() != "")
            {
                strEmail = txtEmail.Text.Trim();
            }

            if (txtPassword.Text.Trim() != "")
            {
                strPassword = txtPassword.Text.Trim();
            }

            if (txtConfirmPassword.Text.Trim() != "")
            {
                strConfirmPassword = txtConfirmPassword.Text.Trim();
            }

            if (objCon.State != ConnectionState.Open)
            {
                objCon.Open();
            }

            SqlCommand objCmd = objCon.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            objCmd.CommandText = "PR_User_Insert";
            objCmd.Parameters.AddWithValue("@Username", strUsername);
            objCmd.Parameters.AddWithValue("@Name", strName);
            objCmd.Parameters.AddWithValue("@MobileNo", strMobileNo);
            objCmd.Parameters.AddWithValue("@Email", strEmail);
            objCmd.Parameters.AddWithValue("@Password", strPassword);
            objCmd.Parameters.AddWithValue("@ConfirmPassword", strConfirmPassword);

            objCmd.ExecuteNonQuery();
            txtUserName.Text = "";
            txtName.Text = "";
            txtMobileNo.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
            txtConfirmPassword.Text = "";
            txtUserName.Focus();
            objCon.Close();

        }
        catch(Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
        finally
        {
            if (objCon.State == ConnectionState.Open)
                objCon.Close();
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Login.aspx");
    }
}