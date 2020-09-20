using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace NavebsiteDAL
{
    public class DBGenre
    {

        public static DataTable AllGenres()
        {
            return DALHelper.AllFromTable("Genres");
        }
        public static DataRow GetGenre(int id)
        {
            return DALHelper.GetRowById(id, "Genres");
        }

        public static int InsertGenre(string genreName)
        {
            return DALHelper.InsertIfDoesntExist($"INSERT INTO Genres ([Genre Name]) VALUES ('{genreName}')", $"SELECT ID FROM Genres WHERE [Genre Name] LIKE '{genreName}'");
        }

        public static DataTable GetGenresByGame(int gameId) 
        {
            string sql = $@"SELECT Genres.*
                            FROM Games 
                            INNER JOIN(Genres INNER JOIN GameGenres ON Genres.ID = GameGenres.Genre) 
                            ON Games.ID = GameGenres.Game 
                            WHERE Games.ID = {gameId};";

            DBHelper helper = new DBHelper(Constants.PROVIDER, Constants.PATH);

            if (!helper.OpenConnection()) throw new ConnectionException();

            DataTable tb = helper.GetDataTable(sql);
            helper.CloseConnection();
            return tb;
        }
    }
}
