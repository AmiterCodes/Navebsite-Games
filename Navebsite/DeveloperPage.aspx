<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="True" CodeBehind="DeveloperPage.aspx.cs" Inherits="Navebsite.DeveloperPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">
    <div class="settings">
        <div class="setting_tab_list" id="list">
            <a class="settings_tab" onclick="openPage('chart', this)" href="#">
                <span class="settings_tab-header">
                    <i class="fas fa-chart-bar"></i>
                    Sales & Purchases
                </span>
                <p class="settings_tab-desc">
                    Here you can view sales and purchases charts for your games.
                </p>
            </a>
            <a class="selected settings_tab " onclick="openPage('gameListContainer', this)" href="#">
                <span class="settings_tab-header">
                    <i class="fas fa-list"></i>
                    Game List
                </span>
                <p class="settings_tab-desc">
                    Here you can see a list of your games.
                </p>
            </a>
            <a class="settings_tab" onclick="openPage('images', this)" href="#">
                <span class="settings_tab-header">
                    <i class="fas fa-photo-video"></i>
                    Edit Media
                </span>
                <p class="settings_tab-desc">
                    Here you edit your account's media information.
                </p>
            </a>
            <a class="settings_tab" onclick="openPage('generalData', this)" href="#">
                <span class="settings_tab-header">
                    <i class="fas fa-user-circle"></i>
                    General Data for your company
                </span>
                <p class="settings_tab-desc">
                    Here you can view and edit the company's data.
                </p>
            </a>
            <asp:HyperLink class="settings_tab" ID="PageLink" runat="server">
                <span class="settings_tab-header">
                    <i class="far fa-file"></i>
                    Your company's Page
                </span>
                <p class="settings_tab-desc">
                    Here you can view your company's page from a user's perspective.
                </p>
            </asp:HyperLink>
        </div>
        
    <div id="settings_list" class="user-settings">
        <asp:Panel runat="server" ID="chart" ClientIDMode="Static">
        <h3 class="header_secondary">Sales & Purchases Chart</h3>
        <NV:SalesChart runat="server" ID="salesChart"/>
    </asp:Panel>
    <div id="generalData">



        <asp:Panel runat="server" DefaultButton="SubmitData">
            <h3 class="header_secondary">Update your data</h3>

            <asp:TextBox ID="AboutField" runat="server" CssClass="input" placeholder="Bio Here"/>
            <asp:RequiredFieldValidator ErrorMessage="You must input something for a bio" ControlToValidate="AboutField" ValidationGroup="DeveloperData" runat="server"/>

            <asp:TextBox ID="DeveloperNameField" runat="server" CssClass="input" placeholder="Developer Name Here"/>
            <asp:RequiredFieldValidator ErrorMessage="You must input a developer name" ControlToValidate="DeveloperNameField" ValidationGroup="DeveloperData" runat="server"/>
            <asp:Button ID="SubmitData" Text="Update Developer Data" runat="server" CssClass="button" OnClick="SubmitData_OnClick"/>


        </asp:Panel>
    </div>

    <div id="images">
        <asp:Panel CssClass="tuple_vert" runat="server" DefaultButton="UploadBackground">
            <h3 class="header_secondary">Developer Banner</h3>
            <asp:Image runat="server" ID="CurrentBackground" CssClass="image_preview"/>
            <asp:FileUpload ID="Background" runat="server" CssClass="input"/>
            <asp:RequiredFieldValidator ErrorMessage="You must upload an image" ControlToValidate="Background" ValidationGroup="Background" runat="server"/>
            <asp:Button ID="UploadBackground" Text="Update Background" runat="server" CssClass="button" OnClick="UploadBackground_OnClick"/>
        </asp:Panel>


        <!-- PROFILE PICTURE -->

        <asp:Panel CssClass="tuple_vert" runat="server" DefaultButton="UploadProfile">
            <h3 class="header_secondary">Developer Icon</h3>
            <asp:Image runat="server" ID="CurrentProfilePicture" CssClass="image_preview"/>

            <asp:FileUpload ID="ProfilePicture" runat="server" CssClass="input"/>
            <asp:RequiredFieldValidator ErrorMessage="You must upload an image" ControlToValidate="ProfilePicture" ValidationGroup="ProfilePicture" runat="server"/>
            <asp:Button ID="UploadProfile" Text="Update Profile Picture" runat="server" CssClass="button" OnClick="UploadProfile_OnClick"/>
        </asp:Panel>
    </div>
    <div id="gameListContainer">
        <h3 class="header_secondary">Your Games</h3>
        
        <asp:HyperLink NavigateUrl="AddGame.aspx" CssClass="button" Text="Add Game" runat="server"/>
        <NV:GameViewList runat="server" ID="games"/>
    </div>
    </div>
    
    </div>
    <script defer>

        function openPage(name, element) {
            const list = document.getElementById('list');
            const settingsPages = document.getElementById('settings_list');

            [...list.children].forEach(child => child.classList.remove('selected'));
            element.classList.add('selected');

            [...settingsPages.children].forEach(child => child.hidden = true);
            const elem = document.getElementById(name);

            elem.hidden = false;

        }

        openPage('generalData', list.children[1]);

    </script>
</asp:Content>
