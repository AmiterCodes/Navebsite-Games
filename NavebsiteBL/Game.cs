using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using NavebsiteDAL;

namespace NavebsiteBL
{
    /// <summary>
    /// enum that is used for ordering a game list
    /// </summary>
    [Serializable]
    public enum OrderBy
    {
        PublishDate,
        GameName,
        Price
    }

    /// <summary>
    /// represents a game in the store
    /// </summary>
    [Serializable]
    public class Game
    {

        public int Id { get; set; }
        public string GameName { get; set; }
        public string GameLink { get; set; }
        public string Description { get; set; }
        private int _reviewStatus;
        public int ReviewStatus
        {
            get => _reviewStatus;
            set
            {
                _reviewStatus = value;
                DbGame.UpdateReviewStatus(value, Id);
            }
        }
        public string Background { get; set; }
        public string Logo { get; set; }

        public string BackgroundUrl => "./Images/GameBackgrounds/" + Background;
        public string LogoUrl => "./Images/GameLogos/" + Logo;
        public int DeveloperId { get; set; }
        public DateTime PublishDate { get; set; }
        public double Price { get; set; }
        private List<Genre> _genres;
        public List<Genre> Genres
        {
            get => _genres ?? (_genres =
(from DataRow r in DbGenre.GetGenresByGame(Id).Rows select new Genre(r)).ToList());
            set => _genres = value;
        }
        public double AverageRating => DbReview.AverageRating(Id);
        public Developer Developer => new Developer(DeveloperId);
        public string DeveloperName => Developer.DeveloperName;

        public List<Update> Updates => Update.ListUpdates(Id);


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


        /// <summary>
        /// creates a game from a row
        /// </summary>
        /// <param name="row">datarow of game</param>
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

        /// <summary>
        /// empty constructor for serialization
        /// </summary>
        public Game()
        {
        }

        /// <summary>
        /// inserts a game into the database
        /// </summary>
        /// <param name="gameName">name of game</param>
        /// <param name="link">link of game</param>
        /// <param name="description">description of game</param>
        /// <param name="background">background filename of game</param>
        /// <param name="logo">logo filename of game</param>
        /// <param name="developer">developer id of game</param>
        /// <param name="price">price of game</param>
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

        /// <summary>
        /// gets a game by id
        /// </summary>
        /// <param name="id">id of game</param>
        public Game(int id) : this(DbGame.GetGame(id))
        {
            LoadGenres();
        }


        /// <summary>
        /// Loads genres for a game
        /// </summary>
        public void LoadGenres()
        {
            List<Genre> genres = Genres;
        }

        /// <summary>
        /// returns all games from a certain developer
        /// </summary>
        /// <param name="developerId">id of developer</param>
        /// <returns>list of games</returns>
        public static List<Game> GamesByDeveloper(int developerId)
        {
            return (from DataRow r in DbGame.AllGamesFromDeveloper(developerId).Rows select new Game(r)).ToList();
        }

        /// <summary>
        ///     returns all games that need reviewing from the database
        /// </summary>
        /// <returns>list of games</returns>
        public static List<Game> ReviewGames()
        {
            return (from DataRow r in DbGame.GamesToReview().Rows select new Game(r)).ToList();
        }

        /// <summary>
        ///     returns all public (accepted review) games from the database
        /// </summary>
        /// <returns>list of all games</returns>
        public static List<Game> StoreGames()
        {
            var games = DbGame.AllPublicGames();
            var genres = DbGenre.GetAllPublicGameGenres();

            List<Game> output = new List<Game>();

            var enumerator = genres.Rows.OfType<DataRow>().GetEnumerator();
            enumerator.MoveNext();
            foreach (DataRow game in games.Rows)
            {

                var gameObject = new Game(game) {_genres = new List<Genre>()};
                if (enumerator.Current != null)
                {
                    int currentGame = (int) enumerator.Current["Game"];
                    bool enumeratorEnded = false;
                    while (!enumeratorEnded && currentGame == gameObject.Id)
                    {
                        gameObject._genres.Add(new Genre(enumerator.Current));
                        enumeratorEnded = !enumerator.MoveNext();
                        if (enumerator.Current != null) currentGame = (int) enumerator.Current["Game"];
                    }
                }

                output.Add(gameObject);
            }

            enumerator.Dispose();

            return output;
        }

        /// <summary>
        /// updates the game in the database with the currnet game info
        /// </summary>
        public void UpdateToDatabase()
        {
            DbGame.UpdateGame(
                Id,
                Description,
                Background,
                Logo,
                DeveloperId,
                GameLink,
                GameName,
                Price);
        }

        /// <summary>
        /// updates the logo of the game
        /// </summary>
        /// <param name="filename">filename of image</param>
        public void UpdateLogo(string filename)
        {
            this.Logo = filename;
            DbGame.UpdateLogo(filename, Id);
        }

        /// <summary>
        /// updates the background of the game
        /// </summary>
        /// <param name="filename">filename of image</param>
        public void UpdateBackground(string filename)
        {
            this.Background = filename;
            DbGame.UpdateBackground(filename, Id);
        }
    }
}