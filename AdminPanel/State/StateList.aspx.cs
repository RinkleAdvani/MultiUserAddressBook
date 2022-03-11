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

public partial class AdminPanel_State_StateList : System.Web.UI.Page
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

    #region FillGridView
    private void FillGridView()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBook2ConnectionString"].ConnectionString);
        try
        {
            if (objConn.State == ConnectionState.Closed)
                objConn.Open();
            #region Set Connection and Command Objects
            SqlCommand objComm = objConn.CreateCommand();
            objComm.CommandType = CommandType.StoredProcedure;
            objComm.CommandText = "PR_State_SelectByUserID";
            if (Session["UserID"] != null)
                objComm.Parameters.AddWithValue("@UserID", Session["UserID"]);
            #endregion Set Connection and Command Objects

            SqlDataReader objSDR = objComm.ExecuteReader();
            gvState.DataSource = objSDR;
            gvState.DataBind();
            objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
    }
    #endregion FillGridView

    #region GridView : State
    protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region Delete record
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteRecord(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
        #endregion Delete record

    }
    #endregion GridView : State

    #region Delete
    private void DeleteRecord(int StateID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBook2ConnectionString"].ConnectionString.Trim());
        try
        {
            if (objConn.State == ConnectionState.Closed)
                objConn.Open();
            #region Set Connection And Commands Objects
            SqlCommand objComm = objConn.CreateCommand();
            objComm.CommandType = CommandType.StoredProcedure;
            objComm.CommandText = "PR_State_DeleteByUserID";
            #endregion Set Connection And Commands Objects

            if (Session["UserID"] != null)
                objComm.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objComm.Parameters.AddWithValue("@StateID", StateID.ToString().Trim());
            objComm.ExecuteNonQuery();

            objConn.Close();
            FillGridView();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
    }
    #endregion Delete
}
