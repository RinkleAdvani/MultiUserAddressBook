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

public partial class AdminPanel_City_CityList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserID"] != null)
            {
                FillGridView();
            }
            
        }
    }
    #endregion Load Event

    #region Fill GridView
    private void FillGridView()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBook2ConnectionString"].ConnectionString);
        try
        {
            objConn.Open();
            SqlCommand objComm = objConn.CreateCommand();
            objComm.CommandType = CommandType.StoredProcedure;
            objComm.CommandText = "PR_City_SelectByUserID";
            if (Session["UserID"] != null)
                objComm.Parameters.AddWithValue("@UserID", Session["UserID"]);
            SqlDataReader objSDR = objComm.ExecuteReader();

            if (objSDR.HasRows)
            {
                gvCity.DataSource = objSDR;
                gvCity.DataBind();
            
            }
            objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }
    }
    #endregion Fill GridView

    #region RowCommand
    protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region Delete Record
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteRecord(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
        #endregion Delete Record
    }
    #endregion RowCommand

    #region Delete record
    private void DeleteRecord(SqlInt32 CityID)
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBook2ConnectionString"].ConnectionString.Trim());
        try
        {
            if (objCon.State == ConnectionState.Closed)
                objCon.Open();

            #region Set Connection and Command Objects
      
            SqlCommand objCom = objCon.CreateCommand();
            objCom.CommandType = CommandType.StoredProcedure;
            objCom.CommandText = "PR_City_DeleteByPK";
            //if (Session["UserID"] != null)
            //    objCom.Parameters.AddWithValue("@UserID", Session["UserID"]);
            #endregion Set Connection and Command Objects

            objCom.Parameters.AddWithValue("@CityID", CityID);
            objCom.ExecuteNonQuery();

            objCon.Close();
            FillGridView();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            objCon.Close();
        }
    }
    #endregion Delete record
}