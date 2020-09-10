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
            return DBUserGames.GameOwnedByUser(gameId, userId);
        }

        public static List<UserGame> UserGames(int user)
        {
            List<UserGame> list = new List<UserGame>();
            foreach(DataRow row in DBUserGames.GetUserGames(user).Rows)
            {
                list.Add(new UserGame(row));
            }
            return list;
        }

        public static DataTable UserGameData() {
            return DBUserGames.AllUserGames();
        }

        public string BoughtString { get => "Bought " + Timestamp.ToShortDateString(); }

        public UserGame(DataRow dr) : base(dr)
        {
            UserId = (int)dr["User"];
            Timestamp = (DateTime)dr["Timestamp"];
        }
    }
}
