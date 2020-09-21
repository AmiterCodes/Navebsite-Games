using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavebsiteDAL
{
    public class DBFriends
    {
        public static DataTable GetFriendsOfUser(int userId)
        {
            return DalHelper.Select("SELECT Users.* " +
                "FROM Users INNER JOIN UserFriends ON(Users.ID = UserFriends.[User 2]) " +
                $"WHERE [User 1] = {userId}; ");
        }

        public static DataTable GetFriendsWhoPlayGame(int userId, int gameId)
        {
            return DalHelper.Select("SELECT Users.* " +
                "FROM(Users INNER JOIN UserFriends ON Users.ID = UserFriends.[User 2]) INNER JOIN UserGames ON Users.ID = UserGames.[User] " +
                $"WHERE(((UserFriends.[User 1]) = {userId}) AND((UserGames.Game) = {gameId}));");
        }
        
    }
}
