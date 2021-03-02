<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="true" CodeBehind="GamePage.aspx.cs" Inherits="Navebsite.GamePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">

    <style>
        .grid-container {
            display: grid;
            gap: 1rem 1rem;
            grid-template-areas:
                               "banner banner"
                               "Play Friends"
                               "Reviews Gallery"
                               "Update Gallery";
            grid-template-columns: 1.5fr 1fr;
            grid-template-rows: 1.5fr 1.5fr 1.5fr 1fr;
            height: 100vh;
        }

        .banner { grid-area: banner; }

        .Friends {
            display: flex;
            flex-direction: column;
            grid-area: Friends;
        }

        .Play { grid-area: Play; }

        .Reviews { grid-area: Reviews; }

        .Update { grid-area: Update; }

        .Gallery { grid-area: Gallery; }
    </style>
    <div class="gamepage grid-container">

        <asp:Panel ID="banner" runat="server" CssClass="gamepage_banner banner">
            <asp:Label Text="Game Name" runat="server" ID="name" CssClass="gamepage_name"/>
        </asp:Panel>
        <div class="gamepage_info Play">
            <asp:Button Id="play" runat="server" CssClass="big-button" OnClick="play_Click"/>
        </div>
        <div class="Update">
            <NV:UpdateList ID="UpdateList" runat="server"/>
        </div>
        <asp:Panel runat="server" ID="reviewList" CssClass="reviews Reviews">
            <h2>Reviews</h2>
            <asp:Panel runat="server" ID="ReviewBox" CssClass="review_box">

            </asp:Panel>
        </asp:Panel>
        <div class="Gallery">
            <NV:Gallery runat="server" ID="gallery"/>
        </div>
        <div class="Friends">
            <NV:UserList runat="server" ID="friends" Title="Friends that play this game"/>
        </div>
    </div>
</asp:Content>