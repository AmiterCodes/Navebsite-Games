using System.Data;

namespace NavebsiteDAL
{

    /// <summary>
    /// static class that deals with user database calls
    /// </summary>
    public class DbUser
    {
        /// <summary>
        /// Retrieves a list of all users that are signed up
        /// </summary>
        /// <returns>DataTable of all users</returns>
        public static DataTable AllUsers()
        {
            return DalHelper.AllFromTable("Users");
        }

        /// <summary>
        /// Gets a user by id
        /// </summary>
        /// <param name="user">id of user</param>
        /// <returns>DataRow of user data</returns>
        public static DataRow GetUserById(int user)
        {
            return DalHelper.GetRowById(user, "Users");
        }


        /// <summary>
        /// Gets a user by username
        /// </summary>
        /// <param name="username">username of user</param>
        /// <returns>DataRow of user data</returns>
        public static DataRow GetUserByName(string username)
        {
            return DalHelper.RowWhere("Users", "Username", username);
        }

        /// <summary>
        /// Method that checks if a user and password are valid for authentication 
        /// </summary>
        /// <param name="username">user</param>
        /// <param name="password">password</param>
        /// <returns>if the username password combination is valid</returns>
        public static bool Authenticate(string username, string password)
        {
            var tb = DalHelper.Select("SELECT HashPass FROM Users WHERE Username = '" + username + "'");

            if (tb.Rows.Count == 0) return false;

            var row = tb.Rows[0];
            var hash = (string) row["HashPass"];

            // Use the BCrypt library for verification
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static int InsertUser(string email, string username, string password)
        {
            return DalHelper.Insert(
                "INSERT INTO Users" +
                "(Email,Username,HashPass)" +
                $"VALUES('{email}','{username}', '{BCrypt.Net.BCrypt.EnhancedHashPassword(password)}')");
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