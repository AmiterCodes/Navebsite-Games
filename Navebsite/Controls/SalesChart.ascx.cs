using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.HtmlControls;
using NavebsiteBL;

namespace Navebsite.Controls
{
    public partial class SalesChart : UserControl
    {
        public List<Sales> Sales { get; set; }

        [WebMethod(EnableSession=true)]
        public static List<Sales> GetSales()
        {
            return (List<Sales>) HttpContext.Current.Session["updatedSales"];
        }

        protected void Page_Load(object sender, EventArgs ev)
        {
            var starting = DateTime.Now.Date.AddDays(-30);
            var ending = DateTime.Now.Date;


            var tb = new DataTable();

            tb.Columns.Add("Timestamp", typeof(DateTime));
            tb.Columns.Add("Purchases", typeof(int));
            tb.Columns.Add("Revenue", typeof(double));

            List<Sales> updatedSales = new List<Sales>();
            IEnumerator<Sales> e = Sales.GetEnumerator();
            e.Reset();
            e.MoveNext();
            while (e.Current != null && e.Current.Date < starting)
            {
                e.MoveNext();
            }
            for (var day = starting; day <= ending; day = day.AddDays(1))
            {
                var row = tb.NewRow();
                row["Timestamp"] = day;

                Sales sale = new Sales();
                sale.Date = day;

                if (e.Current != null && e.Current.Date.Equals(day))
                {
                    var s = e.Current;
                    sale = s;
                    e.MoveNext();
                }
                else
                {
                    sale.Purchases = 0;
                    sale.Revenue = 0;
                }

                row["Purchases"] = sale.Purchases;
                row["Revenue"] = sale.Revenue;


                tb.Rows.Add(row);
                updatedSales.Add(sale);
            }

            Session["updatedSales"] = updatedSales;

            e.Dispose();

            chartRevenue.DataSource = tb;
            chartPurchases.DataSource = tb;
            chartRevenue.DataBind();
            chartPurchases.DataBind();

            StyleChart(chartPurchases);
            StyleChart(chartRevenue);


        }

        private static void StyleChart(Chart chart)
        {
            chart.Height = 500;
            chart.Width = 800;
            chart.ForeColor = Color.White;
            var series1 = chart.Series[0];
            series1.ChartType = SeriesChartType.Bar;
            var a = chart.ChartAreas[0];
            a.BackImageTransparentColor = Color.Transparent;

            a.AxisX.LabelStyle.Format = "MM-dd-yy";
        }
    }
}