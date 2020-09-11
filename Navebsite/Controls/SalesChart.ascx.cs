using NavebsiteBL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace Navebsite.Controls
{
    public partial class SalesChart : System.Web.UI.UserControl
    {
        public List<Sales> Sales { get; set; }
        protected void Page_Load(object sender, EventArgs ev)
        {

            DateTime starting = DateTime.Now.Date.AddDays(-30);
            DateTime ending = DateTime.Now.Date;
            
            chart.Height = 500;
            chart.Width = 800;
            chart.ForeColor = Color.White;
            Series series1 = chart.Series[0];
            series1.ChartType = SeriesChartType.StepLine;
            Series series2 = chart.Series[1];
            series2.ChartType = SeriesChartType.StepLine;
            ChartArea a = chart.ChartAreas[0];
            chart.Style["background"] = "background: linear-gradient(180deg, #0F1016 0%, #1C1D2B 100%)";
            a.BackColor = Color.Transparent;
            ChartArea b = chart.ChartAreas[1];
            b.BackColor = Color.Transparent;

            DataTable tb = new DataTable();

            tb.Columns.Add("Timestamp", typeof(DateTime));
            tb.Columns.Add("Purchases", typeof(int));
            tb.Columns.Add("Revenue", typeof(double));

            IEnumerator<Sales> e = Sales.GetEnumerator();
            e.Reset();
            e.MoveNext();
            for (DateTime day = starting; day < ending; day = day.AddDays(1))
            {
                DataRow row = tb.NewRow();
                row["Timestamp"] = day;

                if (e.Current != null && e.Current.Date.Equals(day)) {
                    Sales s = e.Current;
                    row["Purchases"] = s.Purchases;
                    row["Revenue"] = s.Revenue;
                    e.MoveNext();
                } else
                {
                    row["Purchases"] = 0;
                    row["Revenue"] = 0;
                }

                tb.Rows.Add(row);
            }
            
            chart.DataSource = tb;
            chart.DataBind();
        }
    }
}