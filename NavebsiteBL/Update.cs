using System.Collections.Generic;
using System.Data;
using System.Linq;
using NavebsiteDAL;

namespace NavebsiteBL
{
    public class Update
    {
        public Update(DataRow dr)
        {
            Id = (int) dr["ID"];
            UpdateVersion = (string) dr["Update Version"];
            UpdateName = (string) dr["Update Name"];
            UpdateDescription = (string) dr["Update Description"];
            GameId = (int) dr["Game"];
        }

        public Update(string updateVersion, string updateName, string updateDescription, int gameId)
        {
            UpdateVersion = updateVersion;
            UpdateName = updateName;
            UpdateDescription = updateDescription;
            GameId = gameId;
            Id = DbUpdate.InsertUpdate(updateVersion, updateName, updateDescription, gameId);
        }


        public int Id { get; }
        public string UpdateVersion { get; }
        public string UpdateName { get; }
        public string UpdateDescription { get; }
        public int GameId { get; }

        public Game Game => new Game(GameId);

        public List<Update> ListUpdates(int game)
        {
            return (from DataRow dr in DbUpdate.ListUpdates(game).Rows select new Update(dr)).ToList();
        }
        
    }
}