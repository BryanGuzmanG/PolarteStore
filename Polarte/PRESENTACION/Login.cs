using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRESENTACION
{
    public partial class Login : Form
    {
        public Login()
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
    }
}
