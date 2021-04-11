using System.Data;
using System.Data.OleDb;

namespace NavebsiteDAL
{
    /// <summary>
    /// DB class for game-related data fetching
    /// </summary>
    public class DbGame
    {
        /// <summary>
        /// gets a game by id
        /// </summary>
        /// <param name="id">id of game</param>
        /// <returns>datarow of game</returns>
        public static DataRow GetGame(int id)
        {
            return DalHelper.GetRowById(id, "Games");
        }

        /// <summary>
        /// gets all games from a developer
        /// </summary>
        /// <param name="devId">id of developer</param>
        /// <returns></returns>
        public static DataTable AllGamesFromDeveloper(int devId)
        {
            return DalHelper.AllWhere("Games", "Developer", devId);
        }

        /// <summary>
        /// inserts a game into the database
        /// </summary>
        /// <param name="gameName">name of game</param>
        /// <param name="link">link of game</param>
        /// <param name="description">description of game</param>
        /// <param name="background">background filename of game</param>
        /// <param name="logo">logo filename of game</param>
        /// <param name="developer">developer id of game</param>
        /// <param name="price">price of game</param>
        /// <returns>id of game</returns>
        public static int InsertGame(string gameName, string link, string description, string background, string logo,
            int developer, double price)
        {
            return DalHelper.Insert(
                "INSERT INTO Games ([Game Name],[Game Link],Description,Background,Logo,Developer,Price) " +
                $"VALUES (@gameName,@link,@desc,@background,@logo,{developer},{price})",
                new OleDbParameter("@gameName", gameName),
                new OleDbParameter("@link", gameName),
            new OleDbParameter("@desc", gameName),
            new OleDbParameter("@background", gameName),
            new OleDbParameter("@logo", gameName));
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

        /// <summary>
        /// Updates the review status for a game
        /// </summary>
        /// <param name="newReviewStatus">the new status id</param>
        /// <param name="id">id of game</param>
        public static void UpdateReviewStatus(int newReviewStatus, int id)
        {
            DalHelper.UpdateWhere("Games", "Review Status", newReviewStatus, "ID", id);
        }

        /// <summary>
        /// Updates a game
        /// </summary>
        /// <param name="id">id of game</param>
        /// <param name="description">description of game</param>
        /// <param name="background">background of game</param>
        /// <param name="logo">logo of game</param>
        /// <param name="developerId">developer id of game</param>
        /// <param name="gameLink">link of game</param>
        /// <param name="gameName">name of game</param>
        /// <param name="price">price of game</param>
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

        /// <summary>
        /// updates the logo of the game
        /// </summary>
        /// <param name="filename">filename of image</param>
        /// <param name="id">id of game</param>
        public static void UpdateLogo(string filename, int id)
        {
            DalHelper.UpdateWhere("Games", "Logo", filename, "ID", id);
        }

        /// <summary>
        /// updates the background of the game
        /// </summary>
        /// <param name="filename">filename of image</param>
        /// <param name="id">id of game</param>
        public static void UpdateBackground(string filename, int id)
        {
            DalHelper.UpdateWhere("Games", "Background", filename, "ID", id);
        }
    }
}