<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="True" CodeBehind="DeveloperPage.aspx.cs" Inherits="Navebsite.DeveloperPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">
    <NV:SalesChart runat="server" ID="salesChart" />
    <asp:HyperLink NavigateUrl="AddGame.aspx" CssClass="button" Text="Add Game" runat="server" />
    
    <!-- BANNER -->
    <asp:Panel CssClass="tuple_vert" runat="server" DefaultButton="UploadBackground">
        <h3 class="header">Developer Banner</h3>
        <asp:Image runat="server" ID="CurrentBackground" CssClass="image_preview" />
        <asp:FileUpload ID="Background" runat="server" CssClass="input" />
        <asp:RequiredFieldValidator ErrorMessage="You must upload an image" ControlToValidate="Background" ValidationGroup="Background" runat="server" />
        <asp:Button ID="UploadBackground" Text="Update Background" runat="server" CssClass="button" OnClick="UploadBackground_OnClick" />
    </asp:Panel>
    
    <asp:Panel runat="server" DefaultButton="SubmitData">
        <h3 class="header">Update your data</h3>

        <asp:TextBox ID="AboutField" runat="server" CssClass="input" />
        <asp:RequiredFieldValidator ErrorMessage="You must input something for a bio" ControlToValidate="AboutField" ValidationGroup="DeveloperData" runat="server" />

        <asp:TextBox ID="DeveloperNameField" runat="server" CssClass="input" />
        <asp:RequiredFieldValidator ErrorMessage="You must input a developer name" ControlToValidate="DeveloperNameField" ValidationGroup="DeveloperData" runat="server" />
        <asp:Button ID="SubmitData" Text="Update Developer Data" runat="server" CssClass="button" OnClick="SubmitData_OnClick" />


    </asp:Panel>

    <!-- PROFILE PICTURE -->

    <asp:Panel CssClass="tuple_vert" runat="server" DefaultButton="UploadProfile">
        <h3 class="header">Developer Icon</h3>
        <asp:Image runat="server" ID="CurrentProfilePicture" CssClass="image_preview" />

        <asp:FileUpload ID="ProfilePicture" runat="server" CssClass="input" />
        <asp:RequiredFieldValidator ErrorMessage="You must upload an image" ControlToValidate="ProfilePicture" ValidationGroup="ProfilePicture" runat="server" />
        <asp:Button ID="UploadProfile" Text="Update Profile Picture" runat="server" CssClass="button" OnClick="UploadProfile_OnClick" />
    </asp:Panel>

    <NV:GameViewList runat="server" ID="games" />
</asp:Content>
