using System.Data;

namespace NavebsiteDAL
{
    public class DbFriends
    {
        /// <summary>
        ///     Returns a list of friends of a user
        /// </summary>
        /// <param name="userId">user to return his friends</param>
        /// <returns>DataTable of friends</returns>
        public static DataTable GetFriendsOfUser(int userId)
        {
            var selectDirection = $@"(SELECT Users.*
                FROM Users INNER JOIN UserFriends ON Users.ID = UserFriends.[User $1]
            WHERE(((UserFriends.[User $2]) ={userId}) AND((UserFriends.Type) = TRUE)))";

            var sql = AllDirections(selectDirection);
            return DalHelper.Select(sql);
        }

        /// <summary>
        ///     Returns a list of friends that play a game
        /// </summary>
        /// <param name="userId">id of user to check his friends</param>
        /// <param name="gameId">id of game that friends play</param>
        /// <returns>DataTable of friends</returns>
        public static DataTable GetFriendsWhoPlayGame(int userId, int gameId)
        {
            var selectDirection = "SELECT Users.*" +
                                  "FROM(Users INNER JOIN UserFriends ON Users.ID = UserFriends.[User $2]) INNER JOIN UserGames ON Users.ID = UserGames.[User] " +
                                  $"WHERE(((UserFriends.[User $1]) = {userId}) AND((UserGames.Game) = {gameId}))";
            var sql = AllDirections(selectDirection);
            return DalHelper.Select(sql);
        }

        public static bool AreFriends(int user1, int user2)
        {
            return DalHelper.RowExists(
                $"SELECT [User 1] FROM UserFriends WHERE (([User 1] = {user1} AND [User 2] = {user2}) " +
                $"OR ([User 1] = {user2} AND [User 2] = {user1})) AND Type = TRUE");
        }


        public static bool ExistsConnection(int user1, int user2)
        {
            return DalHelper.RowExists(
                $"SELECT [User 1] FROM UserFriends WHERE (([User 1] = {user1} AND [User 2] = {user2}) " +
                $"OR ([User 1] = {user2} AND [User 2] = {user1}))");
        }

        /// <summary>
        ///     Sends a friend request from user1 to user2
        /// </summary>
        /// <param name="user1">user that sends the request</param>
        /// <param name="user2">user that receives the request</param>
        public static bool SendFriendRequest(int user1, int user2)
        {
            return DalHelper.Insert($"INSERT INTO UserFriends ([User 1], [User 2]) VALUES ({user1}, {user2})") !=
                   DbHelper.WriteDataError;
        }

        /// <summary>
        ///     check if a friend request exists
        /// </summary>
        /// <param name="user1">user that sent the request</param>
        /// <param name="user2">user that accepted the request</param>
        /// <returns>if friend request exists</returns>
        public static bool ExistsFriendRequest(int user1, int user2)
        {
            return DalHelper.RowExists(
                $"SELECT [User 1] FROM UserFriends WHERE [User 1] = {user1} AND [User 2] = {user2}");
        }

        /// <summary>
        ///     Accept a friend request from user1 to user2
        /// </summary>
        /// <param name="user1">user that sent the request</param>
        /// <param name="user2">user that accepted the request</param>
        /// <returns>if it did anything</returns>
        public static bool AcceptFriendRequest(int user1, int user2)
        {
            return DalHelper.Insert(
                $"UPDATE UserFriends SET Type = TRUE WHERE [User 1] = {user1} AND [User 2] = {user2}") > 0;
        }

        /// <summary>
        ///     Denies a friend request from user1 to user2
        /// </summary>
        /// <param name="user1">user that sent the request</param>
        /// <param name="user2">user that denied the request</param>
        /// <returns>if it did anything</returns>
        public static bool DenyFriendRequest(int user1, int user2)
        {
            return DalHelper.Update($"DELETE FROM UserFriends WHERE [User 1] = {user1} AND [User 2] = {user2}") > 0;
        }

        /// <summary>
        ///     Removes the friend connection between user1 and user2
        /// </summary>
        /// <param name="user1">user that is connected</param>
        /// <param name="user2">user that is connected</param>
        /// <returns>if it did anything</returns>
        public static bool RemoveFriend(int user1, int user2)
        {
            return DalHelper.Update("DELETE FROM UserFriends WHERE" +
                                    $" (([User 1] = {user1} AND [User 2] = {user2})" +
                                    $" OR ([User 2] = {user1} AND [User 1] = {user2})) AND Type = TRUE") > 0;
        }


        private static string AllDirections(string selectDirection)
        {
            var sql = selectDirection.Replace("$1", "1").Replace("$2", "2")
                      + " UNION ALL "
                      + selectDirection.Replace("$1", "2").Replace("$2", "1");
            return sql;
        }

        public static DataTable IncomingRequests(int user)
        {
            throw new System.NotImplementedException();
        }
    }
}