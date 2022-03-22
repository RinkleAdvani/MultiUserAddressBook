using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Country_CountryList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridView();
        }
    }
    #endregion Load Event

    #region Fill Grid View
    private void FillGridView()
    {
        SqlConnection objcon = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBook2ConnectionString"].ConnectionString);
        try
        {
            if (objcon.State == ConnectionState.Closed)
            {
                objcon.Open();
            }
            SqlCommand objcom = objcon.CreateCommand();
            objcom.CommandType = CommandType.StoredProcedure;
            objcom.CommandText = "[PR_Country_SelectByUserID]";
            if (Session["UserID"] != null)
                objcom.Parameters.AddWithValue("@UserID", Session["UserID"]);

            SqlDataReader objSDR = objcom.ExecuteReader();
            gvCountry.DataSource = objSDR;
            gvCountry.DataBind();
            objcon.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objcon.State == ConnectionState.Open)
            {
                objcon.Close();
            }
        }
    }
    #endregion Fill Grid View

    #region Country Row Command
    protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != "")
            {
                DeleteRecord(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
    }
    #endregion Country Row Command

    #region Delete Record
    private void DeleteRecord(int CountryID)
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBook2ConnectionString"].ConnectionString.Trim());

        try
        {
            if (objCon.State == ConnectionState.Closed)
            {
                objCon.Open();
            }

            SqlCommand objCmd = objCon.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_DeleteByUserID";

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("CountryID", CountryID.ToString().Trim());
            objCmd.ExecuteNonQuery();

            objCon.Close();
            FillGridView();
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
    #endregion Delete Record
}