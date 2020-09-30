using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using NavebsiteBL;

namespace Navebsite.Controls
{
    [Serializable]
    public class SearchTerms
    {
        public OrderBy OrderBy { get; set; } = OrderBy.PublishDate;
        public string SearchQuery { get; set; } = "";
        public double MaxPrice { get; set; } = double.MaxValue;
        public List<Genre> FilterGenres { get; set; } = Genre.AllGenres();

    }

    public partial class GameList : UserControl
    {
        public List<Game> Games { get; set; }
        public PagedDataSource pg;



        public SearchTerms Search
        {
            get
            {
                var o = ViewState["_search"];
                if (o == null)
                {
                    ViewState["_search"] = new SearchTerms();
                    return (SearchTerms) ViewState["_search"];
                }
                return (SearchTerms) o;
            }
            set
            {
                CurrentPage = 0;
                ViewState["_search"] = value;
                update();
            }
        }

        public int CurrentPage
        {
            get
            {
                // look for current page in ViewState
                var o = this.ViewState["_CurrentPage"];
                if (o == null)
                    return 0; // default page index of 0
                else
                    return (int)o;
            }

            set => ViewState["_CurrentPage"] = value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            update();
        }

        public void update()
        {
            var games = Games.Where(game => game.Price <= Search.MaxPrice);

            switch (Search.OrderBy)
            {
                case OrderBy.PublishDate:
                    games = games.OrderBy(game => game.PublishDate).ThenBy(g => g.Id);
                    break;
                case OrderBy.GameName:
                    games = games.OrderBy(game => game.GameName).ThenBy(g => g.Id);
                    break;
                case OrderBy.Price:
                    games = games.OrderBy(game => game.Price).ThenBy(g => g.Id);
                    break;
                default:
                    games = games.OrderBy(g => g.Id);
                    break;
            }

            games = games.Where(game => game.GameName.ToLower().Contains(Search.SearchQuery.ToLower()));
            games = games.Where(game => game.Genres.Any(genre => Search.FilterGenres.Any(g => genre.Id == g.Id)));

            pg = new PagedDataSource { DataSource = games.ToList()
                , AllowPaging = true, PageSize = 12, CurrentPageIndex = CurrentPage };


            ItemsList.DataSource = pg;
            ItemsList.DataBind();

            prevButton.Visible = !pg.IsFirstPage;
            nextButton.Visible = !pg.IsLastPage;
        }

        protected void prevButton_OnClick(object sender, EventArgs e)
        {
            if (pg.IsFirstPage) return;
            CurrentPage--;
            update();
        }

        protected void nextButton_OnClick(object sender, EventArgs e)
        {
            if (pg.IsLastPage) return;
            CurrentPage++;
            update();
        }
    }
}