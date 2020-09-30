using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NavebsiteDAL;

namespace NavebsiteBL
{
    [Serializable]
    public enum OrderBy
    {
        PublishDate,
        GameName,
        Price
    }
    

    [Serializable]
    public class Game
    {
        public Game(DataRow row)
        {
            if (row == null) throw new InvalidOperationException();

            Id = (int) row["ID"];
            GameName = (string) row["Game Name"];
            GameLink = (string) row["Game Link"];
            Description = (string) row["Description"];
            ReviewStatus = (int) row["Review Status"];
            Background = (string) row["Background"];
            Logo = (string) row["Logo"];
            DeveloperId = (int) row["Developer"];
            PublishDate = (DateTime) row["Publish Date"];
            Price = (double) row["Price"];
        }

        public Game()
        {
        }

        public Game(string gameName, string link, string description, string background, string logo, int developer,
            double price)
        {
            Id = DbGame.InsertGame(gameName, link, description, background, logo, developer, price);
            GameName = gameName;
            GameLink = link;
            Description = description;
            Background = background;
            Logo = logo;
            ReviewStatus = 0;
            PublishDate = DateTime.Now;
            DeveloperId = developer;
            Price = price;
        }

        public Game(int id) : this(DbGame.GetGame(id))
        {
        }

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
        private List<Genre> _genres ;

        public List<Genre> Genres =>
            _genres ?? (_genres =
                (from DataRow r in DbGenre.GetGenresByGame(Id).Rows select new Genre(r)).ToList());

        public Developer Developer => new Developer(DeveloperId);
        public string DeveloperName => Developer.DeveloperName;

        public string GenresString
        {
            get
            {
                var list = Genres;
                if (list.Count == 0) return "";
                var s = list.Aggregate("", (current, g) => current + g.GenreName + ", ");
                return s.Substring(0, s.Length - 2);
            }
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