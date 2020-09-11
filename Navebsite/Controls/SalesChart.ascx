<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SalesChart.ascx.cs" Inherits="Navebsite.Controls.SalesChart" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Chart runat="server" ID="chart">
        <series>
            <asp:Series Name="Series1" XValueMember="Timestamp" YValueMembers="Revenue" ChartArea="ChartArea1"></asp:Series>
            <asp:Series Name="Series2" XValueMember="Timestamp" YValueMembers="Purchases" ChartArea="ChartArea2"></asp:Series>
        </series>
        <chartareas><asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            <asp:ChartArea Name="ChartArea2"></asp:ChartArea>
        </chartareas>
    </asp:Chart>
