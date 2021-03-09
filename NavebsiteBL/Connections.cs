using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NavebsiteDAL;

namespace NavebsiteBL
{
    public class Connections
    {

        
        public static List<User> GetFriends(int user)
        {
            var tb = DbConnections.GetFriendsOfUser(user);

            return (from DataRow row in tb.Rows select new User(row)).ToList();
        }

        public static List<Developer> IncomingDeveloperRequests(int user)
        {
            var tb = DbConnections.IncomingDeveloperRequests(user);
            return (from DataRow row in tb.Rows select new Developer(row)).ToList();
        }

        public static bool ExistsDeveloperRequest(int dev, int user)
        {
            return DbConnections.ExistsDeveloperRequest(dev, user);
        }

        public static List<User> OutgoingDeveloperRequests(int developer)
        {
            var tb = DbConnections.OutgoingDeveloperRequests(developer);
            return (from DataRow row in tb.Rows select new User(row)).ToList();
        }

        public static List<User> OutgoingFriendRequests(int user)
        {
            var tb = DbConnections.OutgoingFriendRequests(user);
            return (from DataRow row in tb.Rows select new User(row)).ToList();
        }

        public static List<User> IncomingFriendRequests(int user)
        {
            var tb = DbConnections.IncomingRequests(user);
            return (from DataRow row in tb.Rows select new User(row)).ToList();
        }

        public static void FulfillRequest(int user, Developer developer)
        {
            developer.AddUser(user);
        }

        public static void DenyRequest(int user, int developer)
        {
            DbConnections.FulfillRequest(user, developer);
        }

        public static List<User> FriendsThatPlayGame(int user, int game)
        {
            var tb = DbConnections.GetFriendsWhoPlayGame(user, game);
            return (from DataRow row in tb.Rows select new User(row)).ToList();
        }

        public static bool ExistsFriendRequest(int user1, int user2)
        {
            return DbConnections.ExistsFriendRequest(user1, user2);
        }

        public static bool SendFriendRequest(int user1, int user2)
        {
            if (ExistsFriendRequest(user2, user1))
                DbConnections.AcceptFriendRequest(user2, user1);
            else if (!ExistsFriendRequest(user1, user2)) return DbConnections.SendFriendRequest(user1, user2);

            return true;
        }

        public static bool SendDeveloperInvite(int user, int dev)
        {
            return DbConnections.SendDeveloperInvite(user, dev);
        }

        public static bool RemoveFriend(int user1, int user2)
        {
            return DbConnections.RemoveFriend(user1, user2);
        }

        public static bool AreFriends(User user1, User user2)
        {
            return AreFriends(user1.Id, user2.Id);
        }

        public static bool AreFriends(int user1Id, int user2Id)
        {
            return DbConnections.AreFriends(user1Id, user2Id);
        }

        public static bool ExistsFriendRequest(User user1, User user2)
        {
            return ExistsFriendRequest(user1.Id, user2.Id);
        }

        public static List<User> GetMutualFriends(int userId, int viewerId)
        {
            List<User> first = GetFriends(userId);
            List<User> second = GetFriends(viewerId);

            var comparer = EqualityComparerFactory.Create<User>(
                user => user.Id.GetHashCode(), (a, b) => a.Id == b.Id);
            return first.Intersect(second, comparer).ToList();
        }

        public static int IncomingFriendRequestsCount(int userId)
        {

            return DbConnections.IncomingFriendRequestsCount(userId);
        }

        public static int IncomingDeveloperRequestsCount(int userId)
        {

            return DbConnections.IncomingDeveloperRequestsCount(userId);
        }
    }
}