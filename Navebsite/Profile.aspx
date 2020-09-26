<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="True" CodeBehind="Profile.aspx.cs" Inherits="Navebsite.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">

    <style>
        .grid-container {
            display: grid;
            gap: 1rem 1rem;
            grid-template-areas:
                               "banner banner"
                               "Activity Friends"
                               "Reviews ."
                               ". .";
            grid-template-columns: 1.5fr 1fr;
            grid-template-rows: 1fr 1fr 1fr 1fr;
        }

        .banner { grid-area: banner; }

        .Activity {
            grid-area: Activity;
            padding: 2rem
        }

        .Friends { grid-area: Friends; }

        .Reviews { grid-area: Reviews; }
    </style>
    <div class="grid-container">
        <div class="banner">

            <asp:Image ID="banner" runat="server" CssClass="profile_banner"/>
            <div class="profile_info">
                <asp:Image ID="icon" runat="server" CssClass="profile_icon"/>
                <asp:Label runat="server" CssClass="profile_name" ID="name"></asp:Label>
                <asp:Button Text="Add Friend" runat="server" CssClass="button" ID="AddButton" OnClick="AddButton_OnClick"/>
                <asp:Button Text="Remove Friend" runat="server" CssClass="button" Id="RemoveButton" OnClick="RemoveButton_OnClick"/>
            </div>
        </div>
        <div class="Activity">
            <Nv:ActivityList runat="server" Id="activities"/>
        </div>
        <div class="Friends">
            <NV:UserList runat="server" ID="friends" ViewStateMode="Enabled" Title="Friends"/>
        </div>
    </div>
</asp:Content>