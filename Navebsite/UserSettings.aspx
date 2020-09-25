<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="true" CodeBehind="UserSettings.aspx.cs" Inherits="Navebsite.UserSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">
    <div class="tuple">
        <asp:FileUpload ID="Background" runat="server" />
        <asp:Button ID="UploadBackground" Text="Upload Background" runat="server"/>
    </div>

    <div class="tuple">
        <asp:FileUpload ID="ProfilePicture" runat="server" />
        <asp:Button ID="ProfilePicture" Text="Upload Background" runat="server"/>
    </div>


</asp:Content>
