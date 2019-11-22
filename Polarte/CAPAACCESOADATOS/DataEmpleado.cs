using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CAPAACCESOADATOS
{
    public class DataEmpleado : SQLConexion
    {
        public DataTable ListarEmpleados()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    DataTable Tabla = new DataTable();
                    command.CommandText = "Select UserID, UserName, Nombre , Apellidos , Rol , Email from Users";
                    command.CommandType = CommandType.Text;
                    SqlDataReader LeerFila = command.ExecuteReader();
                    Tabla.Load(LeerFila);
                    return Tabla;

                }
            }
        }

        public void InsertarEmpleado(string userName, string password, string name, string lastName,string Rol ,string mail)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "spc_InsertarUsuario";
                    command.Parameters.AddWithValue("@userName", userName);
                    command.Parameters.AddWithValue("@pass", password);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@Rol", Rol);
                    command.Parameters.AddWithValue("@mail", mail);
                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }

        }
        public void EditarEmpleado(string userName, string name, string lastName, string Rol, string email, int UserID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "spc_EditarEmpleado";
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@Nombre", name);
                    command.Parameters.AddWithValue("@Apellidos", lastName);
                    command.Parameters.AddWithValue("@Rol", Rol);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.CommandType = CommandType.StoredProcedure;

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }

        }

    }
}
