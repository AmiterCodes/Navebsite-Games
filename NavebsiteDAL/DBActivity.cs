using System.Data;

namespace NavebsiteDAL
{
    public class DbActivity
    {
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

        public static void InsertActivity(string activity, int userId)
        {
            var sql = $"INSERT INTO UserActivity ([ActivityText],[User]) VALUES('{activity}',{userId})";
            DalHelper.Insert(sql);
        }

        public static DataRow GetActivity(int id)
        {
            return DalHelper.GetRowById(id, "UserActivity");
        }
    }
}