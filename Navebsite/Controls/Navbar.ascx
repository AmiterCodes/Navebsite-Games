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
                
                <svg aria-hidden="true" focusable="false" data-prefix="fad" data-icon="gamepad-alt" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 512" class="svg-inline--fa fa-gamepad-alt fa-w-20 fa-7x"><g class="fa-group"><path fill="currentColor" d="M638.59 368.22l-33.37-211.59c-8.86-50.26-48.4-90.77-100.66-103.13h-.07a803.19 803.19 0 0 0-369 0C83.17 65.86 43.64 106.36 34.78 156.63L1.41 368.22C-8.9 426.73 38.8 480 101.51 480c49.67 0 93.77-30.07 109.48-74.64l7.52-21.36h203l7.49 21.36C444.72 449.93 488.82 480 538.49 480c62.71 0 110.41-53.27 100.1-111.78zM280 236a12 12 0 0 1-12 12h-52v52a12 12 0 0 1-12 12h-24a12 12 0 0 1-12-12v-52h-52a12 12 0 0 1-12-12v-24a12 12 0 0 1 12-12h52v-52a12 12 0 0 1 12-12h24a12 12 0 0 1 12 12v52h52a12 12 0 0 1 12 12zm152 76a40 40 0 1 1 40-40 40 40 0 0 1-40 40zm64-96a40 40 0 1 1 40-40 40 40 0 0 1-40 40z" class="fa-secondary"></path><path fill="currentColor" d="M280 236a12 12 0 0 1-12 12h-52v52a12 12 0 0 1-12 12h-24a12 12 0 0 1-12-12v-52h-52a12 12 0 0 1-12-12v-24a12 12 0 0 1 12-12h52v-52a12 12 0 0 1 12-12h24a12 12 0 0 1 12 12v52h52a12 12 0 0 1 12 12z" class="fa-primary"></path></g></svg><span class="link-text">Store</span>
            </asp:HyperLink>
        </li>
        <li class="nav-item" ID="register" runat="server">
            <asp:HyperLink  runat="server" NavigateUrl="../Register.aspx" CssClass="nav-link">
                <svg aria-hidden="true" focusable="false" data-prefix="fad" data-icon="user-plus" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 512" class="svg-inline--fa fa-user-plus fa-w-20 fa-7x"><g class="fa-group"><path fill="currentColor" d="M640 224v32a16 16 0 0 1-16 16h-64v64a16 16 0 0 1-16 16h-32a16 16 0 0 1-16-16v-64h-64a16 16 0 0 1-16-16v-32a16 16 0 0 1 16-16h64v-64a16 16 0 0 1 16-16h32a16 16 0 0 1 16 16v64h64a16 16 0 0 1 16 16z" class="fa-secondary"></path><path fill="currentColor" d="M224 256A128 128 0 1 0 96 128a128 128 0 0 0 128 128zm89.6 32h-16.7a174.08 174.08 0 0 1-145.8 0h-16.7A134.43 134.43 0 0 0 0 422.4V464a48 48 0 0 0 48 48h352a48 48 0 0 0 48-48v-41.6A134.43 134.43 0 0 0 313.6 288z" class="fa-primary"></path></g></svg>
                <span class="link-text">Register</span>
            </asp:HyperLink>
        </li>
        <li class="nav-item" ID="logout" runat="server">
            <asp:HyperLink  runat="server" class="nav-link" NavigateUrl="../Logout.aspx">
                
                <svg aria-hidden="true" focusable="false" data-prefix="fad" data-icon="portal-exit" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512" class="svg-inline--fa fa-portal-exit fa-w-16 fa-7x"><g class="fa-group"><path fill="#ff6600" d="M142.39844,415.99609C127.73438,474.47266,105.25,512,80,512,35.81641,512,0,397.38477,0,256S35.81641,0,80,0c32.41406,0,60.25781,61.79492,72.82812,150.47461-10.21484,11.23437-11.78124,28.14062-2.20312,40.59375a31.09936,31.09936,0,0,0,7.17969,6.27148C159.19141,216.207,160,235.78125,160,256a768.85148,768.85148,0,0,1-5.86719,95.99414H128a32.001,32.001,0,0,0,0,64.00195Z" class="fa-secondary"></path><path fill="currentColor" d="M368,96.00195a48.001,48.001,0,1,0-48-48A48.00237,48.00237,0,0,0,368,96.00195ZM209.6875,317.47852,194.875,351.99414H128a32.001,32.001,0,0,0,0,64.00195h77.4375a47.9242,47.9242,0,0,0,44.125-29.07812l8.78125-20.5332-10.65625-6.29688A95.3862,95.3862,0,0,1,209.6875,317.47852ZM480,223.99023H435.96875l-26.0625-53.25195c-12.5-25.54687-35.46875-44.21875-61.78125-50.9375L277.0625,98.6582a95.69075,95.69075,0,0,0-80.875,17.14258L156.5625,146.207A31.99634,31.99634,0,1,0,195.5,196.99023l39.6875-30.4082c7.65625-5.89062,17.4375-8,25.25-6.14062l14.6875,4.375-37.4375,87.39453A64.16017,64.16017,0,0,0,264,332.52539l84.9375,50.17383L321.5,470.41992a31.96894,31.96894,0,0,0,20.9375,40.0957,31.9422,31.9422,0,0,0,40.125-20.9707l31.625-101.06445a48.16,48.16,0,0,0-21.625-54.39258l-61.25-36.14258,31.3125-78.2832,20.28125,41.43945A48.2689,48.2689,0,0,0,426,287.99219h54a32.001,32.001,0,0,0,0-64.002Z" class="fa-primary"></path></g></svg><span class="link-text">Logout</span>
            </asp:HyperLink>
        </li>
        <li class="nav-item" ID="login" runat="server">
            <asp:HyperLink  runat="server" class="nav-link" NavigateUrl="../Login.aspx" Text="Login">
                <svg aria-hidden="true" focusable="false" data-prefix="fad" data-icon="portal-enter" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512" class="svg-inline--fa fa-portal-enter fa-w-16 fa-7x"><g class="fa-group"><path fill="#0099ff" d="M512,256c0,141.38477-35.81641,256-80,256-40.78906,0-74.38281-97.75781-79.3125-224.00781H384a32.001,32.001,0,0,0,0-64.002H352.69141C357.625,97.74805,391.21094,0,432,0,476.18359,0,512,114.61523,512,256Z" class="fa-secondary"></path><path fill="currentColor" d="M113.6875,317.47852,98.875,351.99414H32a32.001,32.001,0,0,0,0,64.00195h77.4375a47.9242,47.9242,0,0,0,44.125-29.07812l8.78125-20.5332-10.65625-6.29688A95.3862,95.3862,0,0,1,113.6875,317.47852ZM272,96.00195a48.001,48.001,0,1,0-48-48A48.00237,48.00237,0,0,0,272,96.00195ZM384,223.99023H339.96875l-26.0625-53.25195c-12.5-25.54687-35.46875-44.21875-61.78125-50.9375L181.0625,98.6582a95.69075,95.69075,0,0,0-80.875,17.14258L60.5625,146.207A31.99634,31.99634,0,1,0,99.5,196.99023l39.6875-30.4082c7.65625-5.89062,17.4375-8,25.25-6.14062l14.6875,4.375-37.4375,87.39453A64.16017,64.16017,0,0,0,168,332.52539l84.9375,50.17383L225.5,470.41992a31.96894,31.96894,0,0,0,20.9375,40.0957,31.9422,31.9422,0,0,0,40.125-20.9707l31.625-101.06445a48.16,48.16,0,0,0-21.625-54.39258l-61.25-36.14258,31.3125-78.2832,20.28125,41.43945A48.2689,48.2689,0,0,0,330,287.99219h54a32.001,32.001,0,0,0,0-64.002Z" class="fa-primary"></path></g></svg>
            
            <span class="link-text">Login</span>
            </asp:HyperLink>
            </li>
        <li class="nav-item" ID="library" runat="server">
            <asp:HyperLink runat="server" class="nav-link" NavigateUrl="../Library.aspx" Text="Library">
                
                <svg aria-hidden="true" focusable="false" data-prefix="fad" data-icon="dice" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 512" class="svg-inline--fa fa-dice fa-w-20 fa-9x"><g class="fa-group"><path fill="currentColor" d="M433.63 189.3L258.7 14.37a49.07 49.07 0 0 0-69.39 0L14.37 189.3a49.07 49.07 0 0 0 0 69.39L189.3 433.63a49.07 49.07 0 0 0 69.39 0L433.63 258.7a49.08 49.08 0 0 0 0-69.4zM96 248a24 24 0 1 1 24-24 24 24 0 0 1-24 24zm128 128a24 24 0 1 1 24-24 24 24 0 0 1-24 24zm0-128a24 24 0 1 1 24-24 24 24 0 0 1-24 24zm0-128a24 24 0 1 1 24-24 24 24 0 0 1-24 24zm128 128a24 24 0 1 1 24-24 24 24 0 0 1-24 24z" class="fa-secondary"></path><path fill="currentColor" d="M592 192H473.26a81.07 81.07 0 0 1-17 89.32L320 417.58V464a48 48 0 0 0 48 48h224a48 48 0 0 0 48-48V240a48 48 0 0 0-48-48zM480 376a24 24 0 1 1 24-24 24 24 0 0 1-24 24zM96 200a24 24 0 1 0 24 24 24 24 0 0 0-24-24zm256 48a24 24 0 1 0-24-24 24 24 0 0 0 24 24zm-128 80a24 24 0 1 0 24 24 24 24 0 0 0-24-24zm0-256a24 24 0 1 0 24 24 24 24 0 0 0-24-24zm0 128a24 24 0 1 0 24 24 24 24 0 0 0-24-24z" class="fa-primary"></path></g></svg>
                <span class="link-text">Library</span>
            </asp:HyperLink>
        </li>
        <li class="nav-item" ID="devPage" runat="server">
            <asp:HyperLink runat="server" class="nav-link" NavigateUrl="../DeveloperPage.aspx" Text="Developer Page">
                
                <svg aria-hidden="true" focusable="false" data-prefix="fad" data-icon="file-code" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 384 512" class="svg-inline--fa fa-file-code fa-w-12 fa-7x"><g class="fa-group"><path fill="currentColor" d="M384 128H272a16 16 0 0 1-16-16V0H24A23.94 23.94 0 0 0 0 23.88V488a23.94 23.94 0 0 0 23.88 24H360a23.94 23.94 0 0 0 24-23.88V128zM141.79 379.54l-19.58 20.84a5.41 5.41 0 0 1-7.64.24l-64.86-60.69a5.37 5.37 0 0 1-.24-7.6l.25-.25 64.86-60.7a5.42 5.42 0 0 1 7.64.24l19.58 20.85a5.4 5.4 0 0 1-.25 7.62l-.13.12L100.65 336l40.76 35.8a5.4 5.4 0 0 1 .49 7.62zm31.71 71.25l-27.45-8a5.38 5.38 0 0 1-3.67-6.67l61.49-211.24a5.38 5.38 0 0 1 6.68-3.64l27.45 8a5.4 5.4 0 0 1 3.63 6.67l-61.45 211.2a5.4 5.4 0 0 1-6.68 3.68zm161-111.12l-.25.25-64.86 60.69a5.42 5.42 0 0 1-7.64-.23l-19.58-20.84a5.37 5.37 0 0 1 .26-7.6l.13-.12L283.35 336l-40.76-35.8a5.4 5.4 0 0 1-.49-7.62l.11-.12 19.58-20.85a5.42 5.42 0 0 1 7.64-.24l64.86 60.7a5.36 5.36 0 0 1 .25 7.6z" class="fa-secondary"></path><path fill="currentColor" d="M377 105L279.1 7a24 24 0 0 0-17-7H256v112a16 16 0 0 0 16 16h112v-6.1a23.9 23.9 0 0 0-7-16.9zM141.41 371.8L100.65 336l40.76-35.8.13-.12a5.4 5.4 0 0 0 .25-7.62l-19.58-20.85a5.42 5.42 0 0 0-7.64-.24l-64.86 60.7-.25.25a5.37 5.37 0 0 0 .24 7.6l64.86 60.69a5.41 5.41 0 0 0 7.64-.24l19.58-20.84.11-.12a5.4 5.4 0 0 0-.48-7.61zm100.22-135.93a5.4 5.4 0 0 0-3.63-6.67l-27.45-8a5.38 5.38 0 0 0-6.68 3.64l-61.5 211.29a5.38 5.38 0 0 0 3.63 6.67l27.45 8a5.4 5.4 0 0 0 6.68-3.68l61.44-211.22zm92.66 96.2l-64.86-60.7a5.42 5.42 0 0 0-7.64.24l-19.58 20.85-.11.12a5.4 5.4 0 0 0 .49 7.62l40.76 35.8-40.76 35.8-.13.12a5.37 5.37 0 0 0-.26 7.6l19.58 20.84a5.42 5.42 0 0 0 7.64.23l64.86-60.69.25-.25a5.36 5.36 0 0 0-.25-7.6z" class="fa-primary"></path></g></svg><span class="link-text">Developer</span>
            </asp:HyperLink>
        </li>
        <li class="nav-item" ID="adminPage" runat="server">
            <asp:HyperLink runat="server" class="nav-link" NavigateUrl="../AdminPage.aspx" Text="Admin Page">
                
                <svg aria-hidden="true" focusable="false" data-prefix="fad" data-icon="user-shield" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 512" class="svg-inline--fa fa-user-shield fa-w-20 fa-7x"><g class="fa-group"><path fill="currentColor" d="M622.3 271.1l-115.2-45a31 31 0 0 0-22.2 0l-115.2 45c-10.7 4.2-17.7 14-17.7 24.9 0 111.6 68.7 188.8 132.9 213.9a31 31 0 0 0 22.2 0C558.4 489.9 640 420.5 640 296c0-10.9-7-20.7-17.7-24.9zM496 462.4V273.3l95.5 37.3c-5.6 87.1-60.9 135.4-95.5 151.8z" class="fa-secondary"></path><path fill="currentColor" d="M224 256A128 128 0 1 0 96 128a128 128 0 0 0 128 128zm96 40c0-2.5.8-4.8 1.1-7.2-2.5-.1-4.9-.8-7.5-.8h-16.7a174.08 174.08 0 0 1-145.8 0h-16.7A134.43 134.43 0 0 0 0 422.4V464a48 48 0 0 0 48 48h352a49.22 49.22 0 0 0 19.2-4c-54-42.9-99.2-116.7-99.2-212z" class="fa-primary"></path></g></svg><span class="link-text">Admin</span>
            </asp:HyperLink>
        </li>
    </ul>
</nav>
<nav class="sidebar">
    <div class="profile">
        <a href="../Profile.aspx" class="button profile_picture_container">
            <asp:Image runat="server" ID="ProfilePicture" CssClass="profile_picture" ImageUrl="../Images/UserProfiles/profile.png" alt="Profile Picture" />
            <asp:Label Text="0" ID="notifs" CssClass="notifications_count" runat="server" Visible="False" />
            </a>
        <asp:Label runat="server" Text="Guest" ID="ProfileName" class="side_name"></asp:Label>
        <div class="side_content">
            <asp:HyperLink Visible="False" Text="Login" NavigateUrl="../Login.aspx" ID="loginSide" CssClass="button" runat="server" />
            <asp:HyperLink Visible="False" Text="Register" NavigateUrl="../Register.aspx" ID="registerSide" CssClass="button" runat="server" />
            <asp:HyperLink Visible="False" Text="Settings" NavigateUrl="../UserSettings.aspx" ID="userSettingsSide" CssClass="button" runat="server" />
            
            <asp:HyperLink Visible="False" Text="Requests" NavigateUrl="../RequestsPage.aspx" ID="requestsSide" CssClass="button" runat="server" />
            <asp:HyperLink Visible="False" Text="Logout" NavigateUrl="../Logout.aspx" ID="logoutSide" CssClass="button" runat="server" />
            <span class="bold">Balance:</span>
            <asp:Label ID="balance" Text="$0.00" runat="server" />
        </div>
    </div>
</nav>
