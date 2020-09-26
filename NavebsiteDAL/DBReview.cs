using System.Data;

namespace NavebsiteDAL
{
    public class DbReview
    {
        public static DataTable ReviewsByGame(int gameId)
        {
            return DalHelper.Select("SELECT GameReviews.*, Users.Username, Games.[Game Name]" +
                                    " FROM Users INNER JOIN(Games INNER JOIN GameReviews ON Games.ID = GameReviews.Game) ON Users.ID = GameReviews.User" +
                                    $" WHERE Games.ID = {gameId}");
        }

        public static DataTable ReviewsByUser(int userId)
        {
            return DalHelper.Select("SELECT GameReviews.*, Users.Username, Games.[Game Name]" +
                                    " FROM Users INNER JOIN(Games INNER JOIN GameReviews ON Games.ID = GameReviews.Game) ON Users.ID = GameReviews.User" +
                                    $" WHERE Users.ID = {userId}");
        }

        public static int UpdateReview(string content, int gameId, int userId, int stars)
        {
            return DalHelper.Update(
                $"UPDATE GameReviews SET Content = '{content}', Stars = {stars} WHERE Game={gameId} AND [User]={userId}");
        }

        public static int InsertReview(string content, int gameId, int userId, int stars)
        {
            return DalHelper.Insert(
                $"INSERT INTO GameReviews (Content,Game,[User],Stars) VALUES ('{content}',{gameId},{userId},{stars})");
        }
    }
}