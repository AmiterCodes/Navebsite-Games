<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GameView.ascx.cs" Inherits="Navebsite.Controls.GameView" %>
<asp:Panel runat="server" ID="GameViewPanel" class="gameview" style="">
    <div class="gameview_info">
        <asp:Label Text="Minecraft" ID="GameName" CssClass="gameview_title" runat="server" />
        <asp:Label Text="Genres" ID="GameGenres" CssClass="gameview_genres" runat="server" />
        <asp:Label Text="Mojang" ID="GameDeveloper" CssClass="gameview_dev" runat="server" />
        <asp:Label Text="Published" ID="PublishedDate" CssClass="gameview_time" runat="server" />
    </div>
    <div class="tuple_vert">
        <p>Copies Sold</p>
        <asp:Label Text="0" ID="sold" runat="server" />
    </div>
    <div class="tuple_vert">
        <p>Total Revenue</p>
        <asp:Label Text="0" ID="revenue" runat="server" />
    </div>
    <div class="tuple_vert">
        <p>Avg. Rating</p>
        <asp:Label Text="5" ID="rating" runat="server" />
    </div>
    <div class="tuple_vert">
        <p>Price</p>
        <asp:Label Text="5" ID="price" runat="server" />
    </div>
    <asp:Panel runat="server" CssClass="tuple_vert" ID="buttons">
        <asp:Button Text="Approve" CssClass="button" ID="ApproveButton" OnClick="ApproveButton_OnClick" runat="server" />
        <asp:Button Text="Deny" CssClass="button" ID="DenyButton" OnClick="DenyButton_OnClick" runat="server" />
    </asp:Panel>
</asp:Panel>