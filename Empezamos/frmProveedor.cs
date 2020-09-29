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
    public partial class frmProveedor : Form
    {

        public frmProveedor()
        {
            InitializeComponent();            
        }

        void cargartabla()
        {
            LogicaProveedor objeto = new LogicaProveedor();
            dgvProveedor.DataSource = objeto.ListProveedor();                
        }

        void cargarcmbTipoDoc()
        {
            LogicaTipoDocumento objeto = new LogicaTipoDocumento();
            cmbTipoDoc.DataSource = objeto.ListDocumentos();            
            cmbTipoDoc.DisplayMember = "cTipoDocumento";
            cmbTipoDoc.ValueMember = "nIdTipoDocumento";            
        }

        #region Validaciones
        private bool ValidarInsertarProveedor()
        {
            bool no_error = true;
            {
                try
                {
                    if (Convert.ToInt32(txtcodigo.Text) >= 0 || txtrazon.Enabled == false)
                    {
                        MessageBox.Show(this, "Limpie si quiere registrar un nuevo Proveedor", "¿Ud. quiere Registrar?", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        errorProvider1.SetError(btnNuevo, "Click en Limpiar");
                        no_error = false;
                    }
                }
                catch
                { }               
                if (txtrazon.Text == string.Empty)
                {
                    errorProvider1.SetError(txtrazon, "Ingrese un dato");
                    no_error = false;
                }
                if (mtxtTelefono.Text == string.Empty)
                {
                    errorProvider1.SetError(mtxtTelefono, "Ingrese un dato");
                    no_error = false;
                }
                if (txtdireccion.Text == string.Empty)
                {
                    errorProvider1.SetError(txtdireccion, "Ingrese un dato");
                    no_error = false;
                }
                if (cmbTipoDoc.Text == string.Empty)
                {
                    errorProvider1.SetError(cmbTipoDoc, "Ingrese un dato");
                    no_error = false;
                }
                if (txtcaracter.Text == string.Empty)
                {
                    errorProvider1.SetError(txtcaracter, "Ingrese un dato");
                    no_error = false;
                }
                try
                {
                    if (Convert.ToDouble(mtxtTelefono.Text) < 99999999)
                    {
                        errorProvider1.SetError(mtxtTelefono, "Ingrese un dato");
                        no_error = false;
                    }
                }
                catch { }
                int repetido = 0, repetido2 = 0;
                for (int i = 0; i < dgvProveedor.RowCount; i++)
                {
                    if (dgvProveedor.Rows[i].Cells[3].Value.ToString() == txtrazon.Text.ToUpper())
                    {
                        repetido = 1;
                    }
                }
                for (int i = 0; i < dgvProveedor.RowCount; i++)
                {
                    if (dgvProveedor.Rows[i].Cells[2].Value.ToString() == txtcaracter.Text)
                    {
                        repetido2 = 1;
                    }
                }
                if (repetido == 1)
                {
                    MessageBox.Show(this,txtrazon.Text.ToUpper() + " ya esta registrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtrazon.Focus();                    
                    errorProvider1.SetError(txtrazon, "Proveedor Repetido");
                    no_error = false;
                }
                if (repetido2 == 1)
                {
                    MessageBox.Show(this, "Documentos repetidos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider1.SetError(txtcaracter, "Documento Repetido");
                    no_error = false;
                }
                if (cmbTipoDoc.Text == "DNI" & txtcaracter.TextLength <= 7)
                {
                    MessageBox.Show("tiene que ingresar 8 digitos de dni");
                    errorProvider1.SetError(txtcaracter, "tiene que ingresar 8 digitos de dni");
                    no_error = false;
                }
                if (cmbTipoDoc.Text == "PASAPORTE" & txtcaracter.TextLength <= 4)
                {
                    MessageBox.Show("tiene que ingresar de 5 a 15 digitos de su pasaporte");
                    errorProvider1.SetError(txtcaracter, "tiene que ingresar de 5 a 15 digitos de su pasaporte");
                    no_error = false;
                }
                if (cmbTipoDoc.Text == "RUC" & txtcaracter.TextLength < 11)
                {
                    MessageBox.Show("tiene que ingresar 11 digitos de ruc");
                    errorProvider1.SetError(txtcaracter, "tiene que ingresar 11 digitos de ruc");
                    no_error = false;
                }
            }
            return no_error;
        }
        private bool ValidarActualizarProveedor()
        {
            bool no_error = true;
            {
                if (txtcodigo.Text == string.Empty || txtrazon.Enabled == false)
                {
                    MessageBox.Show(this, "Y luego seleccione en la lista", "Click en Limpiar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider1.SetError(btnNuevo, "Click en Limpiar");
                    no_error = false;
                }
                if (txtrazon.Text == string.Empty)
                {
                    errorProvider1.SetError(txtrazon, "Seleccione en la lista");
                    no_error = false;
                }
                if (mtxtTelefono.Text == string.Empty)
                {
                    errorProvider1.SetError(mtxtTelefono, "Seleccione en la lista");
                    no_error = false;
                }
                if (txtdireccion.Text == string.Empty)
                {
                    errorProvider1.SetError(txtdireccion, "Seleccione en la lista");
                    no_error = false;               
                }
                if (cmbTipoDoc.Text == string.Empty)
                {
                    errorProvider1.SetError(cmbTipoDoc, "Seleccione en la lista");
                    no_error = false;
                }
                if (txtcaracter.Text == string.Empty)
                {
                    errorProvider1.SetError(txtcaracter, "Seleccione en la lista");
                    no_error = false;
                }
                try
                {
                    if (Convert.ToDouble(mtxtTelefono.Text) < 99999999)
                    {
                        errorProvider1.SetError(mtxtTelefono, "Seleccione en la lista");
                        no_error = false;
                    }
                }
                catch { }
                if (cmbTipoDoc.Text == "DNI" & txtcaracter.TextLength <= 7)
                {
                    MessageBox.Show("tiene que ingresar 8 digitos de dni");
                    errorProvider1.SetError(txtcaracter, "tiene que ingresar 8 digitos de dni");
                    txtcaracter.Focus();
                    no_error = false;
                }
                if (cmbTipoDoc.Text == "PASAPORTE" & txtcaracter.TextLength <= 4)
                {
                    MessageBox.Show("tiene que ingresar de 5 a 15 digitos de su pasaporte");
                    errorProvider1.SetError(txtcaracter, "tiene que ingresar de 5 a 15 digitos de su pasaporte");
                    txtcaracter.Focus();
                    no_error = false;
                }
                if (cmbTipoDoc.Text == "RUC" & txtcaracter.TextLength < 11)
                {
                    MessageBox.Show("tiene que ingresar 11 digitos de ruc");
                    errorProvider1.SetError(txtcaracter, "tiene que ingresar 11 digitos de ruc");
                    txtcaracter.Focus();
                    no_error = false;
                }
            }
            return no_error;
        }
        private void txtrazon_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtrazon, string.Empty);
        }
        private void txtdireccion_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtdireccion, string.Empty);
        }
        private void cmbTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.cmbTipoDoc, string.Empty);
        }
        private void txtcaracter_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtcaracter, string.Empty);
        }
        private void mtxtTelefono_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.mtxtTelefono, string.Empty);
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
        private void txtrazon_KeyPress(object sender, KeyPressEventArgs e)
        {
            varpublic.SoloLetras(e);
        } 
        void Limpiar()
        {
            errorProvider1.Clear();
            cmbTipoDoc.Enabled = true;
            cmbTipoDoc.SelectedValue = -1;
            mtxtTelefono.Text = "";
            mtxtTelefono.Enabled = true;
            foreach (Control ctrl in panelMantenimiento.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox text = ctrl as TextBox;
                    text.Clear();
                    text.Enabled = true;
                }
            }
            txtrazon.Select();
        }
        #endregion
  
        #region Logica Negocio
        //private bool GuardarProveedor(int IdTipoDocumento, string NroDocumento, string RazonSocial, string Direccion, string Telefono,
        //   string Web, string Email)
        //{
        //    LogicaProveedor logicaProveedor = new LogicaProveedor();
        //    bool resu = logicaProveedor.InsertarProveedor(IdTipoDocumento, NroDocumento, RazonSocial, Direccion, Telefono, Web, Email);
        //    return resu;
        //}
        //private bool ActualizarProveedor( int IdProveedor,int IdTipoDocumento, string NroDocumento, string RazonSocial, string Direccion, string Telefono,
        //   string Web, string Email)
        //{
        //    LogicaProveedor logicaProveedor = new LogicaProveedor();
        //    bool resu = logicaProveedor.ActualizarProveedor(IdProveedor,IdTipoDocumento, NroDocumento, RazonSocial, Direccion, Telefono, Web, Email);
        //    return resu;
        //}
        #endregion            

        #region btn Registrar , Limpiar , Acrualizar y Salir
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarInsertarProveedor())
            {
                try
                {
                    int IdTipoDocumento = Convert.ToInt32(cmbTipoDoc.SelectedValue);
                    string NroDocumento = txtcaracter.Text;
                    string RazonSocial = txtrazon.Text.ToUpper();
                    string Direccion = txtdireccion.Text.ToUpper();
                    string Telefono = mtxtTelefono.Text;
                    string Web = txtweb.Text;
                    string Email = txtemail.Text;

                    bool resu = false;

                    //resu = GuardarProveedor(IdTipoDocumento, NroDocumento, RazonSocial, Direccion, Telefono, Web, Email);
                    if (resu)
                    {
                        MessageBox.Show("Nuevo Proveedor registrado exitósamente");
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
            if (ValidarActualizarProveedor())
            {
                try
                {
                    int IdProveedor = Convert.ToInt32(txtcodigo.Text);
                    int IdTipoDocumento = Convert.ToInt32(cmbTipoDoc.SelectedValue);
                    string NroDocumento = txtcaracter.Text;
                    string RazonSocial = txtrazon.Text.ToUpper();
                    string Direccion = txtdireccion.Text.ToUpper();
                    string Telefono = mtxtTelefono.Text;
                    string Web = txtweb.Text;
                    string Email = txtemail.Text;

                    bool resu = false;

                    //resu = ActualizarProveedor(IdProveedor, IdTipoDocumento, NroDocumento, RazonSocial, Direccion, Telefono, Web, Email);
                    if (resu)
                    {
                        MessageBox.Show("Proveedor actualizado exitósamente");
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

        private void Proveedor_Load(object sender, EventArgs e)
        {
            cargartabla();
            cargarcmbTipoDoc();
        }

        private void dgvProveedor_CurrentCellChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                txtcodigo.Text = Convert.ToString(dgvProveedor.CurrentRow.Cells[0].Value);
                cmbTipoDoc.Text = Convert.ToString(dgvProveedor.CurrentRow.Cells[1].Value);
                txtcaracter.Text = Convert.ToString(dgvProveedor.CurrentRow.Cells[2].Value);
                txtrazon.Text = Convert.ToString(dgvProveedor.CurrentRow.Cells[3].Value);
                txtdireccion.Text = Convert.ToString(dgvProveedor.CurrentRow.Cells[4].Value);
                mtxtTelefono.Text = Convert.ToString(dgvProveedor.CurrentRow.Cells[5].Value);
                txtweb.Text = Convert.ToString(dgvProveedor.CurrentRow.Cells[6].Value);
                txtemail.Text = Convert.ToString(dgvProveedor.CurrentRow.Cells[7].Value);
            }
            catch
            {  }
        }
               
    }
}

