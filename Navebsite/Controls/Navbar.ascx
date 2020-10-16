<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navbar.ascx.cs" Inherits="Navebsite.Controls.Navbar" %>
<nav class="navbar">
    <ul class="navbar-nav">
        <li class="logo nav-item">
            <a href="Default.aspx" class="nav-link">
                
                <svg xmlns="http://www.w3.org/2000/svg" width="90" height="105" viewBox="0 0 90 105" fill="none">
                    <path fill-rule="evenodd" clip-rule="evenodd" d="M85.48 30.8491C80.4435 36.7752 73.5199 40.434 65.8785 40.434C50.4789 40.434 37.995 25.5744 37.995 7.24419C37.995 4.75602 38.2251 2.33179 38.6612 0C16.8346 3.43484 0 25.4322 0 52.0564C0 81.0638 19.9833 104.579 44.634 104.579C69.2847 104.579 89.268 81.0638 89.268 52.0564C89.268 44.5098 87.9154 37.3349 85.48 30.8491ZM72.5175 62.7839C72.5175 67.2276 69.4994 70.8299 65.7764 70.8299C62.0534 70.8299 59.0353 67.2276 59.0353 62.7839C59.0353 58.3402 62.0534 54.7379 65.7764 54.7379C69.4994 54.7379 72.5175 58.3402 72.5175 62.7839Z" fill="white"/>
                </svg>
                <span class="link-text logo-text">Navebsite</span>
            </a>
        </li>
        <li class="nav-item" ID="store" runat="server">
            <asp:HyperLink runat="server" NavigateUrl="../Store.aspx" CssClass="nav-link">
                
                <svg xmlns="http://www.w3.org/2000/svg" aria-hidden="true" focusable="false" data-prefix="fas" data-icon="store" class="svg-inline--fa fa-store fa-w-20" role="img" viewBox="0 0 616 512"><path fill="currentColor" d="M602 118.6L537.1 15C531.3 5.7 521 0 510 0H106C95 0 84.7 5.7 78.9 15L14 118.6c-33.5 53.5-3.8 127.9 58.8 136.4 4.5.6 9.1.9 13.7.9 29.6 0 55.8-13 73.8-33.1 18 20.1 44.3 33.1 73.8 33.1 29.6 0 55.8-13 73.8-33.1 18 20.1 44.3 33.1 73.8 33.1 29.6 0 55.8-13 73.8-33.1 18.1 20.1 44.3 33.1 73.8 33.1 4.7 0 9.2-.3 13.7-.9 62.8-8.4 92.6-82.8 59-136.4zM529.5 288c-10 0-19.9-1.5-29.5-3.8V384H116v-99.8c-9.6 2.2-19.5 3.8-29.5 3.8-6 0-12.1-.4-18-1.2-5.6-.8-11.1-2.1-16.4-3.6V480c0 17.7 14.3 32 32 32h448c17.7 0 32-14.3 32-32V283.2c-5.4 1.6-10.8 2.9-16.4 3.6-6.1.8-12.1 1.2-18.2 1.2z"/></svg>
                <span class="link-text">Store</span>
            </asp:HyperLink>
        </li>
        <li class="nav-item" ID="register" runat="server">
            <asp:HyperLink  runat="server" NavigateUrl="../Register.aspx" CssClass="nav-link">
                
                <svg xmlns="http://www.w3.org/2000/svg" aria-hidden="true" focusable="false" data-prefix="fas" data-icon="user-plus" class="svg-inline--fa fa-user-plus fa-w-20" role="img" viewBox="0 0 640 512"><path fill="currentColor" d="M624 208h-64v-64c0-8.8-7.2-16-16-16h-32c-8.8 0-16 7.2-16 16v64h-64c-8.8 0-16 7.2-16 16v32c0 8.8 7.2 16 16 16h64v64c0 8.8 7.2 16 16 16h32c8.8 0 16-7.2 16-16v-64h64c8.8 0 16-7.2 16-16v-32c0-8.8-7.2-16-16-16zm-400 48c70.7 0 128-57.3 128-128S294.7 0 224 0 96 57.3 96 128s57.3 128 128 128zm89.6 32h-16.7c-22.2 10.2-46.9 16-72.9 16s-50.6-5.8-72.9-16h-16.7C60.2 288 0 348.2 0 422.4V464c0 26.5 21.5 48 48 48h352c26.5 0 48-21.5 48-48v-41.6c0-74.2-60.2-134.4-134.4-134.4z"/></svg>
                <span class="link-text">Register</span>
            </asp:HyperLink>
        </li>
        <li class="nav-item" ID="logout" runat="server">
            <asp:HyperLink  runat="server" class="nav-link" NavigateUrl="../Logout.aspx">
                
                <svg xmlns="http://www.w3.org/2000/svg" aria-hidden="true" focusable="false" data-prefix="fas" data-icon="sign-out-alt" class="svg-inline--fa fa-sign-out-alt fa-w-16" role="img" viewBox="0 0 512 512"><path fill="currentColor" d="M497 273L329 441c-15 15-41 4.5-41-17v-96H152c-13.3 0-24-10.7-24-24v-96c0-13.3 10.7-24 24-24h136V88c0-21.4 25.9-32 41-17l168 168c9.3 9.4 9.3 24.6 0 34zM192 436v-40c0-6.6-5.4-12-12-12H96c-17.7 0-32-14.3-32-32V160c0-17.7 14.3-32 32-32h84c6.6 0 12-5.4 12-12V76c0-6.6-5.4-12-12-12H96c-53 0-96 43-96 96v192c0 53 43 96 96 96h84c6.6 0 12-5.4 12-12z"/></svg>
                <span class="link-text">Logout</span>
            </asp:HyperLink>
        </li>
        <li class="nav-item" ID="login" runat="server">
            <asp:HyperLink  runat="server" class="nav-link" NavigateUrl="../Login.aspx" Text="Login">
                
                <svg xmlns="http://www.w3.org/2000/svg" aria-hidden="true" focusable="false" data-prefix="fas" data-icon="sign-in-alt" class="svg-inline--fa fa-sign-in-alt fa-w-16" role="img" viewBox="0 0 512 512"><path fill="currentColor" d="M416 448h-84c-6.6 0-12-5.4-12-12v-40c0-6.6 5.4-12 12-12h84c17.7 0 32-14.3 32-32V160c0-17.7-14.3-32-32-32h-84c-6.6 0-12-5.4-12-12V76c0-6.6 5.4-12 12-12h84c53 0 96 43 96 96v192c0 53-43 96-96 96zm-47-201L201 79c-15-15-41-4.5-41 17v96H24c-13.3 0-24 10.7-24 24v96c0 13.3 10.7 24 24 24h136v96c0 21.5 26 32 41 17l168-168c9.3-9.4 9.3-24.6 0-34z"/></svg>
                <span class="link-text">Login</span>
            </asp:HyperLink>
        </li>
        <li class="nav-item" ID="library" runat="server">
            <asp:HyperLink runat="server" class="nav-link" NavigateUrl="../Library.aspx" Text="Library">
                
                <svg aria-hidden="true" focusable="false" data-prefix="fad" data-icon="dice" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 512" class="svg-inline--fa fa-dice fa-w-20 fa-9x"><g class="fa-group"><path fill="currentColor" d="M433.63 189.3L258.7 14.37a49.07 49.07 0 0 0-69.39 0L14.37 189.3a49.07 49.07 0 0 0 0 69.39L189.3 433.63a49.07 49.07 0 0 0 69.39 0L433.63 258.7a49.08 49.08 0 0 0 0-69.4zM96 248a24 24 0 1 1 24-24 24 24 0 0 1-24 24zm128 128a24 24 0 1 1 24-24 24 24 0 0 1-24 24zm0-128a24 24 0 1 1 24-24 24 24 0 0 1-24 24zm0-128a24 24 0 1 1 24-24 24 24 0 0 1-24 24zm128 128a24 24 0 1 1 24-24 24 24 0 0 1-24 24z" class="fa-secondary"></path><path fill="currentColor" d="M592 192H473.26a81.07 81.07 0 0 1-17 89.32L320 417.58V464a48 48 0 0 0 48 48h224a48 48 0 0 0 48-48V240a48 48 0 0 0-48-48zM480 376a24 24 0 1 1 24-24 24 24 0 0 1-24 24zM96 200a24 24 0 1 0 24 24 24 24 0 0 0-24-24zm256 48a24 24 0 1 0-24-24 24 24 0 0 0 24 24zm-128 80a24 24 0 1 0 24 24 24 24 0 0 0-24-24zm0-256a24 24 0 1 0 24 24 24 24 0 0 0-24-24zm0 128a24 24 0 1 0 24 24 24 24 0 0 0-24-24z" class="fa-primary"></path></g></svg>
                <span class="link-text">Library</span>
            </asp:HyperLink>
        </li>
    </ul>
</nav>
<nav class="sidebar">
    <div class="profile">
        <a href="../Profile.aspx" class="button profile_picture_container">
            <asp:Image runat="server" ID="ProfilePicture" CssClass="profile_picture" ImageUrl="../Images/UserProfiles/profile.png" alt="Profile Picture" />
            
            </a>
        <asp:Label runat="server" Text="Guest" ID="ProfileName" class="side_name"></asp:Label>
        <div class="side_content">
            <asp:HyperLink Visible="False" Text="Login" NavigateUrl="../Login.aspx" ID="loginSide" CssClass="button" runat="server" />
            <asp:HyperLink Visible="False" Text="Register" NavigateUrl="../Register.aspx" ID="registerSide" CssClass="button" runat="server" />
            <asp:HyperLink Visible="False" Text="Settings" NavigateUrl="../UserSettings.aspx" ID="userSettingsSide" CssClass="button" runat="server" />
            <asp:HyperLink Visible="False" Text="Logout" NavigateUrl="../Logout.aspx" ID="logoutSide" CssClass="button" runat="server" />
            <span class="bold">Balance:</span>
            <asp:Label ID="balance" Text="$0.00" runat="server" />
        </div>
    </div>
</nav>
