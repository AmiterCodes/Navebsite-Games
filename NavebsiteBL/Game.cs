using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavebsiteDAL;

namespace NavebsiteBL
{
    public class Game
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public string GameLink { get; set; }
        public string Description { get; set; }
        public int ReviewStatus { get; set; }
        public string Background { get; set; }
        public string Logo { get; set; }


        public string BackgroundUrl => "./Images/GameBackgrounds/" + Background;
        public string LogoUrl => "./Images/GameLogos/" + Logo;

        public int DeveloperId { get; set; }
        public DateTime PublishDate { get; set; }
        public double Price { get; set; }
        public List<Genre> Genres => (from DataRow r in DbGenre.GetGenresByGame(Id).Rows select new Genre(r)).ToList();
        public Developer Developer => new Developer(DeveloperId);
        public string DeveloperName => Developer.DeveloperName;

        public string GenresString { get
            {
                List<Genre> list = Genres;
                if (list.Count == 0) return "";
                string s = list.Aggregate("", (current, g) => current + (g.GenreName + ", "));
                return s.Substring(0, s.Length - 2);
            } }


        public Game(DataRow row)
        {
            if (row == null) throw new InvalidOperationException();

            this.Id = (int)row["ID"];
            this.GameName = (string)row["Game Name"];
            this.GameLink = (string)row["Game Link"];
            this.Description = (string)row["Description"];
            this.ReviewStatus = (int)row["Review Status"];
            this.Background = (string)row["Background"];
            this.Logo = (string)row["Logo"];
            this.DeveloperId = (int)row["Developer"];
            this.PublishDate = (DateTime)row["Publish Date"];
            this.Price = (double)row["Price"];

        }

        public Game() {}

        public Game(string gameName, string link, string description, string background, string logo, int developer, double price) {

            this.Id = DbGame.InsertGame(gameName,link,description,background,logo,developer,price);
            GameName = gameName;
            GameLink = link;
            Description = description;
            Background = background;
            Logo = logo;
            ReviewStatus = 0;
            this.PublishDate = DateTime.Now;
            DeveloperId = developer;
            Price = price;

        }

        public Game(int id) : this(DbGame.GetGame(id))
        {
            
        }

        public static List<Game> GamesByDeveloper(int developerId)
        {
            return (from DataRow r in DbGame.AllGamesFromDeveloper(developerId).Rows select new Game(r)).ToList();
        }

        public static List<Game> StoreGames()
        {
            return (from DataRow r in DbGame.AllPublicGames().Rows select new Game(r)).ToList();
        }
    }
}
