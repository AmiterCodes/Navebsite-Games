using System.Data;
using NavebsiteDAL;

namespace NavebsiteBL
{
    public class Developer
    {
        public Developer(DataRow row)
        {
            Id = (int) row["ID"];
            DeveloperName = (string) row["Developer Name"];
            About = (string) row["About"];
            Icon = (string) row["Icon"];
            Background = (string) row["Background"];
        }

        public Developer(int id) : this(DbDeveloper.GetDeveloper(id))
        {
        }

        public Developer(string devName)
        {
            this.Id = DbDeveloper.AddDeveloper(devName);
            this.DeveloperName = devName;
        }

        public void AddUser(int userId)
        {
            DbDeveloper.SetUserDeveloper(userId, this.Id);
            DbConnections.FulfillRequest(userId, this.Id);
        }

        public int Id { get; set; }
        public string DeveloperName { get; set; }
        public string About { get; set; } = "";
        public string Icon { get; set; } = "";

        public string IconUrl => "./Images/DeveloperIcons/" + Icon;
        public string BackgroundUrl => "./Images/DeveloperBackgrounds/" + Background;
        public string Background { get; set; }

        public void UpdateData(string name, string about)
        {
            this.About = about;
            this.DeveloperName = name;
            DbDeveloper.UpdateData(name, about, Id);
        }

        public void UpdateIcon(string filename)
        {
            this.Icon = filename;
            DbDeveloper.UpdateIcon(filename, Id);
        }

        public void UpdateBackground(string filename)
        {
            this.Background = filename;
            DbDeveloper.UpdateBackground(filename, Id);
        }
    }
}