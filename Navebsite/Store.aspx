<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="true" CodeBehind="Store.aspx.cs" Inherits="Navebsite.Store" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <asp:DataList id="ItemsList"
           BorderColor="black"
           CellPadding="20"
           CellSpacing="50"
           RepeatDirection="Vertical"
           RepeatLayout="Table"
           RepeatColumns="3"
           runat="server"
                CssClass="store">

         <HeaderStyle BackColor="#aaaadd">
         </HeaderStyle>

         <AlternatingItemStyle BackColor="Gainsboro">
         </AlternatingItemStyle>

         <HeaderTemplate>
            List of items
         </HeaderTemplate>
               
         <ItemTemplate>

            
             <div class="game">
                 <asp:Image id="ProductImage" AlternateText="Product picture" 
                 ImageUrl='<%# "./Images/GameBackgrounds/"+DataBinder.Eval(Container.DataItem, "Background") %>'
                 runat="server" CssClass="game_image"/>
              <div class="game_caption">
                <span class="game_title"><%# DataBinder.Eval(Container.DataItem, "GameName") %></span>
                <span class="game_genres"><%# DataBinder.Eval(Container.DataItem, "GenresString") %></span>
              </div>
              <div class="game_bottom">
                <button class="game_buy"><%# DataBinder.Eval(Container.DataItem, "Price", "${0:c}") %></button>
                <p class="game_company">Mojang Inc.</p>
              </div>
            </div>
         </ItemTemplate>
 
      </asp:DataList>

</asp:Content>
