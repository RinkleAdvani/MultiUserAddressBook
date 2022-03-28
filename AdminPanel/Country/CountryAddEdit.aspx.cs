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

public partial class AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //if (Request.QueryString["CountryID"] != null)
            if (Page.RouteData.Values["CountryID"] != null)
            {
                btnSave.Text = "Update";
                //FillControls(Convert.ToInt32(Request.QueryString["CountryID"]));
                FillControls(EncodeDecode.Base64Decode(Page.RouteData.Values["CountryID"].ToString().Trim()));
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBook2ConnectionString"].ConnectionString);

        SqlString strCountryCode = SqlString.Null;
        SqlString strCountryName = SqlString.Null;

        try
        {
            if (objCon.State == ConnectionState.Closed)
            {
                objCon.Open();
            }
            String strError = "";

            if (txtCountryName.Text.Trim() == "")
            {
                strError += "- Enter Country Name <br/>";
            }

            if (txtCountryCode.Text.Trim() == "")
            {
                strError += "- Enter Country Code <br/>";
            }
            if (strError != "")
            {
                lblMessage.Text += "Kindly solve following Error(s) <br/>" + strError + "<br />";
                return;
            }

            if (txtCountryCode.Text.Trim() != "")
            {
                strCountryCode = txtCountryCode.Text.Trim();
            }
            if (txtCountryName.Text.Trim() != "")
            {
                strCountryName = txtCountryName.Text.Trim();
            }

            

            SqlCommand objCom = objCon.CreateCommand();
            objCom.CommandType = CommandType.StoredProcedure;

            if (Session["UserID"] != null)
                objCom.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCom.Parameters.AddWithValue("@CountryCode", strCountryCode);
            objCom.Parameters.AddWithValue("@CountryName", strCountryName);

            if (Page.RouteData.Values["CountryID"] != null)
            {
                objCom.Parameters.AddWithValue("@CountryID", EncodeDecode.Base64Decode(Page.RouteData.Values["CountryID"].ToString().Trim()));

                objCom.CommandText = "PR_Country_UpdateByPK";
                objCom.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/Country/CountryList.aspx",true);
            }
            else
            {
                objCom.CommandText = "PR_Country_Insert";

                objCom.ExecuteNonQuery();
                lblMsg.Text = "Data Inserted Successfully";
                txtCountryName.Text = "";
                txtCountryCode.Text = "";
                txtCountryCode.Focus();
            }

            objCon.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objCon.State == ConnectionState.Open)
            {
                objCon.Close();
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Country/CountryList.aspx", true);
    }

    protected void FillControls(string CountryID)
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBook2ConnectionString"].ConnectionString);
        try
        {
            if (objCon.State != ConnectionState.Open)
            {
                objCon.Open();
            }

            SqlCommand objCmd = objCon.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectByPK";
            objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString().Trim());

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["CountryName"].Equals(DBNull.Value))
                    {
                        txtCountryName.Text = objSDR["CountryName"].ToString().Trim();
                    }
                    if (!objSDR["CountryCode"].Equals(DBNull.Value))
                    {
                        txtCountryCode.Text = objSDR["CountryCode"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No data available";
            }
            objCon.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objCon.State == ConnectionState.Open)
            {
                objCon.Close();
            }
        }
    }
}