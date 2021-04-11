using System.Data;

namespace NavebsiteBL
{
    /// <summary>
    /// represents a photo
    /// </summary>
    public class Photo
    {
        /// <summary>
        /// empty constructor
        /// </summary>
        public Photo()
        {
            Id = -1;
        }

        /// <summary>
        /// generates a photo from dataRow
        /// </summary>
        /// <param name="dr">dataRow of photo</param>
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