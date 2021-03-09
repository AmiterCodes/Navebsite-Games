using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using NavebsiteDAL;

namespace NavebsiteBL
{
    public class User
    {
        public User(int id) : this(DbUser.GetUserById(id))
        {
        }

        public override bool Equals(object obj)
        {
            if (!(obj is User)) return false;
            User user = (User) obj;
            return user.Id == this.Id;
        }

        public override int GetHashCode() => base.GetHashCode();

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


        public void UpdateBalance(double newBalance)
        {
            this.Balance = newBalance;
            DbUser.UpdateBalance(newBalance, Id);
        }

        public void UpdateDescription(string desc)
        {
            this.Description = desc;
            DbUser.UpdateDescription(desc, Id);
        }

        public void UpdateProfilePicture(string filename)
        {
            this.ProfilePicture = filename;
            DbUser.UpdateProfilePicture(filename, Id);
        }

        public void UpdateBackground(string filename)
        {
            this.Background = filename;
            DbUser.UpdateBackground(filename, Id);
        }

        public bool UpdatePassword(string password)
        {
            return DbUser.UpdatePassword(password, Id);
        }

        public static List<User> AllUsers()
        {
            return (from DataRow row in DbUser.AllUsers().Rows select new User(row)).ToList();
        }

        public void AddActivity(string text)
        {
            DbActivity.InsertActivity(text, Id);
        }

        public static User AuthUser(string username, string password)
        {
            return DbUser.Authenticate(username, password) ? new User(DbUser.GetUserByName(username)) : null;
        }

        public static User RegisterUser(string email, string username, string password)
        {
            var id = DbUser.InsertUser(email ,username, password);
            return new User(id);
        }

        public static bool ExistsWhereUsername(string username)
        {
            return AllUsers().Any(user => user.Username.ToLower() == username.ToLower());
        }

        public static bool ExistsWhereEmail(string email)
        {
            return AllUsers().Any(user => user.Email.ToLower() == email.ToLower());
        }

    }
}