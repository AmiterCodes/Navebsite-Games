using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavebsiteDAL
{
    public class DBStats
    {
        public static DataTable GameSalesStats(int gameId)
        {
            return DalHelper.Select("SELECT CDate(Format(UserGames.Timestamp,\"dd/mm/yyyy\")) AS [Timestamp], SUM(Cost) AS Revenue, COUNT(Cost) AS Purchases FROM UserGames " +
               $"WHERE Game = {gameId} GROUP BY CDate(Format(UserGames.Timestamp, \"dd/mm/yyyy\")) ORDER BY CDate(Format(UserGames.Timestamp, \"dd/mm/yyyy\"));");
        }

        public static DataTable CompanySalesStats(int devId)
        {
            return DalHelper.Select("SELECT CDate(Format(UserGames.Timestamp,\"dd/mm/yyyy\")) AS [Timestamp], SUM(Cost) AS Revenue, COUNT(Cost) AS Purchases FROM  INNER JOIN UserGames ON Games.ID = UserGames.Game " +
               $"WHERE Developer = {devId} GROUP BY CDate(Format(UserGames.Timestamp, \"dd/mm/yyyy\")) ORDER BY CDate(Format(UserGames.Timestamp, \"dd/mm/yyyy\"));");
        }

        public static DataTable TotalSalesStats()
        {
            return DalHelper.Select("SELECT CDate(Format(UserGames.Timestamp,\"dd/mm/yyyy\")) AS [Timestamp], SUM(Cost) AS Revenue, COUNT(Cost) AS Purchases FROM UserGames " +
               $"GROUP BY CDate(Format(UserGames.Timestamp, \"dd/mm/yyyy\")) ORDER BY CDate(Format(UserGames.Timestamp, \"dd/mm/yyyy\"));");
        }

    }
}
