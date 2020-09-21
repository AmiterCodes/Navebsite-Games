<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpdateList.ascx.cs" Inherits="Navebsite.Controls.UpdateList" %>
<div class="game_updates">
<h2>Game Updates</h2>
<asp:DataList ID="ItemsList"
    CellPadding="20"
    CellSpacing="20"
    RepeatDirection="Vertical"
    RepeatLayout="Table"
    RepeatColumns="1"
    runat="server" CssClass="game_update_list"
    >
    <ItemTemplate>
        <div class="libgame" style="background-image: linear-gradient(180deg, rgba(15, 16, 22, 0.72) 0, #1C1D2B 100%), url('../<%#: DataBinder.Eval(Container.DataItem, "BackgroundUrl")%>');">
            <div class="libgame_info">
                <h2><%#: DataBinder.Eval(Container.DataItem, "GameName") %></h2>
                <a class="libgame_company" href="CompanyPage.aspx?dev=<%# DataBinder.Eval(Container.DataItem, "DeveloperID") %>"><%#: DataBinder.Eval(Container.DataItem, "DeveloperName") %></a>
                <div class="libgame_genre"><%#: DataBinder.Eval(Container.DataItem, "GenresString") %></div>
            </div>
            <div class="libgame_time"><%#: DataBinder.Eval(Container.DataItem, "BoughtString") %></div>
            <div class="libgame_buttons">
                <button class="button">Game Page</button>
                <button class="button">Play</button>
            </div>
        </div>
    </ItemTemplate>

</asp:DataList>
</div>