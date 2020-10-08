<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="Navebsite.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">
    
    <NV:SalesChart ID="sales" runat="server"/>
    <NV:GameViewList runat="server" ID="gameList"/>
</asp:Content>
