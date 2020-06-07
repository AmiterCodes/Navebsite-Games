using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using NavebsiteDAL;

namespace NavebsiteBL
{
    public class Genre
    {

        public int ID { get; set; }
        public string GenreName { get; set; }

        public Genre(DataRow row)
        {
            if (row == null) throw new InvalidOperationException();

            this.ID = (int)row["ID"];
            this.GenreName = (string)row["Genre Name"];
        }

        public Genre(int id) : this(DBGenre.GetGenre(id))
        {

        }

    }
}
