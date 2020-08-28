<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Gallery.ascx.cs" Inherits="Navebsite.Controls.Gallery" %>
Photos
<asp:DataList id="ItemsList"
           BorderColor="black"
           CellPadding="20"
           CellSpacing="10"
           RepeatDirection="Vertical"
           RepeatLayout="Table"
           RepeatColumns="3"
           runat="server"
                CssClass="gallery">


               
         <ItemTemplate>
             <div class="image">
                 <img src="../<%# DataBinder.Eval(Container.DataItem,"PhotoUrl") %>" alt="Photo" class="gallery_image" />
                 </div>
         </ItemTemplate>
 
      </asp:DataList>