<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GameList.ascx.cs" Inherits="Navebsite.Controls.GameList" %>
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

               
         <ItemTemplate>
             <div class="game">
                 <asp:Image id="ProductImage" AlternateText="Product picture" 
                 ImageUrl='<%#: "../Images/GameBackgrounds/"+DataBinder.Eval(Container.DataItem, "Background") %>'
                 runat="server" CssClass="game_image"/>
              <div class="game_caption">
                  
             <a href="gamepage?id=<%#: DataBinder.Eval(Container.DataItem, "Id") %>">
                <span class="game_title"><%#: DataBinder.Eval(Container.DataItem, "GameName") %></span>
                 </a>
                <span class="game_genres"><%#: DataBinder.Eval(Container.DataItem, "GenresString") %></span>
              </div>
              <div class="game_bottom">
                <button class="game_buy"><%#: DataBinder.Eval(Container.DataItem, "Price", "${0}") %></button>

                <a class="game_company" href="CompanyPage.aspx?dev=<%# DataBinder.Eval(Container.DataItem, "DeveloperID") %>"><%#: DataBinder.Eval(Container.DataItem, "DeveloperName") %></a>
              </div>
                 </div>
         </ItemTemplate>
 
      </asp:DataList>