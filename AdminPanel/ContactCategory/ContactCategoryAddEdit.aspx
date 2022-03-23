<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryAddEdit.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategoryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="container-fluid">
        <div class="row list">
            <div class="col-md-12">
                <asp:Label ID="lblAddContactCategory" runat="server"><h3>Add Contact Category</h3></asp:Label><hr />
            </div>
        </div>

        <div class="row list">
            <div class="col-md-8 col-lg-push-2">
                <asp:Label ID="lblMessage" runat="server" Text="" EnableViewState="false" ForeColor="#FF3333"></asp:Label>
            </div>
        </div>

        <div class="row list">
            <div class="col-md-8 col-lg-push-2">
                <asp:Label ID="lblMsg" runat="server" Text="" EnableViewState="false" ForeColor="green"></asp:Label>
            </div>
        </div>

        <div class="row country">
            <div class="col-md-2 col-lg-push-2">
                <strong style="color:red;">*</strong>Contact Category Name : 
            </div>
            <div class="col-md-6 col-lg-push-2">
                <asp:TextBox ID="txtContactCatName" runat="server" CssClass="form-control" Placeholder="Enter Contact Category Name"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-md-2 col-lg-push-4">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>
</asp:Content>

