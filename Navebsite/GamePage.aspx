<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="true" CodeBehind="GamePage.aspx.cs" Inherits="Navebsite.GamePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="gamepage">
        
    <asp:Panel ID="banner" runat="server" CssClass="gamepage_banner" >
        <asp:Label Text="Game Name" runat="server" ID="name" CssClass="gamepage_name" />
    </asp:Panel>
        <div class="gamepage_info">
            <asp:Button Id="play" runat="server" CssClass="big-button" OnClick="play_Click" />
        </div>
    </div>
    
    <NV:Gallery runat="server" Id="gallery"/>
</asp:Content>
