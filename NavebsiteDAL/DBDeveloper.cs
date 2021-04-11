using System.Data;
using System.Data.OleDb;

namespace NavebsiteDAL
{
    /// <summary>
    /// DB class for developer-related data fetching
    /// </summary>
    public class DbDeveloper
    {
        /// <summary>
        /// Returns a developer from id
        /// </summary>
        /// <param name="id">id of developer</param>
        /// <returns>DataRow of developer</returns>
        public static DataRow GetDeveloper(int id)
        {
            return DalHelper.GetRowById(id, "Developer");
        }

        /// <summary>
        /// inserts a new developer into the database
        /// </summary>
        /// <param name="developerName">name of developer</param>
        /// <returns></returns>
        public static int AddDeveloper(string developerName)
        {
            return DalHelper.Insert("INSERT INTO Developer ([Developer Name]) VALUES (@name)", new OleDbParameter("@name", developerName));
        }

        /// <summary>
        /// Adds a user to a developer company
        /// </summary>
        /// <param name="userId">id of user</param>
        /// <param name="devId">id of developer</param>
        public static void SetUserDeveloper(int userId, int devId)
        {
            DalHelper.Update($"UPDATE Users SET Developer = true, DeveloperId = {devId} WHERE ID = {userId}");
        }

        /// <summary>
        /// Updates the data for the developer
        /// </summary>
        /// <param name="name">new developer name</param>
        /// <param name="about">new developer bio</param>
        /// <param name="id">id of developer</param>
        public static void UpdateData(string name, string about, int id)
        {
            DalHelper.Update($"UPDATE Developer SET [Developer Name] = @name, [About] = @about WHERE id = {id}", 
                new OleDbParameter("@name", name),
                new OleDbParameter("@about", about));
        }

        /// <summary>
        /// updates the icon for the developer
        /// </summary>
        /// <param name="filename">filename of icon</param>
        /// <param name="id">id of developer</param>
        public static void UpdateIcon(string filename, int id)
        {
            DalHelper.Update($"UPDATE Developer SET [Icon] = @name WHERE id = {id}",
                new OleDbParameter("@name", filename));
        }

        /// <summary>
        /// updates the background for the developer
        /// </summary>
        /// <param name="filename">filename of background</param>
        /// <param name="id">id of developer</param>
        public static void UpdateBackground(string filename, int id)
        {
            DalHelper.Update($"UPDATE Developer SET [Background] = @name WHERE id = {id}",
                new OleDbParameter("@name", filename));
        }
    }
}