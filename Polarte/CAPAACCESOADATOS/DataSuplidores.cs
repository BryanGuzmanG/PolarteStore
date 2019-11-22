using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CAPAACCESOADATOS
{
   public class DataSuplidores : SQLConexion
    {
        public DataTable ListarSuplidores()
        {
            using (var connection  = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    DataTable Tabla = new DataTable();
                    command.CommandText = "select * from Suplidores";
                    command.CommandType = CommandType.Text;
                    SqlDataReader Leerfila = command.ExecuteReader();
                    Tabla.Load(Leerfila);
                    return Tabla;
                }
            }
        }

        public void InsertarSuplidores(string CodigoSuplidor , string NombreSupli, string Telefono, string Direccion )
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "spc_InsertarSuplidor";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodigoSupli", CodigoSuplidor);
                    command.Parameters.AddWithValue("@NombreSuplidor", NombreSupli);
                    command.Parameters.AddWithValue("@Telefono", Telefono);
                    command.Parameters.AddWithValue("@Direccion", Direccion);

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }

        public void EditarSuplidores(string CodigoSuplidor, string NombreSupli, string Telefono, string Direccion,int SupliID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "spc_EditarSuplidor";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodigoSupli", CodigoSuplidor);
                    command.Parameters.AddWithValue("@NombreSuplidor", NombreSupli);
                    command.Parameters.AddWithValue("@Telefono", Telefono);
                    command.Parameters.AddWithValue("@Direccion", Direccion);
                    command.Parameters.AddWithValue("@SuplidorID", SupliID);

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }

        public void DeleteSuplidor(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Delete from Suplidores where SuplidorID = @SupliID";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@SupliID ", id);

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }
    }
}
