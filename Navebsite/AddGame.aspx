<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="true" CodeBehind="AddGame.aspx.cs" Inherits="Navebsite.AddGame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">
    <asp:TextBox runat="server" ID="GameName" />

    <asp:TextBox runat="server" ID="Genres" />

    <asp:TextBox runat="server" ID="Version" />

    <asp:TextBox runat="server" ID="GameLink" />

    <asp:FileUpload ID="Background" runat="server" />

    <asp:FileUpload ID="Logo" runat="server" />

    <asp:TextBox runat="server" ID="Description" />

    <asp:Button Text="Submit for review" runat="server" ID="button" CssClass="button" OnClick="button_Click" />
</asp:Content>
