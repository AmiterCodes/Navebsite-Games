<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="True" CodeBehind="Profile.aspx.cs" Inherits="Navebsite.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">

    <div class="profile">
        
    <asp:Image ID="banner" runat="server" CssClass="profile_banner" />
        <div class="profile_info">
    <asp:Image ID="icon" runat="server" CssClass="profile_icon" />
    <asp:Label runat="server" CssClass="profile_name" ID="name"></asp:Label>
            <asp:Button Text="Add Friend" runat="server" CssClass="button" ID="AddButton" OnClick="AddButton_OnClick" />
            <asp:Button Text="Remove Friend" runat="server" CssClass="button" Id="RemoveButton" OnClick="RemoveButton_OnClick" />
            </div>
    </div>
    <div class="profile_content">
    <Nv:ActivityList runat="server" Id="activities" />
        Friends
    <NV:UserList runat="server" ID="friends" ViewStateMode="Enabled" />
    </div>
</asp:Content>
