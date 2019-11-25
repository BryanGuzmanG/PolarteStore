using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Cache;
using CAPADOMINIO;


namespace PRESENTACION
{
    public partial class frmAddEmpleado : Form
    {
        public frmAddEmpleado()
        {
            InitializeComponent();
            
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close this window?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
        }

        private void BtnSaver_Click(object sender, EventArgs e)
        {
            if(txtUserPass.Text.Length >= 5)
            {
                if(txtUserPass.Text == txtUserCFPass.Text)
                {
                    var UserSaver = new UserModel(
                        userName: txtUserName.Text,
                        password: txtUserPass.Text,
                        nombre: txtFirstname.Text,
                        apellidos: txtLastName.Text,
                        rol: cmbRoles.SelectedItem.ToString(),
                        email: txtUserEmail.Text);
                    var result = UserSaver.AddUser();
                    MessageBox.Show(result);
                    mostrarDatos();
                    inhabilitar();

                } else
                    MessageBox.Show("The password do not match, try again");
            } else
                MessageBox.Show("The password must have a minimum of 5 characters");
        }

        private void inhabilitar()
        {
            txtUserName.Enabled = false;
            txtUserPass.Enabled = false;
            txtUserCFPass.Enabled = false;
            txtFirstname.Enabled = false;
            txtLastName.Enabled = false;
            cmbRoles.Enabled = false;
            txtUserEmail.Enabled = false;
            btnSaver.Enabled = false;
            btnCancel.Enabled = false;
            
        }
        private void habilitar()
        {
            txtUserName.Enabled = true;
            txtUserPass.Enabled = true;
            txtUserCFPass.Enabled = true;
            txtFirstname.Enabled = true;
            txtLastName.Enabled = true;
            cmbRoles.Enabled = true;
            txtUserEmail.Enabled = true;
            btnSaver.Enabled = true;
            btnCancel.Enabled = true;

        }
        private void mostrarDatos()
        {
            lblUser.Text = txtUserName.Text;
            lblNombre.Text = txtFirstname.Text;
            lblApellidos.Text = txtLastName.Text;
            lblEmail.Text = txtUserEmail.Text;
            lblRol.Text = cmbRoles.Text;
        }

        private void Reset()
        {
            txtUserName.Text = "";
            txtUserPass.Text = "";
            txtUserCFPass.Text = "";
            txtFirstname.Text = "";
            txtLastName.Text = "";
            cmbRoles.Text = "";
            txtUserEmail.Text = "";

            //Label
            lblUser.Text = "";
            lblNombre.Text = "";
            lblApellidos.Text = "";
            lblEmail.Text = "";
            lblRol.Text = ""; 

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void LinkEditPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtUserPass.UseSystemPasswordChar = false;
            txtUserCFPass.UseSystemPasswordChar = false;
        }

        private void AddEmployee_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Reset();
            habilitar();
        }

        private void BtnVer_Click(object sender, EventArgs e)
        {
            if (btnVer.Text == "-")
            {

                txtUserPass.UseSystemPasswordChar = true;
                txtUserCFPass.UseSystemPasswordChar = true;
                btnVer.Text = "";

            }
            else if (btnVer.Text == "")
            {
                txtUserPass.UseSystemPasswordChar = false;
                txtUserCFPass.UseSystemPasswordChar = false;
                btnVer.Text = "-";
            }
        }

        private void FrmAddEmpleado_Load(object sender, EventArgs e)
        {
            Reset();
            btnVer.Text = "-";
        }
    }
}
