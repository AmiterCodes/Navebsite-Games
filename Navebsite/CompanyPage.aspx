<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="true" CodeBehind="CompanyPage.aspx.cs" Inherits="Navebsite.CompanyPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">
    <div class="dev">
        
    <asp:Image ID="banner" runat="server" CssClass="dev_banner" />
        <div class="dev_info">
    <asp:Image ID="icon" runat="server" CssClass="dev_icon" />
    <asp:Label runat="server" CssClass="dev_name" ID="name"></asp:Label>
            </div>
    </div>
    
    <NV:GameList runat="server" ID="list"/>
   
    <NV:Gallery runat="server" ID="gallery"/>
    
</asp:Content>
