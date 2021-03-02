using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NavebsiteDAL;

namespace NavebsiteBL
{
    public class Friends
    {
        public static List<User> GetFriends(int user)
        {
            var tb = DbFriends.GetFriendsOfUser(user);

            return (from DataRow row in tb.Rows select new User(row)).ToList();
        }

        public static List<User> FriendsThatPlayGame(int user, int game)
        {
            var tb = DbFriends.GetFriendsWhoPlayGame(user, game);
            return (from DataRow row in tb.Rows select new User(row)).ToList();
        }

        public static bool ExistsFriendRequest(int user1, int user2)
        {
            return DbFriends.ExistsFriendRequest(user1, user2);
        }

        public static bool SendFriendRequest(int user1, int user2)
        {
            if (ExistsFriendRequest(user2, user1))
                DbFriends.AcceptFriendRequest(user2, user1);
            else if (!ExistsFriendRequest(user1, user2)) return DbFriends.SendFriendRequest(user1, user2);

            return true;
        }

        public static bool RemoveFriend(int user1, int user2)
        {
            return DbFriends.RemoveFriend(user1, user2);
        }

        public static bool AreFriends(User user1, User user2)
        {
            return AreFriends(user1.Id, user2.Id);
        }

        public static bool AreFriends(int user1Id, int user2Id)
        {
            return DbFriends.AreFriends(user1Id, user2Id);
        }

        public static bool ExistsFriendRequest(User user1, User user2)
        {
            return ExistsFriendRequest(user1.Id, user2.Id);
        }

        public static List<User> GetMutualFriends(int userId, int viewerId)
        {
            List<User> first = GetFriends(userId);
            List<User> second = GetFriends(viewerId);

            return first.Intersect(second).ToList();
        }
    }
}