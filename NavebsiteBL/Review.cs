using System.Collections.Generic;
using System.Data;
using NavebsiteDAL;

namespace NavebsiteBL
{
 
    /// <summary>
    /// represents a user written review over a game
    /// </summary>
    public class Review
    {
        /// <summary>
        /// inserts or updates a review in the database depending if the user already submitted a review for a game
        /// </summary>
        /// <param name="content">content of review</param>
        /// <param name="gameId">id of game</param>
        /// <param name="userId">id of user</param>
        /// <param name="stars">start amount between 1-5</param>
        public Review(string content, int gameId, int userId, int stars)
        {
            Content = content;
            GameId = gameId;
            UserId = userId;
            Stars = stars;

            if (DbReview.UpdateReview(content, gameId, userId, stars) == 0)
                DbReview.InsertReview(content, gameId, userId, stars);
        }

        /// <summary>
        /// generates a review from dataRow
        /// </summary>
        /// <param name="dr">dataRow of review</param>
        public Review(DataRow dr)
        {
            Id = (int) dr["ID"];
            Content = (string) dr["Content"];
            GameId = (int) dr["Game"];
            UserId = (int) dr["User"];
            Stars = (int) dr["Stars"];
            GameName = (string) dr["Game Name"];
            Username = (string) dr["Username"];
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }
        public int Stars { get; set; }

        public string GameName { get; set; }
        public string Username { get; set; }

        /// <summary>
        /// returns a list of all reviews for a game
        /// </summary>
        /// <param name="gameId">id of game</param>
        /// <returns>list of reviews</returns>
        public static List<Review> ReviewsByGame(int gameId)
        {
            var list = new List<Review>();

            foreach (DataRow row in DbReview.ReviewsByGame(gameId).Rows) list.Add(new Review(row));
            return list;
        }

        /// <summary>
        /// returns a list of reviews by user
        /// </summary>
        /// <param name="userId">id of user</param>
        /// <returns>list of reviews</returns>
        public static List<Review> ReviewsByUser(int userId)
        {
            var list = new List<Review>();

            foreach (DataRow row in DbReview.ReviewsByUser(userId).Rows) list.Add(new Review(row));
            return list;
        }
    }
}