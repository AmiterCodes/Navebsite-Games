<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GameList.ascx.cs" Inherits="Navebsite.Controls.GameList" %>
<div class="game_list">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            
<asp:DataList id="ItemsList"
           CellPadding="20"
           CellSpacing="30"
           RepeatDirection="Horizontal"
           RepeatLayout="Table"
           RepeatColumns="4"
              
           runat="server"
              CssClass="store">

               
         <ItemTemplate>
             <div class="game">
                 <asp:Image id="ProductImage" AlternateText="Product picture" 
                 ImageUrl='<%#: "../Images/GameBackgrounds/"+DataBinder.Eval(Container.DataItem, "Background") %>'
                 runat="server" CssClass="game_image"/>
              <div class="game_caption">
                  
             <a href="gamepage?id=<%#: DataBinder.Eval(Container.DataItem, "Id") %>" style="text-align: center">
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="list_footer">
        <asp:Button Text="&larr; Previous" CssClass="button" OnClick="prevButton_OnClick" ID="prevButton" runat="server" />
        <asp:Label Text="1" ID="PageLabel" runat="server" />
        <asp:Button Text="Next &rarr;" CssClass="button" OnClick="nextButton_OnClick" ID="nextButton" runat="server" />
    </div>
</div>