using CAPADOMINIO;
using System;
using System.Data;
using System.Windows.Forms;
using Common.Cache;


namespace PRESENTACION
{
    public partial class frmVentas : Form
    {
        DoProducto objPro = new DoProducto();
        DoVentas objVentas = new DoVentas();
        double total = 0;
        double subtotal = 0;
        double ITBIS = 0;
        double AItebis = 0;
        double TTOTAL = 0;
        double Cambio = 0;
        double Importe = 0;
        int stock = 0;
        string OrdenID;
        string idProd;
        string Precio;
        string cantidad;
        public frmVentas()
        {
            InitializeComponent();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            MostrarProducto();
            dataGridViewProducto.Enabled = false;
        }

        private void MostrarProducto()
        {
            dataGridViewProducto.DataSource = objPro.MostrarProducto();
            dataGridViewOrden.DataSource = objVentas.MostrarOrdenes();
            //OrdenID = dataGridViewOrden.CurrentRow.Cells[0].Value.ToString();

        }

        /*
        private void DataGridViewProducto_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.ColumnIndex >=0 && this.dataGridViewProducto.Columns[e.ColumnIndex].Name == " " && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell cellAdd = this.dataGridViewProducto.Rows[e.RowIndex].Cells[" "] as DataGridViewButtonCell;

                Icon iconoAdd = new Icon(Environment.CurrentDirectory + @"\\plus.ico");
                e.Graphics.DrawIcon(iconoAdd, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dataGridViewProducto.Rows[e.RowIndex].Height = iconoAdd.Height + 10;
                this.dataGridViewProducto.Columns[e.ColumnIndex].Width = iconoAdd.Width + 10;

                e.Handled = true;
            }
        }*/

        private void DataGridViewProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // if(this.dataGridViewProducto.Columns[e.ColumnIndex].Name == " ")
          //  {
                /*BindingSource source = (BindingSource)dataGridViewProducto.DataSource;
                DataTable datos = ((DataSet)source.DataSource).Tables[0];*/
                //DataTable datos = (DataTable)dataGridViewProducto.DataSource;

                //DataTable Seleccionado = datos.Select(dataGridViewProducto.CurrentRow.Cells.ToString()).CopyToDataTable();

                //dataGridViewDetalle.DataSource = Seleccionado;

               /*/ DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridViewDetalle);

               fila.Cells[0].Value = dataGridViewProducto.CurrentRow.Cells[1].Value.ToString(); 
                */
           // }
        }
        
        private void DataGridViewProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*DataTable datos = (DataTable)dataGridViewProducto.DataSource;
            DataTable Seleccionado = datos.Select(dataGridViewProducto.CurrentRow.Cells.ToString()).CopyToDataTable();
            dataGridViewDetalle.DataSource = Seleccionado;*/

            //dataGridViewDetalle
            //DataGridViewRow fila = new DataGridViewRow();
            //fila.CreateCells(dataGridViewDetalle);

            //fila.Cells[0].Value = dataGridViewProducto.CurrentRow.Cells[0].Value.ToString();

            DataTable datos = (DataTable)dataGridViewProducto.DataSource;
            //DataTable seleccionado = datos.Select("ProducID = '1'").CopyToDataTable();

            DataTable datos2 = (DataTable)dataGridViewDetalle.DataSource;

            

            if (txtCantidad.Text != "" && (Convert.ToInt32(txtCantidad.Text)) < (Convert.ToInt32(this.dataGridViewProducto.CurrentRow.Cells[5].Value)))
            {

               stock = (Convert.ToInt32(this.dataGridViewProducto.CurrentRow.Cells[5].Value)) - (Convert.ToInt32(txtCantidad.Text));
                idProd = dataGridViewProducto.CurrentRow.Cells[0].Value.ToString();

                objPro.EditarStock(idProd, Convert.ToString(stock));
                MostrarProducto();
                foreach (DataGridViewRow rowPrincipa in dataGridViewProducto.SelectedRows)
                {
                    //total = Convert.ToDouble(rowPrincipa.Cells[2].Value.ToString()) * Convert.ToInt32(txtCantidad.Text);
                    total = (Convert.ToDouble(txtCantidad.Text)) * (Convert.ToDouble(this.dataGridViewProducto.CurrentRow.Cells[4].Value));
                   
                    

                    object[] values =
                    {
                    rowPrincipa.Cells[1].Value,
                    rowPrincipa.Cells[2].Value,
                    rowPrincipa.Cells[4].Value,
                    txtCantidad.Text,
                    Convert.ToString(total)
                    };

                    DataGridViewRow row = new DataGridViewRow();

                    row.CreateCells(dataGridViewDetalle, values);
                    //row["TOTAL"] = Convert.ToSingle(total);
                    dataGridViewDetalle.Rows.Add(row);
                    //double total;

                    //dataGridViewProducto.Rows["TOTAL"].Cells = total 
   
                }
                
                txtCantidad.Text = "";
                               
            }
            else
                MessageBox.Show("DEBE ELEGIR UNA CANTIDAD  ADECUADA","Waring",MessageBoxButtons.OK ,MessageBoxIcon.Warning);

            subtotal += total;
            ITBIS = total * 0.18;
            AItebis += ITBIS;
            TTOTAL = subtotal + AItebis;

                     
            txtSubTotal.Text = Convert.ToString(subtotal);
            txtITBIS.Text = Convert.ToString(AItebis);
            txtTotal.Text = Convert.ToString(TTOTAL);
            txtCambio.Text = Convert.ToString(Cambio);
        }
        
        private void BtnHome_Click(object sender, EventArgs e)
        {
            PantallaPrincipal obj = new PantallaPrincipal();

            if (MessageBox.Show("Are you sure you want to close this window?", "Warning",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
            obj.Show();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
           if(txtBuscar.Text != "")
            {
                
                dataGridViewProducto.CurrentCell = null;
                foreach(DataGridViewRow producto in dataGridViewProducto.Rows)
                {
                    producto.Visible = false;
                }
                foreach(DataGridViewRow producto in dataGridViewProducto.Rows)
                {
                    foreach (DataGridViewCell p in producto.Cells)
                    {
                        if ((p.Value.ToString().ToUpper()).IndexOf(txtBuscar.Text.ToUpper()) == 0)
                        {
                            producto.Visible = true;
                            break;


                        }
                    }
                }

            }
            else
                dataGridViewProducto.DataSource = objPro.MostrarProducto();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
           
                TTOTAL = Convert.ToDouble(txtTotal.Text);
                Importe = (Convert.ToDouble(txtImporte.Text));

                Cambio = Importe - TTOTAL;
                txtCambio.Text = Convert.ToString(Cambio);

            
               // MessageBox.Show("El importe debe de ser mayor al monto a pagar");
        }
       
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            //objVentas.InsertarOrdenes(OrdenID, idProd, dataGridViewDetalle.CurrentRow.Cells[5].Value.ToString())
        }

        private void BtnIniciarOrden_Click(object sender, EventArgs e)
        {
            //objVentas.InsertarOrden(UserCache.Nombre, DateTime.Now.Date);
            objVentas.InsertarOrden(Convert.ToString(UserCache.UserID) , DateTime.Now);
            dataGridViewProducto.Enabled = true;
        }
    }
}
