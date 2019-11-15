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
    public partial class PantallaPrincipal : Form
    {
        public PantallaPrincipal()
        {
            InitializeComponent();
            btnRestaurar.Visible = false;
            Permisos();
        }

        private void TbnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close the app?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Exit();
        }

        //Capturar posicion y tamano antes de maximizar  para restaurar
        int lx, ly;
        int sw, sh;

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;

            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            
        }

       
        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mmm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void BtnProducto_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frmProducto());
        }

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frmVentas());
        }

        private void BtnProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frmProveedores());
            
        }

        private void BtnEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frmEmpleados());
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;

            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out of the  app?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
        }

        
        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }
        
        private void LoadUserData()
        {
            lblName.Text = UserCache.Nombre + " " + UserCache.Apellidos;
            lblRol.Text = UserCache.Rol;
        }

        private void LinkProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirFormularioEnPanel(new frmUserProfile());
        }

        /* private void AbrirFormulario<MiForm>() where MiForm : Form , new()
         {
             Form formulario;
             formulario = panelFormularios.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario; Si el formulario

             // Entonces si el formulario o la instancia no existe;
             if(formulario == null)
             {
                 formulario = new MiForm();
                 formulario.TopLevel = false;
                 formulario.FormBorderStyle = FormBorderStyle.None;
                 formulario.Dock = DockStyle.Fill;
                 panelFormularios.Controls.Add(formulario);
                 panelFormularios.Tag = formulario;
                 formulario.Show();
                 formulario.BringToFront();
             }
             else //Si el formulario o la instancia existen 
             {
                 formulario.BringToFront();
             }

         }*/

        private void AbrirFormularioEnPanel(object formHijo)
        {
            if (this.panelFormularios.Controls.Count > 0)
                this.panelFormularios.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelFormularios.Controls.Add(fh);
            this.panelFormularios.Tag = fh;
            fh.Show();
            fh.BringToFront();

        }

        //Manejando los permisos 
        public void Permisos()
        {
            if (UserCache.Rol != Roles.Administrador || UserCache.Rol != Roles.Gerente)
            {
                btnEmpleados.Enabled = false;
                btnReportes.Enabled = false;

            }
        }
    }
}
