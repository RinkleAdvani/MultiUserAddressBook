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

public partial class AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDown();
            FillCBLContactCategory();

            if (Page.RouteData.Values["ContactId"] != null)
            {
                btnSave.Text = "Update";
                //lblMessage.Text += "Edit mode | ContactID = " + Request.QueryString["ContactId"];
                FillControls(Convert.ToInt32(Page.RouteData.Values["ContactId"]));
            }
            //else
            //{
            //    lblMessage.Text = "Add Mode";
            //}
        }
    }
    #endregion Load Event

    #region Fill DropDown
    private void FillDropDown(){

        CommonDropDownFillMethods.FillDropDownListCountry(ddlCountry);
        CommonDropDownFillMethods.FillDropDownListStateByCountryID(ddlState, ddlCountry);
        CommonDropDownFillMethods.FillDropDownListCityByStateID(ddlCity, ddlState);

        //SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBook2ConnectionString"].ConnectionString);
        //try
        //{
        //    if (objCon.State == ConnectionState.Closed)
        //        objCon.Open();

        //    #region Set Connection and Command Objects

        //    SqlCommand objCom = objCon.CreateCommand();
        //    objCom.CommandType = CommandType.StoredProcedure;
        //    objCom.CommandText = "[dbo].[PR_Country_SelectForDropDownList]";

        //    #endregion Set Connection and Command Objects
        //    SqlDataReader objSDR = objCom.ExecuteReader();

        //    //objSDR.Read();

        //    #region Read the Values and Set the Controls

        //    if (objSDR.HasRows == true)
        //    {
        //        ddlCountry.DataSource = objSDR;
        //        ddlCountry.DataValueField = "CountryID";
        //        ddlCountry.DataTextField = "CountryName";
        //        ddlCountry.DataBind();
        //    }
        //    objSDR.Close();

        //    //objCom.CommandText = "PR_State_SelectForDropDownList";
        //    //SqlDataReader objSDR1 = objCom.ExecuteReader();
        //    //objSDR1.Read();
        //    //if (objSDR1.HasRows == true)
        //    //{
        //    //    ddlState.DataSource = objSDR1;
        //    //    ddlState.DataValueField = "StateID";
        //    //    ddlState.DataTextField = "StateName";
        //    //    ddlState.DataBind();
        //    //}
        //    //objSDR1.Close();


        //    //objCom.CommandText = "PR_City_SelectForDropDownList";
        //    //SqlDataReader objSDR2 = objCom.ExecuteReader();
        //    //objSDR2.Read();
        //    //if (objSDR2.HasRows == true)
        //    //{
        //    //    ddlCity.DataSource = objSDR2;
        //    //    ddlCity.DataValueField = "CityID";
        //    //    ddlCity.DataTextField = "CityName";
        //    //    ddlCity.DataBind();
        //    //}
        //    //objSDR2.Close();

        //    //objCom.CommandText = "PR_ContactCategory_SelectByDropDownList";

        //    //SqlDataReader objSDR3 = objCom.ExecuteReader();
        //    ////objSDR3.Read();
        //    //if (objSDR3.HasRows == true)
        //    //{
        //    //    ddlContactCategory.DataSource = objSDR3;
        //    //    ddlContactCategory.DataValueField = "ContactCategoryID";
        //    //    ddlContactCategory.DataTextField = "ContactCategoryName";
        //    //    ddlContactCategory.DataBind();
        //    //}
        //    //objSDR3.Close();
        //    #endregion Read the Values and Set the Controls

        //    objCon.Close();

        //    ddlCountry.Items.Insert(0, new ListItem("---- Select Country ----", "-1"));
        //    //ddlContactCategory.Items.Insert(0, new ListItem("---- Select Contact Category ----", "-1"));
        //    ddlState.Items.Insert(0, new ListItem("---- Select State ----", "-1"));
        //    ddlCity.Items.Insert(0, new ListItem("---- Select City ----", "-1"));

        //}
        //catch (Exception ex)
        //{
        //    lblMessage.Text = ex.Message;
        //}
        //finally
        //{
        //    objCon.Close();
        //}


    }
    #endregion Fill DropDown

    //#region Fill State DropDown
    //public void FillStateDropDown()
    //{
    //    SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBook2ConnectionString"].ConnectionString);

    //    ddlState.Items.Clear();

    //    objCon.Open();
    //    SqlString strCountryID = SqlString.Null;
    //    if (ddlCountry.SelectedIndex > 0)
    //        strCountryID = ddlCountry.SelectedValue;
    //    SqlCommand objCom = objCon.CreateCommand();
    //    objCom.CommandType = CommandType.StoredProcedure;
    //    objCom.CommandText = "PR_Contact_StateDDByCountry";
    //    if (Session["UserID"] != null)
    //    {
    //        objCom.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
    //    }
    //    objCom.Parameters.AddWithValue("@CountryID", strCountryID);
    //    SqlDataReader objSDR1 = objCom.ExecuteReader();
    //    //objSDR1.Read();
    //    if (objSDR1.HasRows == true)
    //    {
    //        ddlState.DataSource = objSDR1;
    //        ddlState.DataValueField = "StateID";
    //        ddlState.DataTextField = "StateName";
    //        ddlState.DataBind();
    //    }
    //    objSDR1.Close();
    //    objCon.Close();
    //    ddlState.Items.Insert(0, new ListItem("---- Select State ----", "-1"));
    //}
    //#endregion Fill State DropDown

    //#region Fill City DropDown
    //public void FillCityDropDown()
    //{
    //    SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBook2ConnectionString"].ConnectionString);

    //    ddlCity.Items.Clear();
    //    objCon.Open();

    //    SqlString strStateID = SqlString.Null;
    //    if (ddlState.SelectedIndex > 0)
    //        strStateID = ddlState.SelectedValue;
    //    SqlCommand objCom = objCon.CreateCommand();
    //    objCom.CommandType = CommandType.StoredProcedure;
    //    objCom.CommandText = "PR_Contact_CityDDByState";
    //    if (Session["UserID"] != null)
    //    {
    //        objCom.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
    //    }
    //    objCom.Parameters.AddWithValue("@StateID", ddlState.SelectedValue);
    //    SqlDataReader objSDR2 = objCom.ExecuteReader();
    //    //objSDR2.Read();
    //    if (objSDR2.HasRows == true)
    //    {
    //        ddlCity.DataSource = objSDR2;
    //        ddlCity.DataValueField = "CityID";
    //        ddlCity.DataTextField = "CityName";
    //        ddlCity.DataBind();
    //    }
    //    objSDR2.Close();
    //    objCon.Close();
    //    ddlCity.Items.Insert(0, new ListItem("---- Select City ----", "-1"));
    //}
    //#endregion Fill City DropDown
     
    #region Fill Controls
    protected void FillControls(SqlInt32 ContactID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBook2ConnectionString"].ConnectionString);

        SqlString strUserID = SqlString.Null;
        try
        {
            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }
            #region Set Connection and Command Objects
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_SelectByPK";

            #endregion Set Connection and Command Objects

            objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString().Trim());

            SqlDataReader objSDR = objCmd.ExecuteReader();

            #region Read the Values and Set Controls
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                    {
                        ddlCountry.SelectedValue = objSDR["CountryID"].ToString().Trim();
                        CommonDropDownFillMethods.FillDropDownListStateByCountryID(ddlState, ddlCountry);
                    }
                    if (!objSDR["StateID"].Equals(DBNull.Value))
                    {
                        ddlState.SelectedValue = objSDR["StateID"].ToString().Trim();

                        CommonDropDownFillMethods.FillDropDownListCityByStateID(ddlCity, ddlState);
                    }
                    if (!objSDR["CityID"].Equals(DBNull.Value))
                    {
                        ddlCity.SelectedValue = objSDR["CityID"].ToString().Trim();
                    }
                    //if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                    //{
                    //    ddlContactCategory.SelectedValue = objSDR["ContactCategoryID"].ToString().Trim();
                    //}
                    if (!objSDR["ContactName"].Equals(DBNull.Value))
                    {
                        txtContactName.Text = objSDR["ContactName"].ToString().Trim();
                    }
                    if (!objSDR["ContactNumber"].Equals(DBNull.Value))
                    {
                        txtContactNumber.Text = objSDR["ContactNumber"].ToString().Trim();
                    }
                    if (!objSDR["WhatsAppNumber"].Equals(DBNull.Value))
                    {
                        txtWhatsApp.Text = objSDR["WhatsAppNumber"].ToString().Trim();
                    }
                    if (!objSDR["Email"].Equals(DBNull.Value))
                    {
                        txtEmail.Text = objSDR["Email"].ToString().Trim();
                    }
                    if (!objSDR["Address"].Equals(DBNull.Value))
                    {
                        txtAddress.Text = objSDR["Address"].ToString().Trim();
                    }
                    if (!objSDR["Age"].Equals(DBNull.Value))
                    {
                        txtAge.Text = objSDR["Age"].ToString().Trim();
                    }
                    if (!objSDR["BirthDate"].Equals(DBNull.Value))
                    {
                        txtBirthDate.Text = Convert.ToDateTime(objSDR["BirthDate"]).ToString("yyyy-MM-dd");
                    }
                    if (!objSDR["BloodGroup"].Equals(DBNull.Value))
                    {
                        txtBloodGroup.Text = objSDR["BloodGroup"].ToString().Trim();
                    }
                    if (!objSDR["FacebookID"].Equals(DBNull.Value))
                    {
                        txtFacebook.Text = objSDR["FacebookID"].ToString().Trim(); 
                    }
                    if (!objSDR["LinkedINID"].Equals(DBNull.Value))
                    {
                        txtLinkedIn.Text = objSDR["LinkedINID"].ToString().Trim();
                    }
                }
            }
            objSDR.Close();

            FillCheckedCBLContactCategoryID(Convert.ToInt32(Page.RouteData.Values["ContactId"]));
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
            #endregion Read the Values and Set Controls
        }
        catch (Exception ex)
        {
            lblMessage.Text += ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Fill Controls

    #region CountrySelectedIndex
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonDropDownFillMethods.FillDropDownListStateByCountryID(ddlState, ddlCountry);
    }
    #endregion CountrySelectedIndex

    #region StateSelectedIndex
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonDropDownFillMethods.FillDropDownListCityByStateID(ddlCity, ddlState);
    }
    #endregion StateSelectedIndex

    #region Button: Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBook2ConnectionString"].ConnectionString);
        #region Local Variables
        SqlInt32 strCountry = SqlInt32.Null;
        SqlInt32 strState = SqlInt32.Null;
        SqlInt32 strCity = SqlInt32.Null;
        //SqlInt32 strContactCategory = SqlInt32.Null;
        SqlString strContactName = SqlString.Null;
        SqlString strContactNumber = SqlString.Null;
        SqlString strWhatsApp = SqlString.Null;
        SqlString strEmail = SqlString.Null;
        SqlString strAddress = SqlString.Null;
        SqlInt32 strAge = SqlInt32.Null;
        SqlDateTime strBirthDate = SqlDateTime.Null;
        SqlString strBloodGroup = SqlString.Null;
        SqlString strFacebookID = SqlString.Null;
        SqlString strLinkedInID = SqlString.Null;
        SqlString strImage = SqlString.Null;
        #endregion Local Variables

        try
        {
            #region Server Side Validation
            string strErrorMessage = "";

            if (ddlCountry.SelectedIndex == 0)
            {
                strErrorMessage += "- Select Country  <br/>";
            }
            if (ddlState.SelectedIndex == 0)
            {
                strErrorMessage += "- Select State  <br/>";
            }
            if (ddlCity.SelectedIndex == 0)
            {
                strErrorMessage += "- Select City  <br/>";
            }
            //if (ddlContactCategory.SelectedIndex == 0)
            //{
            //    strErrorMessage += "- Select ContactCategory  <br/>";
            //}
            if (txtContactName.Text.Trim() == "")
            {
                strErrorMessage += "- Enter Contact Name  <br/>";
            }
            if (txtContactNumber.Text.Trim() == "")
            {
                strErrorMessage += "- Enter Contact Number  <br/>";
            }
            if (txtEmail.Text.Trim() == "")
            {
                strErrorMessage += "- Enter Email  <br/>";
            }
            if (txtAddress.Text.Trim() == "")
            {
                strErrorMessage += "- Enter Address  <br/>";
            }
            if (!fuContactPhotoPath.HasFile)
            {
                strErrorMessage += "- Upload Your Image <br/>";
            }
            if (strErrorMessage.Trim() != "")
            {
                lblMessage.Text += "Kindly solve following Error(s) <br/>" + strErrorMessage + "<br />";
                return;
            }
            #endregion Server Side Validation

            #region Gather Information
            if (ddlCountry.SelectedIndex > 0)
            {
                strCountry = Convert.ToInt32(ddlCountry.SelectedValue);
            }
            if (ddlState.SelectedIndex > 0)
            {
                strState = Convert.ToInt32(ddlState.SelectedValue);
            }
            if (ddlCity.SelectedIndex > 0)
            {
                strCity = Convert.ToInt32(ddlCity.SelectedValue);
            }
            //if (ddlContactCategory.SelectedIndex > 0)
            //{
            //    strContactCategory = Convert.ToInt32(ddlContactCategory.SelectedValue);
            //}

         
            if (txtContactName.Text.Trim() != "")
            {
                strContactName = txtContactName.Text.Trim();
            }
            if (txtContactNumber.Text.Trim() != "")
            {
                strContactNumber = txtContactNumber.Text.Trim();
            }   
            if (txtWhatsApp.Text.Trim() != "")
            {
                strWhatsApp = txtWhatsApp.Text.Trim();
            }
            if (txtEmail.Text.Trim() != "")
            {
                strEmail = txtEmail.Text.Trim();
            }
            if (txtAddress.Text.Trim() != "")
            {
                strAddress = txtAddress.Text.Trim();
            }
            if (txtAge.Text.Trim() != "")
            {
                strAge = Convert.ToInt32(txtAge.Text.Trim());
            }
            if (txtBirthDate.Text.Trim() != "")
            {
                strBirthDate = Convert.ToDateTime(txtBirthDate.Text.Trim());
            }
            if (txtBloodGroup.Text.Trim() != "")
            {
                strBloodGroup = txtBloodGroup.Text.Trim();
            }
            if (txtFacebook.Text.Trim() != "")
            {
                strFacebookID = txtFacebook.Text.Trim();
            }
            if (txtLinkedIn.Text.Trim() != "")
            {
                strLinkedInID = txtLinkedIn.Text.Trim();
            }
            if (fuContactPhotoPath.HasFile)
            {
                strImage = "~/User_Content/" + fuContactPhotoPath.FileName;
                //ContactPhotoPath = "~/User_Content/" + fuContactPhotoPath.FileName.ToString().Trim();
                fuContactPhotoPath.SaveAs(Server.MapPath(strImage.ToString()));
            }
            #endregion Gather Information


            if (objConn.State == ConnectionState.Closed)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            #region Add Parameters
            objCmd.Parameters.AddWithValue("@CountryID", strCountry);                                         		
            objCmd.Parameters.AddWithValue("@StateID", strState);                                                        			
            objCmd.Parameters.AddWithValue("@CityID", strCity);                                                          	
            //objCmd.Parameters.AddWithValue("@ContactCategoryID", strContactCategory);                                    
            objCmd.Parameters.AddWithValue("@ContactName", strContactName);                                            	
            objCmd.Parameters.AddWithValue("@ContactNumber", strContactNumber);                                          
            objCmd.Parameters.AddWithValue("@WhatsAppNumber", strWhatsApp);                                              
            objCmd.Parameters.AddWithValue("@Email", strEmail);                                                          	
            objCmd.Parameters.AddWithValue("@Address", strAddress);                                                      
            objCmd.Parameters.AddWithValue("@Age", strAge);                                                              
            objCmd.Parameters.AddWithValue("@BirthDate", strBirthDate);                                                  
            objCmd.Parameters.AddWithValue("@BloodGroup", strBloodGroup);                                                
            objCmd.Parameters.AddWithValue("@FacebookID", strFacebookID);
            objCmd.Parameters.AddWithValue("@LinkedINID", strLinkedInID);
            if (fuContactPhotoPath.HasFile)
            {
                objCmd.Parameters.AddWithValue("@ContactPhotoPath", strImage);
            }
                    
            
           
            #endregion Add Parameters                                                                                    	

            if (Request.QueryString["ContactID"] != null)
            {
                objCmd.Parameters.AddWithValue("@ContactID", Request.QueryString["ContactID"]);
                objCmd.CommandText = "[dbo].[PR_Contact_UpdateByPK]";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/Contact/ContactList.aspx");
            }

            else
            {
                objCmd.CommandText = "[dbo].[PR_Contact_Insert]";
                if (Session["UserID"] != null)
                {
                    objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
                }

                //Out Parameter
                objCmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                //objCmd.Parameters["@ContactID"].Direction = ParameterDirection.Output;
                objCmd.ExecuteNonQuery();


                SqlInt32 ContactID = 0;
                ContactID = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);

                foreach(ListItem liContactCategoryID in cblContactCategory.Items)
                {
                    if (liContactCategoryID.Selected)
                    {
                        SqlCommand objCmdContactcategory = objConn.CreateCommand();
                        objCmdContactcategory.CommandType = CommandType.StoredProcedure;
                        objCmdContactcategory.CommandText = "[dbo].[ContactWiseContactCategory_Insert]";
                        if (Session["UserID"] != null)
                        {
                            objCmdContactcategory.Parameters.AddWithValue("@UserID", Session["UserID"]);
                        }
                        objCmdContactcategory.Parameters.AddWithValue("@ContactID", ContactID.ToString());
                        objCmdContactcategory.Parameters.AddWithValue("@ContactCategoryID", liContactCategoryID.Value.ToString());
                        objCmdContactcategory.ExecuteNonQuery();
                    }
                }

                objConn.Close();
                ddlCountry.SelectedIndex = 0;
                ddlState.SelectedIndex = 0;
                ddlCity.SelectedIndex = 0;
                //ddlContactCategory.SelectedIndex = 0;
                txtContactName.Text = "";
                txtAddress.Text = "";
                txtAge.Text = "";
                txtBirthDate.Text = "";
                txtBloodGroup.Text = "";
                txtContactNumber.Text = "";
                txtEmail.Text = "";
                txtFacebook.Text = "";
                txtLinkedIn.Text = "";
                txtWhatsApp.Text = "";
                ddlCountry.Focus();
                lblMessage.Text = "Data Inserted Successfully <br /> ContactID = " + ContactID.ToString();
            }
            objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Button: Save

    #region Button: Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Contact/ContactList.aspx", true);
    }
    #endregion Button: Cancel

    #region Fill CheckBoxList ContactCategory
    private void FillCBLContactCategory()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBook2ConnectionString"].ConnectionString);
        try
        {
            objCon.Open();
            SqlCommand objCom = objCon.CreateCommand();
            objCom.CommandType=CommandType.StoredProcedure;
            objCom.CommandText = "[dbo].[PR_ContactCategory_SelectByDropDownList]";
            SqlDataReader objSDR = objCom.ExecuteReader();

            if (objSDR.HasRows)
            {
                cblContactCategory.DataTextField = "ContactCategoryName";
                cblContactCategory.DataValueField = "ContactCategoryID";
                cblContactCategory.DataSource = objSDR;
                cblContactCategory.DataBind();
             }
        }
        catch(Exception ex)
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
    #endregion Fill CheckBoxList ContactCategory

    #region Fill CheckBoxList Checked Items
    private void FillCheckedCBLContactCategoryID(SqlInt32 ContacttID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBook2ConnectionString"].ConnectionString);
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactWiseContactCategory_SelectByPKUserID";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
            objCmd.Parameters.AddWithValue("@ContactID", ContacttID);
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    foreach (ListItem li in cblContactCategory.Items)
                    {
                        if (objSDR["ContactCategoryID"].ToString() == li.Value)
                        {
                            li.Selected = true;
                        }
                    }
                }
                //return;
            }
            else
            {
                lblMessage.Text = "Nothing available";
            }
            #endregion Set Connection & Command Object

            #region Close Connection
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Close Connection

        }
        catch (Exception ex)
        {
            #region Display Appropriate Message
            lblMessage.Text = ex.Message;
            #endregion Display Appropriate Message
        }
        finally
        {
            #region Close Connection
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Close Connection
        }
    }
    #endregion Fill CheckBoxList Checked Items
}