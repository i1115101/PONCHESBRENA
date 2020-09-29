namespace Empezamos
{
    partial class BoletaVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.SV_BOLETA2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BDSOFOBREÑADataSet1 = new Empezamos.BDSOFOBREÑADataSet1();
            this.SV_ReporteBoletaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetBoleta = new Empezamos.DataSetBoleta();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SV_ReporteBoletaTableAdapter = new Empezamos.DataSetBoletaTableAdapters.SV_ReporteBoletaTableAdapter();
            this.SV_BOLETA2TableAdapter = new Empezamos.BDSOFOBREÑADataSet1TableAdapters.SV_BOLETA2TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SV_BOLETA2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BDSOFOBREÑADataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SV_ReporteBoletaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetBoleta)).BeginInit();
            this.SuspendLayout();
            // 
            // SV_BOLETA2BindingSource
            // 
            this.SV_BOLETA2BindingSource.DataMember = "SV_BOLETA2";
            this.SV_BOLETA2BindingSource.DataSource = this.BDSOFOBREÑADataSet1;
            // 
            // BDSOFOBREÑADataSet1
            // 
            this.BDSOFOBREÑADataSet1.DataSetName = "BDSOFOBREÑADataSet1";
            this.BDSOFOBREÑADataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SV_ReporteBoletaBindingSource
            // 
            this.SV_ReporteBoletaBindingSource.DataMember = "SV_ReporteBoleta";
            this.SV_ReporteBoletaBindingSource.DataSource = this.DataSetBoleta;
            // 
            // DataSetBoleta
            // 
            this.DataSetBoleta.DataSetName = "DataSetBoleta";
            this.DataSetBoleta.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SV_BOLETA2BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Empezamos.rptBoleta1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(752, 477);
            this.reportViewer1.TabIndex = 0;
            // 
            // SV_ReporteBoletaTableAdapter
            // 
            this.SV_ReporteBoletaTableAdapter.ClearBeforeFill = true;
            // 
            // SV_BOLETA2TableAdapter
            // 
            this.SV_BOLETA2TableAdapter.ClearBeforeFill = true;
            // 
            // BoletaVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 477);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BoletaVenta";
            this.Text = "BoletaVenta";
            this.Load += new System.EventHandler(this.BoletaVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SV_BOLETA2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BDSOFOBREÑADataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SV_ReporteBoletaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetBoleta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SV_ReporteBoletaBindingSource;
        private DataSetBoleta DataSetBoleta;
        private DataSetBoletaTableAdapters.SV_ReporteBoletaTableAdapter SV_ReporteBoletaTableAdapter;
        private System.Windows.Forms.BindingSource SV_BOLETA2BindingSource;
        private BDSOFOBREÑADataSet1 BDSOFOBREÑADataSet1;
        private BDSOFOBREÑADataSet1TableAdapters.SV_BOLETA2TableAdapter SV_BOLETA2TableAdapter;
    }
}