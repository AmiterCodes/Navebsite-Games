<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpdateList.ascx.cs" Inherits="Navebsite.Controls.UpdateList" %>
<%@ Register TagPrefix="NV" tagName="UpdateView" src="UpdateView.ascx" %>
<div class="game_updates">
    <h2>Game Updates</h2>
    <asp:Repeater ID="Repeater" runat="server" OnItemDataBound="OnItemDataBound">
        <ItemTemplate>
            <NV:UpdateView runat="server" ID="UpdateView" />
        </ItemTemplate>
    </asp:Repeater>
</div>