using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;
using LogicaNegocio;
using Entidad;

namespace Empezamos
{
    public partial class frmEstadisticasVentas : Form
    {
        public frmEstadisticasVentas()
        {
            InitializeComponent();
        }  
        private void Dashboard()
        {
            LogicaDashboard neg = new LogicaDashboard();
            EntidadDashboard obj = new EntidadDashboard();
            neg.Dashboard(obj);

            //recuperamos datos de entidad para cargarlos los datos de Dashboard
            chartProdPreferidos.Series[0].Points.DataBindXY(obj.Producto1, obj.Cant1);
            chartProdxCategoria.Series[0].Points.DataBindXY(obj.Categoria1, obj.CantProd1);
            lblCantCateg.Text = obj.CantCateg1;
            lblCantClient.Text = obj.CantClient1;
            lblCantEmple.Text = obj.CantEmple1;
            lblCantProv.Text = obj.CantProv1;
            lblTotalVentas.Text = obj.TotalVentas1;
            lblCantProd.Text = obj.CantProductos1;
        }   

        private void frmEstadisticasVentas_Load(object sender, EventArgs e)
        {
            Dashboard();
        }
    }
}

