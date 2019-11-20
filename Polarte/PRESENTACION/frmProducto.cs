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
    public partial class frmProducto : Form
    {
        string idPro;
        string operacion = "Insert";
        DoProducto objPro = new DoProducto();

        public frmProducto()
        {
            InitializeComponent();
            
        }

        private void MostrarProducto()
        {
            //DoProducto objPro = new DoProducto(); 
            dataGridViewProducto.DataSource = objPro.MostrarProducto();
        }

        private void MostrarCategoria()
        {
            //DoProducto objPro = new DoProducto();
            cmbCategoria.DataSource = objPro.MostrarCategoria();
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "CategoriaID";


        }

        private void MostrarSuplidores()
        {
            //DoProducto objPro = new DoProducto();
            cmbSuplidor.DataSource = objPro.MostrarSuplidores();
            cmbSuplidor.DisplayMember = "NombreSuplidor";
            cmbSuplidor.ValueMember = "SuplidorID";
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            MostrarProducto();
            MostrarCategoria();
            MostrarSuplidores();
        }

        private void BtnSaver_Click(object sender, EventArgs e)
        {
            if(operacion == "Insert")
            {
                //DoProducto objPro = new DoProducto();
                objPro.InsertarProducts(txtCodigoPro.Text, txtNombrePro.Text, txtStock.Text, txtPrecio.Text,
                    Convert.ToString(cmbSuplidor.SelectedValue), Convert.ToString(cmbCategoria.SelectedValue));
                MostrarProducto();
                reset();

                MessageBox.Show("Se inserto correctamente");
            }
            else if(operacion == "Edit")
            {
                objPro.EditarProducts(txtCodigoPro.Text, txtNombrePro.Text, txtStock.Text, txtPrecio.Text,
                    Convert.ToString(cmbSuplidor.SelectedValue), Convert.ToString(cmbCategoria.SelectedValue), idPro);
                MostrarProducto();
                MessageBox.Show("Se edito correctamente");
                reset();
                operacion = "Insert";
            }

        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if(dataGridViewProducto.SelectedRows.Count > 0)
            {
                operacion = "Edit";
                cmbCategoria.Text = dataGridViewProducto.CurrentRow.Cells[3].Value.ToString();
                cmbSuplidor.Text = dataGridViewProducto.CurrentRow.Cells[6].Value.ToString();
                txtNombrePro.Text = dataGridViewProducto.CurrentRow.Cells[2].Value.ToString();
                txtCodigoPro.Text = dataGridViewProducto.CurrentRow.Cells[1].Value.ToString();
                txtPrecio.Text = dataGridViewProducto.CurrentRow.Cells[4].Value.ToString();
                txtStock.Text = dataGridViewProducto.CurrentRow.Cells[5].Value.ToString();
                idPro = dataGridViewProducto.CurrentRow.Cells[0].Value.ToString();
            }else
                MessageBox.Show("debe seleccionar una fila");
        }

        private void reset()
        {
            idPro = "";
            txtCodigoPro.Text = "";
            txtNombrePro.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducto.SelectedRows.Count > 0)
            {
                idPro = dataGridViewProducto.CurrentRow.Cells[0].Value.ToString();
                objPro.EliminarProduct(idPro);

                MessageBox.Show("Eliminado correctamente");
                MostrarProducto();
            }else
                MessageBox.Show("seleccione una fila por favor");

        }
    }
}
