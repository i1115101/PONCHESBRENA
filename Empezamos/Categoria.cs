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
    public partial class Categoria : Form
    {
        public Categoria()
        {
            InitializeComponent();
        }
        void cargartabla()
        {
            LogicaCategoria objeto = new LogicaCategoria();
            dgvCategoria.DataSource = objeto.MostrarCategoria();
        }

        #region Validaciones
        private bool ValidarRegistrarCategoria()
        {
            bool no_error = true;
            try
            {
                if (Convert.ToInt32(txtcodigo.Text) >= 0 || txtcategoria.Enabled == false)
                {
                    MessageBox.Show(this, "Limpie si quiere registrar una nueva categoria", "¿Ud. quiere Registrar?", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider1.SetError(btnNuevo, "Click en Limpiar");
                    no_error = false;
                }
            }
            catch
            { }
            if (txtcategoria.Text == string.Empty)
            {
                errorProvider1.SetError(txtcategoria, "Ingrese un dato");
                no_error = false;
            }
            int repetido = 0;
            for (int i = 0; i < dgvCategoria.RowCount; i++)
            {
                if (dgvCategoria.Rows[i].Cells[1].Value.ToString() == txtcategoria.Text.ToUpper())
                {
                    repetido = 1;
                }
            }
            if (repetido == 1)
            {
                MessageBox.Show(this, txtcategoria.Text + " ya Existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtcategoria.Focus();
                no_error = false;
            }           
            return no_error;
        }
        private bool ValidarActualizarCategoria()
        {
            bool no_error = true;
            if (txtcodigo.Text == string.Empty || txtcategoria.Enabled == false)
            {
                MessageBox.Show(this, "Y luego seleccione en la lista", "Click en Limpiar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                errorProvider1.SetError(btnNuevo, "Click en Limpiar");
                no_error = false;
            }            
            if (txtcategoria.Text == string.Empty)
            {
                errorProvider1.SetError(txtcategoria, "Ingrese un dato");
                no_error = false;
            }
            
            return no_error;
        }

        private void txtcategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            varpublic.SoloLetras(e);
        }
        private void txtcategoria_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtcategoria, string.Empty);
        }
        void Limpiar()
        {
            errorProvider1.Clear();
            txtcodigo.Clear();
            txtcategoria.Enabled = true;
            txtcategoria.Clear();
            txtcategoria.Focus();
        }
        #endregion

        #region Logica Negocios
        private bool GuardarCategoria(string Categoria)
        {
            LogicaCategoria logicaCategoria = new LogicaCategoria();
            bool resu = logicaCategoria.InsertarCategoria(Categoria);
            return resu;
        }
        private bool ActualizarCategoria(int IdCategoria, string Categoria)
        {
            LogicaCategoria logicaCategoria = new LogicaCategoria();
            bool resu = logicaCategoria.ActualizarCategoria(IdCategoria, Categoria);
            return resu;
        }
        #endregion

        private void dgvCategoria_CurrentCellChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                txtcodigo.Text = Convert.ToString(dgvCategoria.CurrentRow.Cells[0].Value);
                txtcategoria.Text = Convert.ToString(dgvCategoria.CurrentRow.Cells[1].Value);
            }
            catch
            { }
        }

        private void Categoria_Load(object sender, EventArgs e)
        {
            cargartabla();
        }

        #region btn Guardar,Actualizar,Limpiar y Salir
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarRegistrarCategoria())
            {
                try
                {
                    string Categoria = txtcategoria.Text.ToUpper();
                    bool resu = false;

                    resu = GuardarCategoria(Categoria);
                    if (resu)
                    {
                        MessageBox.Show("Categoría insertado exitosamente");
                    }
                    cargartabla();
                    Limpiar();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (ValidarActualizarCategoria())
            {
                try
                {
                    int IdCategoria = Convert.ToInt32(txtcodigo.Text);
                    string Categoria = txtcategoria.Text.ToUpper();
                    bool resu = false;

                    resu = ActualizarCategoria(IdCategoria, Categoria);
                    if (resu)
                    {
                        MessageBox.Show("Categoría actualizada exitósamente");
                    }
                    cargartabla();
                    Limpiar();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        
    }
}
