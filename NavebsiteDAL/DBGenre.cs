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
        public static DataRow GetGenre(int id)
        {
            DBHelper helper = new DBHelper(Constants.PROVIDER, Constants.PATH);

            if (!helper.OpenConnection()) throw new ConnectionException();
            string sql = $"SELECT * FROM Genres WHERE ID = {id}";

            DataTable tb = helper.GetDataTable(sql);
            helper.CloseConnection();

            if (tb.Rows.Count < 1) return null;

            return tb.Rows[0];
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
