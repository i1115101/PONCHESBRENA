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
    public partial class frmProducto : Form
    {
        LogicaProducto objeto = new LogicaProducto();
        LogicaCategoria categoria = new LogicaCategoria();
        string[] produc;
        public frmProducto()
        {
            InitializeComponent();

        }
        void cargarcmbcategoriaid()
        {
            cmbidcategoria.DataSource = categoria.ListCategoria();
            cmbidcategoria.DisplayMember = "cNombreCategoria";
            cmbidcategoria.ValueMember = "nIdTCategoria";
        }
        void cargartabla()
        {            
            dgvProductos.DataSource = objeto.productotable();
            dgvProductos.Columns[3].Visible = false;
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
                
        #region btn Registrar, Actualizar,Limpiar y Cerrar
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarInsertarProducto())
            {
                try
                {
                    produc = new string[] {"0", Convert.ToString(cmbidcategoria.SelectedValue), txtProducto.Text.ToUpper(),txtDescripcion.Text.ToUpper(), Convert.ToString(nudstock.Value),
                                           Convert.ToString(nudstockminimo.Value),Convert.ToString(nudultpreciocosto.Value),Convert.ToString(nudultprecioventa.Value),
                                           Convert.ToString(Convert.ToInt32(nudultprecioventa.Value)-Convert.ToInt32(nudultpreciocosto.Value))};
                    objeto.InsActProducto(produc);
                    MessageBox.Show("Producto insertado exitósamente");
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
                    produc = new string[] {txtIdProducto.Text, Convert.ToString(cmbidcategoria.SelectedValue), txtProducto.Text.ToUpper(),txtDescripcion.Text.ToUpper(), Convert.ToString(nudstock.Value),
                                           Convert.ToString(nudstockminimo.Value),Convert.ToString(nudultpreciocosto.Value),Convert.ToString(nudultprecioventa.Value),
                                           Convert.ToString(Convert.ToDecimal(nudultprecioventa.Value)-Convert.ToDecimal(nudultpreciocosto.Value))};
                    objeto.InsActProducto(produc);
                    MessageBox.Show("Producto actualizado exitósamente");
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
        }

        private void dgvProductos_CurrentCellChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                txtIdProducto.Text = Convert.ToString(dgvProductos.CurrentRow.Cells[0].Value);
                cmbidcategoria.SelectedValue = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                txtProducto.Text = Convert.ToString(dgvProductos.CurrentRow.Cells[2].Value);
                txtDescripcion.Text = Convert.ToString(dgvProductos.CurrentRow.Cells[3].Value);
                nudstock.Value = Convert.ToInt32(dgvProductos.CurrentRow.Cells[4].Value);
                nudstockminimo.Value = Convert.ToInt32(dgvProductos.CurrentRow.Cells[5].Value);
                nudultpreciocosto.Value = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[6].Value);
                nudultprecioventa.Value = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[7].Value);

            }
            catch
            { }
        }

    }
}
