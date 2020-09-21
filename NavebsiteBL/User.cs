using NavebsiteDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavebsiteBL
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
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

        public static List<User> AllUsers()
        {
            var users = new List<User>();
            foreach(DataRow row in DbUser.AllUsers().Rows)
            {
                users.Add(new User(row));
            }
            return users;
        }

        public void AddActivity(string text)
        {
            DbActivity.InsertActivity(text, Id);
        }

        public static User AuthUser(string username, string password)
        {
            if(DbUser.Authenticate(username, password))
            {
                return new User(DbUser.GetUserByName(username));
            }
            return null;
        }

        public static User RegisterUser(string username, string password)
        {
            var id = DbUser.InsertUser(username, password);
            return new User(id);
        }

        public User(int id) : this(DbUser.GetUserById(id))
        {
        }

        public User(DataRow dr)
        {
            if (dr == null) throw new InvalidOperationException();
            Id = (int)dr["ID"];
            Username = (string)dr["Username"];
            Description = (string)dr["Description"];
            Balance = (double)dr["Balance"];
            JoinDate = (DateTime)dr["Join Date"];
            ProfilePicture = (string)dr["Profile Picture"];
            Background = (string)dr["Background"];
            IsAdmin = (bool)dr["Admin"];
            IsDeveloper = (bool)dr["Developer"];
            if (IsDeveloper)
            {
                DeveloperId = (int)dr["DeveloperId"];
            }
            else
            {
                DeveloperId = -1;
            }
        }
    }
}
