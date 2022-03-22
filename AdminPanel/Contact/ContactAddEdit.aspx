<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="AdminPanel_Contact_ContactAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="container-fluid">
        <div class="row list">
            <div class="col-md-12">
                <asp:Label ID="lblAddContact" runat="server"><h3>Add Contact</h3></asp:Label><hr />
            </div>
        </div>

        <div class="row list">
            <div class="col-md-6 col-sm-push-2">
                <asp:Label ID="lblMessage" runat="server" Text="" EnableViewState="false" ForeColor="#FF3333"></asp:Label>
            </div>
        </div>

        <div class="row country">
            <div class="col-md-4 col-sm-push-2">
                <strong style="color: red;">*</strong>Country :
            </div>
            <div class="col-md-6">
                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>

        <div class="row country">
            <div class="col-md-4 col-sm-push-2">
                <strong style="color: red;">*</strong>State :
            </div>
            <div class="col-md-6">
                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>
        <div class="row country">
            <div class="col-md-4 col-sm-push-2">
                <strong style="color: red;">*</strong>City :
            </div>
            <div class="col-md-6">
                <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>

        <%--<div class="row country">
            <div class="col-md-4 col-sm-push-2">
                <strong style="color: red;">*</strong>Contact Category :
            </div>
            <div class="col-md-6">
                <asp:DropDownList ID="ddlContactCategory" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>--%>

        <div class="row country">
            <div class="col-md-4 col-sm-push-2">
                <strong style="color: red;">*</strong>Contact Category :
                        <br />
            </div>
            <div class="col-md-4">
                <asp:CheckBoxList ID="cblContactCategory" runat="server"></asp:CheckBoxList>
            </div>
        </div>

        <div class="row country">
            <div class="col-md-4 col-sm-push-2">
                <strong style="color: red;">*</strong>Contact Name :
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtContactName" runat="server" Placeholder="Enter Contact Name" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row country">
            <div class="col-md-4 col-sm-push-2">
                <strong style="color: red;">*</strong>Contact Number :
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtContactNumber" runat="server" Placeholder="Enter Contact Number" CssClass="form-control"></asp:TextBox>

                <asp:RegularExpressionValidator ID="revMobile" runat="server" ControlToValidate="txtContactNumber" Display="Dynamic" ErrorMessage="Enter Valid Phone No" ForeColor="Red" ValidationExpression="\+?\d[\d -]{8,12}\d"></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="row country">
            <div class="col-md-4 col-sm-push-2">
                Birth Date :
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtBirthDate" runat="server" Placeholder="Enter Birth Date" CssClass="form-control" TextMode="Date"></asp:TextBox>

                <asp:CompareValidator ID="cvBirthDate" runat="server" ControlToValidate="txtBirthDate" Display="Dynamic" ErrorMessage="Enter Valid Date" ForeColor="Red" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
            </div>
        </div>

        <div class="row country">
            <div class="col-md-4 col-sm-push-2">
                WhatsApp Number :
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtWhatsApp" runat="server" Placeholder="Enter WhatsApp Number" CssClass="form-control"></asp:TextBox>

                <asp:RegularExpressionValidator ID="revWhatsAppNumber" runat="server" ControlToValidate="txtWhatsApp" Display="Dynamic" ErrorMessage="Enter Valid Number" ForeColor="Red" ValidationExpression="\+?\d[\d -]{8,12}\d"></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="row country">
            <div class="col-md-4 col-sm-push-2">
                <strong style="color: red;">*</strong>Email :
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtEmail" runat="server" Placeholder="Enter Email" CssClass="form-control"></asp:TextBox>

                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Enter Valid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="row country">
            <div class="col-md-4 col-sm-push-2">
                <strong style="color: red;">*</strong>Address :
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtAddress" runat="server" Placeholder="Enter Address" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row country">
            <div class="col-md-4 col-sm-push-2">
                Age :
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtAge" runat="server" Placeholder="Enter Age" CssClass="form-control"></asp:TextBox>

                <asp:RangeValidator ID="rvAge" runat="server" ControlToValidate="txtAge" Display="Dynamic" ErrorMessage="Enter Valid Age" ForeColor="Red" MaximumValue="60" MinimumValue="12" Type="Integer"></asp:RangeValidator>
            </div>
        </div>

        <div class="row country">
            <div class="col-md-4 col-sm-push-2">
                Blood Group :
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtBloodGroup" runat="server" Placeholder="Enter Blood Group" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row country">
            <div class="col-md-4 col-sm-push-2">
                Facebook ID :
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtFacebook" runat="server" Placeholder="Enter Facebook ID" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row country">
            <div class="col-md-4 col-sm-push-2">
                LinkedIn ID :
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtLinkedIn" runat="server" Placeholder="Enter LinkedIn ID" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row country">
            <div class="col-md-4 col-sm-push-2">
                Upload Photo :
            </div>
            <div class="col-md-6">
                <asp:FileUpload ID="fuContactPhotoPath" runat="server" CssClass="form-control"/>
            </div>
        </div>

        <div class="row country">
            <div class="col-md-6 col-lg-push-4">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" OnClick="btnCancel_Click" />
                <br />
                <br />
                <br />
            </div>
        </div>
    </div>
</asp:Content>

