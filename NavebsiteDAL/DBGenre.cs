using System.Data;

namespace NavebsiteDAL
{
    /// <summary>
    /// DB class for genre-related data fetching
    /// </summary>
    public class DbGenre
    {
        /// <summary>
        /// gets a list of all genres
        /// </summary>
        /// <returns>DataTable of genres</returns>
        public static DataTable AllGenres()
        {
            return DalHelper.AllFromTable("Genres");
        }

        /// <summary>
        /// gets a genre by id
        /// </summary>
        /// <param name="id">id of genre</param>
        /// <returns>DataRow of genre</returns>
        public static DataRow GetGenre(int id)
        {
            return DalHelper.GetRowById(id, "Genres");
        }

        /// <summary>
        /// inserts a genre by name
        /// </summary>
        /// <param name="genreName">name of genre</param>
        /// <returns>id of genre</returns>
        public static int InsertGenre(string genreName)
        {
            return DalHelper.InsertIfNotExist($"INSERT INTO Genres ([Genre Name]) VALUES ('{genreName}')",
                $"SELECT ID FROM Genres WHERE [Genre Name] LIKE '{genreName}'");
        }

        /// <summary>
        /// inserts a game-genre link
        /// </summary>
        /// <param name="genreId">id of genre</param>
        /// <param name="gameId">id of game</param>
        /// <returns>id of gameGenre</returns>
        public static int InsertGameGenre(int genreId, int gameId)
        {
            return DalHelper.Insert($"INSERT INTO GameGenres (Game,Genre) VALUES({gameId},{genreId})");
        }

        /// <summary>
        /// gets all genres of a game
        /// </summary>
        /// <param name="gameId">id of game</param>
        /// <returns>DataTable of genres</returns>
        public static DataTable GetGenresByGame(int gameId)
        {
            var sql = $@"SELECT Genres.*
                            FROM Games 
                            INNER JOIN(Genres INNER JOIN GameGenres ON Genres.ID = GameGenres.Genre) 
                            ON Games.ID = GameGenres.Game 
                            WHERE Games.ID = {gameId};";
            return DalHelper.Select(sql);
        }

        /// <summary>
        /// gets all game genre links
        /// </summary>
        /// <returns>DataTable of gameGenres</returns>
        public static DataTable GetAllGameGenres()
        {
            var sql = $@"SELECT Genres.[Genre Name], Genres.ID, GameGenres.Game
                        FROM Genres INNER JOIN GameGenres ON Genres.ID = GameGenres.Genre ORDER BY GameGenres.Game;";
            return DalHelper.Select(sql);
        }

        /// <summary>
        /// gets all game genre links for public games
        /// </summary>
        /// <returns>DataTable of gameGenres</returns>
        public static DataTable GetAllPublicGameGenres()
        {
            var sql = $@"SELECT Genres.[Genre Name], Genres.ID, GameGenres.Game
FROM Games INNER JOIN (Genres INNER JOIN GameGenres ON Genres.ID = GameGenres.Genre) ON Games.ID = GameGenres.Game WHERE Games.[Review Status] = 1;";
            return DalHelper.Select(sql);
        }

        /// <summary>
        /// deletes all genres of a game
        /// </summary>
        /// <param name="game">id of game</param>
        public static void DeleteGenresForGame(int game)
        {
            var sql = $@"DELETE * FROM GameGenres WHERE Game = {game}";
            DalHelper.Update(sql);
        }
    }
}