using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CAPAACCESOADATOS
{
    public class DataProducto : SQLConexion
    {
        public DataTable ListarProducts()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    
                    command.Connection = connection;
                    DataTable Tabla = new DataTable();
                    command.CommandText = "spc_VerProducts";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader LeerFila = command.ExecuteReader();
                    Tabla.Load(LeerFila);
                     return Tabla;

                }
            }
        }
        /*public DataTable ListarSuplidores()
        {
            using (var connection = GetConnection())
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
            
        }*/
        public DataTable ListarCategoria()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    DataTable Tabla = new DataTable();
                    command.CommandText = "select * from Categorias";
                    command.CommandType = CommandType.Text;
                    SqlDataReader Leerfila = command.ExecuteReader();
                    Tabla.Load(Leerfila);
                    return Tabla;

                }
            }

        }


        public void insertarProdct(string CodigoProd , string Nombre, int Stock, double Precio, int SuplidorID ,int CategoriaID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "spc_InsertarProducts";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodigoProd", CodigoProd);
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Stock", Stock);
                    command.Parameters.AddWithValue("@Precio", Precio);
                    command.Parameters.AddWithValue("@SuplidorID", SuplidorID);
                    command.Parameters.AddWithValue("@CategoriaID", CategoriaID);

                    command.ExecuteNonQuery();

                    command.Parameters.Clear();
                }
            }
        }

        public void EditarProdct(String CodigoProd, string Nombre, int Stock, double Precio, int SuplidorID, int CategoriaID, int ProId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "spc_EditarProducts";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodigoProd", CodigoProd);
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Stock", Stock);
                    command.Parameters.AddWithValue("@Precio", Precio);
                    command.Parameters.AddWithValue("@SuplidorID", SuplidorID);
                    command.Parameters.AddWithValue("@CategoriaID", CategoriaID);
                    command.Parameters.AddWithValue("@ProID", ProId);

                    command.ExecuteNonQuery();

                    command.Parameters.Clear();
                }
            }
        }

        public void EditarStock(int id , int stock)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update Productos set Existencia = @stock where ProductoID = @id";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@stock", stock);
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }

        public void EliminarProd(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    // delete from Productos where Id = @idpro
                    command.Connection = connection;
                    command.CommandText = "Delete from Productos where ProductoID = @idpro";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@idpro", id);

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }

    }
}
