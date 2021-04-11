using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using NavebsiteDAL;

namespace NavebsiteBL
{
    /// <summary>
    /// represents a user
    /// </summary>
    public class User
    {
        /// <summary>
        /// creates a user from database by id
        /// </summary>
        /// <param name="id">id of user</param>
        public User(int id) : this(DbUser.GetUserById(id))
        {
        }

        /// <summary>
        /// compares 2 users to check if they're equal by id
        /// </summary>
        /// <param name="obj">other user</param>
        /// <returns>true if they're equal by id else false</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is User)) return false;
            User user = (User) obj;
            return user.Id == this.Id;
        }

        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// creates a user from dataRow
        /// </summary>
        /// <param name="dr">dataRow of user</param>
        public User(DataRow dr)
        {
            if (dr == null) throw new InvalidOperationException();
            Id = (int) dr["ID"];
            Username = (string) dr["Username"];
            Description = (string) dr["Description"];
            Balance = (double) dr["Balance"];
            JoinDate = (DateTime) dr["Join Date"];
            ProfilePicture = (string) dr["Profile Picture"];
            Background = (string) dr["Background"];
            Email = (string) dr["Email"];
            IsAdmin = (bool) dr["Admin"];
            IsDeveloper = (bool) dr["Developer"];
            if (IsDeveloper)
                DeveloperId = (int) dr["DeveloperId"];
            else
                DeveloperId = -1;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public double Balance { get; set; }
        public DateTime JoinDate { get; set; }
        public string ProfilePicture { get; set; }
        public string Background { get; set; }

        public bool IsAdmin { get; set; }
        public bool IsDeveloper { get; set; }

        public int DeveloperId { get; set; }

        public List<Activity> Activities => Activity.UserActivities(Id);
        public string ProfilePictureUrl => "./Images/UserProfiles/" + ProfilePicture;
        public string BackgroundUrl => "./Images/UserBackgrounds/" + Background;

        /// <summary>
        /// updates the balance for a user
        /// </summary>
        /// <param name="newBalance">new balance that the user should have</param>
        public void UpdateBalance(double newBalance)
        {
            this.Balance = newBalance;
            DbUser.UpdateBalance(newBalance, Id);
        }

        /// <summary>
        /// updates user description
        /// </summary>
        /// <param name="desc">new description</param>
        public void UpdateDescription(string desc)
        {
            this.Description = desc;
            DbUser.UpdateDescription(desc, Id);
        }

        /// <summary>
        /// updates profile picture for user
        /// </summary>
        /// <param name="filename">file of picture</param>
        public void UpdateProfilePicture(string filename)
        {
            this.ProfilePicture = filename;
            DbUser.UpdateProfilePicture(filename, Id);
        }

        /// <summary>
        /// updates background for user
        /// </summary>
        /// <param name="filename">filename for background</param>
        public void UpdateBackground(string filename)
        {
            this.Background = filename;
            DbUser.UpdateBackground(filename, Id);
        }

        /// <summary>
        /// updates the user's password
        /// </summary>
        /// <param name="password">password of user</param>
        /// <returns>true if successful</returns>
        public bool UpdatePassword(string password)
        {
            return DbUser.UpdatePassword(password, Id);
        }

        /// <summary>
        /// lists all users on site
        /// </summary>
        /// <returns>list of user</returns>
        public static List<User> AllUsers()
        {
            return (from DataRow row in DbUser.AllUsers().Rows select new User(row)).ToList();
        }

        /// <summary>
        /// adds an activity for this user
        /// </summary>
        /// <param name="text">text of activity</param>
        public void AddActivity(string text)
        {
            DbActivity.InsertActivity(text, Id);
        }

        /// <summary>
        /// checks if user login info is correct
        /// </summary>
        /// <param name="username">username of user</param>
        /// <param name="password">password of user</param>
        /// <returns>User object, that is null if authentication didn't work</returns>
        public static User AuthUser(string username, string password)
        {
            return DbUser.Authenticate(username, password) ? new User(DbUser.GetUserByName(username)) : null;
        }

        /// <summary>
        /// registers a user
        /// </summary>
        /// <param name="email">email of user</param>
        /// <param name="username">username of user</param>
        /// <param name="password">password of user</param>
        /// <returns></returns>
        public static User RegisterUser(string email, string username, string password)
        {
            var id = DbUser.InsertUser(email ,username, password);
            return new User(id);
        }
        
        /// <summary>
        /// check if a user exists with a certain username
        /// </summary>
        /// <param name="username">username to check</param>
        /// <returns>true if a user with that username exists already</returns>
        public static bool ExistsWhereUsername(string username)
        {
            return AllUsers().Any(user => user.Username.ToLower() == username.ToLower());
        }
        /// <summary>
        /// check if a user exists with a certain email
        /// </summary>
        /// <param name="email">email to check</param>
        /// <returns>true if a user with that email exists already</returns>
        public static bool ExistsWhereEmail(string email)
        {
            return AllUsers().Any(user => user.Email.ToLower() == email.ToLower());
        }

    }
}