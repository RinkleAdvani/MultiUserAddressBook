<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CountryList.aspx.cs" Inherits="AdminPanel_Country_CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12 list">
                <h3>Country List</h3>
                <hr />
            </div>
        </div>

        <div class="row">
            <div class="col-md-12 add">
                <asp:HyperLink ID="hlAdd" runat="server" NavigateUrl="~/AdminPanel/Country/CountryAddEdit.aspx" CssClass="btn btn-sm btn-primary">Add Country</asp:HyperLink>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblMessage" runat="server" EnableViewState="False" ForeColor="#FF3333"></asp:Label>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="gvCountry" runat="server" CssClass="table table-responsive table-bordered table-hover" AutoGenerateColumns="false" OnRowCommand="gvCountry_RowCommand" Width="800px" HorizontalAlign="Center">
                    <Columns>
                        <%--<asp:BoundField DataField="CountryID" HeaderText="ID" />--%>
                        <asp:BoundField DataField="CountryName" HeaderText="Name" />
                        <asp:BoundField DataField="CountryCode" HeaderText="Code" />
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-sm btn-primary" NavigateUrl='<%# "~/AdminPanel/Country/CountryAddEdit.aspx?CountryID=" + Eval("CountryID").ToString() %>'></asp:HyperLink>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-sm btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("CountryID").ToString() %>'></asp:Button>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%-- <asp:Templatefield HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-sm btn-primary" NavigateUrl='<%# "~/AdminPanel/Country/CountryAddEdit.aspx?CountryID=" + Eval("CountryID").ToString() %>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:Templatefield>--%>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

