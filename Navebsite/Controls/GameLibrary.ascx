<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GameLibrary.ascx.cs" Inherits="Navebsite.Controls.GameLibrary" %>
<div class="game_library">
<h2>Library</h2>
<asp:DataList ID="ItemsList"
    CellPadding="20"
    CellSpacing="20"
    RepeatDirection="Vertical"
    RepeatLayout="Table"
    RepeatColumns="1"
    runat="server"
    >
    <ItemTemplate>
        <div class="libgame" style="background-image: linear-gradient(180deg, rgba(15, 16, 22, 0.72) 0, #1C1D2B 100%), url('../<%#: Eval( "BackgroundUrl")%>');">
            <div class="libgame_info">
                <h2><%#: Eval( "GameName") %></h2>
                <a class="libgame_company" href="CompanyPage.aspx?dev=<%# Eval("DeveloperID") %>"><%#: DataBinder.Eval(Container.DataItem, "DeveloperName") %></a>
                <div class="libgame_genre"><%#: Eval( "GenresString") %></div>
            </div>
            <div class="libgame_time"><%#: Eval( "BoughtString") %></div>
            <div class="libgame_buttons">
                <asp:HyperLink Text="Game Page" runat="server" CssClass="button" NavigateUrl=<%# "../GamePage.aspx?id=" + Eval("ID") %> />
            </div>
        </div>
    </ItemTemplate>
</asp:DataList>
    </div>