using System;
using System.Web.UI;
using NavebsiteBL;

namespace Navebsite
{
    public partial class GameData : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            sales.Sales = Sales.AllStats();
        }
    }
}