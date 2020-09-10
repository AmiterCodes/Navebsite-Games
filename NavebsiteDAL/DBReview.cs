using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavebsiteDAL
{
    public class DBReview
    {
        public static DataTable ReviewsByGame(int gameId)
        {
            return DALHelper.Select("SELECT GameReviews.*, Users.Username, Games.[Game Name]" +
                " FROM Users INNER JOIN(Games INNER JOIN GameReviews ON Games.ID = GameReviews.Game) ON Users.ID = GameReviews.User" +
                $" WHERE Games.ID = {gameId}");
        }

        public static DataTable ReviewsByUser(int userId)
        {
            return DALHelper.Select("SELECT GameReviews.*, Users.Username, Games.[Game Name]" +
                " FROM Users INNER JOIN(Games INNER JOIN GameReviews ON Games.ID = GameReviews.Game) ON Users.ID = GameReviews.User" +
                $" WHERE Users.ID = {userId}");
        }

        public static int UpdateReview(string content, int gameId, int userId, int stars)
        {
            return DALHelper.Update($"UPDATE GameReviews SET Content = '{content}', Stars = {stars} WHERE Game={gameId} AND [User]={userId}");
        }

        public static int InsertReview(string content, int gameId, int userId, int stars)
        {
            return DALHelper.Insert($"INSERT INTO GameReviews (Content,Game,[User],Stars) VALUES ('{content}',{gameId},{userId},{stars})");
        }
    }
}
