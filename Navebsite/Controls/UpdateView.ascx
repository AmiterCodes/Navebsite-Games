<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpdateView.ascx.cs" Inherits="Navebsite.Controls.UpdateView" %>
<div class="update">
    <div class="update_header">
        <asp:Label CssClass="update_title" Text="UpdateTitle" ID="Title" runat="server" />
        <div class="update_meta">
        <asp:Label CssClass="update_version" Text="UpdateVersion" ID="Version" runat="server" />
        <asp:Label CssClass="update_date" Text="UpdateDate" ID="Date" runat="server" />
        </div>
    </div>
    <asp:Label CssClass="update_content" Text="UpdateContent" ID="Content" runat="server" />
</div>