﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="True" CodeBehind="AdminPage.aspx.cs" Inherits="Navebsite.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">
    
    <NV:SalesChart ID="sales" runat="server"/>
    <NV:GameViewList runat="server" ID="gameList"/>
<asp:GridView runat="server" ID="TransactionHistory"></asp:GridView>
<div class="centering">
    Balance:
    <asp:Label Text="$23" CssClass="balance" runat="server" />
    
</div>
<asp:Panel class="centering" runat="server">
<h3 class="header">Credit Cards</h3>
<asp:Repeater runat="server" ID="CreditCardRepeater" OnItemDataBound="CreditCardRepeater_OnItemDataBound">
<ItemTemplate>
<div class="tuple">
<div class="Wrap">
<div class="Base">
<div class="Inner-wrap">


<!--       Header SVG -->


<svg class="Logo-name"
     xmlns:svg="http://www.w3.org/2000/svg"
     xmlns="http://www.w3.org/2000/svg"
     version="1.0"
     width="298.72266"
     height="55.51717">
    <defs
        id="defs17040"/>
    <g
        transform="translate(620.34041,-56.426733)"
        id="layer1">
        <g
            transform="translate(0.4494891,0.3945659)"
            id="logotype">
            <g
                id="g17202">
                <g
                    id="logo">
                    <path
                        d="M -358.86107,56.307005 C -359.93357,56.307005 -360.80231,57.175763 -360.80231,58.247007 L -360.80231,71.85327 L -324.86107,71.85327 L -341.22857,56.308263 L -358.86107,56.307005"
                        style="fill: #fff; fill-rule: nonzero; stroke: none"
                        id="logo-ne"/>
                    <path
                        d="M -323.54607,75.969518 C -323.54607,74.895757 -324.40857,74.030756 -325.48731,74.030756 L -339.08982,74.030756 L -339.08982,109.97325 L -323.55233,93.598265 L -323.54607,75.969518"
                        style="fill: #fff; fill-rule: nonzero; stroke: none"
                        id="logo-se"/>
                    <path
                        d="M -343.21106,111.2745 C -342.14106,111.2745 -341.27232,110.4045 -341.27232,109.33076 L -341.27232,95.729517 L -377.21482,95.729517 L -360.84483,111.272 L -343.21106,111.2745"
                        style="fill: #fff; fill-rule: nonzero; stroke: none"
                        id="logo-sw"/>
                    <path
                        d="M -378.52856,91.614507 C -378.52856,92.68701 -377.65982,93.560766 -376.58482,93.560766 L -362.98482,93.560766 L -362.98482,57.61577 L -378.52606,73.985761 L -378.52856,91.614507"
                        style="fill: #fff; fill-rule: nonzero; stroke: none"
                        id="logo-nw"/>
                </g>
                <g
                    id="type">
                    <path
                        d="M -543.26981,62.868265 L -543.26981,79.467005 L -566.39481,79.467005 L -566.39481,62.868265 L -574.81732,62.86077 L -574.81732,104.71326 L -566.39481,104.71326 L -566.39481,86.73326 L -543.26981,86.73326 L -543.26981,104.71326 L -534.83357,104.71326 L -534.83357,62.868265 L -543.26981,62.868265"
                        style="opacity: 1; fill: #fff; fill-stroke: none"
                        id="H"/>
                    <path
                        d="M -431.22357,62.868265 L -431.22357,104.70327 L -394.27231,104.70327 L -398.95232,97.33827 L -422.77731,97.33827 L -422.77731,86.73326 L -399.70732,86.73326 L -399.70732,79.639505 L -422.77731,79.639505 L -422.77731,70.060762 L -398.99231,70.060762 L -394.40732,62.868265 L -431.22357,62.868265"
                        style="opacity: 1; fill: #fff; fill-rule: nonzero; stroke: none"
                        id="E"/>
                    <path
                        d="M -606.12483,62.858251 C -614.88606,62.858251 -619.31107,68.184503 -619.31107,75.934518 L -619.31107,91.55702 C -619.31107,100.52575 -613.60858,104.71326 -606.16856,104.71326 L -579.74356,104.71076 L -584.64232,97.06077 L -604.53606,97.06077 C -608.76233,97.06077 -610.60357,95.53327 -610.60357,90.803255 L -610.60357,76.629518 C -610.60357,72.057012 -609.05356,70.27326 -604.42357,70.27326 L -584.43482,70.27326 L -579.73107,62.858251 L -606.12483,62.858251"
                        style="opacity: 1; fill: #fff; fill-rule: nonzero; stroke: none"
                        id="C"/>
                    <path
                        d="M -468.18356,62.848257 C -473.24357,62.848257 -478.42982,65.889505 -478.42982,73.712018 L -478.42982,75.722002 C -478.42982,83.877005 -473.43981,86.988252 -468.44731,87.00952 L -450.92356,87.00952 C -449.10357,87.00952 -447.62482,87.312006 -447.62482,90.388255 L -447.62732,93.942007 C -447.67357,96.705755 -449.05232,97.33827 -450.98607,97.33827 L -474.03983,97.33827 L -478.76233,104.70327 L -450.44356,104.70327 C -443.61481,104.70327 -438.97856,101.30576 -438.97856,93.458265 L -438.97856,90.574507 C -438.97856,82.987017 -443.28606,79.402002 -449.96481,79.402002 L -466.69732,79.402002 C -468.55233,79.402002 -469.84482,78.895753 -469.84482,76.148256 L -469.84482,73.254503 C -469.84482,70.914511 -468.95857,70.060762 -466.79732,70.060762 L -444.84232,70.052007 L -440.25357,62.838262 L -468.18356,62.848257"
                        style="opacity: 1; fill: #fff; fill-rule: nonzero; stroke: none"
                        id="S"/>
                    <path
                        d="M -510.36356,62.868265 L -530.20731,104.71076 L -520.82858,104.71076 L -516.96356,96.069502 L -495.39982,96.069502 L -491.54732,104.71076 L -482.12731,104.71076 L -502.01731,62.868265 L -510.36356,62.868265 z M -506.20232,71.555761 L -498.57731,88.947005 L -513.77858,88.947005 L -506.20232,71.555761"
                        style="opacity: 1; fill: #fff; fill-rule: nonzero; stroke: none"
                        id="A"/>
                </g>
            </g>
        </g>
    </g>
</svg>



<!--       Logo SVG -->


<svg class="Logo" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px"
     viewBox="0 0 97.814 97.063" style="enable-background: new 0 0 97.814 97.063;" xml:space="preserve">
    <g id="The_x5F_Chase_x5F_Manhattan_x5F_Bank">
        <path class="Logo" style="fill-rule: evenodd; clip-rule: evenodd;" d="M31.534,0.148c11.888,0.129,20.426,0,32.226,0c1.625,0,3.551-0.332,4.912,0
		c1.078,0.264,2.74,2.468,3.714,3.475C80.6,12.116,89.026,20.218,97.064,28.66c-21.246-0.112-47.055,0.218-65.77-0.12
		c-0.103-8.506-0.225-18.47,0-28.033C31.289,0.302,31.384,0.196,31.534,0.148z"/>
        <path class="Logo" style="fill-rule: evenodd; clip-rule: evenodd;" d="M28.778,66.037c-8.482-0.125-19.476,0.192-28.392-0.119
		c-0.203-8.306-0.12-18.252-0.12-27.674c0-2.727-0.6-6.873,0-9.345c0.19-0.783,2.35-2.674,3.355-3.714
		c8.015-8.298,17.314-16.974,25.038-24.798c0.102-0.023,0.112,0.046,0.119,0.119C28.671,24.725,29.012,43.838,28.778,66.037z"/>
        <path class="Logo" style="fill-rule: evenodd; clip-rule: evenodd;" d="M69.39,30.937c9.529,0.098,18.895-0.152,28.033,0.119
		c0.106,9.001,0.204,17.434,0.12,27.314c-0.022,2.579,0.62,6.92,0,9.584c-0.274,1.178-2.454,2.654-3.475,3.714
		c-8.182,8.494-16.734,16.807-24.918,24.679c-0.192-18.602-0.095-42.894-0.12-65.051C69.098,31.123,69.218,31.003,69.39,30.937z"/>
        <path class="Logo" style="fill-rule: evenodd; clip-rule: evenodd;" d="M66.515,68.193c0.309,9.83,0.309,19.073,0,28.513
		c-10.081,0.189-19.016-0.092-28.272,0.12c-2.423,0.055-6.684,0.57-9.105-0.12c-0.847-0.241-2.667-2.308-3.713-3.354
		c-8.051-8.05-16.983-16.943-24.56-24.679c-0.079-0.081-0.112-0.206-0.119-0.359c0.097-0.023,0.119-0.12,0.239-0.12
		C23.242,68.233,44.12,68.237,66.515,68.193z"/>
    </g>
    <g>
    </g>
</svg>




<!-- Card Chip SVG -->

<svg class="Chip" version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px"
     viewBox="0 0 387.8 380.3" style="enable-background: new 0 0 387.8 380.3;" xml:space="preserve">
    <style type="text/css">
        .st0 {fill: url(#gold-gradient);stroke: #000000;stroke-width: 10;stroke-miterlimit: 10;}
    </style>
    <defs>
        <linearGradient id="gold-gradient" x1="0%" y1="0%" x2="100%" y2="0%">
            <stop offset="0%" stop-color="#c79750"></stop>
            <stop offset="20%" stop-color="#e6b964"></stop>
            <stop offset="50%" stop-color=" #f8e889"></stop>
            <stop offset="80%" stop-color=" #deb15f"></stop>
            <stop offset="100%" stop-color=" #dfb461"></stop>
        </linearGradient>
    </defs>
    <g id="XMLID_4_">
        <path id="XMLID_1_" class="st0" d="M308.8,375.3H79.1C38.2,375.3,5,342.1,5,301.2V79.1C5,38.2,38.2,5,79.1,5h229.7
		c40.9,0,74.1,33.2,74.1,74.1v222.2C382.8,342.1,349.7,375.3,308.8,375.3z"/>
        <line id="XMLID_2_" class="st0" x1="109.9" y1="5.1" x2="109.9" y2="375.1"/>
        <line id="XMLID_3_" class="st0" x1="4.9" y1="95.1" x2="109.9" y2="95.1"/>
        <line id="XMLID_7_" class="st0" x1="4.9" y1="185.1" x2="109.9" y2="185.1"/>
        <line id="XMLID_8_" class="st0" x1="1.9" y1="275.1" x2="106.9" y2="275.1"/>
        <line id="XMLID_9_" class="st0" x1="276.9" y1="275.1" x2="381.9" y2="275.1"/>
        <line id="XMLID_10_" class="st0" x1="274.9" y1="185.1" x2="379.9" y2="185.1"/>
        <line id="XMLID_11_" class="st0" x1="277.9" y1="95.1" x2="382.9" y2="95.1"/>
        <g id="XMLID_6_">
            <g id="XMLID_14_">
                <g id="XMLID_32_">
                    <path id="XMLID_33_" d="M277.4,90.1h-1c-2.5,0-4.5,2-4.5,4.5v272c0,2.5,2,4.5,4.5,4.5h1c2.5,0,4.5-2,4.5-4.5v-272
					C281.9,92.1,279.9,90.1,277.4,90.1z"/>
                </g>
            </g>
        </g>
    </g>
</svg>
<div class="Card-number">
    <asp:Label ID="svgnumber" runat="server"/>
</div>

<div class='Expire'>
    <h4>Good Thru</h4>
    <asp:Label ID="svgexpire" runat="server"/>
</div>

<div class='Name'>
    <asp:Label runat="server" ID="svgname"></asp:Label>
</div>

<!--       Visa Logo SVG -->

<svg
    xmlns:dc="http://purl.org/dc/elements/1.1/"
    xmlns:cc="http://creativecommons.org/ns#"
    xmlns:rdf="http://www.w3.org/1999/02/22-rdf-syntax-ns#"
    xmlns:svg="http://www.w3.org/2000/svg"
    xmlns="http://www.w3.org/2000/svg"
    xmlns:sodipodi="http://sodipodi.sourceforge.net/DTD/sodipodi-0.dtd"
    xmlns:inkscape="http://www.inkscape.org/namespaces/inkscape"
    version="1.1"
    id="Layer_1"
    x="0px"
    y="0px"
    class="Visa"
    width="1000.046"
    height="323.65302"
    viewBox="0 0 1000.046 323.653"
    enable-background="new 0 0 258.381 161.154"
    xml:space="preserve"
    inkscape:version="0.91 r13725"
    sodipodi:docname="Visa_2006.svg">
    <metadata
        id="metadata23">
        <rdf:RDF>
            <cc:Work
                rdf:about=""><dc:format>image/svg+xml</dc:format>
                <dc:type
                    rdf:resource="http://purl.org/dc/dcmitype/StillImage"/><dc:title></dc:title></cc:Work></rdf:RDF></metadata>
    <defs
        id="defs21">

    </defs>
    <sodipodi:namedview
        pagecolor="#ffffff"
        bordercolor="#666666"
        borderopacity="1"
        objecttolerance="10"
        gridtolerance="10"
        guidetolerance="10"
        inkscape:pageopacity="0"
        inkscape:pageshadow="2"
        inkscape:window-width="1366"
        inkscape:window-height="705"
        id="namedview19"
        showgrid="false"
        inkscape:zoom="0.35355339"
        inkscape:cx="34.690897"
        inkscape:cy="131.15483"
        inkscape:window-x="-8"
        inkscape:window-y="-8"
        inkscape:window-maximized="1"
        inkscape:current-layer="Layer_1"/>
    <g
        id="g4158"
        transform="matrix(4.4299631,0,0,4.4299631,-81.165783,-105.04783)">
        <polygon
            points="116.145,95.719 97.858,95.719 109.296,24.995 127.582,24.995 "
            id="polygon9"
            style="fill: #f2f2f2"/>
        <path
            d="m 182.437,26.724 c -3.607,-1.431 -9.328,-3.011 -16.402,-3.011 -18.059,0 -30.776,9.63 -30.854,23.398 -0.15,10.158 9.105,15.8 16.027,19.187 7.075,3.461 9.48,5.72 9.48,8.805 -0.072,4.738 -5.717,6.922 -10.982,6.922 -7.301,0 -11.213,-1.126 -17.158,-3.762 l -2.408,-1.13 -2.559,15.876 c 4.289,1.954 12.191,3.688 20.395,3.764 19.188,0 31.68,-9.481 31.828,-24.153 0.073,-8.051 -4.814,-14.22 -15.35,-19.261 -6.396,-3.236 -10.313,-5.418 -10.313,-8.729 0.075,-3.01 3.313,-6.093 10.533,-6.093 5.945,-0.151 10.313,1.278 13.622,2.708 l 1.654,0.751 2.487,-15.272 0,0 z"
            id="path11"
            inkscape:connector-curvature="0"
            style="fill: #fff"/>
        <path
            d="m 206.742,70.664 c 1.506,-4.063 7.301,-19.788 7.301,-19.788 -0.076,0.151 1.503,-4.138 2.406,-6.771 l 1.278,6.094 c 0,0 3.463,16.929 4.215,20.465 -2.858,0 -11.588,0 -15.2,0 l 0,0 z m 22.573,-45.669 -14.145,0 c -4.362,0 -7.676,1.278 -9.558,5.868 l -27.163,64.855 19.188,0 c 0,0 3.159,-8.729 3.838,-10.609 2.105,0 20.771,0 23.479,0 0.525,2.483 2.182,10.609 2.182,10.609 l 16.932,0 -14.753,-70.723 0,0 z"
            id="path13"
            inkscape:connector-curvature="0"
            style="fill: #fff"/>
        <path
            d="M 82.584,24.995 64.675,73.222 62.718,63.441 C 59.407,52.155 49.023,39.893 37.435,33.796 l 16.404,61.848 19.338,0 28.744,-70.649 -19.337,0 0,0 z"
            id="path15"
            inkscape:connector-curvature="0"
            style="fill: #fff"/>
        <path
            d="m 48.045,24.995 -29.422,0 -0.301,1.429 c 22.951,5.869 38.151,20.016 44.396,37.02 L 56.322,30.94 c -1.053,-4.517 -4.289,-5.796 -8.277,-5.945 l 0,0 z"
            id="path17"
            inkscape:connector-curvature="0"
            style="fill: #fff"/></g>
</svg>

</div>
</div>
</div>
<div>
    CVV: <asp:Label ID="svgsecurity" runat="server"/>
</div>
</div>
</ItemTemplate>
</asp:Repeater>
<asp:Button Text="Get new Visa Card" ID="AddCard" runat="server" OnClick="OnClick" CssClass="button"/>
</asp:Panel>


<script defer>

    function openPage(name, element) {
        let list = document.getElementById('list');
        let settingsPages = document.getElementById('settings_list');

        [...list.children].forEach(child => child.classList.remove('selected'));
        element.classList.add('selected');

        [...settingsPages.children].forEach(child => child.hidden = true);
        let elem = document.getElementById(name);

        elem.hidden = false;

    }

    openPage('balance', list.children[0]);

</script>
</asp:Content>
