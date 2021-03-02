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
        /// Inserts a user into the database
        /// </summary>
        /// <param name="email">email of the user</param>
        /// <param name="username">username of the user</param>
        /// <param name="password">plaintext password of the user</param>
        /// <returns>id of new user</returns>
        public static int InsertUser(string email, string username, string password)
        {
            return DalHelper.Insert(
                "INSERT INTO Users" +
                "(Email,Username,HashPass)" +
                $"VALUES('{email}','{username}', '{BCrypt.Net.BCrypt.EnhancedHashPassword(password)}')");
        }


        /// <summary>
        /// updates the password in the database
        /// </summary>
        /// <param name="password">new plaintext password</param>
        /// <param name="user">id of user</param>
        /// <returns>true if it changed anything</returns>
        public static bool UpdatePassword(string password, int user)
        {
            string hash = BCrypt.Net.BCrypt.EnhancedHashPassword(password);

            return DalHelper.UpdateWhere("Users", "HashPass", hash, "ID", user) > 0;
        }

        /// <summary>
        /// updates the description of a user in the database
        /// </summary>
        /// <param name="desc">new description</param>
        /// <param name="user">user id</param>
        public static void UpdateDescription(string desc, int user)
        {
            DalHelper.UpdateWhere("Users", "Description", desc, "ID", user);
        }

        /// <summary>
        /// updates the background of a user in the database
        /// </summary>
        /// <param name="filename">name of the file</param>
        /// <param name="user">user id</param>
        public static void UpdateBackground(string filename, int user)
        {
            DalHelper.UpdateWhere("Users", "Background", filename, "ID", user);
        }

        /// <summary>
        /// updates the profile picture of a user in the database
        /// </summary>
        /// <param name="filename">name of the file</param>
        /// <param name="user">user id</param>
        public static void UpdateProfilePicture(string filename, int user)
        {
            DalHelper.UpdateWhere("Users", "Profile Picture", filename, "ID", user);
        }

        /// <summary>
        /// updates the balance of the user
        /// </summary>
        /// <param name="newBalance">new balance of user</param>
        /// <param name="user">user id</param>
        public static void UpdateBalance(double newBalance, int user)
        {
            DalHelper.UpdateWhere("Users", "Balance", newBalance, "ID", user);
        }
    }
}