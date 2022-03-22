<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryList.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12 list">
                <h3>Contact Category List</h3>
                <hr />
            </div>
        </div>

        <div class="row">
            <div class="col-md-6" style="margin-left: 383px; margin-bottom: 25px;">
                <asp:HyperLink ID="hlAdd" runat="server" NavigateUrl="~/AdminPanel/ContactCategory/Add" CssClass="btn btn-md btn-primary">Add Contact Category</asp:HyperLink>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblMessage" runat="server" Text="" EnableViewState="false"  ForeColor="#FF3333"></asp:Label>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="gvContactCategory" runat="server" CssClass="table table-bordered table-hover table-responsive" OnRowCommand="gvContactCategory_RowCommand" AutoGenerateColumns="false" Width="700px" HorizontalAlign="Center">
                        <Columns>
                            <%--<asp:BoundField DataField="ContactCategoryID" HeaderText="ID" />--%>
                            <asp:BoundField DataField="ContactCategoryName" HeaderText="Contact Category" />

                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>

                                    <asp:HyperLink ID="hlEdit" runat="server" CssClass="btn btn-primary btn-sm" NavigateUrl='<%# "~/AdminPanel/ContactCategory/Edit/" + Eval("ContactCategoryID").ToString() %>'>Edit</asp:HyperLink>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteRecord" CssClass="btn btn-sm btn-danger" CommandArgument='<%# Eval("ContactCategoryID").ToString() %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

