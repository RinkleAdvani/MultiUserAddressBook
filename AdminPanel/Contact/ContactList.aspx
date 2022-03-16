<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="AdminPanel_Contact_Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12 list">
                <h3>Contact List</h3>
                <hr />
            </div>
        </div>

        <div class="row country">
            <div class="col-md-12" style="margin-bottom: 15px;">
                <asp:HyperLink ID="hlAdd" runat="server" NavigateUrl="~/AdminPanel/Contact/ContactAddEdit.aspx" CssClass="btn btn-md btn-primary">Add Contact</asp:HyperLink>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblMessage" Text="" runat="server" EnableViewState="false" ForeColor="#FF3333"></asp:Label>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="gvContact" runat="server" OnRowCommand="gvContact_RowCommand" CssClass="table table-responsive table-bordered table-hover" HorizontalAlign="Center" AutoGenerateColumns="False">
                    <Columns>
                           
                        <%--<asp:BoundField DataField="ContactID" HeaderText="ID" />--%>
                        <asp:BoundField DataField="CountryName" HeaderText="Country" />
                        <asp:BoundField DataField="StateName" HeaderText="State" />
                        <asp:BoundField DataField="CityName" HeaderText="City" />
                        <%--<asp:BoundField DataField="ContactCategoryName" HeaderText="Contact Category" />--%>
                        <asp:BoundField DataField="ContactName" HeaderText="Contact Name" />
                        <asp:BoundField DataField="ContactNumber" HeaderText="Number" />
                        <asp:BoundField DataField="WhatsAppNumber" HeaderText="WhatsApp Number" />
                        <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" DataFormatString="{0:MM/dd/yyyy}" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Age" HeaderText="Age" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="BloodGroup" HeaderText="Blood Group" />
                        <asp:BoundField DataField="FacebookID" HeaderText="Facebook ID" />
                        <asp:BoundField DataField="LinkedINID" HeaderText="LinkedIn ID" />
                        <%--<asp:BoundField DataField="ContactPhotoPath" HeaderText="Photo" />--%>
                        <asp:Templatefield HeaderText="Photo">
                            <ItemTemplate>
                                <asp:Image runat="server" ID="ContactPhotoPath" ImageURL='<%# Eval("ContactPhotoPath") %>' Height="100"/>
                            </ItemTemplate>
                        </asp:Templatefield>

                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <div style="width:150px;">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-primary btn-sm" NavigateUrl='<%# "~/AdminPanel/Contact/ContactAddEdit.aspx?ContactID=" + Eval("ContactID").ToString() %>'>Edit</asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button runat="server" ID="btnDelete" Text="Delete" CommandName="DeleteRecord" CssClass="btn btn-danger btn-sm" CommandArgument='<%# Eval("ContactID").ToString() %>' />
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

