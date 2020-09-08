<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navbar.ascx.cs" Inherits="Navebsite.Controls.Navbar" %>
<nav class="navbar">
    <asp:HyperLink runat="server" class="button" NavigateUrl="../Store.aspx" Text="Store"></asp:HyperLink>
    <asp:Label Text="" runat="server" ID="welcome" />
    <asp:HyperLink ID="profile" runat="server" class="button" NavigateUrl="../Profile.aspx" Text="Profile"></asp:HyperLink>
</nav>