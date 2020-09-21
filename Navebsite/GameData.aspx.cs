using NavebsiteBL;
using System;

namespace Navebsite
{
    public partial class GameData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            sales.Sales = Sales.AllStats();
        }
    }
}