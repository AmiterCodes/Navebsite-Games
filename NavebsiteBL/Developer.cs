using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavebsiteDAL;
namespace NavebsiteBL
{
    public class Developer
    {
        public int ID { get; set; }
        public string DeveloperName { get; set; }
        public string About { get; set; }
        public string Icon { get; set; }

        public string IconUrl { get => "./Images/DeveloperIcons/" + Icon; }
        public string BackgroundUrl { get => "./Images/DeveloperBackgrounds/" + Background; }
        public string Background { get; set; }

        public Developer(DataRow row)
        {
            ID = (int)row["ID"];
            DeveloperName = (string)row["Developer Name"];
            About = (string)row["About"];
            Icon = (string)row["Icon"];
            Background = (string)row["Background"];
        }

        public Developer(int id) : this(DBDeveloper.GetDeveloper(id))
        {

        }
            
    }
}
