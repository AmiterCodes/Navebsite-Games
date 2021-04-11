using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NavebsiteDAL;

namespace NavebsiteBL
{
    /// <summary>
    /// represents a game that is linked to a user
    /// </summary>
    public class UserGame : Game
    {
        /// <summary>
        /// creates a UserGame object from dataRow
        /// </summary>
        /// <param name="dr">dataRow of user game connection</param>
        public UserGame(DataRow dr) : base(dr)
        {
            UserId = (int) dr["User"];
            Timestamp = (DateTime) dr["Timestamp"];
        }

        /// <summary>
        /// adds a game to a user
        /// </summary>
        /// <param name="user">id of user</param>
        /// <param name="game">id of game</param>
        /// <param name="price">price it cost</param>
        public static void AddGame(int user, int game, double price)
        {
            DbUserGames.AddGame(user, game, price);
        }

        public int UserId { get; set; }
        public DateTime Timestamp { get; set; }


        public string BoughtString => "Bought " + Timestamp.ToShortDateString();

        /// <summary>
        /// checks if a game is owned by user
        /// </summary>
        /// <param name="gameId">id of game</param>
        /// <param name="userId">id of user</param>
        /// <returns>true if user owns that game else false</returns>
        public static bool GameOwnedByUser(int gameId, int userId)
        {
            return DbUserGames.GameOwnedByUser(gameId, userId);
        }

        /// <summary>
        /// returns a list of all user games that a certain user holds
        /// </summary>
        /// <param name="user">id of user</param>
        /// <returns>list of userGame</returns>
        public static List<UserGame> UserGames(int user)
        {
            return (from DataRow row in DbUserGames.GetUserGames(user).Rows select new UserGame(row)).ToList();
        }
    }
}