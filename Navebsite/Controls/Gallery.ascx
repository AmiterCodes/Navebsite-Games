<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Gallery.ascx.cs" Inherits="Navebsite.Controls.Gallery" %>
Photos
<asp:DataList id="ItemsList"
              BorderColor="black"
              CellPadding="20"
              CellSpacing="10"
              RepeatDirection="Vertical"
              RepeatLayout="Flow"
              RepeatColumns="3"
              runat="server"
              CssClass="gallery">


    <ItemTemplate>
        <img src="../<%# DataBinder.Eval(Container.DataItem, "PhotoUrl") %>" alt="Photo" class="gallery_image"/>

    </ItemTemplate>

</asp:DataList>