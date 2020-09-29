using System;
using System.Data;
using System.Windows.Forms;
using LogicaNegocio;
using Microsoft.Reporting.WinForms;
using System.Runtime.InteropServices;

namespace Empezamos
{
    public partial class frmComprobanteEntrada : Form
    {
        public frmComprobanteEntrada()
        {
            InitializeComponent();
        }
        
        LogicaInforme comprobante = new LogicaInforme();
        private void frmComprobanteEntrada_Load(object sender, EventArgs e)
        {
            DataTable TablaBoleta;
            TablaBoleta = comprobante.RellComprobEntra();
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("DataSet2", TablaBoleta);
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
        #region Movimiento de form
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
