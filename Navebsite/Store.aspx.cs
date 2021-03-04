using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
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

                GenreChecks.DataSource = Genre.AllGenres();
                GenreChecks.DataTextField = "GenreName";
                GenreChecks.DataValueField = "Id";
                GenreChecks.DataBind();
                foreach (ListItem genreChecksItem in GenreChecks.Items)
                {
                    genreChecksItem.Selected = true;
                }
            };

            gm.Games = (List<Game>) Application["StoreGames"];
        }

        public struct GameDto
        {
            public string GameName { get; set; }
            public string IconUrl { get; set; }

            public int Id { get; set; }
        }


        [WebMethod]
        public static List<GameDto> AutoComplete(string current)
        {
            if(current == "") return new List<GameDto>();
            List<string> terms = new List<string>();
            var games = (List<Game>) HttpContext.Current.Application["StoreGames"];

            return games
                .Where(game => game.GameName.ToLower().Contains(current.ToLower()))
                .Take(10)
                .Select(game => new GameDto() { GameName = game.GameName, IconUrl = game.LogoUrl, Id = game.Id })
                .ToList();
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

        protected void GenreChecks_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var terms = gm.Search;
            terms.FilterGenres = (from ListItem item in GenreChecks.Items where item.Selected select new Genre(int.Parse(item.Value), item.Text)).ToList();
            gm.Search = terms;
        }
    }
}