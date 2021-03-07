<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Navebsite.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">
    <div class="login_page">
        <div class="login_side">
            <div class="login_top">
                <h2 class="login_header">
                    Welcome Back to Navebsite Games
                </h2>
                <h4 class="login_header_sub">Your one stop shop for video games</h4>
            </div>
            <div class="login_image">
            <img class="login_image-img" src="./Images/loginbg.svg" alt="Video game Art" />
                <p>&copy; Art by Amit Nave</p>
            </div>
        </div>
        <div class="login_main">
            <h3 class="header">Login</h3>
            <asp:Label Text="Username" runat="server"/>
            <asp:TextBox runat="server" ID="username" placeholder="username" CssClass="input"/>
            <asp:RequiredFieldValidator ErrorMessage="Username is required!" ControlToValidate="username" runat="server" Display="Dynamic"/>
            <asp:Label Text="Password" runat="server"/>
            <asp:TextBox runat="server" ID="password" placeholder="password" TextMode="Password" CssClass="input"/>
            <asp:RequiredFieldValidator ErrorMessage="Password is required!" ControlToValidate="password" runat="server" Display="Dynamic"/>
            <asp:Label runat="server" ID="errorBox"></asp:Label>
            <asp:Button Text="Sign in" runat="server" OnClick="Login_Click" CssClass="button"/>
            <p>Not a registered user? <a href="Register.aspx" class="link">sign up</a> now!</p>
        </div>
    </div>
</asp:Content>

