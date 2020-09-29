using System;
using System.Data;
using System.Windows.Forms;
using LogicaNegocio;
using Microsoft.Reporting.WinForms;

namespace Empezamos
{
    public partial class frmBuscProducto : Form
    {
        LogicaInforme productos = new LogicaInforme();
        LogicaCategoria Categoria = new LogicaCategoria();
        LogicaProducto objeto = new LogicaProducto();
        DataTable TablaRecordProd;
        void RellenaCombo()
        {
            cmbCategoria.DataSource = Categoria.ListCategoria();
            cmbCategoria.DisplayMember = "cNombreCategoria";
            cmbCategoria.ValueMember = "nIdTCategoria";

            cmbProducto.DataSource = objeto.productotable();
            cmbProducto.DisplayMember = "cNombreProducto";
            cmbProducto.ValueMember = "nIdProducto";
        }
        public frmBuscProducto()
        {
            InitializeComponent();
        }
        private void frmBuscProducto_Load(object sender, EventArgs e)
        {
            rbtFecha.Checked = true;
            cmbCategoria.SelectedIndex = -1;
            cmbProducto.SelectedIndex = -1;
            this.reportViewer1.RefreshReport();
            RellenaCombo();
        }
       
     
        #region RadioBoton
        private void rbtFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtFecha.Checked)
            {
                dtpInicio.Enabled = true;
                dtpFin.Enabled = true;
                cmbCategoria.Enabled = false;
                cmbProducto.Enabled = false;
                cmbProducto.Text="";
                cmbCategoria.Text = "";
                rbtNombre.Checked = false;
                rbtCategoria.Checked = false;
               
            }
        }
        private void rbtNombre_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtNombre.Checked)
            {
                dtpInicio.Enabled = false;
                dtpFin.Enabled = false;
                cmbCategoria.Enabled = false;
                cmbCategoria.Text = "";
                cmbProducto.Enabled = true;
                rbtCategoria.Checked = false;
                rbtFecha.Checked = false;
            }
        }
        private void rbtCategoria_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtCategoria.Checked)
            {
                dtpInicio.Enabled = false;
                dtpFin.Enabled = false;
                cmbCategoria.Enabled = true;
                cmbProducto.Enabled = false;
                cmbProducto.Text = "";
                rbtFecha.Checked = false;
                rbtNombre.Checked = false;
            }
        }
        #endregion

        #region validaciones
        private bool ValidarBusqueda()
        {
            bool no_error = true;

            if (dtpInicio.Value > DateTime.Now)
            {
                errorProvider1.SetError(dtpInicio, "Seleccione una fecha menor a la final");
                no_error = false;
            }
            if (cmbProducto.Text =="" && rbtNombre.Checked == true)
            {
                errorProvider1.SetError(cmbProducto, "Ingrese un nombre de producto");                
                no_error = false;
            }
            if (cmbCategoria.Text == "" && rbtCategoria.Checked == true)
            {
                errorProvider1.SetError(cmbCategoria, "Ingrese un nombre de categoria");               
                no_error = false;
            }
            return no_error;
        }
        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.cmbProducto, string.Empty);
        }
        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.cmbCategoria, string.Empty);
        }
        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.dtpInicio, string.Empty);
        }
        #endregion

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            if (ValidarBusqueda())
            {
                if (rbtFecha.Checked)
                {
                    string[] lsRecordPro = { dtpInicio.Value.ToString("dd-MM-yyyy"), dtpFin.Value.ToString("dd-MM-yyyy") };
                    TablaRecordProd = productos.ParametrosProductos(lsRecordPro);
                }
                if (rbtNombre.Checked)
                {
                    string[] lsRecordPro = { cmbProducto.Text };
                    TablaRecordProd = productos.ParamNomProductos(lsRecordPro);
                }
                if (rbtCategoria.Checked)
                {
                    string[] lsRecordPro = { cmbCategoria.Text };
                    TablaRecordProd = productos.ParamCategriaProduc(lsRecordPro);
                }

                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rp = new ReportDataSource("DataSet1", TablaRecordProd);
                reportViewer1.LocalReport.DataSources.Add(rp);
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
