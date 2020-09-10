<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navbar.ascx.cs" Inherits="Navebsite.Controls.Navbar" %>
<nav class="navbar">
    <asp:HyperLink runat="server" class="button" NavigateUrl="../Store.aspx" Text="Store"></asp:HyperLink>
    <asp:Label Text="" runat="server" ID="welcome" />
    
    <asp:HyperLink ID="register" runat="server" class="button" NavigateUrl="../Register.aspx" Text="Register"></asp:HyperLink>
    <asp:HyperLink ID="logout" runat="server" class="button" NavigateUrl="../Logout.aspx" Text="Logout"></asp:HyperLink>
    <asp:HyperLink ID="login" runat="server" class="button" NavigateUrl="../Login.aspx" Text="Login"></asp:HyperLink>
    <asp:HyperLink ID="profile" runat="server" class="button" NavigateUrl="../Profile.aspx" Text="Profile"></asp:HyperLink>
</nav>