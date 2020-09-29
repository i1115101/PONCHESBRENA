namespace Empezamos
{
    partial class frmInformeAlmacen
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.AlmacenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.InformeVentas = new Empezamos.InformeVentas();
            this.ProveedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RecordProveedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.AlmacenBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InformeVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProveedorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordProveedorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // AlmacenBindingSource
            // 
            this.AlmacenBindingSource.DataMember = "Almacen";
            this.AlmacenBindingSource.DataSource = this.InformeVentas;
            // 
            // InformeVentas
            // 
            this.InformeVentas.DataSetName = "InformeVentas";
            this.InformeVentas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ProveedorBindingSource
            // 
            this.ProveedorBindingSource.DataMember = "Proveedor";
            this.ProveedorBindingSource.DataSource = this.InformeVentas;
            // 
            // RecordProveedorBindingSource
            // 
            this.RecordProveedorBindingSource.DataMember = "RecordProveedor";
            this.RecordProveedorBindingSource.DataSource = this.InformeVentas;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.AlmacenBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.ProveedorBindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.RecordProveedorBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Empezamos.InformeAlmacen.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1052, 544);
            this.reportViewer1.TabIndex = 0;
            // 
            // frmInformeAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 544);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmInformeAlmacen";
            this.Text = "frmInformeAlmacen";
            this.Load += new System.EventHandler(this.frmInformeAlmacen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AlmacenBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InformeVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProveedorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordProveedorBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource AlmacenBindingSource;
        private InformeVentas InformeVentas;
        private System.Windows.Forms.BindingSource ProveedorBindingSource;
        private System.Windows.Forms.BindingSource RecordProveedorBindingSource;
    }
}