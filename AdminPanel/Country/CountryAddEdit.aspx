<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CountryAddEdit.aspx.cs" Inherits="AdminPanel_Country_CountryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="container-fluid">
        <div class="row list">
            <div class="col-md-12">
                <asp:Label ID="lblAddCountry" runat="server"><h3>Add Country</h3></asp:Label><hr />
            </div>
        </div>
        <div class="row list" >
            <div class="col-md-12 col-lg-push-2">
                <asp:Label ID="lblMessage" runat="server" EnableViewState="False" ForeColor="#FF3333"></asp:Label>
            </div>
        </div>

        <div class="row list" >
            <div class="col-md-12 col-lg-push-2">
                <asp:Label ID="lblMsg" runat="server" EnableViewState="False" ForeColor="green"></asp:Label>
            </div>
        </div>

        <div class="row country">
            <div class="col-md-2 col-sm-push-2">
                <strong style="color:red;">*</strong>Country Name : 
            </div>
            <div class="col-md-6 col-sm-push-2">
                <asp:TextBox ID="txtCountryName" runat="server" placeholder="Country Name" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row country">
            <div class="col-md-2 col-sm-push-2">
                <strong style="color:red;">*</strong>Country Code : 
            </div>
            <div class="col-md-6 col-lg-push-2">
                <asp:TextBox ID="txtCountryCode" runat="server" placeholder="Country Code" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-6 col-lg-push-4">
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" OnClick="btnSave_Click" />

            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" OnClick="btnCancel_Click" />
        </div>
    </div>
</asp:Content>


