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
                LoadData();
            }
            UpdateGenres();
        }

        public void LoadData()
        {
            GenreList.DataSource = Genre.AllGenres();
            GenreList.DataTextField = "GenreName";
            GenreList.DataValueField = "ID";
            GenreList.DataBind();
            ViewState["GenreList"] = new HashSet<Genre>();
        }

        protected void UpdateGenres()
        {
            HashSet<Genre> set = (HashSet<Genre>)ViewState["GenreList"];
            if (set.Count == 0) Genres.Text = "No Genres Selected";
            else
            Genres.Text = String.Join(", ", set.Select(genre => genre.GenreName));
        }

        protected void button_Click(object sender, EventArgs e)
        {

        }

        protected void AddGenreToAll_Click(object sender, EventArgs e)
        {
            Genre genre = new Genre(newGenre.Text);
            HashSet<Genre> genres = (HashSet<Genre>)ViewState["GenreList"];
            genres.Add(genre);

            UpdateGenres();
            
        }

        protected void AddToCurrentGenres_Click(object sender, EventArgs e)
        {
            Genre genre = new Genre(int.Parse(GenreList.SelectedValue), GenreList.SelectedItem.Text);
            HashSet<Genre> genres = (HashSet<Genre>)ViewState["GenreList"];
            genres.Add(genre);
            UpdateGenres();
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            ViewState["GenreList"] = new HashSet<Genre>();
            UpdateGenres();
        }
    }
}