using System.Data;

namespace NavebsiteDAL
{
    /// <summary>
    /// class that deals with statistics about sales
    /// </summary>
    public class DbStats
    {
        /// <summary>
        /// gets the total sales stats for a game
        /// </summary>
        /// <param name="gameId">id of game</param>
        /// <returns>DataTable of sale statistics</returns>
        public static DataTable GameSalesStats(int gameId)
        {
            return DalHelper.Select(
                "SELECT CDate(Format(UserGames.Timestamp,\"dd/mm/yyyy\")) AS [Timestamp], SUM(Cost) AS Revenue, COUNT(Cost) AS Purchases FROM UserGames " +
                $"WHERE Game = {gameId} GROUP BY CDate(Format(UserGames.Timestamp, \"dd/mm/yyyy\")) ORDER BY CDate(Format(UserGames.Timestamp, \"dd/mm/yyyy\"));");
        }

        /// <summary>
        /// gets the total sales stats for a company
        /// </summary>
        /// <param name="devId">id of developer</param>
        /// <returns>DataTable of sale statistics</returns>
        public static DataTable CompanySalesStats(int devId)
        {
            return DalHelper.Select(
                "SELECT CDate(Format(UserGames.Timestamp,\"dd/mm/yyyy\")) AS [Timestamp], SUM(Cost) AS Revenue, COUNT(Cost) AS Purchases FROM Games INNER JOIN UserGames ON Games.ID = UserGames.Game " +
                $"WHERE Developer = {devId} GROUP BY CDate(Format(UserGames.Timestamp, \"dd/mm/yyyy\")) ORDER BY CDate(Format(UserGames.Timestamp, \"dd/mm/yyyy\"));");
        }

        /// <summary>
        /// gets the total sales stats for everything
        /// </summary>
        /// <returns>DataTable of sale statistics</returns>
        public static DataTable TotalSalesStats()
        {
            return DalHelper.Select(
                "SELECT CDate(Format(UserGames.Timestamp,\"dd/mm/yyyy\")) AS [Timestamp], SUM(Cost) AS Revenue, COUNT(Cost) AS Purchases FROM UserGames " +
                "GROUP BY CDate(Format(UserGames.Timestamp, \"dd/mm/yyyy\")) ORDER BY CDate(Format(UserGames.Timestamp, \"dd/mm/yyyy\"));");
        }

        /// <summary>
        /// returns stats for a game in one row
        /// </summary>
        /// <param name="id">id of game</param>
        /// <returns>dataRow of sales</returns>
        public static DataRow getGameStats(int id)
        {
            var tb = DalHelper.Select(
                $"SELECT COUNT(Game) AS Purchases, SUM(Cost) AS Revenue from UserGames WHERE Game = {id} GROUP BY Game");
            if (tb.Rows.Count == 0) return null;
            return tb.Rows[0];
        }
    }
}