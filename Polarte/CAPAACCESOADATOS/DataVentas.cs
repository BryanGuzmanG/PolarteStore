using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CAPAACCESOADATOS  
{
    public class DataVentas : SQLConexion
    {
        public void InsertarOrden(int UsuarioID, DateTime Fecha)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "psc_InsertarOrden";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UsuarioID",UsuarioID);
                    command.Parameters.AddWithValue("@FechaOrden", Fecha);

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                     
            }
        }

        public DataTable ListaOrden()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    DataTable table = new DataTable();
                    command.CommandText = "select * from Ordenes where OrdenID = (Select MAX(OrdenID) from Ordenes)";
                    command.CommandType = CommandType.Text;
                    SqlDataReader LeerFila = command.ExecuteReader();
                    table.Load(LeerFila);
                    return table;

                }
            }
        }

        public void insertarOrdenDetalle(int OrdenID, int ProductoID, double Precio, double Cantidad, double SubTotal, double ITBIS)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "psc_InsertaOrdenDetalle";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrdenID", OrdenID);
                    command.Parameters.AddWithValue("@ProductoID", ProductoID);
                    command.Parameters.AddWithValue("@Precio", Precio);
                    command.Parameters.AddWithValue("@Cantidad", Cantidad);
                    command.Parameters.AddWithValue("@SubTotal", SubTotal);
                    command.Parameters.AddWithValue("@ITBIS", ITBIS);

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();

                }
            }
        }
    }
}
