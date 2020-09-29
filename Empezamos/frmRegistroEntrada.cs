using LogicaNegocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace Empezamos
{
    public partial class frmRegistroEntrada : Form
    {
        int idCategoria, idProducto;
        double Total;
        DataTable unidadP;
        LogicaProveedor Proveedor = new LogicaProveedor();
        LogicaTipoDocumento TipoDocumento = new LogicaTipoDocumento();
        LogicaCategoria Categoria = new LogicaCategoria();
        LogicaProducto producto = new LogicaProducto();
        LogicaEntrada Lentrada = new LogicaEntrada();
        LogicaDetalleEntrada DEntrada = new LogicaDetalleEntrada();
        public frmRegistroEntrada()
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
            txtrepresentante.Text = "";
            txtfono.Text = "";

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
        void rellproveedor()
        {
            dgvProveedor.DataSource = Proveedor.ListProveedor();
            cmbProveedor.DataSource = Proveedor.ListProveedor();
            cmbProveedor.DisplayMember = "cRazonSocial";
            cmbProveedor.ValueMember = "nIdProveedor";
        }
        
        void rellenacombo()
        {
            cmbCategoria.DataSource = Categoria.ListCategoria();
            cmbCategoria.DisplayMember = "cNombreCategoria";
            cmbCategoria.ValueMember = "nIdTCategoria";

            cmbTipoDocEntrada.DataSource = TipoDocumento.ListDocEnt();
            cmbTipoDocEntrada.DisplayMember = "cTipoComprobante";
            cmbTipoDocEntrada.ValueMember = "nIdTComprobante";
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
            dgvEntrada.Columns[5].DefaultCellStyle.Format = "N2";
            dgvEntrada.Columns[6].DefaultCellStyle.Format = "N2";
            dgvEntrada.Columns[8].DefaultCellStyle.Format = "N2";
            dgvEntrada.Columns[9].DefaultCellStyle.Format = "N2";
            dgvEntrada.Columns[0].Visible = false;
            dgvEntrada.Columns[2].Visible = false;
            rellproveedor();
            rellenacombo();
            Limpiar();
        }
        #endregion

        #region Agregar, Quitar, Nuevo y Salir
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int rep=0,num=0;
            double suma = 0;

            if (Validar_Agregar_Producto())
            {
                for (int i = 0; i < dgvEntrada.RowCount; i++)
                {
                    if (dgvEntrada.Rows[i].Cells[0].Value.ToString() == idProducto.ToString())
                    {
                        rep = 1;
                        num = i;
                    }
                }
                if (rep == 0)
                {
                    if (MessageBox.Show("¿Seguro de agregar nuevo item al detalle?", "Consulta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        dgvEntrada.Rows.Add(idProducto, cmbProducto.Text, idCategoria, cmbCategoria.Text, dtpFechaVencimiento.Value, nudpreciocompra.Value, nudprecioventa.Value, nudcantidad.Value, nuddescuento.Value, Convert.ToDecimal(nudcantidad.Value * nudpreciocompra.Value) - Convert.ToDecimal(nuddescuento.Value));
                        AgregarLimpiar();
                    }
                }
                else
                {
                    dgvEntrada.Rows[num].Cells[7].Value = Convert.ToInt32(dgvEntrada.Rows[num].Cells[7].Value)+ Convert.ToInt32(nudcantidad.Value);
                    dgvEntrada.Rows[num].Cells[8].Value = Convert.ToDecimal(nuddescuento.Value);
                    dgvEntrada.Rows[num].Cells[9].Value = (Convert.ToDecimal(dgvEntrada.Rows[num].Cells[7].Value) * Convert.ToDecimal(dgvEntrada.Rows[num].Cells[5].Value)) - Convert.ToDecimal(dgvEntrada.Rows[num].Cells[8].Value);
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
            errorProvider1.SetError(this.cmbCategoria, string.Empty);
            try
            {
                string id = Convert.ToString(cmbCategoria.SelectedValue);
                cmbProducto.DataSource = producto.produxcate(id);
                cmbProducto.DisplayMember = "cNombreProducto";
                cmbProducto.ValueMember = "nIdProducto";
                cmbProducto.SelectedIndex = -1;
            }
            catch { }
        }

        private void cmbProducto_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.cmbProducto, string.Empty);
            try
            {
                if ("" != cmbProducto.Text)
                {
                    string id = Convert.ToString(cmbProducto.SelectedValue);
                    unidadP = producto.unidproduc(id);
                    idProducto = Convert.ToInt32(cmbProducto.SelectedValue);
                    idCategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
                    lblPrecioUnitarioCompra.Text = Convert.ToString(unidadP.Rows[0]["nUltPrecioCosto"]);
                    lblPreUnitVenta.Text = Convert.ToString(unidadP.Rows[0]["nUltPrecioVenta"]);
                    lblStockActual.Text = Convert.ToString(unidadP.Rows[0]["nStock"]);
                }
                else
                {
                    lblPrecioUnitarioCompra.Text = "Precio Compra";
                    lblPreUnitVenta.Text = "Precio Venta";
                    lblStockActual.Text = "Stock Actual";
                }

            }
            catch { }
        }
        #endregion

        #region ComboBox TipoDocEntrada, TipoDocProv SelectedIndexChanged
        private void cmbTipoDocEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.cmbTipoDocEntrada, string.Empty);
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

        #endregion

        #region check Cliente, Contraer y expandir grupo entrada

        private void chkCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (chknewprov.Checked == true)
            {
                lbldireccion.Visible = true; lbltelefono.Visible = true; lblNumDocProv.Visible = true; lblNuevo.Visible = true;
                btnProveedor.Visible = false;
                this.cmbProveedor.DropDownStyle = ComboBoxStyle.Simple;
                cmbProveedor.SelectedIndex = -1;

                txtruc.Text = ""; txtrepresentante.Text = ""; txtfono.Text = "";
                chkupdprov.Enabled = false;
            }
            else
            {
                lbldireccion.Visible = false; lbltelefono.Visible = false; lblNumDocProv.Visible = false; lblNuevo.Visible = false;
                txtruc.Text = ""; txtrepresentante.Text = ""; txtfono.Text = "";
                btnProveedor.Visible = true;

                this.cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
                chkupdprov.Enabled = true;
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
            cmbTipoDocEntrada.SelectedIndex = -1;
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
                if (MessageBox.Show("¿Desea aumentar la cantidad del item al detalle?", "Consulta", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    AgregarLimpiar();
                    //MessageBox.Show(this, "El Producto ya está en la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //errorProvider1.SetError(cmbProducto, "Repetido");
                    no_error = false;
                }
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

            if (txtruc.Text == string.Empty)
            {
                //MessageBox.Show(this, "Inserte el número del documento del proveedor");
                errorProvider1.SetError(txtruc, "Inserte el número del documento del proveedor");
                no_error = false;
            }
            if (txtrepresentante.Text == string.Empty)
            {
                //MessageBox.Show(this, "Ingrese el número de telefono del proveedor");
                errorProvider1.SetError(txtrepresentante, "Ingrese el número de telefono del proveedor");
                no_error = false;
            }
            if (txtfono.Text == string.Empty)
            {
                //MessageBox.Show(this, "Ingrese la dirección del proveedor");
                errorProvider1.SetError(txtfono, "Ingrese la dirección del proveedor");
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
                if (dgvProveedor.Rows[i].Cells[2].Value.ToString() == txtruc.Text)
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
                errorProvider1.SetError(txtruc, "Documento Repetido");
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
            
            for (int i = 0; i < dgvProveedor.Rows.Count; i++)
            {
                if (Convert.ToString(dgvProveedor.Rows[i].Cells["nIdProveedor"].Value) == Convert.ToString(cmbProveedor.SelectedValue))
                {
                    txtruc.Text = Convert.ToString(dgvProveedor.Rows[i].Cells["cRuc"].Value);
                    txtrepresentante.Text = Convert.ToString(dgvProveedor.Rows[i].Cells["cRepresentante"].Value);
                    txtfono.Text = Convert.ToString(dgvProveedor.Rows[i].Cells["cTelefono"].Value);
                }
            }
        }
        private void txtNumDocEntrada_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtNumDocEntrada, string.Empty);
        }
        private void txtNumDocProv_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtruc, string.Empty);
        }
        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtrepresentante, string.Empty);
        }
        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtfono, string.Empty);
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

        private void chkupdprov_CheckedChanged(object sender, EventArgs e)
        {
            if (chkupdprov.Checked == true)
            {
                lbldireccion.Visible = true; lbltelefono.Visible = true; lblNumDocProv.Visible = true; lblNuevo.Visible = true;
                btnProveedor.Visible = false;
                                
                chknewprov.Enabled = false;
            }
            else
            {
                lbldireccion.Visible = false; lbltelefono.Visible = false; lblNumDocProv.Visible = false; lblNuevo.Visible = false;                
                btnProveedor.Visible = true;
                this.cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
                chknewprov.Enabled = true;
            }
        }

        private void chkupdprov_Click(object sender, EventArgs e)
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
            //cmbTipoDocEntrada.SelectedIndex = -1;
        }

        private void txtfono_KeyPress(object sender, KeyPressEventArgs e)
        {
            varpublic.SoloNumeros(e);
        }
        #endregion

        #endregion

        #region Registrar 

        private void cmdRegistrar_Click(object sender, EventArgs e)
        {
            string idprov, ident;
            if (dgvEntrada.Rows.Count > 0)
            {
                try
                {
                    if (chknewprov.Checked == true)
                    {
                        string[] lprov = { "0",cmbProveedor.Text, txtruc.Text, txtrepresentante.Text, txtfono.Text };
                        idprov = Proveedor.InsActProveedor(lprov);
                    }
                    else if (chkupdprov.Checked == true)
                    {
                        string[] lprov = { Convert.ToString(cmbProveedor.SelectedValue), cmbProveedor.Text, txtruc.Text, txtrepresentante.Text, txtfono.Text };
                        idprov = Proveedor.InsActProveedor(lprov);
                    }
                    else
                    {
                        idprov = Convert.ToString(cmbProveedor.SelectedValue);
                    }

                    string[] lEnt = { idprov,DateTime.Now.ToString("dd-MM-yyyy"),cmbTipoDocEntrada.SelectedValue.ToString(),
                              txtNumDocEntrada.Text,lblTotalPagar.Text};
                    ident = Lentrada.InsertarEntrada(lEnt);

                    for (int i = 0; i < dgvEntrada.Rows.Count; i++)
                    {
                        string[] stdent = { ident, dgvEntrada.Rows[i].Cells[0].Value.ToString(), Convert.ToDateTime(dgvEntrada.Rows[i].Cells[4].Value).ToString("dd-MM-yyyy"), dgvEntrada.Rows[i].Cells[5].Value.ToString(),
                                      dgvEntrada.Rows[i].Cells[6].Value.ToString(),dgvEntrada.Rows[i].Cells[7].Value.ToString(),dgvEntrada.Rows[i].Cells[8].Value.ToString(),
                                      dgvEntrada.Rows[i].Cells[9].Value.ToString()};
                        DEntrada.InsertarDetalleEntrada(stdent);
                    }
                    frmComprobanteEntrada frmAbout = new frmComprobanteEntrada();
                    frmAbout.ShowDialog();
                    producto.ProductoId();                    
                    dgvEntrada.Rows.Clear();
                    rellproveedor();
                    Limpiar();
                    AgregarLimpiar();
                    
                }
                catch (System.Exception ex) { MessageBox.Show(ex.ToString()); }
            }

            else
            {
                MessageBox.Show("No se puede grabar ingreso," + Char.ConvertFromUtf32(13) + "No existen items o superó límite máximo de items por comprobante", "Aviso");
            }
        }
        #endregion
    }
}

