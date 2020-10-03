<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="Navebsite.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">
    
    <NV:SalesChart ID="sales" runat="server"/>
    <asp:GridView runat="server"
                  ID="GameGrid"
                  EmptyDataText="No Data"
                  AutoGenerateColumns="False"
                  
                  >
        <Columns>
            <asp:BoundField DataField="GameName" HeaderText="Name"/>
            <asp:BoundField DataField="Description" HeaderText="Description"/>
            <asp:BoundField DataField="Price" HeaderText="Price"/>
            <asp:HyperLinkField Text="Link" HeaderText="Link" DataNavigateUrlFields="GameLink" />
            <asp:ButtonField Text="Accept" HeaderText="Accept">
                <ItemStyle CssClass="button" />
            </asp:ButtonField>
            <asp:ButtonField Text="Deny" HeaderText="Deny">
                <ItemStyle CssClass="button" />
            </asp:ButtonField>

        </Columns>
    </asp:GridView>
</asp:Content>
