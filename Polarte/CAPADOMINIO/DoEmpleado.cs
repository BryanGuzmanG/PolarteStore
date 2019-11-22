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
    public class DoEmpleado
    {
        DataEmpleado objEmpleado = new DataEmpleado();

        public DataTable MostrarEmpleados()
        {
            DataTable tabla = new DataTable();
            tabla = objEmpleado.ListarEmpleados();
            return tabla;
        }

        public void EditarEmpleado(string userName, string name, string lastName, string Rol, string Email, string UserID)
        {
            objEmpleado.EditarEmpleado(userName, name, lastName, Rol, Email, Convert.ToInt32(UserID));
        }

    }
}
