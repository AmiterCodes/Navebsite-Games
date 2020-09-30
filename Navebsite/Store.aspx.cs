using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Navebsite.Controls;
using NavebsiteBL;

namespace Navebsite
{
    public partial class Store : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                ViewState["Games"] = Game.StoreGames(OrderBy.PublishDate);
            };

            gm.Games = (List<Game>) ViewState["Games"];
        }
        

        protected void slider_OnTextChanged(object sender, EventArgs e)
        {
            int value = int.Parse(slider.Text);


            if (value == 150) return;


            text.Text = "$" + value;
            var terms = gm.Search;
            terms.MaxPrice = value;
            gm.Search = terms;
        }

        protected void sortBy_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Enum.TryParse(sortBy.SelectedValue, out OrderBy order)) return;
            var terms = gm.Search;
            terms.OrderBy = order;
            gm.Search = terms;
        }

        protected void SearchBox_OnTextChanged(object sender, EventArgs e)
        {
            var terms = gm.Search;
            terms.SearchQuery = SearchBox.Text;
            gm.Search = terms;
        }
    }
}