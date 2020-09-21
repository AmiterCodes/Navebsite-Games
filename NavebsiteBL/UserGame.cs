using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavebsiteDAL;

namespace NavebsiteBL
{
    public class UserGame : Game
    {
        public int UserId { get; set; }
        public DateTime Timestamp { get; set; }

        public static bool GameOwnedByUser(int gameId, int userId)
        {
            return DbUserGames.GameOwnedByUser(gameId, userId);
        }

        public static List<UserGame> UserGames(int user)
        {
            return (from DataRow row in DbUserGames.GetUserGames(user).Rows select new UserGame(row)).ToList();
        }
        

        public string BoughtString => "Bought " + Timestamp.ToShortDateString();

        public UserGame(DataRow dr) : base(dr)
        {
            UserId = (int)dr["User"];
            Timestamp = (DateTime)dr["Timestamp"];
        }
    }
}
