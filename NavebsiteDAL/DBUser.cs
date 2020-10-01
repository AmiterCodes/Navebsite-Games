using System.Data;

namespace NavebsiteDAL
{
    public class DbUser
    {
        public static DataTable AllUsers()
        {
            return DalHelper.AllFromTable("Users");
        }

        public static DataRow GetUserById(int user)
        {
            return DalHelper.GetRowById(user, "Users");
        }



        public static DataRow GetUserByName(string username)
        {
            return DalHelper.RowWhere("Users", "Username", username);
        }

        public static bool Authenticate(string username, string password)
        {
            var tb = DalHelper.Select("SELECT HashPass FROM Users WHERE username = '" + username + "'");

            if (tb.Rows.Count == 0) return false;

            var row = tb.Rows[0];
            var hash = (string) row["HashPass"];

            return BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
        }

        public static int InsertUser(string username, string password)
        {
            return DalHelper.Insert(
                "INSERT INTO Users" +
                "(Username,HashPass)" +
                $"VALUES('{username}', '{BCrypt.Net.BCrypt.EnhancedHashPassword(password)}')");
        }

        public static void UpdatePassword(string password)
        {
            throw new System.NotImplementedException();
        }

        public static void UpdateDescription(string desc, int user)
        {
            DalHelper.UpdateWhere("Users", "Description", desc, "ID", user);
        }
    }
}