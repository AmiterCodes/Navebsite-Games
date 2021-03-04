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
            <div class="tuple">
            <asp:TextBox runat="server" ID="SearchBox" ClientIDMode="Static" CssClass="input" placeholder="Search..." />
                <asp:Button Text="Search!" CssClass="button" OnClick="SearchBox_OnTextChanged" runat="server" />
            </div>
            <div id="found_games" class="found_games">

            </div>
        </div>
        <script>
            let slider = document.getElementById("slider");
            let text = document.getElementById("text");
            let textbox = document.getElementById("SearchBox");

            textbox.addEventListener('input', (e) => {
                    fetch('Store.aspx/AutoComplete',
                        {
                            headers: { 'Accept': 'application/json', 'Content-type': 'application/json; charset=utf-8' },
                            method: 'POST',
                            body: JSON.stringify({ current: textbox.value }),
                            credentials: 'include'
                        }
                    )
                
                    .then(data => data.json())
                        .then(data => data.d).
                        then(arr => {
                            console.table(arr);
                            let foundGames = document.getElementById('found_games');
                            foundGames.innerHTML = "";
                            arr.forEach(game => {

                                const div = document.createElement('a');
                                div.href = '../gamepage?id=' + game.Id;
                                div.classList.add('found-game');

                                div.innerHTML = `<img src='${game.IconUrl}' class='found-game-image'/><h3 class='found-game_name'>${game.GameName}</h3>`;
                                foundGames.appendChild(div);
                            });
                    });
            });
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