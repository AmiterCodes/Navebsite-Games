using NavebsiteBL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;

namespace Navebsite
{
    public partial class AddGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = (User)Session["user"];
            if (user == null) Response.Redirect("404");
            if (user != null && !user.IsDeveloper) Response.Redirect("404");
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
            var set = (HashSet<Genre>)ViewState["GenreList"];
            if (set.Count == 0) Genres.Text = "No Genres Selected";
            else
            Genres.Text = String.Join(", ", set.Select(genre => genre.GenreName));
        }

        static string backgroundFormat = @"\Images\GameBackgrounds\";
        static string logoFormat = @"\Images\GameLogos\";

        protected string ImageFileUpload(FileUpload fileUpload, string path, string def)
        {
            string output;
            if (fileUpload.HasFile)
            {
                output = Server.MapPath("~/" +  path +
                    Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(Logo.FileName)));
                Logo.SaveAs(output);
            }
            else
            {
                output = Server.MapPath("~/" + path + def);
            }
            return output;
        }

        protected void button_Click(object sender, EventArgs e)
        {
            var user = (User)Session["user"];
            if (user == null)
            {
                Response.Redirect("404");
                return;
            }
            if (!user.IsDeveloper) Response.Redirect("404");
            
            var developer = user.DeveloperId;

            var bgPath = ImageFileUpload(Background, backgroundFormat, "no.jpg");
            var logoPath = ImageFileUpload(Logo, logoFormat, "no.jpg");

            string description = null;
            string version = null;
            string link = null;
            string gameName = null;
            double price = 0;
            var game = new Game(gameName, link, version, description, bgPath, logoPath, developer, price);
            
        }

        protected void AddGenreToAll_Click(object sender, EventArgs e)
        {
            var genre = new Genre(newGenre.Text);
            LoadData();
            
        }

        protected void AddToCurrentGenres_Click(object sender, EventArgs e)
        {
            var genre = new Genre(int.Parse(GenreList.SelectedValue), GenreList.SelectedItem.Text);
            var genres = (HashSet<Genre>)ViewState["GenreList"];
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