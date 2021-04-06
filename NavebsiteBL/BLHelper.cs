using NavebsiteDAL;

namespace NavebsiteBL
{
    /// <summary>
    /// utility class for settings the database path
    /// </summary>
    public class BlHelper
    {
        /// <summary>
        /// sets the path of the DAL database 
        /// </summary>
        /// <param name="path"></param>
        public static void SetPath(string path)
        {
            Constants.Path = path;
        }
    }
}