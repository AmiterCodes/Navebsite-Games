using System.Data;

namespace NavebsiteDAL
{
    /// <summary>
    /// DB class for user activity-related data fetching
    /// </summary>
    public class DbActivity
    {
        /// <summary>
        /// returns all activity from user
        /// </summary>
        /// <param name="user">id of user</param>
        /// <returns>DataTable of user activity</returns>
        public static DataTable UserActivity(int user)
        {
            return DalHelper.Select($@"
SELECT TOP 30
*
FROM UserActivity
WHERE User = {user}
ORDER BY Timestamp DESC;
");
        }

        /// <summary>
        /// Inserts a new user activity
        /// </summary>
        /// <param name="activity">activity string</param>
        /// <param name="userId">id of user</param>
        public static void InsertActivity(string activity, int userId)
        {
            var sql = $"INSERT INTO UserActivity ([ActivityText],[User]) VALUES('{activity}',{userId})";
            DalHelper.Insert(sql);
        }


        /// <summary>
        /// gets an activity by id
        /// </summary>
        /// <param name="id">id of activity</param>
        /// <returns>DataRow of activity</returns>
        public static DataRow GetActivity(int id)
        {
            return DalHelper.GetRowById(id, "UserActivity");
        }
    }
}