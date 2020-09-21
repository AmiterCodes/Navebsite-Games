using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using NavebsiteDAL;

namespace NavebsiteBL
{
    [Serializable]
    public class Genre
    {

        public int Id { get; set; }
        public string GenreName { get; set; }

        public Genre(string genreName)
        {
            this.GenreName = genreName;
            Id = DbGenre.InsertGenre(GenreName);
        }

        public Genre(int id, string genreName)
        {
            this.Id = id;
            this.GenreName = genreName;

        }



        public Genre(DataRow row)
        {
            if (row == null) throw new InvalidOperationException();

            this.Id = (int)row["ID"];
            this.GenreName = (string)row["Genre Name"];
        }

        public static List<Genre> AllGenres()
        {
            var list = new List<Genre>();
            foreach(DataRow row in DbGenre.AllGenres().Rows)
            {
                list.Add(new Genre(row));
            }
            return list;
        }
        public Genre(int id) : this(DbGenre.GetGenre(id))
        {

        }

    }
}
