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
        public static DataTable GetUserGames(int userId)
        {
            return DALHelper.Select($"SELECT * FROM Games INNER JOIN UserGames ON Games.ID = UserGames.Game WHERE User = {userId}");
        }
    }
}
