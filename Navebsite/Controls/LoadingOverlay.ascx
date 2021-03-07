﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoadingOverlay.ascx.cs" Inherits="Navebsite.Controls.LoadingOverlay" %>


<div class="overlay">

    <div class='tetrominos'>
        <div class='tetromino box1'></div>
        <div class='tetromino box2'></div>
        <div class='tetromino box3'></div>
        <div class='tetromino box4'></div>
    </div>
</div>
<style>
    .overlay{
        cursor: progress;
        width: 100vw;
        z-index: 100000;
        top: 0;
        left: 0;
        height: 100vh;
        position: fixed;
        background-color: rgba(0,0,0,.5);
			}
			
    .tetrominos {
        position: absolute;
        top: 50%;
        left: 50%;
        transform: translate(-112px, -96px);
    }

    .tetromino {
        width: 96px;
        height: 112px;
        position: absolute;
        transition: all ease .3s;
        background: url('data:image/svg+xml;utf-8,%3Csvg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 612 684"%3E%3Cpath fill="%23010101" d="M305.7 0L0 170.9v342.3L305.7 684 612 513.2V170.9L305.7 0z"/%3E%3Cpath fill="%23fff" d="M305.7 80.1l-233.6 131 233.6 131 234.2-131-234.2-131"/%3E%3C/svg%3E') no-repeat top center;
    }

    .box1 {
        animation: tetromino1 1.5s ease-out infinite;
    }

    .box2 {
        animation: tetromino2 1.5s ease-out infinite;
    }

    .box3 {
        animation: tetromino3 1.5s ease-out infinite;
        z-index: 2;
    }

    .box4 {
        animation: tetromino4 1.5s ease-out infinite;
    }

    @keyframes tetromino1 {
        0%, 40% {
            /* compose logo */
            /* 1 on 3 */
            /* L-shape */
            transform: translate(0, 0);
        }

        50% {
            /* pre-box */
            transform: translate(48px, -27px);
        }

        60%, 100% {
            /* box */
            /* compose logo */
            transform: translate(96px, 0);
        }
    }

    @keyframes tetromino2 {
        0%, 20% {
            /* compose logo */
            /* 1 on 3 */
            transform: translate(96px, 0px);
        }

        40%, 100% {
            /* L-shape */
            /* box */
            /* compose logo */
            transform: translate(144px, 27px);
        }
    }

    @keyframes tetromino3 {
        0% {
            /* compose logo */
            transform: translate(144px, 27px);
        }

        20%, 60% {
            /* 1 on 3 */
            /* L-shape */
            /* box */
            transform: translate(96px, 54px);
        }

        90%, 100% {
            /* compose logo */
            transform: translate(48px, 27px);
        }
    }

    @keyframes tetromino4 {
        0%, 60% {
            /* compose logo */
            /* 1 on 3 */
            /* L-shape */
            /* box */
            transform: translate(48px, 27px);
        }

        90%, 100% {
            /* compose logo */
            transform: translate(0, 0);
        }
    }
</style>
