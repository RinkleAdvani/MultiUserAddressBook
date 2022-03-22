<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="AdminPanel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12 list">
                <h3>City List</h3>
                <hr />
            </div>
        </div>

        <div class="row">
            <div class="col-md-6" style="margin-left: 180px; margin-bottom: 25px;">
                <asp:HyperLink ID="hlAdd" runat="server" NavigateUrl="~/AdminPanel/City/Add" CssClass="btn btn-md btn-primary" >Add City</asp:HyperLink>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <asp:Label runat="server" Text="" ID="lblMessage" EnableViewState="false" ForeColor="#FF3333"></asp:Label>
            </div>
        </div>
        

        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="gvCity" runat="server" CssClass="table table-responsive table-bordered table-hover" AutoGenerateColumns="false" OnRowCommand="gvCity_RowCommand" Width="1100px" HorizontalAlign="Center">
                    <Columns>
                        <%--<asp:BoundField DataField="CityID" HeaderText="ID" />--%>
                        <asp:BoundField DataField="CountryName" HeaderText="Country" />
                        <asp:BoundField DataField="StateName" HeaderText="State" />
                        <asp:BoundField DataField="CityName" HeaderText="City" />
                        <asp:BoundField DataField="STDCode" HeaderText="STD Code" />
                        <asp:BoundField DataField="PinCode" HeaderText="Pin Code" />

                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlEdit" runat="server" CssClass="btn btn-primary btn-sm" NavigateUrl='<%# "~/AdminPanel/City/Edit/" + Eval("CityID").ToString() %>'>Edit</asp:HyperLink>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("CityID").ToString() %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
