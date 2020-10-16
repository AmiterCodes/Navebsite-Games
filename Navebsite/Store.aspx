<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="true" CodeBehind="Store.aspx.cs" Inherits="Navebsite.Store" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">
    <div class="store_page">
        <div class="store_search">
        <asp:DropDownList runat="server" ID="sortBy" AutoPostBack="True" OnSelectedIndexChanged="sortBy_OnSelectedIndexChanged">
            <asp:ListItem Value="PublishDate">Release Date</asp:ListItem>
            <asp:ListItem Value="GameName">Name</asp:ListItem>
            <asp:ListItem Value="Price">Price</asp:ListItem>
        </asp:DropDownList>

        <div class="tuple_vert">
            <asp:TextBox runat="server" type="range" min="10" max="150" step="10" value="150" CssClass="slider" Id="slider" ClientIDMode="Static" AutoPostBack="True" OnTextChanged="slider_OnTextChanged"></asp:TextBox>
            <asp:Label Text="Any Price" runat="server" ClientIDMode="Static" ID="text"/>
            <asp:CheckBoxList ID="GenreChecks" AutoPostBack="True" runat="server" OnSelectedIndexChanged="GenreChecks_OnSelectedIndexChanged">
            </asp:CheckBoxList>
            <asp:TextBox runat="server" ID="SearchBox" CssClass="input" placeholder="Search..."  AutoPostBack="True" OnTextChanged="SearchBox_OnTextChanged" />
        </div>
        <script>
            let slider = document.getElementById("slider");
            let text = document.getElementById("text");
            slider.addEventListener('change',
                (e) => {
                    if (slider.value === slider.max) text.innerText = "Any Price";
                    else
                        text.innerText = "$" + slider.value;
                });
        </script>   
        </div>
        <div class="store_games">
            <NV:GameList ID="gm" runat="server"/>
        </div>
    </div>
</asp:Content>