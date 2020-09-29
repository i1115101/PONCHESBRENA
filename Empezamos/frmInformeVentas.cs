using System;
using System.Data;
using System.Windows.Forms;
using LogicaNegocio;
using Microsoft.Reporting.WinForms;

namespace Empezamos
{
    public partial class frmInformeVentas : Form
    {
        public frmInformeVentas()
        {
            InitializeComponent();
        }

        private void frmInformeVentas_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
        LogicaInforme Informe = new LogicaInforme();
        DataTable Listado = new DataTable();
        private void btnListar_Click(object sender, EventArgs e)
        {
           
        }
        private bool ValidarFechas()
        {
            bool no_error = true;

            if (dtpInicio.Value > dtpFinal.Value)
            {
                errorProvider1.SetError(dtpInicio, "Seleccione una fecha menor a la final");
                no_error = false;
            }
            return no_error;
        }
        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.dtpInicio, string.Empty);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarFechas())
            {

                DataTable TablaRecordProd;
                string[] lsRecordPro = { dtpInicio.Value.ToString("dd-MM-yyyy"), dtpFinal.Value.ToString("dd-MM-yyyy") };
                TablaRecordProd = Informe.ParametrosRecordProd(lsRecordPro);
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rp = new ReportDataSource("DataSet2", TablaRecordProd);
                reportViewer1.LocalReport.DataSources.Add(rp);

                DataTable TablaRecordCli;
                string[] lsRecordCli = { dtpInicio.Value.ToString("dd-MM-yyyy"), dtpFinal.Value.ToString("dd-MM-yyyy") };
                TablaRecordCli = Informe.ParametrosRecordCli(lsRecordCli);
                ReportDataSource rc = new ReportDataSource("DataSet3", TablaRecordCli);
                reportViewer1.LocalReport.DataSources.Add(rc);

                DataTable InformeVentas;
                string[] lsInforme = { dtpInicio.Value.ToString("dd-MM-yyyy"), dtpFinal.Value.ToString("dd-MM-yyyy") };
                InformeVentas = Informe.ParametrosInforme(lsInforme);
                ReportDataSource cp = new ReportDataSource("DataSet1", InformeVentas);
                reportViewer1.LocalReport.DataSources.Add(cp);
                reportViewer1.RefreshReport();
            }
        }
    }
}
