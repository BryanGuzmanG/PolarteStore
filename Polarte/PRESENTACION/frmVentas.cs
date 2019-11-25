using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAPADOMINIO;

namespace PRESENTACION
{
    public partial class frmVentas : Form
    {
        DoProducto objPro = new DoProducto();
        public frmVentas()
        {
            InitializeComponent();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            MostrarProducto();
        }

        private void MostrarProducto()
        {
            dataGridViewProducto.DataSource = objPro.MostrarProducto();
        }
    }
}
