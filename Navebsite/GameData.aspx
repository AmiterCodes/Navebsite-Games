<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="true" CodeBehind="GameData.aspx.cs" Inherits="Navebsite.GameData" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">
<asp:Chart runat="server" ID="chart">
        <series><asp:Series Name="Series1" XValueMember="Timestamp" YValueMembers="Cost"></asp:Series></series>
        <chartareas><asp:ChartArea Name="ChartArea1"></asp:ChartArea></chartareas>
    </asp:Chart>
    
</asp:Content>
