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
using System.Security.Cryptography;
using LogicaNegocio;

namespace Empezamos
{
    public partial class frmEmpleado : Form
    {
        LogicaEmpleado Empleado = new LogicaEmpleado();
        LogicaTipoDocumento Documento = new LogicaTipoDocumento();
        string[] datoempl;
        public frmEmpleado()
        {
            InitializeComponent();

        }
        void cargartabla()
        {
            
           dgvEmpleados.DataSource = Empleado.retorEmple();  
        }
        void rellenacombo()
        {
            cmbIdTipoDoc.DataSource = Documento.ListDocumentos();
            cmbIdTipoDoc.DisplayMember = "cTipoDocumento";
            cmbIdTipoDoc.ValueMember = "nIdTipoDocumento";
        }

        #region Validaciones
        private bool ValidarRegistrarEmpleado()
        {
            int repetido = 0, repetido2 = 0;
            bool no_error = true;
            {
                try
                {
                    if (Convert.ToInt32(txtIdEmpleado.Text) >= 0 || txtNombres.Enabled == false)
                    {
                        MessageBox.Show(this, "Limpie si quiere registrar un nuevo Empleado", "¿Ud. quiere Registrar?", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        errorProvider1.SetError(btnNuevo, "Click en Limpiar");
                        no_error = false;
                    }
                }
                catch
                { }                  
                if (txtNombres.Text == string.Empty)
                {
                    errorProvider1.SetError(txtNombres, "Ingrese un dato");
                    no_error = false;
                }
                if (txtApellidos.Text == string.Empty)
                {
                    errorProvider1.SetError(txtApellidos, "Ingrese un dato");
                    no_error = false;
                }
                if (txtUsuario.Text == string.Empty)
                {
                    errorProvider1.SetError(txtUsuario, "Ingrese un dato");
                    no_error = false;
                }
                if (txtClave.Text == string.Empty)
                {
                    errorProvider1.SetError(txtClave, "Ingrese un dato");
                    no_error = false;
                }
                if (txtDireccion.Text == string.Empty)
                {
                    errorProvider1.SetError(txtDireccion, "Ingrese un dato");
                    no_error = false;
                }
                if (mtxtTelefono.Text == string.Empty)
                {
                    errorProvider1.SetError(mtxtTelefono, "Ingrese un dato");
                    no_error = false;
                }
                if (cmbIdTipoDoc.Text == string.Empty)
                {
                    errorProvider1.SetError(cmbIdTipoDoc, "Ingrese un dato");
                    no_error = false;
                }
                if (txtnrodoc.Text == string.Empty)
                {
                    errorProvider1.SetError(txtnrodoc, "Ingrese un dato");
                    no_error = false;
                }
                if (cmbIdCargo.Text == string.Empty)
                {
                    errorProvider1.SetError(cmbIdCargo, "Ingrese un dato");
                    no_error = false;
                }
                if (cmbTurno.Text == string.Empty)
                {
                    errorProvider1.SetError(cmbTurno, "Ingrese un dato");
                    no_error = false;
                }
                if (cmbSexo.Text == string.Empty)
                {
                    errorProvider1.SetError(cmbSexo, "Ingrese un dato");
                    no_error = false;
                }
                if (cmbIdTipoDoc.Text == "DNI" & txtnrodoc.TextLength <= 7)
                {
                    MessageBox.Show("Ingrese 8 dígitos de DNI");
                    errorProvider1.SetError(txtnrodoc, "Ingrese 8 dígitos de DNI");
                    txtnrodoc.Focus();
                    no_error = false;
                }
                if (cmbIdTipoDoc.Text == "PASAPORTE" & txtnrodoc.TextLength <= 4)
                {
                    MessageBox.Show("Ingrese de 5 a 15 dígitos del pasaporte");
                    errorProvider1.SetError(txtnrodoc, "Ingrese de 5 a 15 dígitos del pasaporte");
                    txtnrodoc.Focus();
                    no_error = false;
                }
                if (cmbIdTipoDoc.Text == "RUC" & txtnrodoc.TextLength < 11)
                {
                    MessageBox.Show("Ingrese 11 dígitos de ruc");
                    errorProvider1.SetError(txtnrodoc, "Ingrese 11 dígitos de RUC");
                    txtnrodoc.Focus();
                    no_error = false;
                }

                for (int i = 0; i < dgvEmpleados.RowCount; i++)
                {
                    if (dgvEmpleados.Rows[i].Cells[2].Value.ToString() == txtnrodoc.Text)
                    {
                        repetido = 1;
                    }
                }
                if (repetido == 1)
                {
                    MessageBox.Show(this, txtnrodoc.Text + " ya esta registrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider1.SetError(txtnrodoc, "Documento repetido");
                    txtnrodoc.Focus();                    
                    no_error = false;
                }

                for (int i = 0; i < dgvEmpleados.RowCount; i++)
                {
                    if (dgvEmpleados.Rows[i].Cells[5].Value.ToString() == txtUsuario.Text.ToUpper())
                    {
                        repetido2 = 1;
                    }
                }

                if (repetido2 == 1)
                {
                    MessageBox.Show(this, txtUsuario.Text + " ya esta registrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider1.SetError(txtUsuario, "Usuario repetido");
                    txtUsuario.Focus();                    
                    no_error = false;
                }
            }
            return no_error;
        }
        private bool ValidarActualizarEmpleado()
        {
            bool no_error = true;
            {
                if (txtIdEmpleado.Text == string.Empty || txtNombres.Enabled == false)
                {
                    MessageBox.Show(this, "Y luego seleccione en la lista", "Click en Limpiar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider1.SetError(btnNuevo, "Click en Limpiar");
                    no_error = false;
                }                
                if (txtNombres.Text == string.Empty)
                {
                    errorProvider1.SetError(txtNombres, "Seleccione en la lista");
                    no_error = false;
                }
                if (txtApellidos.Text == string.Empty)
                {
                    errorProvider1.SetError(txtApellidos, "Seleccione en la lista");
                    no_error = false;
                }
                if (txtUsuario.Text == string.Empty)
                {
                    errorProvider1.SetError(txtUsuario, "Seleccione en la lista");
                    no_error = false;
                }
                if (txtClave.Text == string.Empty)
                {
                    errorProvider1.SetError(txtClave, "Seleccione en la lista");
                    no_error = false;
                }
                if (txtDireccion.Text == string.Empty)
                {
                    errorProvider1.SetError(txtDireccion, "Seleccione en la lista");
                    no_error = false;
                }
                if (mtxtTelefono.Text == string.Empty)
                {
                    errorProvider1.SetError(mtxtTelefono, "Seleccione en la lista");
                    no_error = false;
                }
                if (cmbIdTipoDoc.Text == string.Empty)
                {
                    errorProvider1.SetError(cmbIdTipoDoc, "Seleccione en la lista");
                    no_error = false;
                }
                if (txtnrodoc.Text == string.Empty)
                {
                    errorProvider1.SetError(txtnrodoc, "Seleccione en la lista");
                    no_error = false;
                }
                if (cmbIdCargo.Text == string.Empty)
                {
                    errorProvider1.SetError(cmbIdCargo, "Seleccione en la lista");
                    no_error = false;
                }
                if (cmbTurno.Text == string.Empty)
                {
                    errorProvider1.SetError(cmbTurno, "Seleccione en la lista");
                    no_error = false;
                }
                if (cmbSexo.Text == string.Empty)
                {
                    errorProvider1.SetError(cmbSexo, "Seleccione en la lista");
                    no_error = false;
                }
                if (cmbIdTipoDoc.Text == "DNI" & txtnrodoc.TextLength <= 7)
                {
                    MessageBox.Show("Ingrese 8 dígitos de DNI");
                    errorProvider1.SetError(txtnrodoc, "Ingrese 8 dígitos de DNI");
                    txtnrodoc.Focus();
                    no_error = false;
                }
                if (cmbIdTipoDoc.Text == "PASAPORTE" & txtnrodoc.TextLength <= 4)
                {
                    MessageBox.Show("Ingrese de 5 a 15 dígitos del pasaporte");
                    errorProvider1.SetError(txtnrodoc, "Ingrese de 5 a 15 dígitos del pasaporte");
                    txtnrodoc.Focus();
                    no_error = false;
                }
                if (cmbIdTipoDoc.Text == "RUC" & txtnrodoc.TextLength < 11)
                {
                    MessageBox.Show("Ingrese 11 dígitos de ruc");
                    errorProvider1.SetError(txtnrodoc, "Ingrese 11 dígitos de RUC");
                    txtnrodoc.Focus();
                    no_error = false;
                }
            }
            return no_error;
        }
        private void txtNombres_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtNombres, string.Empty);
        }
        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtApellidos, string.Empty);
        }
        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtUsuario, string.Empty);
        }
        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtClave, string.Empty);
        }
        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtDireccion, string.Empty);
        }
        private void mtxtTelefono_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            errorProvider1.SetError(this.mtxtTelefono, string.Empty);
        }
        private void cmbIdCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.cmbIdCargo, string.Empty);
        }
        private void cmbTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.cmbTurno, string.Empty);
        }
        private void txtnrodoc_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtnrodoc, string.Empty);
        }
        private void cmbSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.cmbSexo, string.Empty);
        }
        private void txtnrodoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            varpublic.SoloNumeros(e);
        }
        private void mtxtTelefono_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.mtxtTelefono, string.Empty);
        }
        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            varpublic.SoloLetras(e);
        }
        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            varpublic.SoloLetras(e);
        }
        private void cmbIdTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.cmbIdTipoDoc, string.Empty);
            if (cmbIdTipoDoc.Text == "OTROS")
            {
                txtnrodoc.Clear();
                txtnrodoc.Text = "0";
            }
            if (cmbIdTipoDoc.Text == "DNI")
            {
                txtnrodoc.Clear();
                txtnrodoc.MaxLength = 8;
            }
            if (cmbIdTipoDoc.Text == "CARNET")
            {
                txtnrodoc.Clear();
            }
            if (cmbIdTipoDoc.Text == "PASAPORTE")
            {
                txtnrodoc.Clear();
                txtnrodoc.MaxLength = 15;
            }
            if (cmbIdTipoDoc.Text == "RUC")
            {
                txtnrodoc.Clear();
                txtnrodoc.MaxLength = 11;
            }
        }

        void Limpiar()
        {
            errorProvider1.Clear();

            mtxtTelefono.Enabled = true;
            mtxtTelefono.Clear();

            foreach (Control ctrl in panelMantenimiento.Controls)
            {
                if (ctrl is ComboBox)
                {
                    ComboBox cmb = ctrl as ComboBox;
                    cmb.Enabled = true;
                    cmb.SelectedIndex = -1;
                }
            }

            foreach (Control ctrl in panelMantenimiento.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox text = ctrl as TextBox;
                    text.Clear();
                    text.Enabled = true;
                    text.Clear();
                }
            }
            txtNombres.Select();
        }
        #endregion
        
        private void Form7_Load(object sender, EventArgs e)
        {
            cargartabla();
            rellenacombo();
        }

        private void dgvEmpleados_CurrentCellChanged(object sender, EventArgs e)
        {

            try
            {
                txtIdEmpleado.Text = Convert.ToString(dgvEmpleados.CurrentRow.Cells[0].Value);
                txtNombres.Text = Convert.ToString(dgvEmpleados.CurrentRow.Cells[1].Value);
                txtApellidos.Text = Convert.ToString(dgvEmpleados.CurrentRow.Cells[2].Value);
                txtUsuario.Text = Convert.ToString(dgvEmpleados.CurrentRow.Cells[5].Value);
                txtClave.Text = Convert.ToString(dgvEmpleados.CurrentRow.Cells[6].Value);
                txtDireccion.Text = Convert.ToString(dgvEmpleados.CurrentRow.Cells[9].Value);
                mtxtTelefono.Text = Convert.ToString(dgvEmpleados.CurrentRow.Cells[10].Value);
                cmbIdTipoDoc.SelectedValue = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells[3].Value);
                txtnrodoc.Text = Convert.ToString(dgvEmpleados.CurrentRow.Cells[4].Value);
                cmbIdCargo.Text = Convert.ToString(dgvEmpleados.CurrentRow.Cells[7].Value);
                cmbTurno.Text = Convert.ToString(dgvEmpleados.CurrentRow.Cells[8].Value);
                cmbSexo.Text = Convert.ToString(dgvEmpleados.CurrentRow.Cells[11].Value);

                dgvEmpleados.Columns[6].Visible = false;
            }
            catch
            { }
        }

        #region Guardar,Actualizar,Limpiar y salir
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarRegistrarEmpleado())
            {
                try
                {
                    datoempl = new string[] { "0", txtNombres.Text.ToUpper(), txtApellidos.Text.ToUpper(), Convert.ToString(cmbIdTipoDoc.SelectedValue),
                                             txtnrodoc.Text, txtUsuario.Text.ToUpper(), txtClave.Text.ToUpper(), cmbIdCargo.Text.ToUpper(),
                                             cmbTurno.Text.ToUpper(),txtDireccion.Text.ToUpper(),mtxtTelefono.Text,cmbSexo.Text.ToUpper()};

                    Empleado.InsAtcEmpleado(datoempl);

                    MessageBox.Show("Empleado registrado exitósamente");

                    cargartabla();
                    Limpiar();
                }
                catch
                {
                    MessageBox.Show("Error, no se inserto registro");
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {            
            if (ValidarActualizarEmpleado())
            {
                try
                {
                    datoempl = new string[] { txtIdEmpleado.Text, txtNombres.Text.ToUpper(), txtApellidos.Text.ToUpper(), Convert.ToString(cmbIdTipoDoc.SelectedValue),
                                             txtnrodoc.Text, txtUsuario.Text.ToUpper(), txtClave.Text.ToUpper(), cmbIdCargo.Text.ToUpper(),
                                             cmbTurno.Text.ToUpper(),txtDireccion.Text.ToUpper(),mtxtTelefono.Text,cmbSexo.Text.ToUpper()};

                    Empleado.InsAtcEmpleado(datoempl);

                    MessageBox.Show("Empleado actuaizado exitósamente");
                    
                    cargartabla();
                    Limpiar();
                }
                catch
                {
                    MessageBox.Show("Error, no se actualizó registro");
                }
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (ValidarActualizarEmpleado())
            {
                try
                {
                    int id = Convert.ToInt32(txtIdEmpleado.Text);

                    Empleado.DesabEmpleado(id);

                    MessageBox.Show("Empleado actuaizado exitósamente");

                    cargartabla();
                    Limpiar();
                }
                catch
                {
                    MessageBox.Show("Error, no se actualizó registro");
                }
            }
        }
    }
}
    

