<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="AdminPanel_State_StateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12 list">
                <h3>State List</h3>
                <hr />
            </div>
        </div>

        <div class="row">
            <div class="col-md-6" style="margin-left: 270px;margin-bottom: 25px">
                <asp:HyperLink ID="hlAdd" runat="server" NavigateUrl="~/AdminPanel/State/StateAddEdit.aspx" CssClass="btn btn-md btn-primary" >Add State</asp:HyperLink>
            </div>
        </div>


        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblMessage" runat="server" Text="" EnableViewState="false" ForeColor="#FF3333"></asp:Label>
            </div>
        </div>


        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="gvState" runat="server" CssClass="table table-responsive table-bordered table-hover" AutoGenerateColumns="false" OnRowCommand="gvState_RowCommand" Width="900px" HorizontalAlign="Center">
                    <Columns>

                        <%-- <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" CssClass="btn btn-primary btn-sm" NavigateUrl='<%# "~/AdminPanel/State/StateAddEdit.aspx?StateID=" + Eval("StateID").ToString() %>' />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <%--<asp:BoundField DataField="StateID" HeaderText="ID" />--%>
                        <asp:BoundField DataField="CountryName" HeaderText="Country" />
                        <asp:BoundField DataField="StateName" HeaderText="State" />
                        <asp:BoundField DataField="StateCode" HeaderText="Code" />
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" CssClass="btn btn-primary btn-sm" NavigateUrl='<%# "~/AdminPanel/State/StateAddEdit.aspx?StateID=" + Eval("StateID").ToString() %>' />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("StateID").ToString() %>' />

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

        </div>
    </div>
</asp:Content>

