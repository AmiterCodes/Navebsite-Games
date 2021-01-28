using System.Data;

namespace NavebsiteDAL
{
    public class DbReview
    {
        /// <summary>
        /// gets all reviews from a certain game
        /// </summary>
        /// <param name="gameId">id of game</param>
        /// <returns>DataTable of reviews</returns>
        public static DataTable ReviewsByGame(int gameId)
        {
            return DalHelper.Select("SELECT GameReviews.*, Users.Username, Games.[Game Name]" +
                                    " FROM Users INNER JOIN(Games INNER JOIN GameReviews ON Games.ID = GameReviews.Game) ON Users.ID = GameReviews.User" +
                                    $" WHERE Games.ID = {gameId}");
        }

        /// <summary>
        /// returns the average review rating
        /// </summary>
        /// <param name="gameId">id of game</param>
        /// <returns>double with the average rating in stars, e.g 4.7</returns>
        public static double AverageRating(int gameId)
        {
            DataTable tb = DalHelper.Select($@"SELECT Avg(GameReviews.Stars) AS Rating
FROM GameReviews
WHERE Game = {gameId}
GROUP BY GameReviews.Game;");
            if (tb.Rows.Count == 0) return -1;
            return (double) tb.Rows[0][0];
        }

        /// <summary>
        /// gets all reviews from a certain
        /// </summary>
        /// <param name="userId">id of user</param>
        /// <returns>DataTable of reviews</returns>
        public static DataTable ReviewsByUser(int userId)
        {
            return DalHelper.Select("SELECT GameReviews.*, Users.Username, Games.[Game Name]" +
                                    " FROM Users INNER JOIN(Games INNER JOIN GameReviews ON Games.ID = GameReviews.Game) ON Users.ID = GameReviews.User" +
                                    $" WHERE Users.ID = {userId}");
        }

        /// <summary>
        /// updates an existing review
        /// </summary>
        /// <param name="content">content of review</param>
        /// <param name="gameId">id of game</param>
        /// <param name="userId">id of user</param>
        /// <param name="stars">stars from 1-5</param>
        /// <returns>rows affected</returns>
        public static int UpdateReview(string content, int gameId, int userId, int stars)
        {
            return DalHelper.Update(
                $"UPDATE GameReviews SET Content = '{content}', Stars = {stars} WHERE Game={gameId} AND [User]={userId}");
        }

        /// <summary>
        /// inserts a new review into the database
        /// </summary>
        /// <param name="content">content of review</param>
        /// <param name="gameId">id of game</param>
        /// <param name="userId">id of user</param>
        /// <param name="stars">stars from 1-5</param>
        /// <returns>id of new review</returns>
        public static int InsertReview(string content, int gameId, int userId, int stars)
        {
            return DalHelper.Insert(
                $"INSERT INTO GameReviews (Content,Game,[User],Stars) VALUES ('{content}',{gameId},{userId},{stars})");
        }
    }
}