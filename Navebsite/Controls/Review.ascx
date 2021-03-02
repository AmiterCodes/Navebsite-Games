<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Review.ascx.cs" Inherits="Navebsite.Controls.Review" %>
<div class="review">
    <asp:HyperLink class="review_title" ID="title" runat="server">Review Name</asp:HyperLink>
    <asp:HyperLink class="review_author" ID="author" runat="server">by Author</asp:HyperLink>
    <hr />
    <asp:Panel runat="server" CssClass="review_stars" ID="stars">
    </asp:Panel>
    <asp:Label runat="server" ID="content" class="review_content">Content</asp:Label>
</div>