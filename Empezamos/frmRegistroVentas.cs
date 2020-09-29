using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LogicaNegocio;
using Entidad.Cache;

namespace Empezamos
{
    public partial class frmRegistroVentas : Form
    {
        int StockMinimo, StockActual, IdCliente,idProducto, idCategoria, condicion = 0;
        decimal PrecioUnitario;
        double   TotalVenta, gananc = 0;
        DataTable unidadP,precapital;
        LogicaCategoria Categoria = new LogicaCategoria();
        LogicaProducto producto = new LogicaProducto();
        LogicaCliente cliente = new LogicaCliente();
        LogicaDetalleVenta dventa = new LogicaDetalleVenta(); 
        LogicaTipoDocumento MostarTipoDoc = new LogicaTipoDocumento();
        LogicaVenta Venta = new LogicaVenta();
        public frmRegistroVentas()
        {
            InitializeComponent();
        }

        #region Rellenar ComboBox
        void rellenacombo()
        {            
            cmbCategoria.DataSource = Categoria.ListCategoria();
            cmbCategoria.DisplayMember = "cNombreCategoria";
            cmbCategoria.ValueMember = "nIdTCategoria";

            dgvClientes.DataSource = cliente.ListaCliente();
            cmbNumeroDocumento.DataSource = cliente.ListaCliente();
            cmbNumeroDocumento.DisplayMember = "cNumeroDocumento";
            cmbNumeroDocumento.ValueMember = "nIdCliente";

            cmbTipoDoc.DataSource = MostarTipoDoc.ListDocumentos();
            cmbTipoDoc.DisplayMember = "cTipoDocumento";
            cmbTipoDoc.ValueMember = "nIdTipoDocumento";            
        }

        #endregion

        private void RegistroVentas_Load(object sender, EventArgs e)
        {            
            rellenacombo();
            cmbNumeroDocumento.SelectedIndex = -1;
            limpio(0);
            
            dgvRegistrarVenta.ColumnCount = 8;
            dgvRegistrarVenta.Columns[0].HeaderText = "Id Producto";
            dgvRegistrarVenta.Columns[1].HeaderText = "Nombre del Producto";
            dgvRegistrarVenta.Columns[2].HeaderText = "Precio Unitario";
            dgvRegistrarVenta.Columns[3].HeaderText = "Cantidad";
            dgvRegistrarVenta.Columns[4].HeaderText = "Descuento";
            dgvRegistrarVenta.Columns[5].HeaderText = "Importe";
            dgvRegistrarVenta.Columns[6].HeaderText = "Stock Actual";
            dgvRegistrarVenta.Columns[7].HeaderText = "ganancia";
            dgvRegistrarVenta.Columns[0].Visible = false;
            dgvRegistrarVenta.Columns[7].Visible = false;
            dgvRegistrarVenta.Columns[2].DefaultCellStyle.Format = "N2";
            cmbCategoria.Focus();
            precapital = producto.productotable();
            lblEmpleado.Text = varpublic.nombreEmpleado;
        }

        #region Validaciones

        #region Validar Ingreso Producto
        private bool Validar_Ingreso_Producto()
        {
            bool no_error = true;
            double repetido = 0;

            if (cmbCategoria.Text == string.Empty)
            {
                lblMensaje.Text = "Info! ";
                lblMensaje.ForeColor = Color.Yellow;
                cmbCategoria.Focus();
                errorProvider1.SetError(cmbCategoria, "Seleccione una Categoria");
                no_error = false;
            }
            if (cmbProducto.Text == string.Empty)
            {
                lblMensaje.Text = "Info! ";
                lblMensaje.ForeColor = Color.Yellow;
                cmbProducto.Focus();
                errorProvider1.SetError(cmbProducto, "Seleccione una producto");
                no_error = false;
            }
            if (nudQuantity.Value == 0)
            {
                lblMensaje.Text = "Info! ";
                lblMensaje.ForeColor = Color.Yellow;
                nudQuantity.Focus();
                errorProvider1.SetError(nudQuantity, "Ingrese una cantidad");
                no_error = false;
            }
            if (nudDescuento.Text == string.Empty)
            {
                lblMensaje.Text = "Info! ";
                lblMensaje.ForeColor = Color.Yellow;
                nudDescuento.Focus();
                errorProvider1.SetError(nudDescuento, "Ingrese un descuento");
                no_error = false;
            }
            try
            {
                for (int i = 0; i < dgvRegistrarVenta.RowCount; i++)
                {
                    if (dgvRegistrarVenta.Rows[i].Cells[0].Value.ToString() == idProducto.ToString())
                    {
                        repetido = 1;
                    }
                }
                if (repetido == 1)
                {
                    if (MessageBox.Show("¿Desea aumentar la cantidad del item al detalle?", "Consulta", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        limpio(1);
                        //MessageBox.Show(this, cmbProducto.Text + " ya esta en la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbProducto.Focus();
                        //errorProvider1.SetError(cmbProducto, "ya esta en la lista");
                        no_error = false;
                    }
                    
                }
                if ((Convert.ToDouble(StockActual) == 0) && cmbProducto.Text == string.Empty)
                {
                    MessageBox.Show("Seleccione una categoria", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblMensaje.Text = "Info! ";
                    lblMensaje.ForeColor = Color.Yellow;
                    no_error = false;
                }
                else
                {
                    if ((Convert.ToDouble(StockActual) == 0))
                    {
                        MessageBox.Show("No tiene los suficientes recursos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbCategoria.Focus();
                        lblMensaje.ForeColor = Color.Red;
                        errorProvider1.SetError(lblStockActual, "No hay recursos");
                        lblMensaje.Text = cmbProducto.Text + " Está agotado del almacén";
                        no_error = false;
                    }
                    else
                    {
                        if ((Convert.ToDouble(StockActual) - Convert.ToDouble(nudQuantity.Value)) < 0)
                        {
                            MessageBox.Show("Cantidad elevada al stock", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            nudQuantity.Focus();
                            lblMensaje.Text = "Info! ";
                            lblMensaje.ForeColor = Color.Yellow;
                            errorProvider1.SetError(nudQuantity, "Valor elevado al stock");
                            no_error = false;
                        }
                    }
                }
                if ((Convert.ToDouble(PrecioUnitario) < Convert.ToDouble(nudDescuento.Value)))
                {
                    MessageBox.Show("Revise su descuento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nudQuantity.Focus();
                    lblMensaje.Text = "Info! ";
                    lblMensaje.ForeColor = Color.Yellow;
                    errorProvider1.SetError(nudDescuento, "Valor elevado al precio unitario");
                    no_error = false;
                }
            }
            catch { }
            return no_error;
        }
        #endregion

        #region validarClienteNuevo
        private bool ValidarClientes()
        {
            bool no_error = true;
            int repetido = 0;

            if (cmbNumeroDocumento.Text == string.Empty)
            {
                errorProvider1.SetError(cmbNumeroDocumento, "Ingrese el numero del nuevo cliente");
                no_error = false;
            }
            if (cmbTipoDoc.Text == string.Empty)
            {
                errorProvider1.SetError(cmbTipoDoc, "Seleccione un tipo de documento");
                no_error = false;
            } 
            if (txtRazonSocial.Text == string.Empty)
            {
                errorProvider1.SetError(txtRazonSocial, "Ingrese el nombre del cliente");
                no_error = false;
            }
            if (txtDirección.Text == string.Empty)
            {
                errorProvider1.SetError(txtDirección, "Ingrese una dirección domiciliaria");
                no_error = false;
            }
            for (int i = 0; i < dgvClientes.RowCount; i++)
            {
                if (dgvClientes.Rows[i].Cells[3].Value.ToString() == cmbNumeroDocumento.Text)
                {
                    repetido = 1;
                }
            }
            if (repetido == 1 & chkCliente.Checked == true)
            {
                MessageBox.Show(this, "El Documento ya esta registrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(cmbNumeroDocumento, "Documento repetido");
                txtRazonSocial.Focus();
                chkCliente.Checked = false;
                no_error = false;
            }
            //if (cmbTipoDoc.Text == "DNI" & txtRazonSocial.TextLength <= 7)
            //{
            //    MessageBox.Show("Ingrese 8 dígitos de DNI");
            //    errorProvider1.SetError(txtRazonSocial, "Ingrese 8 dígitos de DNI");
            //    txtRazonSocial.Focus();
            //    no_error = false;
            //}
            //if (cmbTipoDoc.Text == "PASAPORTE" & txtRazonSocial.TextLength <= 4)
            //{
            //    MessageBox.Show("Ingrese de 5 a 15 dígitos del pasaporte");
            //    errorProvider1.SetError(txtRazonSocial, "Ingrese de 5 a 15 dígitos del pasaporte");
            //    txtRazonSocial.Focus();
            //    no_error = false;
            //}
            //if (cmbTipoDoc.Text == "RUC" & txtRazonSocial.TextLength < 11)
            //{
            //    MessageBox.Show("Ingrese 11 dígitos de ruc");
            //    errorProvider1.SetError(txtRazonSocial, "Ingrese 11 dígitos de RUC");
            //    txtRazonSocial.Focus();
            //    no_error = false;
            //}
            return no_error;
        }

        #endregion

        void limpio(int num)
        {
            if(num==0)cmbNumeroDocumento.SelectedIndex = 0;
            cmbCategoria.SelectedIndex = -1;
            cmbProducto.SelectedIndex = -1;
            lblPrecioUnitario.Text = "Seleccione una Categoría";
            lblStockActual.Text = "Seleccione una Categoría";
            nudQuantity.Value = 0;
            nudDescuento.Text = "0";
            chkCliente.Checked = false;
            errorProvider1.Clear();
        }

        #region borrar icono error al escribir

        private void txtDirección_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtDirección, string.Empty);
        }
        private void cmbrazonsocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            varpublic.SoloNumeros(e);
            errorProvider1.SetError(this.cmbNumeroDocumento, string.Empty);
        }
        private void txtnrodoc_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtRazonSocial, string.Empty);
        }
        private void lblStockActual_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.lblStockActual, string.Empty);
        }
        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.nudDescuento, string.Empty);
        }
        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.nudQuantity, string.Empty);
        }
        private void txtnrodoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            varpublic.SoloLetras(e);
        }
        #endregion

        private void cmbTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.cmbTipoDoc, string.Empty);
            //if (cmbTipoDoc.Text == "OTROS")
            //{
            //    txtRazonSocial.Clear();
            //    txtRazonSocial.Text = "0";
            //}
            if (cmbTipoDoc.Text == "DNI")
            {
                txtRazonSocial.Clear();
                txtRazonSocial.MaxLength = 8;
            }
            if (cmbTipoDoc.Text == "CARNET")
            {
                txtRazonSocial.Clear();
            }
            if (cmbTipoDoc.Text == "PASAPORTE")
            {
                txtRazonSocial.Clear();
                txtRazonSocial.MaxLength = 15;
            }
            if (cmbTipoDoc.Text == "RUC")
            {
                txtRazonSocial.Clear();
                txtRazonSocial.MaxLength = 11;
            }
        }
        private void dgvRegistrarVenta_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvRegistrarVenta.Columns[e.ColumnIndex].Index == 6)
            {
                if (Convert.ToInt32(e.Value) <= 10)
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.BackColor = Color.Orange;
                }
            }
        }
        #endregion

        #region ComboBox Producto,Categoria,TipoDoc y check nuevo cliente
        private void cmbproducto_SelectedIndexChanged(object sender, EventArgs e)
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
                    StockMinimo = Convert.ToInt32(unidadP.Rows[0]["nStockMinimo"]);
                    PrecioUnitario = Convert.ToDecimal(unidadP.Rows[0]["nUltPrecioVenta"]);
                    lblPrecioUnitario.Text = Convert.ToString(PrecioUnitario);
                   StockActual = Convert.ToInt32(unidadP.Rows[0]["nStock"]);
                    lblStockActual.Text = Convert.ToString(StockActual);
                }
                else
                {
                    
                    lblPrecioUnitario.Text = "Precio Venta";
                    lblStockActual.Text = "Stock Actual";
                }

            }
            catch { }
        }
        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {            
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

        private void cmbNumeroDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.cmbNumeroDocumento, string.Empty);
            try
            {

                string id = Convert.ToString(cmbNumeroDocumento.SelectedValue);
                unidadP = cliente.unidcliente(id);
                cmbTipoDoc.SelectedValue = Convert.ToString(unidadP.Rows[0]["IdTipoDocumento"]);
                txtDirección.Text = Convert.ToString(unidadP.Rows[0]["cDireccion"]);
                txtRazonSocial.Text = Convert.ToString(unidadP.Rows[0]["cRazonSocial"]);

            }
            catch { }
        }
        private void chkCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCliente.Checked == true)
            {

                rellenacombo();
                this.cmbNumeroDocumento.DropDownStyle = ComboBoxStyle.Simple;
                cmbNumeroDocumento.Text = "";
                txtDirección.Text = "";
                cmbTipoDoc.SelectedIndex = -1;
                txtRazonSocial.Text = "";

                txtDirección.Enabled = true;
                cmbTipoDoc.Enabled = true;
                txtRazonSocial.Enabled = true;

                cmbNumeroDocumento.Focus();
            }
            else
            {
                this.cmbNumeroDocumento.DropDownStyle = ComboBoxStyle.DropDownList;

                txtDirección.Enabled = false;
                cmbTipoDoc.Enabled = false;
                txtRazonSocial.Enabled = false;
                errorProvider1.Clear();
            }
        }
        #endregion

        #region Agregar, Quitar y Nuevo
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal gana=0;
            double suma = 0;
            int rep = 0, mun = 0;
            
            if (Validar_Ingreso_Producto())
            {
                for (int i = 0; i < dgvRegistrarVenta.RowCount; i++)
                {
                    if (dgvRegistrarVenta.Rows[i].Cells[0].Value.ToString() == idProducto.ToString())
                    {
                        rep = 1;
                        mun = i;
                    }
                }

                try
                {
                    condicion = Convert.ToInt32(StockActual) - Convert.ToInt32(nudQuantity.Value);
                    if (rep == 0)
                    {
                        if (MessageBox.Show("¿Seguro de agregar nuevo item al detalle?", "Consulta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            for (int i = 0; i < precapital.Rows.Count; i++)
                            {
                                if (Convert.ToInt32(precapital.Rows[i]["nIdProducto"]) == idProducto)
                                {
                                    gana = ((Convert.ToDecimal(nudQuantity.Value) * Convert.ToDecimal(PrecioUnitario)) - Convert.ToDecimal(nudDescuento.Text)) - (Convert.ToDecimal(nudQuantity.Value) * Convert.ToDecimal(precapital.Rows[i]["nUltPrecioCosto"]));
                                    i = precapital.Rows.Count;
                                }
                            }
                            dgvRegistrarVenta.Rows.Add(idProducto, cmbProducto.Text, PrecioUnitario, nudQuantity.Value, nudDescuento.Text,
                                                       (Convert.ToDouble(nudQuantity.Value) * Convert.ToDouble(PrecioUnitario)) - Convert.ToDouble(nudDescuento.Text),
                                                       StockActual - Convert.ToInt32(nudQuantity.Value), gana);
                        }
                    }
                    else
                    {
                        dgvRegistrarVenta.Rows[mun].Cells[3].Value = Convert.ToInt32(dgvRegistrarVenta.Rows[mun].Cells[3].Value) + Convert.ToInt32(nudQuantity.Value);
                        dgvRegistrarVenta.Rows[mun].Cells[4].Value = Convert.ToDecimal(nudDescuento.Value);
                        dgvRegistrarVenta.Rows[mun].Cells[5].Value = (Convert.ToDecimal(dgvRegistrarVenta.Rows[mun].Cells[3].Value) * Convert.ToDecimal(dgvRegistrarVenta.Rows[mun].Cells[2].Value)) - Convert.ToDecimal(dgvRegistrarVenta.Rows[mun].Cells[4].Value);
                        for (int i = 0; i < precapital.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(precapital.Rows[i]["nIdProducto"]) == idProducto)
                            {
                                dgvRegistrarVenta.Rows[mun].Cells[7].Value = Convert.ToDecimal(dgvRegistrarVenta.Rows[mun].Cells[5].Value) - (Convert.ToDecimal(dgvRegistrarVenta.Rows[mun].Cells[3].Value) * Convert.ToDecimal(precapital.Rows[i]["nUltPrecioCosto"])); 
                            } 
                        }
                        dgvRegistrarVenta.Rows[mun].Cells[6].Value = Convert.ToInt32(dgvRegistrarVenta.Rows[mun].Cells[6].Value) - Convert.ToInt32(nudQuantity.Value);
                    }
                    if (Convert.ToDouble(StockMinimo) < Convert.ToDouble(StockActual))
                    {
                        lblMensaje.ForeColor = Color.Blue;
                        lblMensaje.Text = cmbProducto.Text + " está Abastecido en el Almacén";
                    }
                    if (Convert.ToDouble(StockMinimo) > Convert.ToDouble(condicion))
                    {
                        lblMensaje.ForeColor = Color.Yellow;
                        lblMensaje.Text = cmbProducto.Text + " está por agotarse del almacén solo le queda " + condicion;
                    }
                    if (condicion == 0)
                    {
                        lblMensaje.ForeColor = Color.Red;
                        lblMensaje.Text = cmbProducto.Text + " se agoto del almacén ";
                    }
                    for (int i = 0; i < dgvRegistrarVenta.RowCount; i++)
                    {
                        suma = suma + double.Parse(dgvRegistrarVenta.Rows[i].Cells[5].Value.ToString());
                        gananc=gananc+ double.Parse(dgvRegistrarVenta.Rows[i].Cells[7].Value.ToString());
                    }
                    //MessageBox.Show(gananc + "");
                    TotalVenta = Convert.ToDouble(suma);
                    lblTotalPagar.Text = Convert.ToString(TotalVenta);
                    limpio(1);
                    
                }
                catch { }
            }
        }

        

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            double suma = 0;
            if (dgvRegistrarVenta.RowCount > 0)
            {
                if (MessageBox.Show("¿Seguro de eliminar item seleccionado a comprobante?", "Consulta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dgvRegistrarVenta.Rows.RemoveAt(dgvRegistrarVenta.CurrentRow.Index);
                }                
            }
            else
            {
                MessageBox.Show("No existen items para eliminar", "Aviso", MessageBoxButtons.YesNo);
            }
            for (int i = 0; i < dgvRegistrarVenta.RowCount; i++)
            {
                suma = suma + double.Parse(dgvRegistrarVenta.Rows[i].Cells[5].Value.ToString());
            }
            TotalVenta = Convert.ToDouble(suma);
            lblTotalPagar.Text = Convert.ToString(TotalVenta);
            lblMensaje.Text = "Info! ";
            lblMensaje.ForeColor = Color.Yellow;
            nudDescuento.Text = "0";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpio(0);
            cmbCategoria.Focus();
            dgvRegistrarVenta.Rows.Clear();
            lblTotalPagar.Text = "Total a pagar";
            lblMensaje.Text = "Info!";
            lblMensaje.ForeColor = Color.Yellow;
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Registrar Venta
        private void cmdbfRegistar_Click(object sender, EventArgs e)
        {
            int IdVenta;

            if (dgvRegistrarVenta.RowCount > 0)
            {
                if (ValidarClientes())
                {
                    if (chkCliente.Checked == true)
                    {                        
                        string[] RCli = { "0",txtRazonSocial.Text, cmbTipoDoc.SelectedValue.ToString(), cmbNumeroDocumento.Text, txtDirección.Text };
                        cliente.insActCliente(RCli);
                        IdCliente = cliente.IdCliente();
                    }
                    else
                    {
                        IdCliente = Convert.ToInt32(cmbNumeroDocumento.SelectedValue);
                    }
                    string nSerieVenta = Convert.ToString(0001000);
                    try
                    {
                        string[] RVen = {IdCliente.ToString().ToString(),varpublic.idEmpleado.ToString(), DateTime.Now.ToString("dd-MM-yyyy"),
                       "2",nSerieVenta,TotalVenta.ToString(),TotalVenta.ToString(),Convert.ToString(gananc)};
                        IdVenta = Venta.InsertarVenta(RVen);

                        for (int c = 0; c <= dgvRegistrarVenta.RowCount - 1; c++)
                        {
                            string[] IDVen = {IdVenta.ToString(), dgvRegistrarVenta.Rows[c].Cells[0].Value.ToString(),
                        dgvRegistrarVenta.Rows[c].Cells[3].Value.ToString(),dgvRegistrarVenta.Rows[c].Cells[4].Value.ToString(),
                        dgvRegistrarVenta.Rows[c].Cells[5].Value.ToString()};
                            dventa.InsertarDetalleVenta(IDVen);

                            producto.resStock(Convert.ToInt32(dgvRegistrarVenta.Rows[c].Cells[0].Value), Convert.ToInt32(dgvRegistrarVenta.Rows[c].Cells[6].Value));
                        }
                        frmBoletaVenta frmAbout = new frmBoletaVenta();
                        frmAbout.ShowDialog();                        
                        producto.ProductoId();                        
                        rellenacombo();
                        dgvRegistrarVenta.Rows.Clear();                        
                        btnNuevo_Click(sender, e);
                        lblTotalPagar.Text = "Total a pagar";
                        cmbCategoria.Focus();
                        lblMensaje.Text = "Info!";
                        
                    }
                    catch (System.Exception ex) { MessageBox.Show(ex.ToString()); }
                }
            }
            else
            {
                MessageBox.Show("No se puede grabar ingreso," + Char.ConvertFromUtf32(13) + "No existen items o superó límite máximo de items por comprobante", "Aviso");
            }
        }
        
        #endregion

        private void bunipicVentas_Click(object sender, EventArgs e)
        {
            frmDevolucion frmAbout = new frmDevolucion();
            frmAbout.ShowDialog();
        }

        
    }
}