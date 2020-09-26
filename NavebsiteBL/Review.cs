using System.Collections.Generic;
using System.Data;
using NavebsiteDAL;

namespace NavebsiteBL
{
    public class Review
    {
        public Review(string content, int gameId, int userId, int stars)
        {
            Content = content;
            GameId = gameId;
            UserId = userId;
            Stars = stars;

            if (DbReview.UpdateReview(content, gameId, userId, stars) == 0)
                DbReview.InsertReview(content, gameId, userId, stars);
        }

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

        public static List<Review> ReviewsByGame(int gameId)
        {
            var list = new List<Review>();

            foreach (DataRow row in DbReview.ReviewsByGame(gameId).Rows) list.Add(new Review(row));
            return list;
        }

        public static List<Review> ReviewsByUser(int userId)
        {
            var list = new List<Review>();

            foreach (DataRow row in DbReview.ReviewsByGame(userId).Rows) list.Add(new Review(row));
            return list;
        }
    }
}