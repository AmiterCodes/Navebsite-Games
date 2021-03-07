<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="Navebsite._404" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">
    <div class="f04_main">
        <div class="f04_text">
            <h1 class="f04_header">
                404
            </h1>
            <p class="f04_subtext">That's sus... There's nothing here...</p>
        </div>
        <img src="./Images/amogus.svg" class="f04_amogus" alt="Amogus" />
        <a href="Store.aspx" class="button f04_button">Take me to the store page</a>
    </div>
    <script>
        var sus = new Audio('./Sounds/amogus.mp3');
        sus.play();
    </script>
</asp:Content>
