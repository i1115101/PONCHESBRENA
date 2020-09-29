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
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
        }
        void cargarcmbTipoDoc()
        {            
            LogicaTipoDocumento TipoDocumeno = new LogicaTipoDocumento();
            cmbTipoDoc.DataSource = TipoDocumeno.MostrarTipoDocumento();
            cmbTipoDoc.DisplayMember = "TipoDocumento";
            cmbTipoDoc.ValueMember = "IdTipoDocumento";
        }
        void cargartabla()
        {
            LogicaCliente Cliente = new LogicaCliente();
            dgvCliente.DataSource = Cliente.MostrarCliente();
        }

        #region Validaciones
        private bool ValidarInsertarCliente()
        {
            bool no_error = true;
            
            if (txtRazonSocial.Text == string.Empty)
            {
                errorProvider1.SetError(txtRazonSocial, "Ingrese un dato");
                no_error = false;
            }
            try
            {
                if (Convert.ToInt32(txtCodigo.Text) >= 0 || txtRazonSocial.Enabled == false)
                {
                    MessageBox.Show(this, "Limpie si quiere registrar un nuevo Cliente", "¿Ud. quiere Registrar?", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider1.SetError(btnNuevo, "Click en Limpiar");
                    no_error = false;
                }
            }
            catch
            { }            
            if (txtcaracter.Text == string.Empty)
            {
                errorProvider1.SetError(txtcaracter, "Ingrese un dato");
                no_error = false;
            }            
            if (cmbTipoDoc.Text == string.Empty)
            {
                errorProvider1.SetError(cmbTipoDoc, "Ingrese un dato");
                no_error = false;
            }
            if (cmbTipoDoc.Text == "DNI" & txtcaracter.TextLength <= 7)
            {
                MessageBox.Show("tiene que ingresar 8 digitos de dni");
                txtcaracter.Focus();
                no_error = false;
            }
            if (cmbTipoDoc.Text == "PASAPORTE" & txtcaracter.TextLength <= 4)
            {
                MessageBox.Show("tiene que ingresar de 5 a 15 digitos de su pasaporte");
                txtcaracter.Focus();
                no_error = false;
            }
            if (cmbTipoDoc.Text == "RUC" & txtcaracter.TextLength < 11)
            {
                MessageBox.Show("tiene que ingresar 11 digitos de ruc");
                txtcaracter.Focus();
                no_error = false;
            }
            int repetido = 0;
            for (int i = 0; i < dgvCliente.RowCount; i++)
            {
                if (dgvCliente.Rows[i].Cells[3].Value.ToString() == txtcaracter.Text)
                {
                    repetido = 1;
                }
            }
            if (repetido == 1)
            {
                MessageBox.Show(this,txtcaracter.Text + " ya existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtcaracter, " El documento ya existe");
                txtcaracter.Focus();
                no_error = false;
            }
            return no_error;
        }

        private bool ValidarActualizarCliente()
        {
            bool no_error = true;
            if (txtCodigo.Text == string.Empty || txtRazonSocial.Enabled == false)
            {
                MessageBox.Show(this, "Y luego seleccione en la lista", "Click en Limpiar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                errorProvider1.SetError(btnNuevo, "Click en Limpiar");
                no_error = false;
            }
            if (txtcaracter.Text == string.Empty)
            {
                errorProvider1.SetError(txtcaracter, "Seleccione en la lista");
                no_error = false;
            }            
            if (cmbTipoDoc.Text == string.Empty)
            {
                errorProvider1.SetError(cmbTipoDoc, "Seleccione en la lista");
                no_error = false;
            }
            if (cmbTipoDoc.Text == "DNI" & txtcaracter.TextLength <= 7)
            {
                MessageBox.Show("tiene que ingresar 8 digitos de dni");
                txtcaracter.Focus();
                no_error = false;
            }
            if (cmbTipoDoc.Text == "PASAPORTE" & txtcaracter.TextLength <= 4)
            {
                MessageBox.Show("tiene que ingresar de 5 a 15 digitos de su pasaporte");
                txtcaracter.Focus();
                no_error = false;
            }
            if (cmbTipoDoc.Text == "RUC" & txtcaracter.TextLength < 11)
            {
                MessageBox.Show("tiene que ingresar 11 digitos de ruc");
                txtcaracter.Focus();
                no_error = false;
            }
            return no_error;
        }
        private void txtcaracter_KeyPress(object sender, KeyPressEventArgs e)
        {
            varpublic.SoloNumeros(e);
            if (cmbTipoDoc.Text == "DNI")
            {
                txtcaracter.MaxLength = 8;
            }
            if (cmbTipoDoc.Text == "PASAPORTE")
            {
                txtcaracter.MaxLength = 15;
            }
            if (cmbTipoDoc.Text == "RUC")
            {
                txtcaracter.MaxLength = 11;
            }
        }
        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtRazonSocial, string.Empty);   
        }
        private void cmbTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.cmbTipoDoc, string.Empty);
        }
        private void txtcaracter_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtcaracter, string.Empty);
        }
        private void txtDirección_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtDirección, string.Empty);
        }
        private void txtRazonSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            varpublic.SoloLetras(e);
        }
        void Limpiar()
        {
            cmbTipoDoc.Enabled = true;
            cmbTipoDoc.SelectedValue = -1;

            errorProvider1.Clear();

            foreach (Control ctrl in panelMantenimiento.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox text = ctrl as TextBox;
                    text.Clear();
                    text.Enabled = true;
                }
            }
            txtRazonSocial.Focus();
        }

        #endregion

        #region LogicaNegocio

        private bool GuardarCliente(string RazonSocial, int IdTipoDocumento, string NroDocumento, string Direccion)
        {
            LogicaCliente logicaCliente = new LogicaCliente();
            bool resu = logicaCliente.InsertarCliente(RazonSocial, IdTipoDocumento, NroDocumento, Direccion);
            return resu;
        }
        private bool ActualizarCliente(int IdCliente, string RazonSocial, int IdTipoDocumento, string NroDocumento, string Direccion)
        {
            LogicaCliente logicaCliente = new LogicaCliente();
            bool resu = logicaCliente.ActualizarCliente(IdCliente, RazonSocial, IdTipoDocumento, NroDocumento, Direccion);
            return resu;
        }
        #endregion

        private void dgvCliente_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                txtCodigo.Text = Convert.ToString(dgvCliente.CurrentRow.Cells[0].Value);
                txtRazonSocial.Text = Convert.ToString(dgvCliente.CurrentRow.Cells[1].Value);
                cmbTipoDoc.Text = Convert.ToString(dgvCliente.CurrentRow.Cells[2].Value);
                txtcaracter.Text = Convert.ToString(dgvCliente.CurrentRow.Cells[3].Value);
                txtDirección.Text = Convert.ToString(dgvCliente.CurrentRow.Cells[4].Value);
            }
            catch
            {

            }
        }
        private void Cliente_Load(object sender, EventArgs e)
        {
            cargarcmbTipoDoc();
            cargartabla();           
        }

        #region btn Registrar, Actualizar, Limpiar y Cerrar
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarInsertarCliente())
            {
                try
                {
                    string RazonSocial = txtRazonSocial.Text.ToUpper();
                    int IdTipoDocumento = Convert.ToInt32(cmbTipoDoc.SelectedValue);
                    string NroDocumento = txtcaracter.Text;
                    string Direccion = txtDirección.Text.ToUpper(); ;

                    bool resu = false;

                    resu = GuardarCliente(RazonSocial, IdTipoDocumento, NroDocumento, Direccion);
                    if (resu)
                    {
                        MessageBox.Show("Cliente insertado exitósamente");
                    }

                    Limpiar();
                    cargartabla();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (ValidarActualizarCliente())
            {
                try
                {
                    int IdCliente = Convert.ToInt32(txtCodigo.Text);
                    string RazonSocial = txtRazonSocial.Text.ToUpper();
                    int IdTipoDocumento = Convert.ToInt32(cmbTipoDoc.SelectedValue);
                    string NroDocumento = txtcaracter.Text;
                    string Direccion = txtDirección.Text.ToUpper();

                    bool resu = false;

                    resu = ActualizarCliente(IdCliente, RazonSocial, IdTipoDocumento, NroDocumento, Direccion);
                    if (resu)
                    {
                        MessageBox.Show("Cliente Actualizado exitósamente");
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
