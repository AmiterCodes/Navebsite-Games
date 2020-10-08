using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using NavebsiteBL;

namespace Navebsite.Controls
{
    public partial class SalesChart : UserControl
    {
        public List<Sales> Sales { get; set; }

        protected void Page_Load(object sender, EventArgs ev)
        {
            var starting = DateTime.Now.Date.AddDays(-30);
            var ending = DateTime.Now.Date;

            chart.Height = 500;
            chart.Width = 800;
            chart.ForeColor = Color.White;
            var series1 = chart.Series[0];
            series1.ChartType = SeriesChartType.SplineArea;
            var series2 = chart.Series[1];
            series2.ChartType = SeriesChartType.SplineArea;
            var a = chart.ChartAreas[0];
            chart.Style["background"] = "linear-gradient(180deg, #0F1016 0%, #1C1D2B 100%)";
            a.BackImageTransparentColor = Color.Transparent;
            var b = chart.ChartAreas[1];
            b.BackImageTransparentColor = Color.Transparent;


            var tb = new DataTable();

            tb.Columns.Add("Timestamp", typeof(DateTime));
            tb.Columns.Add("Purchases", typeof(int));
            tb.Columns.Add("Revenue", typeof(double));

            IEnumerator<Sales> e = Sales.GetEnumerator();
            e.Reset();
            e.MoveNext();
            for (var day = starting; day < ending; day = day.AddDays(1))
            {
                var row = tb.NewRow();
                row["Timestamp"] = day;

                if (e.Current != null && e.Current.Date.Equals(day))
                {
                    var s = e.Current;
                    row["Purchases"] = s.Purchases;
                    row["Revenue"] = s.Revenue;
                    e.MoveNext();
                }
                else
                {
                    row["Purchases"] = 0;
                    row["Revenue"] = 0;
                }

                tb.Rows.Add(row);
            }

            e.Dispose();

            chart.DataSource = tb;
            chart.DataBind();
        }
    }
}