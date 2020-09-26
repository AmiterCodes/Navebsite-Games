<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="true" CodeBehind="UserSettings.aspx.cs" Inherits="Navebsite.UserSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">


    <div class="tuple">
        <asp:Image runat="server" ID="CurrentBackground"/>
        <asp:FileUpload ID="Background" runat="server" CssClass="input"/>
        <asp:Button ID="UploadBackground" Text="Update Background" runat="server" CssClass="button" OnClick="UploadBackground_OnClick"/>
    </div>

    <div class="tuple">
        <asp:Image runat="server" ID="CurrentProfilePicture"/>
        <asp:FileUpload ID="ProfilePicture" runat="server" CssClass="input"/>
        <asp:Button ID="UploadProfile" Text="Update Profile Picture" runat="server" CssClass="button" OnClick="UploadProfile_OnClick"/>
    </div>

    <div class="tuple_vert">
        <asp:TextBox ID="Bio" TextMode="MultiLine" runat="server" CssClass="input" placeholder="Bio Here..."/>
        <asp:Button Text="Update Bio" ID="UpdateBio" runat="server" CssClass="button" OnClick="UpdateBio_OnClick"/>
    </div>

    <div class="tuple">
        <asp:FileUpload ID="ImageUpload" runat="server" CssClass="input"/>
        <asp:Button ID="UploadImage" Text="Add Image to user gallery" runat="server" CssClass="button" OnClick="UploadImage_OnClick"/>
    </div>
</asp:Content>