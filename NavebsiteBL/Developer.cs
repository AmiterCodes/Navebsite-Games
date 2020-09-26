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

        public int Id { get; set; }
        public string DeveloperName { get; set; }
        public string About { get; set; }
        public string Icon { get; set; }

        public string IconUrl => "./Images/DeveloperIcons/" + Icon;
        public string BackgroundUrl => "./Images/DeveloperBackgrounds/" + Background;
        public string Background { get; set; }
    }
}