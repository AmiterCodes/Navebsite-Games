using NavebsiteBL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace Navebsite
{
    public partial class GameData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            chart.Height = 500;
            chart.Width = 800;
            chart.ForeColor = Color.White;
            Series series = chart.Series[0];
            series.ChartType = SeriesChartType.StackedArea;

            ChartArea a = chart.ChartAreas[0];
            chart.Style["background"] = "background: linear-gradient(180deg, #0F1016 0%, #1C1D2B 100%)";
            chart.DataSource = UserGame.UserGameData();
            chart.DataBind();
        }
    }
}