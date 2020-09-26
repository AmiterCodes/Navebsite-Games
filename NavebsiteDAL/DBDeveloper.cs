using System.Data;

namespace NavebsiteDAL
{
    public class DbDeveloper
    {
        public static DataRow GetDeveloper(int id)
        {
            return DalHelper.GetRowById(id, "Developer");
        }
    }
}