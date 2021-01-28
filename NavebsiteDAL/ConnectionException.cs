using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavebsiteDAL
{
    [Serializable]
    class ConnectionException : Exception
    {
        /// <summary>
        /// connection exception
        /// </summary>
        public ConnectionException() : base("Unable to open connection")
        {

        }
    }
}
