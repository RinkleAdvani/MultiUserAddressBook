<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="AdminPanel_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="container-fluid">
        <div class="row list">
            <div class="col-md-12">
                <asp:Label ID="lblAddCity" runat="server"><h3>Add City</h3></asp:Label><hr />
            </div>
        </div>

        <div class="row list">
            <div class="col-md-12 col-lg-push-2">
                <asp:Label ID="lblMessage" runat="server" Text="" EnableViewState="false" ForeColor="#FF3333"></asp:Label>
            </div>
        </div>

        <div class="row country">
            <div class="col-md-4 col-sm-push-2">
                <strong style="color:red;">*</strong>Country :
            </div>
            <div class="col-md-6">
                <asp:DropDownList ID="ddlCountryID" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCountryID_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            </div>
        </div>
        <div class="row country">
            <div class="col-md-4 col-sm-push-2">
                <strong style="color:red;">*</strong>State :
            </div>
            <div class="col-md-6">
                <asp:DropDownList ID="ddlStateID" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>

        <div class="row country">
            <div class="col-md-2 col-sm-push-2">
                <strong style="color:red;">*</strong>City Name :
            </div>
            <div class="col-md-6 col-sm-push-2">
                <asp:TextBox ID="txtCityName" runat="server" CssClass="form-control" Placeholder="Enter City Name"></asp:TextBox>
            </div> 
        </div>
        <div class="row country">
            <div class="col-md-2 col-sm-push-2">
                <strong style="color:red;">*</strong>STD Code :
            </div>
            <div class="col-md-6 col-sm-push-2">
                <asp:TextBox ID="txtSTDCode" runat="server" CssClass="form-control" Placeholder="Enter STD Code"></asp:TextBox>
            </div>
        </div>
        <div class="row country">
            <div class="col-md-2 col-sm-push-2">
                <strong style="color:red;">*</strong>Pin Code :
            </div>
            <div class="col-md-6 col-sm-push-2">
                <asp:TextBox ID="txtPinCode" runat="server" CssClass="form-control" Placeholder="Enter Pin Code"></asp:TextBox>
            </div>
        </div>
        <div class="row country">
            <div class="col-md-2 col-lg-push-4">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-sm btn-primary" OnClick="btnSave_Click" />

                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>
</asp:Content>
