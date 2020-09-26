using System.Data;

namespace NavebsiteDAL
{
    public class DbUpdate
    {
        public static int InsertUpdate(string version, string updateName, string description, int game)
        {
            return DalHelper.Insert(
                $"INSERT INTO GameUpdates ([Update Version],[Update Name], [Update Description], [Game]) VALUES ('{version}','{updateName}','{description}',{game})");
        }

        public static DataTable ListUpdates(int game)
        {
            return DalHelper.AllWhere("GameUpdates", "Game", game);
        }
    }
}