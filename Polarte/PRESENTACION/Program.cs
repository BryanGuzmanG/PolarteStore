﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRESENTACION
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

             //Application.Run(new frmLogin());
             Application.Run(new frmVentas());
            //Application.Run(new frmProducto());  
            //Application.Run(new frmProducto());
        }
    }
}
