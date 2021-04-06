using System.Data;
using NavebsiteDAL;

namespace NavebsiteBL
{
    /// <summary>
    /// represents a game developer company
    /// </summary>
    public class Developer
    {
        public int Id { get; set; }
        public string DeveloperName { get; set; }
        public string About { get; set; } = "";
        public string Icon { get; set; } = "";

        public string IconUrl => "./Images/DeveloperIcons/" + Icon;
        public string BackgroundUrl => "./Images/DeveloperBackgrounds/" + Background;
        public string Background { get; set; }

        /// <summary>
        /// creates a developer from datarow
        /// </summary>
        /// <param name="row">row of dev data</param>
        public Developer(DataRow row)
        {
            Id = (int) row["ID"];
            DeveloperName = (string) row["Developer Name"];
            About = (string) row["About"];
            Icon = (string) row["Icon"];
            Background = (string) row["Background"];
        }

        /// <summary>
        /// Returns a developer from id
        /// </summary>
        /// <param name="id">id of developer</param>
        public Developer(int id) : this(DbDeveloper.GetDeveloper(id))
        {
        }

        /// <summary>
        /// inserts a new developer into the database
        /// </summary>
        /// <param name="devName">name of developer</param>
        public Developer(string devName)
        {
            this.Id = DbDeveloper.AddDeveloper(devName);
            this.DeveloperName = devName;
        }

        /// <summary>
        /// Adds a user to a developer company
        /// </summary>
        /// <param name="userId">id of user</param>
        public void AddUser(int userId)
        {
            DbDeveloper.SetUserDeveloper(userId, this.Id);
            DbConnections.FulfillRequest(userId, this.Id);
        }


        /// <summary>
        /// Updates the data for the developer
        /// </summary>
        /// <param name="name">new developer name</param>
        /// <param name="about">new developer bio</param>
        public void UpdateData(string name, string about)
        {
            this.About = about;
            this.DeveloperName = name;
            DbDeveloper.UpdateData(name, about, Id);
        }

        /// <summary>
        /// updates the icon for the developer
        /// </summary>
        /// <param name="filename">filename of icon</param>
        public void UpdateIcon(string filename)
        {
            this.Icon = filename;
            DbDeveloper.UpdateIcon(filename, Id);
        }

        // <summary>
        /// updates the background for the developer
        /// </summary>
        /// <param name="filename">filename of background</param>
        public void UpdateBackground(string filename)
        {
            this.Background = filename;
            DbDeveloper.UpdateBackground(filename, Id);
        }
    }
}