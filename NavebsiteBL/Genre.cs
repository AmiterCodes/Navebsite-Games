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

        public static int InsertGameGenre(Genre genre, int gameId)
        {
            return DbGenre.InsertGameGenre(genre.Id,gameId);
        }
        
        public static List<Genre> AllGenres()
        {
            return (from DataRow row in DbGenre.AllGenres().Rows select new Genre(row)).ToList();
        }
        public Genre(int id) : this(DbGenre.GetGenre(id))
        {

        }

    }
}
