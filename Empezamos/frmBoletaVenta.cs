using System;
using System.Data;
using System.Windows.Forms;
using LogicaNegocio;
using Microsoft.Reporting.WinForms;
using System.Runtime.InteropServices;

namespace Empezamos
{
    public partial class frmBoletaVenta : Form
    {
        public frmBoletaVenta()
        {
            InitializeComponent();
        }
        LogicaInforme boleta = new LogicaInforme();
        private void frmBoletaVenta_Load(object sender, EventArgs e)
        {            
            DataTable TablaBoleta;
            TablaBoleta = boleta.RellenarBoleta();
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("DataSet1", TablaBoleta);
            reportViewer1.LocalReport.DataSources.Add(rp);
            this.reportViewer1.RefreshReport();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cerrar?", "Alerta¡¡", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        #region Movimiento del form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void sendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            sendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
    }
}
