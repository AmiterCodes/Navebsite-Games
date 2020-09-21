<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="true" CodeBehind="AddGame.aspx.cs" Inherits="Navebsite.AddGame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">
    <asp:Panel runat="server" ID="AddGameForm" CssClass="centering">
        <div>
        <asp:TextBox runat="server" ID="GameName" CssClass="input" />
<div class="tuple">    
     <asp:Label Text="Current Genres" AssociatedControlID="Genres" runat="server" CssClass="input_label" />
    <asp:Label runat="server" ID="Genres" CssClass="input" />    
    <asp:Button Text="Reset Genres" runat="server" ID="ResetButton" OnClick="ResetButton_Click" CssClass="button" />
    </div>
        <div class="tuple">
             <asp:Label Text="Select Genre to add" AssociatedControlID="GenreList" runat="server" CssClass="input_label" />
    <asp:DropDownList ID="GenreList" runat="server" CssClass="input_list"></asp:DropDownList>
    <asp:Button Text="Add to Current Genres" runat="server" ID="AddToCurrentGenres" OnClick="AddToCurrentGenres_Click" CssClass="button" />
            </div>
        <div class="tuple">
             <asp:Label Text="Add New Genre" AssociatedControlID="newGenre" runat="server" CssClass="input_label" />
        <asp:TextBox runat="server" ID="newGenre" CssClass="input" />
                
            
        <asp:Button Text="Add to All Genres" runat="server" ID="AddGenreToAll" OnClick="AddGenreToAll_Click" CssClass="button" />
            </div>
        <div class="tuple">
            <asp:Label Text="Version" AssociatedControlID="Version" runat="server" CssClass="input_label" />
    <asp:TextBox runat="server" ID="Version" CssClass="input" />
            </div>

        <div class="tuple">
            <asp:Label Text="Link to Game" AssociatedControlID="GameLink" runat="server" CssClass="input_label" />
    <asp:TextBox runat="server" ID="GameLink" CssClass="input"/>
            </div>
        <div class="tuple">
            <asp:Label Text="Background Image" AssociatedControlID="Background" runat="server" CssClass="input_label" />
    <asp:FileUpload ID="Background" runat="server" CssClass="input"/>
            </div>
        
    <asp:FileUpload ID="Logo" runat="server" CssClass="input"/>


    <asp:TextBox runat="server" ID="Description" CssClass="input"/>


    <asp:Button Text="Submit for ReviewObject" runat="server" ID="button" CssClass="button" OnClick="button_Click" />
            </div>
</asp:Panel>
</asp:Content>
