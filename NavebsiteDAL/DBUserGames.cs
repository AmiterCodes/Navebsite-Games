using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavebsiteDAL
{
    public class DBUserGames
    {
        public static bool GameOwnedByUser(int gameId, int userId)
        {
            return DALHelper.RowExists($"SELECT Game FROM UserGames WHERE Game = {gameId} AND [User] = {userId}");
        }

        public static DataTable GetUserGames(int userId)
        {
            return DALHelper.Select($"SELECT * FROM Games INNER JOIN UserGames ON Games.ID = UserGames.Game WHERE User = {userId}");
        }

        public static DataTable AllUserGames()
        {
            return DALHelper.AllFromTable("UserGames");
        }

        
    }
}
