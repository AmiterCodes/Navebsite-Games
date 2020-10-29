<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="true" CodeBehind="DeveloperPage.aspx.cs" Inherits="Navebsite.DeveloperPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">
    <NV:SalesChart runat="server" ID="salesChart" />
    <NV:GameViewList runat="server" ID="games" />
</asp:Content>
