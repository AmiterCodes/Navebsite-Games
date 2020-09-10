<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Navebsite.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">
    <asp:TextBox runat="server" ID="username" placeholder="username" />
    <asp:RequiredFieldValidator ErrorMessage="Username is required!" ControlToValidate="username" runat="server" />
    <asp:RegularExpressionValidator ErrorMessage="Username must be between 3 and 16 characters, with no special characters" ControlToValidate="username" runat="server" ValidationExpression="^\w{3,16}$" />
    <asp:TextBox runat="server" ID="password" placeholder="password" />
    <asp:RequiredFieldValidator ErrorMessage="Password is required!" ControlToValidate="password" runat="server" />
    <asp:RegularExpressionValidator ErrorMessage="Password must be at least 6 letters, with at least one capital letter, lowercase letter and one number" ControlToValidate="password" runat="server" ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{6,}$" />
    <asp:Label runat="server" ID="errorBox"></asp:Label>
    <asp:Button Text="Register" runat="server" OnClick="Register_Click" />
</asp:Content>
