using System.Data;
using System.Data.OleDb;

namespace NavebsiteDAL
{
    public class DbGame
    {
        public static DataRow GetGame(int id)
        {
            return DalHelper.GetRowById(id, "Games");
        }

        public static DataTable AllGamesFromDeveloper(int devId)
        {
            return DalHelper.AllWhere("Games", "Developer", devId);
        }

        public static int InsertGame(string gameName, string link, string description, string background, string logo,
            int developer, double price)
        {
            return DalHelper.Insert(
                "INSERT INTO Games ([Game Name],[Game Link],Description,Background,Logo,Developer,Price) " +
                $"VALUES ('{gameName}','{link}','{description}','{background}','{logo}',{developer},{price})");
        }

        /// <summary>
        ///     returns all public (accepted review) games from the database
        /// </summary>
        /// <returns>DataTable of all games</returns>
        public static DataTable AllPublicGamesOrder(string orderBy)
        {
            return DalHelper.Select($"SELECT * FROM Games WHERE [Review Status] = 1 ORDER BY `{orderBy}`");
        }

        /// <summary>
        ///     returns all public (accepted review) games from the database
        /// </summary>
        /// <returns>DataTable of all games</returns>
        public static DataTable AllPublicGames()
        {
            return DalHelper.Select("SELECT * FROM Games WHERE [Review Status] = 1 ORDER BY Games.ID");
        }

        /// <summary>
        ///     returns all games that need reviewing from the database
        /// </summary>
        /// <returns>DataTable of all games</returns>
        public static DataTable GamesToReview()
        {
            return DalHelper.AllWhere("Games", "Review Status", 0);
        }

        public static void UpdateReviewStatus(int newReviewStatus, int id)
        {
            DalHelper.UpdateWhere("Games", "Review Status", newReviewStatus, "ID", id);
        }

        public static void UpdateGame(int id, string description, string background, string logo, int developerId, string gameLink, string gameName, double price)
        {
            DalHelper.Update($@"UPDATE Games
SET [Game Name] = @gameName, 
[Game Link] = @gameLink, 
[Description] = @desc, 
[Background] = @background, 
[Logo] = @logo, 
[Developer] = @dev, 
[Price] = @price 
WHERE ID = {id}", 
                new OleDbParameter("@gameName", gameName),
                new OleDbParameter("@gameLink", gameLink),
                new OleDbParameter("@desc", description),
                new OleDbParameter("@background", background),
                new OleDbParameter("@logo", logo),
                new OleDbParameter("@dev", developerId),
                new OleDbParameter("@price", price));
        }
    }
}