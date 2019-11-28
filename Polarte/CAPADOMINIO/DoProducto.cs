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
    public class DoProducto
    {
        DataProducto objProct = new DataProducto();

        public DataTable MostrarProducto()
        {
            DataTable tabla = new DataTable();
            tabla = objProct.ListarProducts();
            return tabla;

        }
        /*
        public DataTable MostrarSuplidores()
        {
            DataTable tabla = new DataTable();
            tabla = objProct.ListarSuplidores();
            return tabla;
        }
        */

        public DataTable MostrarCategoria()
        {
            DataTable tabla = new DataTable();
            tabla = objProct.ListarCategoria();
            return tabla;
        }

        public void InsertarProducts (string Codigoprod, string Nombre, string Stock,
            string precio, string suplidorid, string categoriaid) 
        {
            objProct.insertarProdct(Codigoprod, Nombre, Convert.ToInt32(Stock), Convert.ToDouble(precio), 
                Convert.ToInt32(suplidorid), Convert.ToInt32(categoriaid));

        }

        public void EditarProducts(string Codigoprod, string Nombre, string Stock,
          string precio, string suplidorid, string categoriaid, string proID)
        {
            objProct.EditarProdct(Codigoprod, Nombre, Convert.ToInt32(Stock), Convert.ToDouble(precio),
                Convert.ToInt32(suplidorid), Convert.ToInt32(categoriaid), Convert.ToInt32(proID));

        }

        public void EliminarProduct(string id)
        {
            objProct.EliminarProd(Convert.ToInt32(id));
        }

        public void EditarStock(string id , string stock)
        {
            objProct.EditarStock(Convert.ToInt32(id), Convert.ToInt32(stock));
        }

    }
}
