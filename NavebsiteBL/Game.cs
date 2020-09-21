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
        public int ID { get; set; }
        public string GameName { get; set; }
        public string GameLink { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public int ReviewStatus { get; set; }
        public string Background { get; set; }
        public string Logo { get; set; }


        public string BackgroundUrl => "./Images/GameBackgrounds/" + Background;
        public string LogoUrl => "./Images/GameLogos/" + Logo;

        public int DeveloperId { get; set; }
        public DateTime PublishDate { get; set; }
        public double Price { get; set; }
        public List<Genre> Genres { get {
                List<Genre> l = new List<Genre>();
                foreach (DataRow r in DBGenre.GetGenresByGame(ID).Rows)
                {
                    l.Add(new Genre(r));
                }
                return l;
            } }
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

            this.ID = (int)row["ID"];
            this.GameName = (string)row["Game Name"];
            this.GameLink = (string)row["Game Link"];
            this.Version = (string)row["Version"];
            this.Description = (string)row["Description"];
            this.ReviewStatus = (int)row["Review Status"];
            this.Background = (string)row["Background"];
            this.Logo = (string)row["Logo"];
            this.DeveloperId = (int)row["Developer"];
            this.PublishDate = (DateTime)row["Publish Date"];
            this.Price = (double)row["Price"];

        }

        public Game() {}

        public Game(string gameName, string link, string version, string description, string background, string logo, int developer, double price) {

            this.ID = DBGame.InsertGame(gameName,link,version,description,background,logo,developer,price);
            GameName = gameName;
            GameLink = link;
            Version = version;
            Description = description;
            Background = background;
            Logo = logo;
            ReviewStatus = 0;
            this.PublishDate = DateTime.Now;
            DeveloperId = developer;
            Price = price;

        }

        public Game(int id) : this(DBGame.GetGame(id))
        {
            
        }

        public static List<Game> GamesByDeveloper(int developerId) {
            List<Game> l = new List<Game>();
            foreach (DataRow r in DBGame.AllGamesFromDeveloper(developerId).Rows)
            {
                l.Add(new Game(r));
            }
            return l;
        }

        public static List<Game> AllGames()
        {
            List<Game> l = new List<Game>();
            foreach(DataRow r in DBGame.AllGames().Rows)
            {
                l.Add(new Game(r));
            }
            return l;
        }
    }
}
