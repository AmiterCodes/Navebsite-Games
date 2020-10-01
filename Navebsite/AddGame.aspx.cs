using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NavebsiteBL;
using Navebsite;
using Navebsite.App_Code;

namespace Navebsite
{
    

    public partial class AddGame : Page
    {
        private static readonly string backgroundFormat = @"\Images\GameBackgrounds\";
        private static readonly string logoFormat = @"\Images\GameLogos\";

        protected void Page_Load(object sender, EventArgs e)
        {
            
            var user = (User) Session["user"];
            if (user == null) Response.Redirect("404");
            if (user != null && !user.IsDeveloper) Response.Redirect("404");
            if (!IsPostBack) LoadData();
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
            var set = (HashSet<Genre>) ViewState["GenreList"];
            Genres.Text = set.Count == 0
                ? "No Genres Selected"
                : string.Join(", ", set.Select(genre => genre.GenreName));
        }

        protected void button_Click(object sender, EventArgs e)
        {
            var user = (User) Session["user"];
            if (user == null)
            {
                Response.Redirect("404");
                return;
            }

            if (!user.IsDeveloper) Response.Redirect("404");
            Validate();
            if (!IsValid) return;

            var developer = user.DeveloperId;

            var bgPath = UploadHelper.ImageFileUpload(Background, backgroundFormat, "no.jpg", Server);
            var logoPath = UploadHelper.ImageFileUpload(Logo, logoFormat, "no.jpg", Server);

            var description = Description.Text;
            var version = Version.Text;
            var link = GameLink.Text;
            var gameName = GameName.Text;
            var price = double.Parse(Price.Text);

            var game = new Game(gameName, link, description, bgPath, logoPath, developer, price);

            foreach (var genre in (HashSet<Genre>) ViewState["GenreList"]) Genre.InsertGameGenre(genre, game.Id);

            var update = new Update(version, "Game Added", "'" + GameName + "' has been added to the store", game.Id);
            Response.Redirect("GamePage.aspx?id=" + game.Id);
        }

        protected void AddGenreToAll_Click(object sender, EventArgs e)
        {
            var genre = new Genre(newGenre.Text);
            LoadData();
        }

        protected void AddToCurrentGenres_Click(object sender, EventArgs e)
        {
            var genre = new Genre(int.Parse(GenreList.SelectedValue), GenreList.SelectedItem.Text);
            var genres = (HashSet<Genre>) ViewState["GenreList"];
            if (genres.All(g => g.GenreName != genre.GenreName))
            {
                genres.Add(genre);
                UpdateGenres();
            }
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            ViewState["GenreList"] = new HashSet<Genre>();
            UpdateGenres();
        }
    }
}