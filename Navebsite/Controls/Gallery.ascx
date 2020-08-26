<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Gallery.ascx.cs" Inherits="Navebsite.Controls.Gallery" %>

<asp:DataList id="ItemsList"
           BorderColor="black"
           CellPadding="20"
           CellSpacing="50"
           RepeatDirection="Vertical"
           RepeatLayout="Table"
           RepeatColumns="3"
           runat="server"
                CssClass="gallery">

         <HeaderStyle BackColor="#aaaadd">
         </HeaderStyle>

         <AlternatingItemStyle BackColor="Gainsboro">
         </AlternatingItemStyle>

               
         <ItemTemplate>
             <div class="image">
                 <img src="../<%# DataBinder.Eval(Container.DataItem,"PhotoUrl") %>" alt="Game Photo" />
         </ItemTemplate>
 
      </asp:DataList>