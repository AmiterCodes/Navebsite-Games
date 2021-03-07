<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Navebsite.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">
    <div class="login_page">
    <div class="login_side">
        <div class="login_top">
            <h2 class="login_header">
                Join Navebsite Games!
            </h2>
            <h4 class="login_header_sub">Your one stop shop for video games</h4>
        </div>
        <div class="login_image">
            <img class="login_image-img" src="./Images/loginbg.svg" alt="Video game Art"/>
            <p>&copy; Art by Amit Nave</p>
        </div>
    </div>
    <div class="login_main">


        <h3 class="header">Register</h3>
        <asp:Label Text="Email" runat="server"/>
        <asp:TextBox runat="server" TextMode="Email" CssClass="input" ID="Email" placeholder="email" required="true"/>
        <asp:RequiredFieldValidator Display="Dynamic" ErrorMessage="Email is required!" ControlToValidate="Email" runat="server"/>
        <asp:RegularExpressionValidator Display="Dynamic" ErrorMessage="Email must be valid!" ControlToValidate="Email" runat="server" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"/>

        <asp:Label Text="Username" runat="server"/>
        <asp:TextBox runat="server" ID="username" placeholder="username" CssClass="input" required="true"/>
        <asp:RequiredFieldValidator Display="Dynamic" ErrorMessage="Username is required!" ControlToValidate="username" runat="server"/>
        <asp:RegularExpressionValidator Display="Dynamic" ErrorMessage="Username must be between 3 and 16 characters, with no special characters" ControlToValidate="username" runat="server" ValidationExpression="^\w{3,16}$"/>

        <asp:Label Text="Password" runat="server"/>
        <asp:TextBox runat="server" CssClass="input" ID="password" placeholder="password" TextMode="Password" required="true"/>
        <asp:RequiredFieldValidator Display="Dynamic" ErrorMessage="Password is required!" ControlToValidate="password" runat="server"/>
        <asp:RegularExpressionValidator Display="Dynamic" ErrorMessage="Password must be at least 6 letters, with at least one capital letter, lowercase letter and one number" ControlToValidate="password" runat="server" ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{6,}$"/>

        <asp:Label runat="server" ID="errorBox"></asp:Label>

        <asp:CheckBox ID="NewDevCheck" AutoPostBack="True" Text="Sign up as new developer" runat="server"/>

        <asp:Panel ID="DevDetails" runat="server">
            <div class="tuple_vert">
                <asp:Label Text="Developer Name" runat="server"/>
                <asp:TextBox ID="DevName" placeholder="Developer name" runat="server" CssClass="input"/>
            </div>
        </asp:Panel>

        <asp:Button Text="Register" runat="server" OnClick="Register_Click" CssClass="button"/>
        <p>Already registered? <a href="Register.aspx" class="link">sign in here</a></p>

    </div>
    </div>
</asp:Content>
