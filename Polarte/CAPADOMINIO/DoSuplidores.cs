using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CAPAACCESOADATOS;

namespace CAPADOMINIO
{
   public class DoSuplidores 
    {
        DataSuplidores objSuplidor = new DataSuplidores();

        public DataTable MostrarSuplidores()
        {
            DataTable tabla = new DataTable();
            tabla = objSuplidor.ListarSuplidores();
            return tabla;
        }
        
        public void InsertarSuplidor(string CodigoSuplidor, string NombreSupli, string Telefono, string Direccion)
        {
            objSuplidor.InsertarSuplidores(CodigoSuplidor, NombreSupli, Telefono, Direccion);

        }

        public void EditarSuplidor(string CodigoSuplidor, string NombreSupli, string Telefono, string Direccion, string SupliID)
        {
            objSuplidor.EditarSuplidores(CodigoSuplidor, NombreSupli, Telefono, Direccion, Convert.ToInt32(SupliID));
        }

        public void EliminarSuplidor(string SupliID)
        {
            objSuplidor.DeleteSuplidor(Convert.ToInt32(SupliID));
        }
    }
}
