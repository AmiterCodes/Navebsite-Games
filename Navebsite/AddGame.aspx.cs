using NavebsiteBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Navebsite
{
    public partial class AddGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenreList.DataSource = Genre.AllGenres();
                GenreList.DataTextField = "GenreName";
                GenreList.DataValueField = "ID";
                GenreList.DataBind();
                ViewState["GenreList"] = new List<Genre>();
            }
            Genres.Text = String.Join(", ",((List<Genre>)ViewState["GenreList"]).Select(genre => genre.GenreName));
        }



        protected void button_Click(object sender, EventArgs e)
        {

        }

        protected void AddGenreToAll_Click(object sender, EventArgs e)
        {
            Genre genre = new Genre(newGenre.Text);
            List<Genre> genres = (List<Genre>)ViewState["GenreList"];
            genres.Add(genre);
        }

        protected void AddToCurrentGenres_Click(object sender, EventArgs e)
        {
            Genre genre = new Genre(int.Parse(GenreList.SelectedValue), GenreList.SelectedItem.Text);
            List<Genre> genres = (List<Genre>)ViewState["GenreList"];
            genres.Add(genre);
        }
    }
}