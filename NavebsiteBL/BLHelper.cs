using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavebsiteDAL;
namespace NavebsiteBL
{
    public class BLHelper
    {
        public static void SetPath(string path)
        {
            Constants.PATH = path;
        }
    }
}
