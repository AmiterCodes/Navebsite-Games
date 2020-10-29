<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="true" CodeBehind="EditGame.aspx.cs" Inherits="Navebsite.EditGame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">
    <asp:Panel runat="server" ID="EditGameForm" CssClass="centering">
        <div>
            <div>
            <div class="tuple_vert">
            <asp:Label Text="Game Name" AssociatedControlID="GameName" runat="server" CssClass="input_label"/>
            <asp:TextBox runat="server" ID="GameName" CssClass="input"/>
            </div>
            <div class="tuple_vert">
                <asp:Label Text="Current Genres" AssociatedControlID="Genres" runat="server" CssClass="input_label"/>
                <asp:Label runat="server" ID="Genres" CssClass="input"/>
                <asp:Button Text="Reset Genres" runat="server" ID="ResetButton" OnClick="ResetButton_Click" CssClass="button" CausesValidation="False"/>
            </div>
            <div class="tuple">
                <asp:Label Text="Select Genre to add" AssociatedControlID="GenreList" runat="server" CssClass="input_label"/>
                <asp:DropDownList ID="GenreList" runat="server" CssClass="input_list"></asp:DropDownList>
                <asp:Button Text="Add to Current Genres" runat="server" ID="AddToCurrentGenres" OnClick="AddToCurrentGenres_Click" CausesValidation="False" CssClass="button"/>
            </div>
            <div class="tuple">
                <asp:Label Text="Add New Genre" AssociatedControlID="newGenre" runat="server" CssClass="input_label"/>
                <asp:TextBox runat="server" ID="newGenre" CssClass="input"/>


                <asp:Button Text="Add to All Genres" runat="server" ID="AddGenreToAll" OnClick="AddGenreToAll_Click" CssClass="button" CausesValidation="False"/>
            </div>
            </div>
            <div>

            <div class="tuple_vert">
                <asp:Label Text="Link to Game" AssociatedControlID="GameLink" runat="server" CssClass="input_label"/>
                <asp:TextBox runat="server" ID="GameLink" CssClass="input"/>
            </div>
            <div class="tuple_vert">
                <asp:Label Text="Background Image" AssociatedControlID="Background" runat="server" CssClass="input_label"/>
                <asp:FileUpload ID="Background" runat="server" CssClass="input" accept=".png,.jpg,.jpeg,.jfif,.webp"/>
            </div>
            <div class="tuple_vert">
                <asp:Label Text="Logo Image" AssociatedControlID="Logo" runat="server" CssClass="input_label"/>
                <asp:FileUpload ID="Logo" runat="server" CssClass="input" accept=".png,.jpg,.jpeg,.jfif,.webp"/>
                
            </div>
            <div class="tuple_vert">
                <asp:Label Text="Description" AssociatedControlID="Description" runat="server" />
                <asp:TextBox runat="server" ID="Description" CssClass="input" TextMode="MultiLine"/>
            </div>
            <div class="tuple_vert">
                <asp:Label Text="Price" AssociatedControlID="Price" runat="server" CssClass="input_label"/>
                <asp:TextBox runat="server" ID="Price" CssClass="input"/>
            </div>
            <asp:Button Text="Update" runat="server" ID="button" CssClass="button" OnClick="button_Click"/>
        </div>
        </div>
        <div class="=centering">
            <asp:RangeValidator ID="PriceValidator" runat="server" ErrorMessage="Price must be a double"
                                Type="Double" ControlToValidate="Price" MinimumValue="0" MaximumValue="1000" Display="Dynamic">
            </asp:RangeValidator>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Description" ErrorMessage="You must enter a description" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ErrorMessage="You must put a game link" ControlToValidate="GameLink" Display="Dynamic" runat="server"/>
            <asp:RegularExpressionValidator ErrorMessage="Must be a valid URL" ControlToValidate="GameLink" ValidationExpression="https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)" Display="Dynamic" runat="server"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ErrorMessage="You must put a game name" ControlToValidate="GameName" Display="Dynamic" runat="server"/>


        </div>
    </asp:Panel>
</asp:Content>
