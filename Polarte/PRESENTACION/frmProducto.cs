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
using Common.Cache;

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
            DoSuplidores objSupli = new DoSuplidores();

            cmbSuplidor.DataSource = objSupli.MostrarSuplidores();
            cmbSuplidor.DisplayMember = "NombreSuplidor";
            cmbSuplidor.ValueMember = "SuplidorID";
           
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
           
            MostrarProducto();
            MostrarCategoria();
            MostrarSuplidores();
            Permisos();
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
                deshabilitar();
            }
            else if(operacion == "Edit")
            {
                objPro.EditarProducts(txtCodigoPro.Text, txtNombrePro.Text, txtStock.Text, txtPrecio.Text,
                    Convert.ToString(cmbSuplidor.SelectedValue), Convert.ToString(cmbCategoria.SelectedValue), idPro);
                MostrarProducto();
                MessageBox.Show("Se edito correctamente");
                reset();
                deshabilitar();
                operacion = "Insert";
            }

        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if(dataGridViewProducto.SelectedRows.Count > 0)
            {
                operacion = "Edit";
                llenarInfo();
                Habilitar();

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
        private void Habilitar()
        {
            txtCodigoPro.Enabled = true;
            txtNombrePro.Enabled = true;
            
            cmbCategoria.Enabled = true;
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSuplidor.Enabled = true;
            cmbSuplidor.DropDownStyle = ComboBoxStyle.DropDownList;
            btnSaver.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void deshabilitar()
        {
            txtCodigoPro.Enabled = false;
            txtNombrePro.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;
            cmbCategoria.Enabled = false;
            cmbSuplidor.Enabled = false;
            btnSaver.Enabled = false;
            btnCancel.Enabled = false;
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Habilitar();
            txtCodigoPro.Focus();
            txtPrecio.Enabled = true;
            txtStock.Enabled = true;
        }
        
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            reset();
            deshabilitar();
        }

        private void DataGridViewProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            llenarInfo();
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;
           
        }


        private void llenarInfo()
        {
            cmbCategoria.Text = dataGridViewProducto.CurrentRow.Cells[3].Value.ToString();
            cmbSuplidor.Text = dataGridViewProducto.CurrentRow.Cells[6].Value.ToString();
            txtNombrePro.Text = dataGridViewProducto.CurrentRow.Cells[2].Value.ToString();
            txtCodigoPro.Text = dataGridViewProducto.CurrentRow.Cells[1].Value.ToString();
            txtPrecio.Text = dataGridViewProducto.CurrentRow.Cells[4].Value.ToString();
            txtStock.Text = dataGridViewProducto.CurrentRow.Cells[5].Value.ToString();
            idPro = dataGridViewProducto.CurrentRow.Cells[0].Value.ToString();
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            PantallaPrincipal obj = new PantallaPrincipal();
                       
            if (MessageBox.Show("Are you sure you want to close this window?", "Warning",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
                obj.Show();
        }

        private void Permisos()
        {
            if (UserCache.Rol == Roles.Administrador || UserCache.Rol == Roles.Gerente)
            {
                btnAdd.Enabled = true;
                btnEditar.Enabled = true;
                btnEditar.Enabled = true;
                txtPrecio.Enabled = true;
                txtStock.Enabled = true;

            }
            else if (UserCache.Rol == Roles.Vendedor)
            {
                btnEliminar.Enabled = false;
                txtPrecio.Enabled = false;
                txtStock.Enabled = false;
            }
        }
    }
}
