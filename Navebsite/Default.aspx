<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Navebsite.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">
    <main class="home">
        <section class="navebsite">
            <div class="navebsite_title">
                <span class="navebsite_logo">
                    <svg xmlns="http://www.w3.org/2000/svg" width="90" height="105" viewBox="0 0 90 105" fill="none">
                        <path fill-rule="evenodd" clip-rule="evenodd" d="M85.48 30.8491C80.4435 36.7752 73.5199 40.434 65.8785 40.434C50.4789 40.434 37.995 25.5744 37.995 7.24419C37.995 4.75602 38.2251 2.33179 38.6612 0C16.8346 3.43484 0 25.4322 0 52.0564C0 81.0638 19.9833 104.579 44.634 104.579C69.2847 104.579 89.268 81.0638 89.268 52.0564C89.268 44.5098 87.9154 37.3349 85.48 30.8491ZM72.5175 62.7839C72.5175 67.2276 69.4994 70.8299 65.7764 70.8299C62.0534 70.8299 59.0353 67.2276 59.0353 62.7839C59.0353 58.3402 62.0534 54.7379 65.7764 54.7379C69.4994 54.7379 72.5175 58.3402 72.5175 62.7839Z" fill="white"/>
                    </svg>
                </span>
                <span class="navebsite_title_text"><svg class="anim_logo" xmlns="http://www.w3.org/2000/svg" width="824" height="124" viewBox="0 0 824 124" fill="none">
<path d="M95.3066 118H72.3086L27.5391 44.5596V118H4.54102V6.38281H27.5391L72.3853 79.9766V6.38281H95.3066V118Z" stroke="white" stroke-width="8" mask="url(#path-1-outside-1)"/>
<path d="M179.786 95.002H139.463L131.797 118H107.342L148.892 6.38281H170.204L211.983 118H187.529L179.786 95.002ZM145.672 76.3735H173.577L159.548 34.5938L145.672 76.3735Z" stroke="white" stroke-width="8" mask="url(#path-1-outside-1)"/>
<path d="M257.673 90.3257L282.971 6.38281H308.575L269.708 118H245.714L207 6.38281H232.528L257.673 90.3257Z" stroke="white" stroke-width="8" mask="url(#path-1-outside-1)"/>
<path d="M386.309 69.6274H342.152V99.5249H393.975V118H319.154V6.38281H393.821V25.0112H342.152V51.6123H386.309V69.6274Z" stroke="white" stroke-width="8" mask="url(#path-1-outside-1)"/>
<path d="M407.467 118V6.38281H446.563C460.107 6.38281 470.379 8.98926 477.381 14.2021C484.382 19.3639 487.883 26.9533 487.883 36.9702C487.883 42.4386 486.478 47.2682 483.667 51.459C480.856 55.5986 476.946 58.6395 471.938 60.5815C477.662 62.0125 482.159 64.9001 485.43 69.2441C488.752 73.5882 490.413 78.9033 490.413 85.1895C490.413 95.9219 486.989 104.048 480.141 109.567C473.292 115.087 463.531 117.898 450.856 118H407.467ZM430.465 69.3975V99.5249H450.167C455.584 99.5249 459.8 98.2472 462.815 95.6919C465.882 93.0854 467.415 89.508 467.415 84.9595C467.415 74.7381 462.125 69.5508 451.546 69.3975H430.465ZM430.465 53.1455H447.483C459.085 52.9411 464.885 48.3159 464.885 39.27C464.885 34.2104 463.403 30.5819 460.439 28.3843C457.526 26.1356 452.901 25.0112 446.563 25.0112H430.465V53.1455Z" stroke="white" stroke-width="8" mask="url(#path-1-outside-1)"/>
<path d="M565.617 88.7158C565.617 84.3717 564.083 81.0498 561.017 78.75C557.951 76.3991 552.431 73.946 544.458 71.3906C536.486 68.7842 530.174 66.2288 525.523 63.7246C512.849 56.8763 506.512 47.6515 506.512 36.0503C506.512 30.0197 508.198 24.6535 511.571 19.9517C514.995 15.1987 519.876 11.4935 526.213 8.83594C532.602 6.17839 539.757 4.84961 547.678 4.84961C555.651 4.84961 562.755 6.30615 568.99 9.21924C575.225 12.0812 580.054 16.1442 583.479 21.4082C586.954 26.6722 588.691 32.6517 588.691 39.3467H565.693C565.693 34.236 564.083 30.2752 560.864 27.4644C557.644 24.6024 553.121 23.1714 547.295 23.1714C541.673 23.1714 537.304 24.3724 534.186 26.7744C531.069 29.1253 529.51 32.2428 529.51 36.127C529.51 39.7555 531.324 42.7964 534.953 45.2495C538.632 47.7026 544.024 50.0024 551.128 52.1489C564.211 56.0841 573.743 60.9648 579.722 66.791C585.702 72.6172 588.691 79.8743 588.691 88.5625C588.691 98.2217 585.037 105.811 577.729 111.331C570.421 116.799 560.583 119.533 548.215 119.533C539.629 119.533 531.81 117.974 524.757 114.857C517.704 111.688 512.312 107.37 508.582 101.901C504.902 96.4329 503.062 90.0957 503.062 82.8896H526.137C526.137 95.2064 533.496 101.365 548.215 101.365C553.683 101.365 557.951 100.266 561.017 98.0684C564.083 95.8197 565.617 92.7021 565.617 88.7158Z" stroke="white" stroke-width="8" mask="url(#path-1-outside-1)"/>
<path d="M628.785 118H605.787V6.38281H628.785V118Z" stroke="white" stroke-width="8" mask="url(#path-1-outside-1)"/>
<path d="M731.893 25.0112H697.702V118H674.704V25.0112H640.974V6.38281H731.893V25.0112Z" stroke="white" stroke-width="8" mask="url(#path-1-outside-1)"/>
<path d="M812.232 69.6274H768.076V99.5249H819.898V118H745.078V6.38281H819.745V25.0112H768.076V51.6123H812.232V69.6274Z" stroke="white" stroke-width="8" mask="url(#path-1-outside-1)"/>
</svg></span>
            </div>
            <div class="navebsite_subtitle"> GAME STORE</div>
            <a href="Store.aspx" class="navebsite_store">STORE</a>
        </section>
        <section class="home_2">
            <h1 class="big-title">Game Everywhere</h1>
            <div class="home_2_container">
                <div class="home_2_text">
                    login everywhere,
                    jump right in
                    to your favorite game
                </div>
                <div class="home_2_images">
                    <img src="./Images/GameBackgrounds/unnamed.png" alt="Alternate Text"/>
                    <img src="./Images/GameBackgrounds/3cd3fe5a0e2456f6a61784b1b76079a7e024a4bf.jpeg" alt="Alternate Text"/>
                    <img src="./Images/GameBackgrounds/terraria-cover.jpg" alt="Alternate Text"/>

                </div>
            </div>
        </section>
    </main>
</asp:Content>