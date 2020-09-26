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

            var helper = new DbHelper(Constants.Provider, Constants.Path);

            if (!helper.OpenConnection()) throw new ConnectionException();

            var tb = helper.GetDataTable(sql);
            helper.CloseConnection();
            return tb;
        }
    }
}