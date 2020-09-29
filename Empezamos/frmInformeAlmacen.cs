using System;
using System.Data;
using System.Windows.Forms;
using LogicaNegocio;
using Microsoft.Reporting.WinForms;

namespace Empezamos
{
    public partial class frmInformeAlmacen : Form
    {
        public frmInformeAlmacen()
        {
            InitializeComponent();
        }
        LogicaInforme informealmacen = new LogicaInforme();
        private void frmInformeAlmacen_Load(object sender, EventArgs e)
        {
            DataTable TablaInfoAlmacen;
            TablaInfoAlmacen = informealmacen.MostrarInformeAlmacen();
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("DataSet1", TablaInfoAlmacen);
            reportViewer1.LocalReport.DataSources.Add(rp);

            DataTable TablaInfoProveedor;
            TablaInfoProveedor = informealmacen.MostrarInformeProveedor();
            ReportDataSource rpr = new ReportDataSource("DataSet2", TablaInfoProveedor);
            reportViewer1.LocalReport.DataSources.Add(rpr);
            this.reportViewer1.RefreshReport();

            DataTable RecordProveedor;
            RecordProveedor = informealmacen.RecordProveedor();
            ReportDataSource rpro = new ReportDataSource("DataSet3", RecordProveedor);
            reportViewer1.LocalReport.DataSources.Add(rpro);
            this.reportViewer1.RefreshReport();
            
        }
    }
}
