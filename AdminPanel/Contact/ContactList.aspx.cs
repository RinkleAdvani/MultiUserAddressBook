using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Contact_Contact : System.Web.UI.Page
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

    #region Fill GridView
    private void FillGridView()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBook2ConnectionString"].ConnectionString);
        try
        {
            if (objConn.State == ConnectionState.Closed)
                objConn.Open();

            #region Set Connection and Command Objects
            SqlCommand objComm = new SqlCommand();
            objComm.Connection = objConn;
            objComm.CommandType = CommandType.StoredProcedure;
            objComm.CommandText = "PR_Contact_SelectByUserID";
            if (Session["UserID"] != null)
            {
                objComm.Parameters.AddWithValue("@UserID", Session["UserID"]);
            }
            #endregion Set Connection and Command Objects

            SqlDataReader objSDR = objComm.ExecuteReader();
            gvContact.DataSource = objSDR;
            gvContact.DataBind();
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
    #endregion Fill GridView

    #region RowCommand
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region  Delete Record
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteRecord(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                DeleteContactCategory(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
        #endregion  Delete Record
    }
    #endregion RowCommand

    #region Delete Record
    private void DeleteRecord(SqlInt32 ContactID)
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBook2ConnectionString"].ConnectionString.Trim());
        try
        {
            if (objCon.State == ConnectionState.Closed)
                objCon.Open();

            #region Delete Photo from floder

            #region Set Connection and Command Objects
            SqlCommand objcmdPhoto = objCon.CreateCommand();
            objcmdPhoto.CommandType = CommandType.StoredProcedure;
            objcmdPhoto.CommandText = "PR_Contact_SelectByPK";
            #endregion Set Connection and Command Objects

            objcmdPhoto.Parameters.AddWithValue("@ContactID", ContactID.ToString().Trim());

            SqlDataReader objSDR = objcmdPhoto.ExecuteReader();

            #region Read the Values and Set Controls
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["ContactPhotoPath"].Equals(DBNull.Value))
                    {
                        String ContactPhotoPath = objSDR["ContactPhotoPath"].ToString().Trim();

                        FileInfo file = new FileInfo(Server.MapPath(ContactPhotoPath));

                        if (file.Exists)
                        {

                            file.Delete();  
                        }
                    }
                    break;
                }
            }
            objSDR.Close();
            #endregion Read the Values and Set Controls


            #endregion Delete Photo from floder

            #region Set Connection And Command Object
            SqlCommand objCom = objCon.CreateCommand();
            objCom.CommandType = CommandType.StoredProcedure;
            objCom.CommandText = "PR_Contact_DeleteByPK";
            #endregion Set Connection And Command Object

            objCom.Parameters.AddWithValue("@ContactID", ContactID.ToString().Trim());
            objCom.ExecuteNonQuery();
            objCon.Close();


            FillGridView();
            DeleteContactCategory(Convert.ToInt32(Page.RouteData.Values["ContactId"]));
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
    #endregion Delete Record

    #region Delete ContactCategory
    private void DeleteContactCategory(SqlInt32 ContactID)
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBook2ConnectionString"].ConnectionString.Trim());
        try
        {
            if (objCon.State == ConnectionState.Closed)
                objCon.Open();

            #region Set Connection And Command Object
            SqlCommand objCom = objCon.CreateCommand();
            objCom.CommandType = CommandType.StoredProcedure;
            objCom.CommandText = "PR_ContactWiseContactCategory_DeleteByContactIDUserID";
            #endregion Set Connection And Command Object

            objCom.Parameters.AddWithValue("@ContactID", ContactID.ToString().Trim());
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
    #endregion Delete ContactCategory

    //#region Delete File
    //private void DeleteFile(SqlInt32 ContactID)
    //{
    //    String LogicalPath = "";
    //    SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBook2ConnectionString"].ConnectionString);
    //    try
    //    {
    //        if (objConn.State != ConnectionState.Open)
    //            objConn.Open();
    //        SqlCommand objCmd = objConn.CreateCommand();
    //        objCmd.CommandType = CommandType.StoredProcedure;
    //        objCmd.CommandText = "[dbo].[PR_Contact_GetLogicalPathByUserIDContactID]";
    //        if (Session["UserID"] != null)
    //            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
    //        objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString());
    //        SqlDataReader objSDR = objCmd.ExecuteReader();

    //        if (objSDR.HasRows)
    //        {
    //            while (objSDR.Read())
    //            {
    //                LogicalPath = objSDR["ContactPhotoPath"].ToString();
    //            }
    //        }
    //        if (objConn.State == ConnectionState.Open)
    //            objConn.Close();

    //        String AbsolutePath = Server.MapPath(LogicalPath);
    //        FileInfo file = new FileInfo(AbsolutePath);
    //        lblMessage.Text = AbsolutePath + "----" + file.Exists;

    //        if (file.Exists)
    //        {
    //            System.GC.Collect();
    //            System.GC.WaitForPendingFinalizers();
    //            file.Delete();
    //            lblMessage.Text = "File is Deleted";
    //        }
    //        else
    //        {
    //            lblMessage.Text = "File not Found";
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Text = ex.Message;
    //    }
    //    finally
    //    {
    //        if (objConn.State == ConnectionState.Open)
    //            objConn.Close();
    //    }

    //}
    //#endregion Delete File

}