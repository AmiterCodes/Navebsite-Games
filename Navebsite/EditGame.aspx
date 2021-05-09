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
    <asp:Panel ID="ImageForms" runat="server">
        <div class="tuple_vert">
            <asp:Label Text="Background Image" AssociatedControlID="Background" runat="server" CssClass="input_label"/>
            <asp:FileUpload ID="Background" runat="server" CssClass="input" accept=".png,.jpg,.jpeg,.jfif,.webp"/>
            <asp:Button Text="Update Background" CssClass="button" ValidationGroup="Background" ID="UpdateBackgroundButton" OnClick="UpdateBackgroundButton_OnClick" runat="server" />
            <asp:RequiredFieldValidator ID="FileUpload1Validator" ControlToValidate="Background" runat="server" ErrorMessage="You must put a valid logo" ValidationGroup="Logo"></asp:RequiredFieldValidator>
        </div>
        <div class="tuple_vert">
            <asp:Label Text="Logo Image" AssociatedControlID="Logo" runat="server" CssClass="input_label"/>
            <asp:FileUpload ID="Logo" runat="server" CssClass="input" ValidationGroup="Logo" accept=".png,.jpg,.jpeg,.jfif,.webp"/>
            <asp:RequiredFieldValidator ID="FileUpload2Validator" ControlToValidate="Logo" runat="server" ErrorMessage="You must put a valid logo" ValidationGroup="Logo"></asp:RequiredFieldValidator>
            <asp:Button Text="Update Logo" CssClass="button" ID="UpdateLogoButton" OnClick="UpdateLogoButton_OnClick" ValidationGroup="Logo" runat="server" />
        </div>
    </asp:Panel>

    <asp:Panel runat="server" ID="AddUpdateForm" DefaultButton="AddUpdateButton">

        <span style="font-size: 2rem">Add Update</span>
        <asp:TextBox Visible="false" runat="server" ID="updateOutput" ClientIDMode="Static"  />
       <div class="tuple_vert">
                <asp:Label Text="Version" AssociatedControlID="Version" runat="server" CssClass="input_label"/>
                <asp:TextBox runat="server" ID="Version" CssClass="input" ValidationGroup="Update"/>
            </div>
     <div class="tuple_vert">
                <asp:Label Text="Version Title" AssociatedControlID="VersionTitle" runat="server" CssClass="input_label"/>
                <asp:TextBox runat="server" ID="VersionTitle" CssClass="input" ValidationGroup="Update"/>
            </div>
     
        <asp:TextBox runat="server" ID="MyID" ClientIDMode="Static" ValidationGroup="Update" />
        <asp:RequiredFieldValidator ErrorMessage="You must put version content" ControlToValidate="updateOutput" runat="server" Display="Dynamic" />
        
        <asp:RequiredFieldValidator ErrorMessage="You must put a version title" ControlToValidate="VersionTitle" runat="server" Display="Dynamic" />
                <asp:RequiredFieldValidator ErrorMessage="You must put a version title" ControlToValidate="Version" runat="server" Display="Dynamic" />

        <asp:Button CssClass="button" Text="Add Update" OnClick="AddUpdateButton_Click" ValidationGroup="Update" Id="AddUpdateButton" runat="server" />
    </asp:Panel>

    <script defer>
        var simplemde = new SimpleMDE({ element: document.getElementById("MyID") });
        simplemde.codemirror.on("change", function () {
            let elem = document.getElementById("updateOutput");
            elem.value = simplemde.value();
        });
    </script>
</asp:Content>
