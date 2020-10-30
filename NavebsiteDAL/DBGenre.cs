using System.Data;

namespace NavebsiteDAL
{
    public class DbGenre
    {
        public static DataTable AllGenres()
        {
            return DalHelper.AllFromTable("Genres");
        }

        public static DataRow GetGenre(int id)
        {
            return DalHelper.GetRowById(id, "Genres");
        }

        public static int InsertGenre(string genreName)
        {
            return DalHelper.InsertIfNotExist($"INSERT INTO Genres ([Genre Name]) VALUES ('{genreName}')",
                $"SELECT ID FROM Genres WHERE [Genre Name] LIKE '{genreName}'");
        }

        public static int InsertGameGenre(int genreId, int gameId)
        {
            return DalHelper.Insert($"INSERT INTO GameGenres (Game,Genre) VALUES({gameId},{genreId})");
        }

        public static DataTable GetGenresByGame(int gameId)
        {
            var sql = $@"SELECT Genres.*
                            FROM Games 
                            INNER JOIN(Genres INNER JOIN GameGenres ON Genres.ID = GameGenres.Genre) 
                            ON Games.ID = GameGenres.Game 
                            WHERE Games.ID = {gameId};";
            return DalHelper.Select(sql);
        }

        public static DataTable GetAllGameGenres()
        {
            var sql = $@"SELECT Genres.[Genre Name], Genres.ID, GameGenres.Game
                        FROM Genres INNER JOIN GameGenres ON Genres.ID = GameGenres.Genre ORDER BY GameGenres.Game;";
            return DalHelper.Select(sql);
        }

        public static DataTable GetAllPublicGameGenres()
        {
            var sql = $@"SELECT Genres.[Genre Name], Genres.ID, GameGenres.Game
FROM Games INNER JOIN (Genres INNER JOIN GameGenres ON Genres.ID = GameGenres.Genre) ON Games.ID = GameGenres.Game WHERE Games.[Review Status] = 1;";
            return DalHelper.Select(sql);
        }

        public static void DeleteGenresForGame(int game)
        {
            var sql = $@"DELETE * FROM GameGenres WHERE Game = {game}";
            DalHelper.Update(sql);
        }
    }
}