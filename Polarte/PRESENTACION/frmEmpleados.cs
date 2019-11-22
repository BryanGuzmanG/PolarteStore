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
    public partial class frmEmpleados : Form
    {
        string IdEmpleado;

        DoEmpleado objEmpleado = new DoEmpleado();
        public frmEmpleados()
        {
            InitializeComponent();
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            MostrarEmpleados();
        }

        private void MostrarEmpleados()
        {
            dataGridViewEmpleados.DataSource = objEmpleado.MostrarEmpleados();
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LlenarInfo()
        {
            IdEmpleado = dataGridViewEmpleados.CurrentRow.Cells[0].Value.ToString();
            txtUserName.Text = dataGridViewEmpleados.CurrentRow.Cells[1].Value.ToString();
            txtFirstname.Text = dataGridViewEmpleados.CurrentRow.Cells[2].Value.ToString();
            txtLastName.Text = dataGridViewEmpleados.CurrentRow.Cells[3].Value.ToString();
            cmbRoles.Text = dataGridViewEmpleados.CurrentRow.Cells[4].Value.ToString();
            txtUserEmail.Text = dataGridViewEmpleados.CurrentRow.Cells[5].Value.ToString();
        }

        private void DataGridViewEmpleados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LlenarInfo();
            deshabilitar();
        }

        private void Habilitar()
        {
            txtFirstname.Enabled = true;
            txtLastName.Enabled = true;
            txtUserEmail.Enabled = true;
            txtUserName.Enabled = true;
            btnCancel.Enabled = true;
            btnSaver.Enabled = true;
            cmbRoles.Enabled = true;

        }
        private void deshabilitar()
        {
            txtFirstname.Enabled = false;
            txtLastName.Enabled = false;
            txtUserEmail.Enabled = false;
            txtUserName.Enabled = false;
            btnSaver.Enabled = false;
            btnCancel.Enabled = false;
            cmbRoles.Enabled = false;

        }
        private void Reset()
        {
            txtFirstname.Text = "";
            txtLastName.Text = "";
            txtUserEmail.Text = "";
            txtUserName.Text = "";
            cmbRoles.Text = "";
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmpleados.SelectedRows.Count > 0)
            {

                LlenarInfo();
                Habilitar();

            }
            else
                MessageBox.Show("debe seleccionar una fila");
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Reset();
            deshabilitar();
        }

        private void BtnSaver_Click(object sender, EventArgs e)
        {
            objEmpleado.EditarEmpleado(txtUserName.Text, txtFirstname.Text, txtLastName.Text, cmbRoles.SelectedItem.ToString() , txtUserEmail.Text , IdEmpleado);
            MostrarEmpleados();
            MessageBox.Show("Se edito correctamente");
            Reset();

            deshabilitar();
        }
    }
}
