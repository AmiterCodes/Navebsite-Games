<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SalesChart.ascx.cs" Inherits="Navebsite.Controls.SalesChart" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Chart runat="server" ID="chartRevenue">
        <series>
            <asp:Series Name="Series1" XValueMember="Timestamp" YValueMembers="Revenue" ChartArea="ChartArea1"></asp:Series>
        </series>
    <chartareas><asp:ChartArea Name="ChartArea1"></asp:ChartArea>
    </chartareas>

</asp:Chart>
<asp:Chart runat="server" ID="chartPurchases">
    <series>
        <asp:Series Name="Series1" XValueMember="Timestamp" YValueMembers="Purchases" ChartArea="ChartArea1"></asp:Series>
    </series>
    <chartareas><asp:ChartArea Name="ChartArea1"></asp:ChartArea>
    </chartareas>
    
</asp:Chart>
<script defer>
    console.log('<%=Sales %>');
</script>
