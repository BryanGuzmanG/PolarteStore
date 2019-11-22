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
    public partial class frmSuplidores : Form
    {
        string idSuplidor;
        string operacion = "Insert";

        DoSuplidores objSupli = new DoSuplidores();
        public frmSuplidores()
        {
            InitializeComponent();
        }

        private void FrmSuplidores_Load(object sender, EventArgs e)
        {
            MostrarSuplidores();
            Permisos();
        }

        private void MostrarSuplidores()
        {
            dataGridViewSuplidores.DataSource = objSupli.MostrarSuplidores();
        }

        private void llenarInfo()
        {
            idSuplidor = dataGridViewSuplidores.CurrentRow.Cells[0].Value.ToString();
            txtCodigoSupli.Text = dataGridViewSuplidores.CurrentRow.Cells[1].Value.ToString();
            txtNombreSupli.Text = dataGridViewSuplidores.CurrentRow.Cells[2].Value.ToString();
            txtTelefono.Text = dataGridViewSuplidores.CurrentRow.Cells[3].Value.ToString();
            txtDireccion.Text = dataGridViewSuplidores.CurrentRow.Cells[4].Value.ToString();

        }
        private void Reset()
        {
            txtCodigoSupli.Text = "";
            txtNombreSupli.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";

        }

        private void Habilitar()
        {
            txtCodigoSupli.Enabled = true;
            txtNombreSupli.Enabled = true;
            txtTelefono.Enabled = true;
            txtDireccion.Enabled = true;
            btnSaver.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void deshabilitar()
        {
            txtCodigoSupli.Enabled = false;
            txtNombreSupli.Enabled = false;
            txtTelefono.Enabled = false;
            txtDireccion.Enabled = false;
            btnSaver.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Habilitar();
            txtCodigoSupli.Focus();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewSuplidores.SelectedRows.Count > 0)
            {
                operacion = "Edit";
                llenarInfo();
                Habilitar();

            }
            else
                MessageBox.Show("debe seleccionar una fila");
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewSuplidores.SelectedRows.Count > 0)
            {
                idSuplidor = dataGridViewSuplidores.CurrentRow.Cells[0].Value.ToString();
                objSupli.EliminarSuplidor(idSuplidor);

                MessageBox.Show("Eliminado correctamente");
                MostrarSuplidores();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void BtnSaver_Click(object sender, EventArgs e)
        {
            if(operacion == "Insert")
            {
                objSupli.InsertarSuplidor(txtCodigoSupli.Text, txtNombreSupli.Text, txtTelefono.Text, txtDireccion.Text);
                MostrarSuplidores();
                MessageBox.Show("Se inserto correctamente");
                Reset();
                deshabilitar();

            }
            else if(operacion == "Edit")
            {
                objSupli.EditarSuplidor(txtCodigoSupli.Text, txtNombreSupli.Text, txtTelefono.Text, txtDireccion.Text, idSuplidor);
                MostrarSuplidores();
                MessageBox.Show("Se edito correctamente");
                Reset();

                deshabilitar();
                operacion = "Insert";
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Reset();
            deshabilitar();
        }

        private void DataGridViewSuplidores_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            llenarInfo();
        }

       
        private void BtnHome_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close this window?", "Warning",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
        }

        private void Permisos()
        {
            if (UserCache.Rol == Roles.Administrador || UserCache.Rol == Roles.Gerente)
            {
                btnAdd.Enabled = true;
                btnEditar.Enabled = true;
                btnEditar.Enabled = true;


            }
            else if (UserCache.Rol == Roles.Vendedor)
            {
                btnEditar.Enabled = false;
            }
        }

    }
}
