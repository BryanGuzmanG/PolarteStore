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
    public partial class frmUserProfile : Form
    {
        public frmUserProfile()
        {
            InitializeComponent();
        }

        private void FrmUserProfile_Load(object sender, EventArgs e)
        {
            LoadUSerData();
            IniciarPassEdit();
        }

        private void LoadUSerData()
        {
            //View
            lblUser.Text = UserCache.Username;
            lblNombre.Text = UserCache.Nombre;
            lblApellidos.Text = UserCache.Apellidos;
            lblEmail.Text = UserCache.Email;
            lblRol.Text = UserCache.Rol;

            //Edit Panel
            txtUserName.Text = UserCache.Username;
            txtFirstname.Text = UserCache.Nombre;
            txtLastName.Text = UserCache.Apellidos;
            txtUserEmail.Text = UserCache.Email;
            txtUserPass.Text = UserCache.Password;
            txtUserCFPass.Text = UserCache.Password;
            txtCurrentPass.Text = "";
        }
         
        private void IniciarPassEdit()
        {
            LinkEditPass.Text = "Edit";
            txtUserPass.UseSystemPasswordChar = true;
            txtUserPass.Enabled = false;
            txtUserCFPass.UseSystemPasswordChar = true;
            txtUserCFPass.Enabled = false;
        }

        private void reset()
        {
            LoadUSerData();
            IniciarPassEdit();
        }

        private void LinkEditProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelEdit.Visible = true;
            LoadUSerData();
        }

        private void LinkEditPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (LinkEditPass.Text == "Edit")
            {
                LinkEditPass.Text = "Cancel";
                txtUserPass.Enabled = true;
                txtUserPass.Text = "";
                txtUserCFPass.Enabled = true;
                txtUserCFPass.Text = "";
            }
            else if (LinkEditPass.Text == "Cancel")
            {
                IniciarPassEdit();
                txtUserPass.Text = UserCache.Password;
                txtUserCFPass.Text = UserCache.Password;
            }

        }

        private void BtnSaver_Click(object sender, EventArgs e)
        {
            if (txtUserPass.Text.Length >= 5)
            {
                if (txtUserPass.Text == txtUserCFPass.Text)
                {
                    if (txtCurrentPass.Text == UserCache.Password)
                    {
                        var userModel = new UserModel(
                            userID : UserCache.UserID,
                            userName: txtUserName.Text,
                            password: txtUserPass.Text,
                            nombre: txtFirstname.Text,
                            apellidos: txtLastName.Text,
                            rol: null,
                            email: txtUserEmail.Text);
                        var result = userModel.editUserProfile();
                        MessageBox.Show(result);
                        reset();
                        panelEdit.Visible = false;
                    }
                    else
                        MessageBox.Show("Icorrect current password, try again");
                }
                else
                    MessageBox.Show("The password do not match, try again");
            }
            else
                MessageBox.Show("The password must have a minimum of 5 characters");
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            panelEdit.Visible = false;
            reset();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
