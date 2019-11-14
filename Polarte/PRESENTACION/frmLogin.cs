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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void TxtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "USERNAME")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void TxtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "USERNAME";
                txtUser.ForeColor = Color.DimGray;
            }
        }

        private void TxtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "PASSWORD")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void TxtPass_Leave(object sender, EventArgs e)
        {
            if(txtPass.Text == "")
            {
                txtPass.Text = "PASSWORD";
                txtPass.ForeColor = Color.DimGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnAcceder_Click(object sender, EventArgs e)
        {
            if (txtUser.Text != "USERNAME" && txtUser.TextLength > 2)
            {
                if (txtPass.Text != "PASSWORD")
                {
                    UserModel user = new UserModel();
                    var validarLogin = user.LoginUser(txtUser.Text, txtPass.Text);
                    if (validarLogin == true)
                    {
                        PantallaPrincipal mainMenu = new PantallaPrincipal();
                        mainMenu.Show();
                        this.Hide();
                    }
                    else
                    {
                        msgError("Incorrect username or password entered.");
                        txtPass.Text = "PASSWORD";
                        txtPass.UseSystemPasswordChar = false;
                        txtPass.Focus();
                    }
                }
                else msgError("Please enter password.");
            }
            else msgError("Please enter username.");
        }

        private void msgError(string msg)
        {
            lblErrorMessage.Text = "     "  + msg;
            lblErrorMessage.Visible = true;
        }
    }
}
