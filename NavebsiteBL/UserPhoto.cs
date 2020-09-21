using NavebsiteDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavebsiteBL
{
    public class UserPhoto : Photo
    {   

        public int UserId { get; set; }
        public DateTime Timestamp { get; set; }

        public UserPhoto(int id)
        {
            Id = id;
            var dr = DBPhotos.GetPhoto(id, PhotoType.GamePhotos);
            if (dr == null) throw new ArgumentException("no photo with that id");

            UserId = (int)dr["User"];
            Image = (string)dr["Photo"];
            Timestamp = (DateTime)dr["Timestamp"];
        }

        public UserPhoto(DataRow dr) : base(dr)
        {
            UserId = (int)dr["User"];
            Timestamp = (DateTime)dr["Timestamp"];
        }

        /// <summary>
        /// Returns all photos of a specified user
        /// </summary>
        /// <param name="user">id of the user to search for</param>
        /// <returns>empty list if user does not have any photos or doesn't exist, else returns a List<UserPhoto> of all photos of specified user</returns>
        public static List<UserPhoto> GetPhotosByUser(int user)
        {
            var list = new List<UserPhoto>();
            var tb = DBPhotos.GetPhotosOfUser(user);
            foreach (DataRow r in tb.Rows)
            {
                list.Add(new UserPhoto(r));
            }
            return list;
        }
    }
}
