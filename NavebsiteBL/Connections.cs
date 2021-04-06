using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NavebsiteDAL;

namespace NavebsiteBL
{
    /// <summary>
    /// Class for connections between users and developers, 
    /// for both Friends and DeveloperInvitations connections
    /// </summary>
    public class Connections
    {


        /// <summary>
        /// Returns all friends for a certain user
        /// </summary>
        /// <param name="user">id of user</param>
        /// <returns></returns>
        public static List<User> GetFriends(int user)
        {
            var tb = DbConnections.GetFriendsOfUser(user);

            return (from DataRow row in tb.Rows select new User(row)).ToList();
        }

        /// <summary>
        /// returns all incoming developer requests for a user
        /// </summary>
        /// <param name="user">id of user</param>
        /// <returns></returns>
        public static List<Developer> IncomingDeveloperRequests(int user)
        {
            var tb = DbConnections.IncomingDeveloperRequests(user);
            return (from DataRow row in tb.Rows select new Developer(row)).ToList();
        }

        /// <summary>
        /// returns if exists an unfulfilled developer request to a user
        /// </summary>
        /// <param name="dev"></param>
        /// <param name="user">id of user</param>
        /// <returns>true if exists connection</returns>
        public static bool ExistsDeveloperRequest(int dev, int user)
        {
            return DbConnections.ExistsDeveloperRequest(dev, user);
        }

        /// <summary>
        /// get all outgoing developer request users
        /// </summary>
        /// <param name="developer">developer that sent requests</param>
        /// <returns>list of users</returns>
        public static List<User> OutgoingDeveloperRequests(int developer)
        {
            var tb = DbConnections.OutgoingDeveloperRequests(developer);
            return (from DataRow row in tb.Rows select new User(row)).ToList();
        }


        /// <summary>
        /// Gets all outgoing friend request users
        /// </summary>
        /// <param name="user">user who initiated requests</param>
        /// <returns>list of users</returns>
        public static List<User> OutgoingFriendRequests(int user)
        {
            var tb = DbConnections.OutgoingFriendRequests(user);
            return (from DataRow row in tb.Rows select new User(row)).ToList();
        }

        /// <summary>
        /// gets all incoming friend requests
        /// </summary>
        /// <param name="userId">id of user</param>
        /// <returns>list of incoming friend requests</returns>
        public static List<User> IncomingFriendRequests(int user)
        {
            var tb = DbConnections.IncomingRequests(user);
            return (from DataRow row in tb.Rows select new User(row)).ToList();
        }

        /// <summary>
        /// Accepts a dev request
        /// </summary>
        /// <param name="user">id of user</param>
        /// <param name="developer">id of developer</param>
        public static void FulfillRequest(int user, Developer developer)
        {
            developer.AddUser(user);
        }

        /// <summary>
        /// Denies a dev request
        /// </summary>
        /// <param name="user">id of user</param>
        /// <param name="developer">id of developer</param>
        public static void DenyRequest(int user, int developer)
        {
            DbConnections.FulfillRequest(user, developer);
        }

        /// <summary>
        ///     Returns a list of friends that play a game
        /// </summary>
        /// <param name="userId">id of user to check his friends</param>
        /// <param name="gameId">id of game that friends play</param>
        /// <returns>list of friend users</returns>
        public static List<User> FriendsThatPlayGame(int user, int game)
        {
            var tb = DbConnections.GetFriendsWhoPlayGame(user, game);
            return (from DataRow row in tb.Rows select new User(row)).ToList();
        }

        /// <summary>
        ///     check if a friend request exists
        /// </summary>
        /// <param name="user1">user that sent the request</param>
        /// <param name="user2">user that accepted the request</param>
        /// <returns>if friend request exists</returns>
        public static bool ExistsFriendRequest(int user1, int user2)
        {
            return DbConnections.ExistsFriendRequest(user1, user2);
        }

        /// <summary>
        ///     Sends a friend request from user1 to user2
        /// </summary>
        /// <param name="user1">user that sends the request</param>
        /// <param name="user2">user that receives the request</param>
        public static bool SendFriendRequest(int user1, int user2)
        {
            if (ExistsFriendRequest(user2, user1))
                DbConnections.AcceptFriendRequest(user2, user1);
            else if (!ExistsFriendRequest(user1, user2)) return DbConnections.SendFriendRequest(user1, user2);

            return true;
        }

        /// <summary>
        /// sends an invite from developer to user
        /// </summary>
        /// <param name="user">user invited</param>
        /// <param name="dev">developer to invite</param>
        /// <returns>true if went successful</returns>
        public static bool SendDeveloperInvite(int user, int dev)
        {
            return DbConnections.SendDeveloperInvite(user, dev);
        }

        /// <summary>
        ///     Removes the friend connection between user1 and user2
        /// </summary>
        /// <param name="user1">user that is connected</param>
        /// <param name="user2">user that is connected</param>
        /// <returns>if it did anything</returns>
        public static bool RemoveFriend(int user1, int user2)
        {
            return DbConnections.RemoveFriend(user1, user2);
        }

        /// <summary>
        /// checks if 2 users are friends
        /// </summary>
        /// <param name="user1">user 1</param>
        /// <param name="user2">user 2</param>
        /// <returns>true if user1 and user2 are friends</returns>
        public static bool AreFriends(User user1, User user2)
        {
            return AreFriends(user1.Id, user2.Id);
        }

        /// <summary>
        /// checks if 2 users are friends
        /// </summary>
        /// <param name="user1">id of user 1</param>
        /// <param name="user2">id of user 2</param>
        /// <returns>true if user1 and user2 are friends</returns>
        public static bool AreFriends(int user1Id, int user2Id)
        {
            return DbConnections.AreFriends(user1Id, user2Id);
        }

        /// <summary>
        ///     check if a friend request exists
        /// </summary>
        /// <param name="user1">user that sent the request</param>
        /// <param name="user2">user that accepted the request</param>
        /// <returns>if friend request exists</returns>
        public static bool ExistsFriendRequest(User user1, User user2)
        {
            return ExistsFriendRequest(user1.Id, user2.Id);
        }

        /// <summary>
        /// returns a list of mutual friends
        /// </summary>
        /// <param name="userId">id of first user</param>
        /// <param name="viewerId">id of second user</param>
        /// <returns>list of mutual friends</returns>
        public static List<User> GetMutualFriends(int userId, int viewerId)
        {
            List<User> first = GetFriends(userId);
            List<User> second = GetFriends(viewerId);

            var comparer = EqualityComparerFactory.Create<User>(
                user => user.Id.GetHashCode(), (a, b) => a.Id == b.Id);
            return first.Intersect(second, comparer).ToList();
        }

        /// <summary>
        /// gets a count of all incoming friend requests
        /// </summary>
        /// <param name="userId">id of user</param>
        /// <returns>amount of incoming friend requests</returns>
        public static int IncomingFriendRequestsCount(int userId)
        {

            return DbConnections.IncomingFriendRequestsCount(userId);
        }

        /// <summary>
        /// gets a count of all incoming dev requests
        /// </summary>
        /// <param name="userId">id of user</param>
        /// <returns>int amount of requests</returns>
        public static int IncomingDeveloperRequestsCount(int userId)
        {

            return DbConnections.IncomingDeveloperRequestsCount(userId);
        }
    }
}