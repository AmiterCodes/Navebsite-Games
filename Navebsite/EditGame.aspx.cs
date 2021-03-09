using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Navebsite.App_Code;
using NavebsiteBL;

namespace Navebsite
{
    public partial class EditGame : System.Web.UI.Page
    {

        private static readonly string backgroundFormat = @"\Images\GameBackgrounds\";
        private static readonly string logoFormat = @"\Images\GameLogos\";

        private Game game;


        protected void Page_Load(object sender, EventArgs e)
        {

            //user validation and game loading

            var user = (User)Session["user"];
            LoadGame();
            ValidateUser(user);


            // data loading

            if (!IsPostBack)
            {
                LoadGenreData();
                LoadData();
            }


            UpdateGenres();
        }

        private void ValidateUser(User user)
        {
            if (user == null) Response.Redirect("404");
            if (user.IsAdmin) return;
            if (user != null && !user.IsDeveloper) Response.Redirect("404");

            if (game.DeveloperId != user.DeveloperId) Response.Redirect("404");
        }

        private void LoadGame()
        {
            string gameIdString = Request.QueryString["game"];
            if (!int.TryParse(gameIdString, out int gameId)) Response.Redirect("404");
            try
            {
                game = new Game(gameId);
            }
            catch (InvalidOperationException)
            {
                Response.Redirect("404");
            }
        }

        private void UpdateGenres()
        {
            var set = (HashSet<Genre>)ViewState["GenreList"];
            Genres.Text = set.Count == 0
                ? "No Genres Selected"
                : string.Join(", ", set.Select(genre => genre.GenreName));

        }

        private void LoadData()
        {
            GameName.Text = game.GameName;
            GameLink.Text = game.GameLink;
            Description.Text = game.Description;
            Price.Text = "" + game.Price;

        }

        private void LoadGenreData()
        {
            GenreList.DataSource = Genre.AllGenres();
            GenreList.DataTextField = "GenreName";
            GenreList.DataValueField = "ID";
            GenreList.DataBind();
            var set = new HashSet<Genre>();
            game.Genres.ForEach(genre => set.Add(genre));
            ViewState["GenreList"] = set;
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
            Validate();
            if (!IsValid) return;

            var developer = user.DeveloperId;

            //var bgPath = UploadHelper.ImageFileUpload(Background, backgroundFormat, "no.jpg", Server);
            //var logoPath = UploadHelper.ImageFileUpload(Logo, logoFormat, "no.jpg", Server);

            var description = Description.Text;
            var link = GameLink.Text;
            var gameName = GameName.Text;
            var price = double.Parse(Price.Text.Replace("$", ""));

            game.DeveloperId = developer;
            //game.Background = bgPath;
            //game.Logo = logoPath;
            game.Description = description;
            game.GameLink = link;
            game.GameName = gameName;
            game.Price = price;

            game.UpdateToDatabase();
            
            Genre.ClearGenres(game.Id);

            foreach (var genre in (HashSet<Genre>)ViewState["GenreList"]) Genre.InsertGameGenre(genre, game.Id);

            Response.Redirect("GamePage.aspx?id=" + game.Id);

            game.Genres = ((HashSet<Genre>) ViewState["GenreList"]).ToList();

            List<Game> storeGames = (List<Game>) Application["StoreGames"];
            storeGames.RemoveAll(g => g.Id == game.Id);

            storeGames.Insert(0, game);
        }

        protected void AddGenreToAll_Click(object sender, EventArgs e)
        {
            var genre = new Genre(newGenre.Text);
            LoadGenreData();
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

        protected void UpdateLogoButton_OnClick(object sender, EventArgs e)
        {
            string filename = UploadHelper.ImageFileUpload(Logo, "Images/GameLogos/", "no.png", Server);
            game.UpdateLogo(filename);
        }

        protected void UpdateBackgroundButton_OnClick(object sender, EventArgs e)
        {
            string filename = UploadHelper.ImageFileUpload(Background, "Images/GameBackgrounds/", "no.png", Server);
            game.UpdateBackground(filename);
        }
    }
}