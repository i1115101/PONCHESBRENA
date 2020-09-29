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
    public partial class RegistroVentas : Form
    {
        int idCliente, idProducto;
        decimal PrecioUnitario;
        double StockActual, StockMinimo, TotalVenta, condicion = 0;

        public RegistroVentas()
        {
            InitializeComponent();
        }        

        #region Rellenar ComboBox
        void cargarcmbTipoDoc()
        {
            try
            {
                LogicaTipoDocumento objeto = new LogicaTipoDocumento();
                cmbTipoDoc.DataSource = objeto.MostrarTipoDocumento();
                cmbTipoDoc.DisplayMember = "TipoDocumento";
                cmbTipoDoc.ValueMember = "IdTipoDocumento";
            }
            catch (System.Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        void rellenacomboproducto()
        {
            try
            {
                LogicaProducto objeto = new LogicaProducto();
                cmbProducto.DataSource = objeto.MostrarProducto();
                cmbProducto.DisplayMember = "Producto";
                cmbProducto.ValueMember = "Código";
            }
            catch (System.Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        void rellenarCliente()
        {
            try
            {
                LogicaCliente ClienteLista = new LogicaCliente();
                dgvClientes.DataSource = ClienteLista.MostrarCliente();
                LogicaCliente Cliente = new LogicaCliente();
                cmbrazonsocial.DataSource = Cliente.MostrarCliente();
                cmbrazonsocial.DisplayMember = "Razón_Social";
                cmbrazonsocial.ValueMember = "Código";               
            }
            catch (System.Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        void rellenacategoria()
        {
            try
            {
                LogicaCategoria objeto = new LogicaCategoria();
                cmbCategoria.DataSource = objeto.MostrarCategoria();                  
                cmbCategoria.DisplayMember = "Categoria";
                cmbCategoria.ValueMember = "IdCategoria";                
            }
            catch (System.Exception ex) { MessageBox.Show(ex.ToString()); }
        }      
        #endregion

        private void RegistroVentas_Load(object sender, EventArgs e)
        {
            rellenarCliente();
            rellenacomboproducto();
            rellenacategoria();
            cargarcmbTipoDoc();
            limpio();

            dgvRegistrarVenta.ColumnCount = 7;
            dgvRegistrarVenta.Columns[0].HeaderText = "Id Producto";
            dgvRegistrarVenta.Columns[1].HeaderText = "Nombre del Producto";
            dgvRegistrarVenta.Columns[2].HeaderText = "Precio Unitario";
            dgvRegistrarVenta.Columns[3].HeaderText = "Cantidad";
            dgvRegistrarVenta.Columns[4].HeaderText = "Descuento";
            dgvRegistrarVenta.Columns[5].HeaderText = "Importe";
            dgvRegistrarVenta.Columns[6].HeaderText = "Stock Actual";
            dgvRegistrarVenta.Columns[0].Visible = false;
            cmbCategoria.Focus();
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
                    limpio();
                    MessageBox.Show(this, cmbProducto.Text + " ya esta en la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbProducto.Focus();
                    errorProvider1.SetError(cmbProducto, "ya esta en la lista");
                    no_error = false;
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

            if (cmbrazonsocial.Text == string.Empty)
            {
                errorProvider1.SetError(cmbrazonsocial, "Ingrese el nombre del nuevo cliente");
                no_error = false;
            }
            if (cmbTipoDoc.Text == string.Empty)
            {
                errorProvider1.SetError(cmbTipoDoc, "Seleccione un tipo de documento");
                no_error = false;
            } 
            if (txtnrodoc.Text == string.Empty)
            {
                errorProvider1.SetError(txtnrodoc, "Ingrese el número del documento");
                no_error = false;
            }
            for (int i = 0; i < dgvClientes.RowCount; i++)
            {
                if (dgvClientes.Rows[i].Cells[3].Value.ToString() == txtnrodoc.Text)
                {
                    repetido = 1;
                }
            }
            if (repetido == 1)
            {
                MessageBox.Show(this, "El Documento ya esta registrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtnrodoc, "Documento repetido");
                txtnrodoc.Focus();
                no_error = false;
            }
            if (cmbTipoDoc.Text == "DNI" & txtnrodoc.TextLength <= 7)
            {
                MessageBox.Show("Ingrese 8 dígitos de DNI");
                errorProvider1.SetError(txtnrodoc, "Ingrese 8 dígitos de DNI");
                txtnrodoc.Focus();
                no_error = false;
            }
            if (cmbTipoDoc.Text == "PASAPORTE" & txtnrodoc.TextLength <= 4)
            {
                MessageBox.Show("Ingrese de 5 a 15 dígitos del pasaporte");
                errorProvider1.SetError(txtnrodoc, "Ingrese de 5 a 15 dígitos del pasaporte");
                txtnrodoc.Focus();
                no_error = false;
            }
            if (cmbTipoDoc.Text == "RUC" & txtnrodoc.TextLength < 11)
            {
                MessageBox.Show("Ingrese 11 dígitos de ruc");
                errorProvider1.SetError(txtnrodoc, "Ingrese 11 dígitos de RUC");
                txtnrodoc.Focus();
                no_error = false;
            }
            return no_error;
        }
        
        #endregion

        void limpio()
        {
          
                cmbrazonsocial.SelectedIndex = 0;
                cmbCategoria.SelectedIndex = -1;
                cmbProducto.SelectedIndex = -1;
                lblPrecioUnitario.Text = "Seleccione una Categoría";
                lblStockActual.Text = "Seleccione una Categoría";
                lblFechaVcto.Text = "Seleccione una Categoría";
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
            varpublic.SoloLetras(e);
            errorProvider1.SetError(this.cmbrazonsocial, string.Empty);
        }
        private void txtnrodoc_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtnrodoc, string.Empty);
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
            varpublic.SoloNumeros(e);
        }
        #endregion

        private void cmbTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.cmbTipoDoc, string.Empty);
            if (cmbTipoDoc.Text == "OTROS")
            {
                txtnrodoc.Clear();
                txtnrodoc.Text = "0";
            }
            if (cmbTipoDoc.Text == "DNI")
            {
                txtnrodoc.Clear();
                txtnrodoc.MaxLength = 8;
            }
            if (cmbTipoDoc.Text == "CARNET")
            {
                txtnrodoc.Clear();
            }
            if (cmbTipoDoc.Text == "PASAPORTE")
            {
                txtnrodoc.Clear();
                txtnrodoc.MaxLength = 15;
            }
            if (cmbTipoDoc.Text == "RUC")
            {
                txtnrodoc.Clear();
                txtnrodoc.MaxLength = 11;
            }
        }

        #endregion

        #region ComboBox Producto,Categoria,TipoDoc y razonsocial = SelectedIndexChanged
        private void cmbproducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime FechaVen;
            errorProvider1.SetError(this.cmbProducto, string.Empty);
            try
            {
                SqlDataAdapter da1 = new SqlDataAdapter("Select Producto.* from Producto where Producto='" + cmbProducto.Text + "'", varpublic.conexion);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                idProducto = Convert.ToInt32(dt1.Rows[0]["IdProducto"]);
                PrecioUnitario = Math.Round(Convert.ToDecimal(dt1.Rows[0]["UltPrecioVenta"]), 2);
                lblPrecioUnitario.Text = Convert.ToString(PrecioUnitario);
                StockMinimo = Convert.ToDouble(dt1.Rows[0]["StockMinimo"]);
                StockActual = Convert.ToDouble(dt1.Rows[0]["Stock"]);
                lblStockActual.Text = Convert.ToString(StockActual);
                da1.Dispose();               

                SqlDataAdapter da = new SqlDataAdapter("SELECT Top 1 DetalleEntrada.* FROM  DetalleEntrada  where  IdProducto = '" + idProducto + "' order by IdEntrada desc", varpublic.conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                FechaVen = Convert.ToDateTime(dt.Rows[0]["FechaVencimiento"]);
                lblFechaVcto.Text = Convert.ToString(FechaVen.ToShortDateString()); ;
                da.Dispose();
            }
            catch { }
        }
        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCategoria;
            errorProvider1.SetError(this.cmbCategoria, string.Empty);
            try
            {
                SqlDataAdapter da1 = new SqlDataAdapter("Select IdCategoria from Categoria where Categoria='" + cmbCategoria.Text + "'", varpublic.conexion);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                idCategoria = Convert.ToInt32(dt1.Rows[0]["IdCategoria"]);
                da1.Dispose();

                SqlDataAdapter da = new SqlDataAdapter("SELECT Categoria.*, Producto.*  FROM Categoria INNER JOIN Producto ON Categoria.IdCategoria = Producto.IdCategoria where  Categoria.IdCategoria = '" + idCategoria + "'", varpublic.conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbProducto.DataSource = dt;
                cmbProducto.DisplayMember = "Producto";
                cmbProducto.ValueMember = "IdProducto";
                da.Dispose();
            }
            catch { }
        }
        
        private void cmbrazonsocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.cmbrazonsocial, string.Empty);
            try
            {
                if (chkCliente.Checked == true)
                {
                    txtDirección.Text = "";
                    cmbTipoDoc.SelectedIndex = -1;
                    txtnrodoc.Text = "";
                    cmbrazonsocial.SelectedIndex = -1;
                    errorProvider1.SetError(cmbrazonsocial, "El Cliente ya existe");
                    cmbrazonsocial.Focus();
                }
                else
                {
                    SqlDataAdapter cli = new SqlDataAdapter("select Cliente.* from Cliente where RazonSocial='" + cmbrazonsocial.Text+ "'", varpublic.conexion);
                    DataTable clie = new DataTable();
                    cli.Fill(clie);
                    idCliente = Convert.ToInt32(clie.Rows[0]["IdCliente"]);                    
                    cmbTipoDoc.SelectedValue = Convert.ToInt32(clie.Rows[0]["IdTipoDocumento"]);
                    txtnrodoc.Text = Convert.ToString(clie.Rows[0]["NroDocumento"]);
                    txtDirección.Text = Convert.ToString(clie.Rows[0]["Direccion"]);
                    clie.Dispose();                    
                }
            }
            catch { }
        }
        #endregion

        private void chkCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCliente.Checked == true)
            {
                this.cmbrazonsocial.DropDownStyle = ComboBoxStyle.Simple;
                cmbrazonsocial.Text = "";
                txtDirección.Text = "";
                cmbTipoDoc.SelectedIndex = -1;
                txtnrodoc.Text = "";

                txtDirección.Enabled = true;
                cmbTipoDoc.Enabled = true;
                txtnrodoc.Enabled = true;

                cmbrazonsocial.Focus();
            }
            else
            {
                this.cmbrazonsocial.DropDownStyle = ComboBoxStyle.DropDownList;
                rellenarCliente();
                txtDirección.Enabled = false;
                cmbTipoDoc.Enabled = false;
                txtnrodoc.Enabled = false;
            }
        }

        #region Agregar, Quitar y Nuevo
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            double suma = 0;

            if (Validar_Ingreso_Producto())
            {

                try
                {
                    condicion = Convert.ToDouble(StockActual) - Convert.ToDouble(nudQuantity.Value);

                    if (MessageBox.Show("¿Seguro de agregar nuevo item al detalle?", "Consulta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        dgvRegistrarVenta.Rows.Add(idProducto, cmbProducto.Text, PrecioUnitario, nudQuantity.Value, nudDescuento.Text, (Convert.ToDouble(nudQuantity.Value) * Convert.ToDouble(PrecioUnitario)) - Convert.ToDouble(nudDescuento.Text), Convert.ToDouble(StockActual) - Convert.ToDouble(nudQuantity.Value));
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
                    }
                    TotalVenta = Convert.ToDouble(suma);
                    lblTotalPagar.Text = Convert.ToString(TotalVenta);
                    limpio();
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
            limpio();
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

        #region LogicaNegocio

        private bool GuardarCliente(string RazonSocial, int IdTipoDocumento, string NroDocumento, string Direccion)
        {
            LogicaCliente logicaCliente = new LogicaCliente();
            bool resu = logicaCliente.InsertarCliente(RazonSocial, IdTipoDocumento, NroDocumento, Direccion);
            return resu;
        }

        private bool GuardarVenta(int IdEmpleado, int IdCliente, DateTime FechaEmision, decimal Total)
        {
            LogicaVenta logicaVenta = new LogicaVenta();
            bool resu2 = logicaVenta.InsertarVenta(IdEmpleado, IdCliente, FechaEmision, Total);
            return resu2;
        }

        private bool GuardarDetalleVenta(int IdVenta, int IdProducto, int Cantidad, decimal Descuento, decimal Importe)
        {
            LogicaDetalleVenta logicaDetalleVenta = new LogicaDetalleVenta();
            bool resu3 = logicaDetalleVenta.InsertarDetalleVenta(IdVenta, IdProducto, Cantidad, Descuento, Importe);
            return resu3;
        }

        #endregion

        #region Registrar Venta
        private void cmdbfRegistar_Click(object sender, EventArgs e)
        {

            if (chkCliente.Checked == true && dgvRegistrarVenta.RowCount > 0)
            {
                if (ValidarClientes())
                {
                    try
                    {                      
                        string RazonSocial = cmbrazonsocial.Text.ToUpper();
                        int IdTipoDocumento = Convert.ToInt32(cmbTipoDoc.SelectedValue);
                        string NroDocumento = txtnrodoc.Text;
                        string Direccion = txtDirección.Text.ToUpper();

                        bool resu = false;

                        resu = GuardarCliente(RazonSocial, IdTipoDocumento, NroDocumento, Direccion);
                        if (resu)
                        {
                            MessageBox.Show("Nuevo cliente registrado", "Aviso");                           
                        }                        

                        SqlDataAdapter da2 = new SqlDataAdapter("select top 1 IdCliente from Cliente order by IdCliente desc", varpublic.conexion);
                        DataTable dt2 = new DataTable();
                        da2.Fill(dt2);
                        da2.Dispose();
                        idCliente = Convert.ToInt32(dt2.Rows[0]["IdCliente"]);
                        da2.Dispose(); 
                      
                        int IdEmpleado = varpublic.idEmpleado;
                        int IdCliente = idCliente;
                        DateTime FechaEmision =Convert.ToDateTime( DateTime.Now);
                        decimal Total = Convert.ToDecimal(TotalVenta);
                        bool resu2 = false;
                        resu2 = GuardarVenta(IdEmpleado, IdCliente, FechaEmision, Total);
                      

                        SqlDataAdapter da3 = new SqlDataAdapter("select top 1 IdVenta from Venta order by IdVenta desc", varpublic.conexion);
                        DataTable dt3 = new DataTable();
                        da3.Fill(dt3);
                        da3.Dispose();
                        varpublic.idVenta = Convert.ToInt32(dt3.Rows[0]["IdVenta"]);
                        da3.Dispose();
                        
                        for (int c = 0; c <= dgvRegistrarVenta.RowCount - 1; c++)
                        {
                            int IdVenta = varpublic.idVenta;
                            int IdProducto = Convert.ToInt32(dgvRegistrarVenta.Rows[c].Cells[0].Value);
                            int Cantidad = Convert.ToInt32(dgvRegistrarVenta.Rows[c].Cells[3].Value);
                            decimal Descuento = Convert.ToDecimal(dgvRegistrarVenta.Rows[c].Cells[4].Value);
                            decimal Importe = Convert.ToDecimal(dgvRegistrarVenta.Rows[c].Cells[5].Value);
                            bool resu3 = false;
                            resu3 = GuardarDetalleVenta(IdVenta, IdProducto, Cantidad, Descuento, Importe);
                         } 
                        for (int d = 0; d <= dgvRegistrarVenta.RowCount - 1; d++)
                        {
                            SqlDataAdapter da6 = new SqlDataAdapter("UPDATE Producto  SET Stock ='" + Convert.ToInt32(dgvRegistrarVenta.Rows[d].Cells[6].Value) + "'WHERE IdProducto='" + Convert.ToInt32(dgvRegistrarVenta.Rows[d].Cells[0].Value) + "'", varpublic.conexion);
                            DataTable dt6 = new DataTable();
                            da6.Fill(dt6);
                            da6.Dispose();
                        }

                        MessageBox.Show("Venta Registrada Exitósamente", "Aviso");
                       
                        dgvRegistrarVenta.Rows.Clear();
                        rellenarCliente();
                        limpio();
                        lblTotalPagar.Text = "Total a pagar";
                        cmbCategoria.Focus();                        
                        lblMensaje.Text = "Info!";
                    }
                    catch (System.Exception exc)
                    {
                        MessageBox.Show(exc.ToString());
                    }
                }
            }
            else
            {
                
                if (dgvRegistrarVenta.RowCount > 0)
                {
                    try
                    {                       
                        int IdEmpleado = varpublic.idEmpleado;
                        int IdCliente = idCliente;
                        DateTime FechaEmision = Convert.ToDateTime(DateTime.Now);
                        decimal Total = Convert.ToDecimal(TotalVenta);
                        bool resu2 = false;
                        resu2 = GuardarVenta(IdEmpleado, IdCliente, FechaEmision, Total);                        

                        SqlDataAdapter da2 = new SqlDataAdapter("select top 1 IdVenta from Venta order by IdVenta desc", varpublic.conexion);
                        DataTable dt2 = new DataTable();
                        da2.Fill(dt2);
                        da2.Dispose();
                        varpublic.idVenta = Convert.ToInt32(dt2.Rows[0]["IdVenta"]);
                        da2.Dispose();
                        
                        for (int c = 0; c <= dgvRegistrarVenta.RowCount - 1; c++)
                        {
                            int IdVenta = varpublic.idVenta;
                            int IdProducto = Convert.ToInt32(dgvRegistrarVenta.Rows[c].Cells[0].Value);
                            int Cantidad = Convert.ToInt32(dgvRegistrarVenta.Rows[c].Cells[3].Value);
                            decimal Descuento = Convert.ToDecimal(dgvRegistrarVenta.Rows[c].Cells[4].Value);
                            decimal Importe = Convert.ToDecimal(dgvRegistrarVenta.Rows[c].Cells[5].Value);
                            bool resu3 = false;
                            resu3 = GuardarDetalleVenta(IdVenta, IdProducto, Cantidad, Descuento, Importe);
                        }
                        
                        for (int d = 0; d <= dgvRegistrarVenta.RowCount - 1; d++)
                        {
                            SqlDataAdapter da6 = new SqlDataAdapter("UPDATE Producto  SET Stock ='" + Convert.ToInt32(dgvRegistrarVenta.Rows[d].Cells[6].Value) + "'WHERE IdProducto='" + Convert.ToInt32(dgvRegistrarVenta.Rows[d].Cells[0].Value) + "'", varpublic.conexion);
                            DataTable dt6 = new DataTable();
                            da6.Fill(dt6);
                            da6.Dispose();
                        }
                        MessageBox.Show("Venta Registrada Exitósamente", "Aviso");       
                        
                        dgvRegistrarVenta.Rows.Clear();
                        limpio();
                        lblTotalPagar.Text = "Total a pagar";
                        cmbCategoria.Focus();                        
                        lblMensaje.Text = "Info!";
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("No se puede grabar ingreso," + Char.ConvertFromUtf32(13) + "No existen items o superó límite máximo de items por comprobante", "Aviso");
                }
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

        private void bunipicVentas_Click(object sender, EventArgs e)
        {
            //VisualizarVentas fm = new VisualizarVentas();
            //fm.Show();
        }

        
    }
}