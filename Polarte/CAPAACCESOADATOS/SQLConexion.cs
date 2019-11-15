using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CAPAACCESOADATOS
{
    public abstract class SQLConexion
    {
        private readonly string conexionString;

        public SQLConexion()
        {
            conexionString = "Server = DESKTOP-1AHN8HK\\SQLEXPRESS; DataBase = PolarteDB; integrated security = true";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(conexionString);
        }
    }
}
