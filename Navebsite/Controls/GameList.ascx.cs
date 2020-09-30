using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using NavebsiteBL;

namespace Navebsite.Controls
{
    public partial class GameList : UserControl
    {
        public List<Game> Games { get; set; }
        public PagedDataSource pg;

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
            pg = new PagedDataSource { DataSource = Games, AllowPaging = true, PageSize = 12, CurrentPageIndex = CurrentPage };
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