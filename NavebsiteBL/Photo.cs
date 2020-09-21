using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavebsiteBL
{
    public class Photo
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string PhotoUrl => "./Images/Photos/" + Image;

        public Photo()
        {
            Id = -1;
        }

        public Photo(DataRow dr)
        {
            Id = (int)dr["ID"];
            Image = (string)dr["Photo"];
        }
    }
}
