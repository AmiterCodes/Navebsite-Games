using System.Data;

namespace NavebsiteDAL
{
    /// <summary>
    /// DB class for friends and developer connection related data fetching
    /// </summary>
    public class DbConnections
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

        /// <summary>
        /// checks if 2 users are friends
        /// </summary>
        /// <param name="user1">id of user 1</param>
        /// <param name="user2">id of user 2</param>
        /// <returns>true if user1 and user2 are friends</returns>
        public static bool AreFriends(int user1, int user2)
        {
            return DalHelper.RowExists(
                $"SELECT [User 1] FROM UserFriends WHERE (([User 1] = {user1} AND [User 2] = {user2}) " +
                $"OR ([User 1] = {user2} AND [User 2] = {user1})) AND Type = TRUE");
        }


        /// <summary>
        /// checks if exists a friend connection, including a sent request between 2 users
        /// </summary>
        /// <param name="user1">id of user 1</param>
        /// <param name="user2">id of user 2</param>
        /// <returns></returns>
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
                                    $" OR ([User 2] = {user1} AND [User 1] = {user2}))") > 0;
        }


        private static string AllDirections(string selectDirection)
        {
            var sql = selectDirection.Replace("$1", "1").Replace("$2", "2")
                      + " UNION ALL "
                      + selectDirection.Replace("$1", "2").Replace("$2", "1");
            return sql;
        }

        /// <summary>
        /// Gets all incoming friend request users
        /// </summary>
        /// <param name="user">user that has the requests to</param>
        /// <returns>dataTable of users</returns>
        public static DataTable IncomingRequests(int user)
        {
            var sql = $@"(SELECT Users.*
                FROM Users INNER JOIN UserFriends ON Users.ID = UserFriends.[User 1]
            WHERE(((UserFriends.[User 2]) ={user}) AND((UserFriends.Type) = FALSE)))";

            return DalHelper.Select(sql);
        }

        /// <summary>
        /// get all outgoing developer request users
        /// </summary>
        /// <param name="developer">developer that sent requests</param>
        /// <returns>dataTable of users</returns>
        public static DataTable OutgoingDeveloperRequests(int developer)
        {
            var sql = $@"(SELECT Users.*
                FROM Users INNER JOIN DeveloperInvitations ON Users.ID = DeveloperInvitations.[To]
            WHERE(((DeveloperInvitations.[From]) ={developer}) AND((DeveloperInvitations.Fulfilled) = FALSE)))";

            return DalHelper.Select(sql);
        }

        /// <summary>
        /// Gets all incoming developer request developers
        /// </summary>
        /// <param name="user">user that is requested</param>
        /// <returns>dataTable of developers</returns>
        public static DataTable IncomingDeveloperRequests(int user)
        {
            var sql = $@"(SELECT Developer.*
                FROM Developer INNER JOIN DeveloperInvitations ON Developer.ID = DeveloperInvitations.[From]
            WHERE(((DeveloperInvitations.[To]) ={user}) AND((DeveloperInvitations.Fulfilled) = FALSE)))";

            return DalHelper.Select(sql);
        }

        /// <summary>
        /// Gets all outgoing friend request users
        /// </summary>
        /// <param name="user">user who initiated requests</param>
        /// <returns>dataTable of users</returns>
        public static DataTable OutgoingFriendRequests(int user)
        {
            var sql = $@"(SELECT Users.*
                FROM Users INNER JOIN UserFriends ON Users.ID = UserFriends.[User 2]
            WHERE(((UserFriends.[User 1]) ={user}) AND((UserFriends.Type) = FALSE)))";

            return DalHelper.Select(sql);
        }

        /// <summary>
        /// Fulfills developer invitation
        /// </summary>
        /// <param name="userId">id of user</param>
        /// <param name="developer">id of developer</param>
        public static void FulfillRequest(int userId, int developer)
        {
            DalHelper.UpdateWhere("DeveloperInvitations", "Fulfilled", true, "To", userId, "From", developer);
        }

        /// <summary>
        /// sends an invite from developer to user
        /// </summary>
        /// <param name="user">user invited</param>
        /// <param name="dev">developer to invite</param>
        /// <returns>true if went successful</returns>
        public static bool SendDeveloperInvite(int user, int dev)
        {
            return DalHelper.Insert($"INSERT INTO DeveloperInvitations ([From], [To], Fulfilled) VALUES ({dev},{user},FALSE)") != -1;
        }

        /// <summary>
        /// returns if exists an unfulfilled developer request from develoepr to user
        /// </summary>
        /// <param name="dev">id of developer</param>
        /// <param name="user">user invited</param>
        /// <returns>true if exists else false</returns>
        public static bool ExistsDeveloperRequest(int dev, int user)
        {
            return DalHelper.Select($"SELECT ID FROM DeveloperInvitations WHERE [From] = {dev} AND [To] = {user} AND Fulfilled = FALSE").Rows.Count > 0;
        }

        /// <summary>
        /// gets a count of all incoming dev requests
        /// </summary>
        /// <param name="userId">id of user</param>
        /// <returns>int amount of requests</returns>
        public static int IncomingDeveloperRequestsCount(int userId)
        {
            return DalHelper.Select($"SELECT ID FROM DeveloperInvitations WHERE [To] = {userId} AND Fulfilled = FALSE").Rows.Count;
        }

        /// <summary>
        /// gets a count of all incoming friend requests
        /// </summary>
        /// <param name="userId">id of user</param>
        /// <returns>amount of incoming friend requests</returns>
        public static int IncomingFriendRequestsCount(int userId)
        {
            return DalHelper.Select($"SELECT [User 1] FROM UserFriends WHERE [User 2] = {userId} AND [Type] = FALSE").Rows.Count;
        }
    }
}