using System.Data;

namespace NavebsiteDAL
{
    /// <summary>
    /// static DB class that deals with the relations between games and users
    /// </summary>
    public class DbUserGames
    {
        /// <summary>
        /// returns if a game is owned by user
        /// </summary>
        /// <param name="gameId">id of game</param>
        /// <param name="userId">id of user</param>
        /// <returns></returns>
        public static bool GameOwnedByUser(int gameId, int userId)
        {
            return DalHelper.RowExists($"SELECT Game FROM UserGames WHERE Game = {gameId} AND [User] = {userId}");
        }

        /// <summary>
        /// Retrieves a list of all games of a certain user
        /// </summary>
        /// <param name="userId">id of user</param>
        /// <returns></returns>
        public static DataTable GetUserGames(int userId)
        {
            return DalHelper.Select(
                $"SELECT * FROM Games INNER JOIN UserGames ON Games.ID = UserGames.Game WHERE User = {userId}");
        }
        
        /// <summary>
        /// Adds a user game relation to the store (happens when user buys a game)
        /// </summary>
        /// <param name="user">id of user</param>
        /// <param name="game">id of game</param>
        /// <param name="price">the cost the user paid</param>
        public static void AddGame(int user, int game, double price)
        {
            DalHelper.Insert($"INSERT INTO UserGames ([User],[Game],[Cost]) VALUES ({user},{game},{price});");
        }

    }
}