using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

public static class CommonDropDownFillMethods
{
    #region Fill DropDown List of Country
    public static void FillDropDownListCountry(DropDownList ddl)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBook2ConnectionString"].ConnectionString);
        try
        {
            #region Connection and Command Object
            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }
            SqlCommand objComm = objConn.CreateCommand();
            objComm.CommandType = CommandType.StoredProcedure;
            objComm.CommandText = "PR_Country_SelectForDropDownList";
            SqlDataReader objSDR = objComm.ExecuteReader();
            #endregion Connection and Command Object

            if (objSDR.HasRows == true)
            {
                ddl.DataSource = objSDR;
                ddl.DataValueField = "CountryID";
                ddl.DataTextField = "CountryName";
                ddl.DataBind();
            }

            ddl.Items.Insert(0, new ListItem("---- Select Country ----", "-1"));
            objConn.Close();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            objConn.Close();
        }
    }
    #endregion Fill DropDown List of Country

    #region Fill DropDown List State By CountryID
    public static void FillDropDownListStateByCountryID(DropDownList ddl, DropDownList ddlCountry)
    {

        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBook2ConnectionString"].ConnectionString);

        ddl.Items.Clear();

        objCon.Open();
        SqlString strCountryID = SqlString.Null;
        if (ddlCountry.SelectedIndex > 0)
            strCountryID = ddlCountry.SelectedValue;
        SqlCommand objCom = objCon.CreateCommand();
        objCom.CommandType = CommandType.StoredProcedure;
        objCom.CommandText = "PR_Contact_StateDDByCountry";

        objCom.Parameters.AddWithValue("@CountryID", strCountryID);
        SqlDataReader objSDR1 = objCom.ExecuteReader();
        //objSDR1.Read();
        if (objSDR1.HasRows == true)
        {
            ddl.DataSource = objSDR1;
            ddl.DataValueField = "StateID";
            ddl.DataTextField = "StateName";
            ddl.DataBind();
        }
        objSDR1.Close();
        objCon.Close();
        ddl.Items.Insert(0, new ListItem("---- Select State ----", "-1"));
    }
    #endregion Fill DropDown List State By CountryID

    #region Fill DropDown List City By StateID
    public static void FillDropDownListCityByStateID(DropDownList ddl, DropDownList ddlState)
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBook2ConnectionString"].ConnectionString);

        ddl.Items.Clear();
        objCon.Open();

        SqlString strStateID = SqlString.Null;
        if (ddlState.SelectedIndex > 0)
            strStateID = ddlState.SelectedValue;
        SqlCommand objCom = objCon.CreateCommand();
        objCom.CommandType = CommandType.StoredProcedure;
        objCom.CommandText = "PR_Contact_CityDDByState";
       
        objCom.Parameters.AddWithValue("@StateID", ddlState.SelectedValue);
        SqlDataReader objSDR2 = objCom.ExecuteReader();
        //objSDR2.Read();
        if (objSDR2.HasRows == true)
        {
            ddl.DataSource = objSDR2;
            ddl.DataValueField = "CityID";
            ddl.DataTextField = "CityName";
            ddl.DataBind();
        }
        objSDR2.Close();
        objCon.Close();
        ddl.Items.Insert(0, new ListItem("---- Select City ----", "-1"));
    }
    #endregion Fill DropDown List City By StateID
}


