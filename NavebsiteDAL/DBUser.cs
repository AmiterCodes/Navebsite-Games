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

        public static bool UpdatePassword(string password, int user)
        {
            string hash = BCrypt.Net.BCrypt.EnhancedHashPassword(password);

            return DalHelper.UpdateWhere("Users", "HashPass", hash, "ID", user) > 0;
        }

        public static void UpdateDescription(string desc, int user)
        {
            DalHelper.UpdateWhere("Users", "Description", desc, "ID", user);
        }

        public static void UpdateBackground(string filename, int user)
        {
            DalHelper.UpdateWhere("Users", "Background", filename, "ID", user);
        }

        public static void UpdateProfilePicture(string filename, int user)
        {
            DalHelper.UpdateWhere("Users", "Profile Picture", filename, "ID", user);
        }

        public static void UpdateBalance(double newBalance, int user)
        {
            DalHelper.UpdateWhere("Users", "Balance", newBalance, "ID", user);
        }
    }
}