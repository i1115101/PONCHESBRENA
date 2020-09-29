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
    public partial class Producto : Form
    {
        public Producto()
        {
            InitializeComponent();

        }
        void cargarcmbcategoriaid()
        {
            LogicaCategoria objeto = new LogicaCategoria();
            cmbidcategoria.DataSource = objeto.MostrarCategoria();
            cmbidcategoria.DisplayMember = "Categoria";
            cmbidcategoria.ValueMember = "idCategoria";           
        }
        void cargartabla()
        {
            LogicaProducto objeto = new LogicaProducto();
            dgvProductos.DataSource = objeto.MostrarProducto();
        }

        #region validaciones
        private bool ValidarInsertarProducto()
        {
            bool no_error = true;
            int repetido = 0;
            try
            {
                if (Convert.ToInt32(txtIdProducto.Text) >= 0 ||txtProducto.Enabled == false)
                {
                    MessageBox.Show(this, "Limpie si quiere registrar un nuevo Producto", "¿Ud. quiere Registrar?", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider1.SetError(btnLimpiar, "Click en Limpiar");
                    no_error = false;
                }
            }
            catch
            { }    
            if (txtProducto.Enabled == false)
            {
                MessageBox.Show(this, "Limpie Primero", "Click en Limpiar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                no_error = false;
            }
            if (txtProducto.Text == string.Empty)
            {
                errorProvider1.SetError(txtProducto, "Ingrese un dato");
                no_error = false;
            }
            if (cmbidcategoria.Text == string.Empty)
            {
                errorProvider1.SetError(cmbidcategoria, "Ingrese un dato");
                no_error = false;
            }
            if (nudstockminimo.Value <= 0)
            {
                errorProvider1.SetError(nudstockminimo, "Ingrese un dato");
                no_error = false;
            }
            for (int i = 0; i < dgvProductos.RowCount; i++)
            {
                if (dgvProductos.Rows[i].Cells[2].Value.ToString() == txtProducto.Text.ToUpper())
                {
                    repetido = 1;
                }
            }
            if (repetido == 1)
            {
                MessageBox.Show(this, txtProducto.Text + " ya está registrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtProducto, "Producto repetido");
                txtProducto.Focus();
                no_error = false;
            }

            return no_error;
        }
        private bool ValidarActualizarProducto()
        {
            bool no_error = true;

            if (txtIdProducto.Text == string.Empty || txtProducto.Enabled == false)
            {
                MessageBox.Show(this, "Y luego seleccione en la lista", "Click en Limpiar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                errorProvider1.SetError(btnLimpiar, "Click en Limpiar");
                no_error = false;
            }           
            if (txtProducto.Text == string.Empty)
            {
                errorProvider1.SetError(txtProducto, "Seleccione en la lista");
                no_error = false;
            }
            if (cmbidcategoria.Text == string.Empty)
            {
                errorProvider1.SetError(cmbidcategoria, "Seleccione en la lista");
                no_error = false;
            }
            if (nudstockminimo.Value <= 0)
            {
                errorProvider1.SetError(nudstockminimo, "Seleccione en la lista");
                no_error = false;
            }
            return no_error;
        }
        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtProducto, string.Empty);
        }
        private void nudstockminimo_ValueChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.nudstockminimo, string.Empty);
        }
        private void cmbidcategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.cmbidcategoria, string.Empty);
        }
        void Limpiar()
        {
            nudstockminimo.Enabled = true;

            foreach (Control ctrl in panelMantenimiento.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox text = ctrl as TextBox;
                    text.Clear();
                    text.Enabled = true;

                }
                if (ctrl is ComboBox)
                {
                    ComboBox cmb = ctrl as ComboBox;
                    cmb.SelectedIndex = -1;
                    cmb.Enabled = true;
                }
                if (ctrl is NumericUpDown)
                {
                    NumericUpDown nud = ctrl as NumericUpDown;
                    nud.Value = 0;
                }
                txtProducto.Focus();
                errorProvider1.Clear();
            }
        }
        #endregion

        #region Logica Negocio
        private bool GuardarProducto(int IdCategoria, string Producto, string Descripcion, int Stock, int StockMinimo,
            decimal UltPrecioCosto, decimal UltPrecioVenta)
        {
            LogicaProducto logicaProducto = new LogicaProducto();
            bool resu = logicaProducto.InsertarProducto(IdCategoria, Producto, Descripcion, Stock, StockMinimo,
                UltPrecioCosto, UltPrecioVenta);
            return resu;
        }
        private bool ActualizarProducto(int IdProducto, int IdCategoria, string Producto, string Descripcion, int Stock, int StockMinimo,
            decimal UltPrecioCosto, decimal UltPrecioVenta)
        {
            LogicaProducto logicaProducto = new LogicaProducto();
            bool resu = logicaProducto.ActualizarProducto(IdProducto, IdCategoria, Producto, Descripcion, Stock, StockMinimo,
                UltPrecioCosto, UltPrecioVenta);
            return resu;
        }
        #endregion

        #region btn Registrar, Actualizar,Limpiar y Cerrar
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarInsertarProducto())
            {
                try
                {
                    int IdCategoria = Convert.ToInt32(cmbidcategoria.SelectedValue);
                    string Producto = txtProducto.Text.ToUpper();
                    string Descripcion = txtDescripcion.Text.ToUpper();
                    int Stock = Convert.ToInt32(nudstock.Value);
                    int StockMinimo = Convert.ToInt32(nudstockminimo.Value);
                    decimal UltPrecioCosto = Convert.ToDecimal(nudultpreciocosto.Value);
                    decimal UltPrecioVenta = Convert.ToDecimal(nudultprecioventa.Value);

                    bool resu = false;

                    resu = GuardarProducto(IdCategoria, Producto, Descripcion, Stock, StockMinimo,
            UltPrecioCosto, UltPrecioVenta);
                    if (resu)
                    {
                        MessageBox.Show("Producto insertado exitósamente");
                    }
                    cargartabla();
                    Limpiar();
                }
                catch
                {
                    MessageBox.Show("Error, no se inserto registro");
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (ValidarActualizarProducto())
            {
                try
                {
                    int IdProducto = Convert.ToInt32(txtIdProducto.Text);
                    int IdCategoria = Convert.ToInt32(cmbidcategoria.SelectedValue);
                    string Producto = txtProducto.Text.ToUpper();
                    string Descripcion = txtDescripcion.Text.ToUpper();
                    int Stock = Convert.ToInt32(nudstock.Value);
                    int StockMinimo = Convert.ToInt32(nudstockminimo.Value);
                    decimal UltPrecioCosto = Convert.ToDecimal(nudultpreciocosto.Value);
                    decimal UltPrecioVenta = Convert.ToDecimal(nudultprecioventa.Value);

                    bool resu = false;

                    resu = ActualizarProducto(IdProducto, IdCategoria, Producto, Descripcion, Stock, StockMinimo,
            UltPrecioCosto, UltPrecioVenta);
                    if (resu)
                    {
                        MessageBox.Show("Producto actualizado exitósamente");
                    }
                    cargartabla();
                    Limpiar();
                }
                catch { MessageBox.Show("Error, no se actualizó registro"); }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void Producto_Load(object sender, EventArgs e)
        {
            cargarcmbcategoriaid();
            cargartabla();
            dgvProductos.Columns[6].DefaultCellStyle.Format = "N2";
            dgvProductos.Columns[7].DefaultCellStyle.Format = "N2";
        }

        private void dgvProductos_CurrentCellChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                txtIdProducto.Text = Convert.ToString(dgvProductos.CurrentRow.Cells[0].Value);
                cmbidcategoria.Text = Convert.ToString(dgvProductos.CurrentRow.Cells[1].Value);
                txtProducto.Text = Convert.ToString(dgvProductos.CurrentRow.Cells[2].Value);
                txtDescripcion.Text = Convert.ToString(dgvProductos.CurrentRow.Cells[3].Value);
                nudstock.Value = Convert.ToInt32(dgvProductos.CurrentRow.Cells[4].Value);
                nudstockminimo.Value = Convert.ToInt32(dgvProductos.CurrentRow.Cells[5].Value);
                nudultpreciocosto.Value = Convert.ToDecimal((dgvProductos.CurrentRow.Cells[6].Value));
                nudultprecioventa.Value = Convert.ToDecimal((dgvProductos.CurrentRow.Cells[7].Value));

            }
            catch
            { }
        }

    }
}
