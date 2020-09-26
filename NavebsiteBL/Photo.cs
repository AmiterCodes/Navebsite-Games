using System.Data;

namespace NavebsiteBL
{
    public class Photo
    {
        public Photo()
        {
            Id = -1;
        }

        public Photo(DataRow dr)
        {
            Id = (int) dr["ID"];
            Image = (string) dr["Photo"];
        }

        public int Id { get; set; }
        public string Image { get; set; }
        public string PhotoUrl => "./Images/Photos/" + Image;
    }
}