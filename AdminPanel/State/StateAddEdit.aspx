<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="StateAddEdit.aspx.cs" Inherits="AdminPanel_State_StateAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="container-fluid">
        <div class="row list">
            <div class="col-md-12">
                <asp:Label ID="lblAddState" runat="server"><h3>Add State</h3></asp:Label><hr />
            </div>
        </div>
        <div class="row list">
            <div class="col-md-12 col-sm-push-2">
                <asp:Label ID="lblMessage" runat="server" Text="" EnableViewState="false" ForeColor="#FF3333"></asp:Label>
            </div>
        </div>

        <div class="row country">
            <div class="col-md-6">
                <div class="col-md-4 col-sm-push-4">
                    <strong style="color: red;">*</strong>Country :
                </div>
                <div class="col-md-6 col-lg-push-4">
                    <asp:DropDownList ID="ddlCountryID" runat="server" CssClass="form-control" Width="713px"></asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="row country">
            <div class="col-md-2 col-sm-push-2">
                <strong style="color:red;">*</strong>State Name :
            </div>
            <div class="col-md-6 col-sm-push-2">
                <asp:TextBox ID="txtStateName" runat="server" CssClass="form-control" Placeholder="Enter State Name"></asp:TextBox>
            </div>
        </div>
        <div class="row country">
            <div class="col-md-2 col-sm-push-2">
                <strong style="color:red;">*</strong>State Code :
            </div>
            <div class="col-md-6 col-sm-push-2">
                <asp:TextBox ID="txtStateCode" runat="server" CssClass="form-control" Placeholder="Enter State Code"></asp:TextBox>
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

