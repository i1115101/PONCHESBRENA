using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicaNegocio;

namespace Empezamos
{
    public partial class RegistroEntrada : Form
    {
        int idCategoria, idProducto;
        double Total;
        

        public RegistroEntrada()
        {
            InitializeComponent();           
        }

        #region Limpieza
        void Limpiar()
        {
            cmbCategoria.SelectedIndex = -1;
            cmbProducto.SelectedIndex = -1;
            dtpFechaVencimiento.Value = DateTime.Today;
            nudpreciocompra.Value = 0;
            nudprecioventa.Value = 0;
            nudcantidad.Value = 0;
            nuddescuento.Value = 0;
            lblPrecioUnitarioCompra.Text = "Precio Compra";
            lblPreUnitVenta.Text = "Precio Venta";
            lblStockActual.Text = "Stock";
            lblFechaVcto.Text = "Vencimiento";
            lblTotalPagar.Text = "Total a Pagar";
            

            cmbProveedor.SelectedIndex = -1;
            cmbTipoDocEntrada.SelectedIndex = -1;
            txtNumDocEntrada.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtWeb.Text = "";
            txtEmail.Text = "";

            cmbCategoria.Focus();
            errorProvider1.Clear();

        }
        void AgregarLimpiar()
        {
            cmbCategoria.SelectedIndex = -1;
            cmbProducto.SelectedIndex = -1;
            dtpFechaVencimiento.Value = DateTime.Today;
            nudpreciocompra.Value = 0;
            nudprecioventa.Value = 0;
            nudcantidad.Value = 0;
            nuddescuento.Value = 0;
            lblPrecioUnitarioCompra.Text = "Precio Compra";
            lblPreUnitVenta.Text = "Precio Venta";
            lblStockActual.Text = "Stock";
            lblFechaVcto.Text = "Vencimiento";
            cmbCategoria.Focus();
            errorProvider1.Clear();
            
        }
        #endregion

        #region RellenarComboBox Proveedor, Categoria y TipoDocumento
        void rellenacombo()
        {
            LogicaProveedor ProveedorLis = new LogicaProveedor();
            dgvProveedor.DataSource = ProveedorLis.MostrarProveedor();

            LogicaProveedor Proveedor = new LogicaProveedor();
            cmbProveedor.DataSource = Proveedor.MostrarProveedor();
            cmbProveedor.DisplayMember = "Razón_Social";
            cmbProveedor.ValueMember = "Código";

            LogicaCategoria Categoria = new LogicaCategoria();
            cmbCategoria.DataSource = Categoria.MostrarCategoria();            
            cmbCategoria.DisplayMember = "Categoria";
            cmbCategoria.ValueMember = "IdCategoria";            
        
            LogicaTipoDocumento TipoDocumento = new LogicaTipoDocumento();
            cmbTipoDocProv.DataSource = TipoDocumento.MostrarTipoDocumento();            
            cmbTipoDocProv.DisplayMember = "TipoDocumento";
            cmbTipoDocProv.ValueMember = "IdTipoDocumento";
        }        
        #endregion

        #region Formulario RegistroEntrada_Load
        private void RegistroEntrada_Load(object sender, EventArgs e)
        {            
            dgvEntrada.ColumnCount = 10;
            dgvEntrada.Columns[0].HeaderText = "IdProducto";
            dgvEntrada.Columns[1].HeaderText = "Producto";
            dgvEntrada.Columns[2].HeaderText = "Id Categoria";
            dgvEntrada.Columns[3].HeaderText = "Categoria";
            dgvEntrada.Columns[4].HeaderText = "Fecha Vencimiento";
            dgvEntrada.Columns[5].HeaderText = "Precio Compra";
            dgvEntrada.Columns[6].HeaderText = "Precio Venta";
            dgvEntrada.Columns[7].HeaderText = "Cantidad";
            dgvEntrada.Columns[8].HeaderText = "Descuento";
            dgvEntrada.Columns[9].HeaderText = "Importe";
            dgvEntrada.Columns[0].Visible = false;
            dgvEntrada.Columns[2].Visible = false;
            rellenacombo();            
            Limpiar();
        }
        #endregion

        #region Agregar, Quitar, Nuevo y Salir
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            double suma = 0;

            if (Validar_Agregar_Producto())
            {
                if (MessageBox.Show("¿Seguro de agregar nuevo item al detalle?", "Consulta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dgvEntrada.Rows.Add(idProducto, cmbProducto.Text, idCategoria, cmbCategoria.Text, dtpFechaVencimiento.Value, nudpreciocompra.Value, nudprecioventa.Value, nudcantidad.Value, nuddescuento.Value, Convert.ToDecimal(nudcantidad.Value * nudpreciocompra.Value) - Convert.ToDecimal(nuddescuento.Value));
                    AgregarLimpiar();
                }
                try
                {
                    for (int i = 0; i < dgvEntrada.RowCount; i++)
                    {
                        suma = suma + double.Parse(dgvEntrada.Rows[i].Cells[9].Value.ToString());
                    }
                    Total = Convert.ToDouble(suma);
                    lblTotalPagar.Text = Convert.ToString(Total);
                }
                catch { }
            }
        }
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            double suma = 0;
            if (dgvEntrada.RowCount > 0)
            {
                if (MessageBox.Show("¿Seguro de eliminar item seleccionado a comprobante?", "Consulta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dgvEntrada.Rows.RemoveAt(dgvEntrada.CurrentRow.Index);
                    AgregarLimpiar();
                }
                else
                {
                    MessageBox.Show("No existen items para eliminar", "Aviso", MessageBoxButtons.YesNo);
                }
            }
            for (int i = 0; i < dgvEntrada.RowCount; i++)
            {
                suma = suma + double.Parse(dgvEntrada.Rows[i].Cells[9].Value.ToString());
            }
            Total = Convert.ToDouble(suma);
            lblTotalPagar.Text = Convert.ToString(Total);
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            dgvEntrada.Rows.Clear();
            Limpiar();
            AgregarLimpiar();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region ComboBox Categoria y Producto SelectedIndexChanged

        private void cmbCategoria_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.cmbCategoria,string.Empty);
            try
            {
                SqlDataAdapter sa = new SqlDataAdapter("select IdCategoria from Categoria where IdCategoria='" + cmbCategoria.SelectedValue + "'", varpublic.conexion);
                DataTable da = new DataTable();
                sa.Fill(da);
                idCategoria = Convert.ToInt32(da.Rows[0]["IdCategoria"]);
                sa.Dispose();

                SqlDataAdapter sa2 = new SqlDataAdapter(" SELECT Categoria.IdCategoria, Producto.Producto, Producto.IdProducto FROM Categoria INNER JOIN Producto ON Categoria.IdCategoria = Producto.IdCategoria where Categoria.IdCategoria='" + idCategoria + "'", varpublic.conexion);
                DataTable da2 = new DataTable();
                sa2.Fill(da2);
                cmbProducto.DataSource = da2;
                cmbProducto.DisplayMember = "Producto";
                cmbProducto.ValueMember = "IdProducto";
            }
            catch { }
        }

        private void cmbProducto_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            decimal PrecioVenta, PrecioCompra;
            DateTime FechaVen;
            errorProvider1.SetError(this.cmbProducto, string.Empty);
            try
            {
                SqlDataAdapter sa3 = new SqlDataAdapter("select Producto.* from Producto where Producto='" + cmbProducto.Text + "'", varpublic.conexion);
                DataTable da3 = new DataTable();
                sa3.Fill(da3);
                idProducto = Convert.ToInt32(da3.Rows[0]["IdProducto"]);
                idCategoria = Convert.ToInt32(da3.Rows[0]["IdCategoria"]);
                lblStockActual.Text = Convert.ToString((da3.Rows[0]["Stock"]));
                PrecioVenta = Math.Round(Convert.ToDecimal(da3.Rows[0]["UltPrecioVenta"]), 2);
                lblPreUnitVenta.Text = Convert.ToString(PrecioVenta);
                PrecioCompra = Math.Round(Convert.ToDecimal(da3.Rows[0]["UltPrecioCosto"]), 2);
                lblPrecioUnitarioCompra.Text = Convert.ToString(PrecioCompra);
                sa3.Dispose();

                SqlDataAdapter da = new SqlDataAdapter("SELECT Top 1 DetalleEntrada.* FROM  DetalleEntrada  where  IdProducto = '" + idProducto + "' order by IdEntrada desc", varpublic.conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                FechaVen = Convert.ToDateTime(dt.Rows[0]["FechaVencimiento"]);
                lblFechaVcto.Text = Convert.ToString(FechaVen.ToShortDateString()); ;
                da.Dispose();
            }
            catch { }
        }
        #endregion

        #region ComboBox TipoDocEntrada, TipoDocProv SelectedIndexChanged
        private void cmbTipoDocEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.cmbTipoDocEntrada,string.Empty);
            if (cmbTipoDocEntrada.Text == "Guia de Remisión")
            {
                txtNumDocEntrada.MaxLength = 20;
                txtNumDocEntrada.Clear();
                txtNumDocEntrada.Focus();
            }
            if (cmbTipoDocEntrada.Text == "Entrada Interna")
            {
                txtNumDocEntrada.MaxLength = 20;
                txtNumDocEntrada.Clear();
                txtNumDocEntrada.Focus();
            }
            if (cmbTipoDocEntrada.Text == "Factura")
            {
                txtNumDocEntrada.MaxLength = 8;
                txtNumDocEntrada.Clear();
                txtNumDocEntrada.Focus();
            }
            if (cmbTipoDocEntrada.Text == "Boleta")
            {
                txtNumDocEntrada.MaxLength = 8;
                txtNumDocEntrada.Clear();
                txtNumDocEntrada.Focus();
            }
        }
        private void cmbTipoDocProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.cmbTipoDocProv,string.Empty);
            if (cmbTipoDocProv.Text == "OTROS")
            {
                txtNumDocProv.Clear();
                txtNumDocProv.Text = "0";
            }
            if (cmbTipoDocProv.Text == "DNI")
            {
                txtNumDocProv.Clear();
                txtNumDocProv.MaxLength = 8;
                txtNumDocProv.Focus();
            }
            if (cmbTipoDocProv.Text == "CARNET")
            {
                txtNumDocProv.Clear();
                txtNumDocProv.Focus();
            }
            if (cmbTipoDocProv.Text == "PASAPORTE")
            {
                txtNumDocProv.Clear();
                txtNumDocProv.MaxLength = 15;
                txtNumDocProv.Focus();

            }
            if (cmbTipoDocProv.Text == "RUC")
            {
                txtNumDocProv.Clear();
                txtNumDocProv.MaxLength = 11;
                txtNumDocProv.Focus();
            }
        }
        #endregion

        #region check Cliente, Contraer y expandir grupo entrada

        private void chkCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCliente.Checked == true)
            {
                lbldireccion.Visible = true; lbltelefono.Visible = true; lblweb.Visible = true; lblemail.Visible = true; lblDocProv.Visible = true; lblNumDocProv.Visible = true; lblNuevo.Visible = true;
                //chkCliente.Location = new Point(568, 147);
                rellenacombo();
                btnProveedor.Visible = false;
                this.cmbProveedor.DropDownStyle = ComboBoxStyle.Simple;
                cmbProveedor.SelectedIndex = -1;
                cmbTipoDocProv.SelectedIndex = -1;
                txtNumDocProv.Text = ""; txtTelefono.Text = ""; txtDireccion.Text = ""; txtWeb.Text = ""; txtEmail.Text = "";
            }
            else
            {
                lbldireccion.Visible = false; lbltelefono.Visible = false; lblweb.Visible = false; lblemail.Visible = false; lblDocProv.Visible = false; lblNumDocProv.Visible = false; lblNuevo.Visible = false;
                txtNumDocProv.Text = ""; txtTelefono.Text = ""; txtDireccion.Text = ""; txtWeb.Text = ""; txtEmail.Text = "";
                //chkCliente.Location = new Point(306, 147);
                btnProveedor.Visible = true;

                this.cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private void tmExpandirEntrada_Tick(object sender, EventArgs e)
        {
            if (gbEntrada.Width >= 584)
                this.tmExpandirEntrada.Stop();            
            else
                gbEntrada.Width = gbEntrada.Width + 5;
        }

        private void tmContraerEntrada_Tick(object sender, EventArgs e)
        {
            if (gbEntrada.Width <= 393)
                this.tmContraerEntrada.Stop();            
            else
                gbEntrada.Width = gbEntrada.Width - 5;            
        }

        private void chkCliente_Click(object sender, EventArgs e)
        {
            if (gbEntrada.Width >= 584)
            {
                this.tmContraerEntrada.Start();
                cmbProveedor.Width = 239;
            }
            else if (gbEntrada.Width == 393)
            {
                this.tmExpandirEntrada.Start();
                cmbProveedor.Width = 139;                
            }
            cmbTipoDocEntrada.SelectedValue = -1;
        }

        #endregion

        #region Error Provider

        #region Validar_Agregar_Producto
        private bool Validar_Agregar_Producto()
        {
            double repetido = 0;
            bool no_error = true;

            if (cmbCategoria.Text == string.Empty)
            {
                //MessageBox.Show(this, "Seleccione una Categoria");
                errorProvider1.SetError(cmbCategoria, "Seleccione una Categoria");
                no_error = false;
            }
            if (cmbProducto.Text == string.Empty)
            {
                //MessageBox.Show(this, "Seleccione una Producto");
                errorProvider1.SetError(cmbProducto, "Seleccione una Producto");
                no_error = false;
            }
            if (dtpFechaVencimiento.Value <= DateTime.Today)
            {
                //MessageBox.Show(this, "Seleccione la Fecha de Vencimiento");
                dtpFechaVencimiento.Focus();
                errorProvider1.SetError(dtpFechaVencimiento, "La fecha tiene que ser mayor que hoy");
                no_error = false;
            }
            if (nudpreciocompra.Value == 0)
            {
                //MessageBox.Show(this, "Ingrese un valor de compra");
                errorProvider1.SetError(nudpreciocompra, "Ingrese un valor compra");
                no_error = false;
            }
            if (nudprecioventa.Value == 0)
            {
                //MessageBox.Show(this, "Ingrese un valor de venta");
                errorProvider1.SetError(nudprecioventa, "Ingrese un valor de venta");
                no_error = false;
            }
            if (nudcantidad.Value == 0)
            {
                //MessageBox.Show(this, "Inserte una cantidad");
                errorProvider1.SetError(nudcantidad, "Inserte una cantidad");
                no_error = false;
            }
            if (nudprecioventa.Value <= nudpreciocompra.Value)
            {
                //MessageBox.Show(this, "El Precio de venta no puede ser menor al precio de compra");
                //nudprecioventa.Value = 0;
                nudprecioventa.Focus();
                errorProvider1.SetError(nudprecioventa, "El valor es muy bajo");
                no_error = false;
            }
            for (int i = 0; i < dgvEntrada.RowCount; i++)
            {
                if (dgvEntrada.Rows[i].Cells[0].Value.ToString() == idProducto.ToString())
                {
                    repetido = 1;
                }
            }
            if (repetido == 1)
            {
                AgregarLimpiar();
                MessageBox.Show(this, "El Producto ya está en la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(cmbProducto, "Repetido");
                no_error = false;
            }
            return no_error;
        }
        #endregion

        #region Validar_Registrar_Entrada_Cliente_Nuevo
        private bool Validar_Registrar_Entrada_Cliente_Nuevo()
        {
            bool no_error = true;
            int repetido = 0, repetido2 = 0;

            if (cmbProveedor.Text == string.Empty)
            {
                //MessageBox.Show(this, "Inserte nuevo proveedor");
                errorProvider1.SetError(cmbProveedor, "Inserte nuevo proveedor");
                no_error = false;
            }
            if (cmbTipoDocEntrada.Text == string.Empty)
            {
                //MessageBox.Show(this, "Seleccione un tipo de documento de entrada");
                errorProvider1.SetError(cmbTipoDocEntrada, "Seleccione un tipo de documento de entrada");
                no_error = false;
            }
            if (txtNumDocEntrada.Text == string.Empty)
            {
                //MessageBox.Show(this, "Inserte el número del documento");
                errorProvider1.SetError(txtNumDocEntrada, "Inserte el número del documento");
                no_error = false;
            }
            if (cmbTipoDocProv.Text == string.Empty)
            {
                //MessageBox.Show(this, "Seleccione un tipo de documento del proveedor");
                errorProvider1.SetError(cmbTipoDocProv, "Seleccione un tipo de documento del proveedor");
                no_error = false;
            }
            if (txtNumDocProv.Text == string.Empty)
            {
                //MessageBox.Show(this, "Inserte el número del documento del proveedor");
                errorProvider1.SetError(txtNumDocProv, "Inserte el número del documento del proveedor");
                no_error = false;
            }
            if (txtTelefono.Text == string.Empty)
            {
                //MessageBox.Show(this, "Ingrese el número de telefono del proveedor");
                errorProvider1.SetError(txtTelefono, "Ingrese el número de telefono del proveedor");
                no_error = false;
            }
            if (txtDireccion.Text == string.Empty)
            {
                //MessageBox.Show(this, "Ingrese la dirección del proveedor");
                errorProvider1.SetError(txtDireccion, "Ingrese la dirección del proveedor");
                no_error = false;
            }


            for (int i = 0; i < dgvProveedor.RowCount; i++)
            {
                if (dgvProveedor.Rows[i].Cells[3].Value.ToString() == cmbProveedor.Text.ToUpper())
                {
                    repetido = 1;
                }
            }
            for (int i = 0; i < dgvProveedor.RowCount; i++)
            {
                if (dgvProveedor.Rows[i].Cells[2].Value.ToString() == txtNumDocProv.Text)
                {
                    repetido2 = 1;
                }
            }

            if (repetido == 1)
            {
                MessageBox.Show(this, "Proveedor ya esta registrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProveedor.Text = "";
                cmbProveedor.Focus();
                errorProvider1.SetError(cmbProveedor, "Ingrese Nuevo Proveedor");
                no_error = false;
            }
            if (repetido2 == 1)
            {
                MessageBox.Show(this, "El Documento ya esta registrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtNumDocProv, "Documento Repetido");
                no_error = false;
            }

            if (cmbTipoDocProv.Text == "DNI" & txtNumDocProv.TextLength <= 7)
            {
                //MessageBox.Show("Ingrese 8 digitos del DNI");
                errorProvider1.SetError(txtNumDocProv, "Ingrese 8 digitos del DNI");
                no_error = false;
            }

            if (cmbTipoDocProv.Text == "PASAPORTE" & txtNumDocProv.TextLength <= 4)
            {
                //MessageBox.Show("Ingrese 5 a 15 digitos del pasaporte");
                errorProvider1.SetError(txtNumDocProv, "Ingrese 5 a 15 digitos del pasaporte");
                no_error = false;
            }

            if (cmbTipoDocProv.Text == "RUC" & txtNumDocProv.TextLength < 11)
            {
                //MessageBox.Show("Tiene que ingresar 11 digitos de RUC");
                errorProvider1.SetError(txtNumDocProv, "tiene que ingresar 11 digitos de ruc");
                no_error = false;
            }
            return no_error;
        }
        #endregion

        #region Validar_Registrar_Entrada
        private bool Validar_Registrar_Entrada()
        {
            bool no_error = true;

            if (cmbProveedor.Text == string.Empty)
            {
                //MessageBox.Show(this, "Inserte un proveedor");
                errorProvider1.SetError(cmbProveedor, "Inserte proveedor");
                no_error = false;
            }
            if (cmbTipoDocEntrada.Text == string.Empty)
            {
                //MessageBox.Show(this, "Seleccione un tipo de documento de entrada");
                errorProvider1.SetError(cmbTipoDocEntrada, "Seleccione un tipo de documento de entrada");
                no_error = false;
            }
            if (txtNumDocEntrada.Text == string.Empty)
            {
                //MessageBox.Show(this, "Inserte el número del documento");
                errorProvider1.SetError(txtNumDocEntrada, "Inserte el número del documento");
                no_error = false;
            }

            return no_error;
        }
        #endregion

        #region limpiar icono error al escribir

        private void dtpFechaVencimiento_ValueChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.dtpFechaVencimiento, string.Empty);
        }
        private void nudpreciocompra_ValueChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.nudpreciocompra, string.Empty);
        }
        private void nudprecioventa_ValueChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.nudprecioventa, string.Empty);
        }
        private void nudcantidad_ValueChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.nudcantidad, string.Empty);
        }
        private void nuddescuento_ValueChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.nuddescuento, string.Empty);
        }
        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.cmbProveedor, string.Empty);
        }
        private void txtNumDocEntrada_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtNumDocEntrada, string.Empty);
        }
        private void txtNumDocProv_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtNumDocProv, string.Empty);
        }
        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtTelefono, string.Empty);
        }
        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtDireccion, string.Empty);
        }
        private void cmbProveedor_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.cmbProveedor, string.Empty);
        }      
        private void txtNumDocEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            varpublic.SoloNumeros(e);
        }
        private void txtNumDocProv_KeyPress(object sender, KeyPressEventArgs e)
        {
            varpublic.SoloNumeros(e);
        }
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            varpublic.SoloNumeros(e);
        }
        #endregion

        #endregion

        #region Logica Negocio
        private bool GuardarEntrada(int IdProveedor, DateTime FechaEntrada, string TipoDocumentoEntrada, string NroDocumentoEntrada, decimal CostoTotal)
        {
            LogicaEntrada logicaEntrada = new LogicaEntrada();
            bool resu = logicaEntrada.InsertarEntrada(IdProveedor, FechaEntrada, TipoDocumentoEntrada, NroDocumentoEntrada, CostoTotal);
            return resu;
        }
        private bool GuardarDetalleEntrada(int IdProducto, int IdEntrada, DateTime FechaVencimiento, decimal PrecioCompra,decimal PrecioVenta, int Cantidad, decimal Descuento, decimal Importe)
        {
            LogicaDetalleEntrada logicaDetalleEntrada = new LogicaDetalleEntrada();

            bool resu2 = logicaDetalleEntrada.InsertarDetalleEntrada(IdProducto, IdEntrada, FechaVencimiento, PrecioCompra, PrecioVenta, Cantidad, Descuento, Importe);
            return resu2;
        }
        private bool GuardarProveedor(int IdTipoDocumento, string NroDocumento, string RazonSocial, string Direccion, string Telefono,
           string Web, string Email)
        {
            LogicaProveedor logicaProveedor = new LogicaProveedor();
            bool resu3 = logicaProveedor.InsertarProveedor(IdTipoDocumento, NroDocumento, RazonSocial, Direccion, Telefono, Web, Email);
            return resu3;
        }
        #endregion

        #region Registrar 

        private void cmdRegistrar_Click(object sender, EventArgs e)
        {
            if (dgvEntrada.RowCount > 0 && chkCliente.Checked == true)
            {
                if (Validar_Registrar_Entrada_Cliente_Nuevo())
                {
                    try
                    {
                        //Insertar Proveedor
                        int IdTipoDocumento = Convert.ToInt32(cmbTipoDocProv.SelectedValue);
                        string NroDocumento = txtNumDocProv.Text;
                        string RazonSocial = cmbProveedor.Text.ToUpper();
                        string Direccion = txtDireccion.Text.ToUpper();
                        string Telefono = txtTelefono.Text;
                        string Web = txtWeb.Text;
                        string Email = txtEmail.Text;

                        bool resu3 = false;

                        resu3 = GuardarProveedor(IdTipoDocumento, NroDocumento, RazonSocial, Direccion, Telefono, Web, Email);
                        if (resu3)
                        {
                            MessageBox.Show("Nuevo Proveedor registrado exitosamente");                            
                        }
                        //-------------------------------------------------------------------------

                        SqlDataAdapter p = new SqlDataAdapter("select top 1 * from Proveedor order by IdProveedor desc", varpublic.conexion);
                        DataTable pr = new DataTable();
                        p.Fill(pr);
                        p.Dispose();
                        varpublic.idProveedor = Convert.ToInt32(pr.Rows[0]["IdProveedor"]);
                        p.Dispose();

                        //Insertar Entrada
                        int IdProveedor = varpublic.idProveedor;
                        DateTime FechaEntrada = Convert.ToDateTime(DateTime.Now);
                        string TipoDocumentoEntrada = cmbTipoDocEntrada.Text;
                        string NroDocumentoEntrada = txtNumDocEntrada.Text;
                        decimal CostoTotal = Convert.ToDecimal(Total);

                        bool resu = false;

                        resu = GuardarEntrada(IdProveedor, FechaEntrada, TipoDocumentoEntrada, NroDocumentoEntrada, CostoTotal);
                        //-----------------------------------------------------------------------------------


                        SqlDataAdapter da2 = new SqlDataAdapter("select top 1 * from Entrada order by IdEntrada desc", varpublic.conexion);
                        DataTable dt2 = new DataTable();
                        da2.Fill(dt2);
                        da2.Dispose();
                        varpublic.idEntrada = Convert.ToInt32(dt2.Rows[0]["IdEntrada"]);

                        da2.Dispose();

                        //Insertar DetalleEntrada
                        for (int c = 0; c <= dgvEntrada.RowCount - 1; c++)
                        {
                            int IdProducto = Convert.ToInt32(dgvEntrada.Rows[c].Cells[0].Value);
                            int IdEntrada = Convert.ToInt32(varpublic.idEntrada);
                            DateTime FechaVencimiento = Convert.ToDateTime(dgvEntrada.Rows[c].Cells[4].Value);
                            decimal PrecioCompra = Convert.ToDecimal(dgvEntrada.Rows[c].Cells[5].Value);
                            decimal PrecioVenta = Convert.ToDecimal(dgvEntrada.Rows[c].Cells[6].Value);
                            int Cantidad = Convert.ToInt32(dgvEntrada.Rows[c].Cells[7].Value);
                            decimal Descuento = Convert.ToDecimal(dgvEntrada.Rows[c].Cells[8].Value);
                            decimal Importe = Convert.ToDecimal(dgvEntrada.Rows[c].Cells[9].Value);

                            bool resu2 = false;

                            resu2 = GuardarDetalleEntrada(IdProducto, IdEntrada, FechaVencimiento, PrecioCompra, PrecioVenta,
                                                         Cantidad, Descuento, Importe);
                         }
                        //-----------------------------------------------------------------------------------


                        for (int d = 0; d <= dgvEntrada.Rows.Count - 1; d++)
                        {
                            SqlDataAdapter esta = new SqlDataAdapter("update Producto set Stock=Stock+'" + Convert.ToInt32(dgvEntrada.Rows[d].Cells[7].Value) + "',UltPrecioCosto='" + Convert.ToDecimal(dgvEntrada.Rows[d].Cells[5].Value) + "',UltPrecioVenta='" + Convert.ToDecimal(dgvEntrada.Rows[d].Cells[6].Value) + "'  where IdProducto='" + Convert.ToInt32(dgvEntrada.Rows[d].Cells[0].Value) + "'", varpublic.conexion);
                            DataTable xd = new DataTable();
                            esta.Fill(xd);
                            esta.Dispose();
                        }
                        MessageBox.Show("Ingreso procesado exitosamente", "Aviso");
                        dgvEntrada.Rows.Clear();
                        rellenacombo();
                        Limpiar();
                        AgregarLimpiar();
                        chkCliente.Checked = false;
                        this.tmContraerEntrada.Start();
                        cmbProveedor.Width = 239;
                        errorProvider1.Clear();
                    }
                    catch
                    {
                        MessageBox.Show("Error, no se inserto registro");
                    }
                }
            }
            else
            {
                if (dgvEntrada.RowCount > 0)
                {
                    if (Validar_Registrar_Entrada())
                    {
                        try
                        {
                            //Insertar Entrada
                            int IdProveedor = Convert.ToInt32(cmbProveedor.SelectedValue);
                            DateTime FechaEntrada = Convert.ToDateTime(DateTime.Now);
                            string TipoDocumentoEntrada = cmbTipoDocEntrada.Text;
                            string NroDocumentoEntrada = txtNumDocEntrada.Text;
                            decimal CostoTotal = Convert.ToDecimal(Total);

                            bool resu = false;

                            resu = GuardarEntrada(IdProveedor, FechaEntrada, TipoDocumentoEntrada, NroDocumentoEntrada, CostoTotal);
                            //-----------------------------------------------------------------------------------

                            SqlDataAdapter da2 = new SqlDataAdapter("select top 1 * from Entrada order by IdEntrada desc", varpublic.conexion);
                            DataTable dt2 = new DataTable();
                            da2.Fill(dt2);
                            da2.Dispose();
                            varpublic.idEntrada = Convert.ToInt32(dt2.Rows[0]["IdEntrada"]);
                            da2.Dispose();

                            //Insertar DetalleEntrada
                            for (int c = 0; c <= dgvEntrada.RowCount - 1; c++)
                            {
                                int IdProducto = Convert.ToInt32(dgvEntrada.Rows[c].Cells[0].Value);
                                int IdEntrada = Convert.ToInt32(varpublic.idEntrada);
                                DateTime FechaVencimiento = Convert.ToDateTime(dgvEntrada.Rows[c].Cells[4].Value);
                                decimal PrecioCompra = Convert.ToDecimal(dgvEntrada.Rows[c].Cells[5].Value);
                                decimal PrecioVenta = Convert.ToDecimal(dgvEntrada.Rows[c].Cells[6].Value);
                                int Cantidad = Convert.ToInt32(dgvEntrada.Rows[c].Cells[7].Value);
                                decimal Descuento = Convert.ToDecimal(dgvEntrada.Rows[c].Cells[8].Value);
                                decimal Importe = Convert.ToDecimal(dgvEntrada.Rows[c].Cells[9].Value);

                                bool resu2 = false;

                                resu2 = GuardarDetalleEntrada(IdProducto, IdEntrada, FechaVencimiento, PrecioCompra, PrecioVenta, Cantidad, Descuento, Importe);                               
                            }                           
                            for (int d = 0; d <= dgvEntrada.Rows.Count - 1; d++)
                            {
                                SqlDataAdapter esta = new SqlDataAdapter("update Producto set Stock=Stock+'" + Convert.ToInt32(dgvEntrada.Rows[d].Cells[7].Value) + "',UltPrecioCosto='" + Convert.ToDecimal(dgvEntrada.Rows[d].Cells[5].Value) + "',UltPrecioVenta='" + Convert.ToDecimal(dgvEntrada.Rows[d].Cells[6].Value) + "'  where IdProducto='" + Convert.ToInt32(dgvEntrada.Rows[d].Cells[0].Value) + "'", varpublic.conexion);
                                DataTable xd = new DataTable();
                                esta.Fill(xd);
                                esta.Dispose();
                            }
                            MessageBox.Show("Ingreso procesado", "Aviso");
                            dgvEntrada.Rows.Clear();
                            rellenacombo();
                            Limpiar();
                            AgregarLimpiar();
                        }
                        catch(System.Exception ex) { MessageBox.Show(ex.ToString()); }                      
                    }
                }
                else
                {
                    MessageBox.Show("No se puede grabar ingreso," + Char.ConvertFromUtf32(13) + "No existen items o superó límite máximo de items por comprobante", "Aviso");
                }
            }
        }
        #endregion
    }
}

