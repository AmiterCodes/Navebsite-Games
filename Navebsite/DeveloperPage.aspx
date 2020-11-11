<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="true" CodeBehind="DeveloperPage.aspx.cs" Inherits="Navebsite.DeveloperPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">
    <NV:SalesChart runat="server" ID="salesChart" />
    <asp:HyperLink NavigateUrl="AddGame.aspx" CssClass="button" Text="Add Game" runat="server" />
    <NV:GameViewList runat="server" ID="games" />
</asp:Content>
