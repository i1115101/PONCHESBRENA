using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Empezamos
{
    public partial class BoletaVenta : Form
    {
        public BoletaVenta()
        {
            InitializeComponent();
        }

        private void BoletaVenta_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'BDSOFOBREÑADataSet1.SV_BOLETA2' table. You can move, or remove it, as needed.
            this.SV_BOLETA2TableAdapter.Fill(this.BDSOFOBREÑADataSet1.SV_BOLETA2);
            // TODO: esta línea de código carga datos en la tabla 'DataSetBoleta.SV_ReporteBoleta' Puede moverla o quitarla según sea necesario.
            this.SV_ReporteBoletaTableAdapter.Fill(this.DataSetBoleta.SV_ReporteBoleta);

            this.reportViewer1.RefreshReport();
        }
    }
}
