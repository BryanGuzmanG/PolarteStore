using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CAPAACCESOADATOS;
using Common.Cache;

namespace CAPADOMINIO
{
    public class DoVentas
    {
        DataVentas objVentas = new DataVentas();
       public void InsertarOrden(string UsuarioID, DateTime Fecha)
        {
            objVentas.InsertarOrden(Convert.ToInt32(UsuarioID), Fecha);
        }

        public DataTable MostrarOrdenes()
        {
            DataTable tabla = new DataTable();
            tabla = objVentas.ListaOrden();
            return tabla;
        }

        public void InsertarOrdenes(string OrdenID, string ProductoID, string Precio, string Cantidad, string SubTotal, string ITBIS)
        {
            objVentas.insertarOrdenDetalle(Convert.ToInt32(OrdenID), Convert.ToInt32(ProductoID) , Convert.ToDouble(Precio) ,Convert.ToDouble(Cantidad) ,Convert.ToDouble(SubTotal) , Convert.ToDouble(ITBIS));
        }
    }
}
