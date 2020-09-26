<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="true" CodeBehind="Store.aspx.cs" Inherits="Navebsite.Store" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">
    <asp:DropDownList runat="server" ID="sortBy">
        <asp:ListItem Value="Publish Date">Release Date</asp:ListItem>
        <asp:ListItem Value="Game Name">Name</asp:ListItem>
        <asp:ListItem Value="Price">Price</asp:ListItem>
    </asp:DropDownList>

    <div class="tuple_vert">
        <asp:TextBox runat="server" type="range" min="0" max="300" step="20" value="300" CssClass="slider" Id="slider" ClientIDMode="Static"></asp:TextBox>
        <asp:Label Text="Any Price" runat="server" ClientIDMode="Static" ID="text"/>
    </div>
    <script>
        let slider = document.getElementById("slider");
        let text = document.getElementById("text");
        slider.addEventListener('change',
            (e) => {
                if (slider.value === slider.max) text.innerText = "Any price";
                else
                    text.innerText = slider.value + "";
            });
    </script>

    <NV:GameList ID="gm" runat="server"/>
</asp:Content>