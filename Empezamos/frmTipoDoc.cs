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
    public partial class frmTipoDoc : Form
    {
        LogicaTipoDocumento objeto = new LogicaTipoDocumento();
        string[] doc, comp;
        public frmTipoDoc()
        {
            InitializeComponent();            
        }

        private void cargartabla()
        {
            dgvTipoDocumento.DataSource = objeto.ListDocumentos();
            dgvComprovante.DataSource = objeto.ListDocEnt();
        }        

        #region btn Registrar, Limpiar , Acualizar y Cerrar
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarRegistrarTipoDocumento())
            {
                try
                {
                    if (cmbdcoccom.SelectedIndex == 0)
                    {
                        doc = new string[] { "0", txtTipoDoc.Text.ToUpper() };

                        objeto.InsUpdDocumento(doc);
                    }
                    else if (cmbdcoccom.SelectedIndex == 1)
                    {
                        comp = new string[] { "0", txtTipoDoc.Text.ToUpper() };

                        objeto.InsUpdComprobante(comp);
                    }

                    MessageBox.Show("Registro insertado exitósamente");

                    cargartabla();
                    Limpiar();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (ValidarActualizarTipoDocumento())
            {
                try
                {
                    if (cmbdcoccom.SelectedIndex == 0)
                    {
                        doc = new string[] { txtIdTipoDoc.Text, txtTipoDoc.Text.ToUpper() };

                        objeto.InsUpdDocumento(doc);
                    }
                    else if (cmbdcoccom.SelectedIndex == 1)
                    {
                        comp = new string[] { txtIdTipoDoc.Text, txtTipoDoc.Text.ToUpper() };

                        objeto.InsUpdComprobante(comp);
                    }
                    MessageBox.Show("Registro actualizado exitósamente");
                    
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
                      
        #region validaciones
        private bool ValidarRegistrarTipoDocumento()
        {
            bool no_error = true;
            int repetido = 0;
           
            if (txtTipoDoc.Text == string.Empty)
            {
                errorProvider1.SetError(txtTipoDoc, "Ingrese un dato");
                no_error = false;
            }  
            try
            {
                if (Convert.ToInt32(txtIdTipoDoc.Text) >= 0 || txtTipoDoc.Enabled == false)
                {
                    MessageBox.Show(this, "Limpie si quiere registrar un nuevo documento", "¿Ud. quiere Registrar?", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider1.SetError(btnNuevo, "Click en Limpiar");
                    no_error = false;
                }
            }
            catch 
            { }
            if (cmbdcoccom.SelectedIndex == 0)
            {
                for (int i = 0; i < dgvTipoDocumento.RowCount; i++)
                {
                    if (dgvTipoDocumento.Rows[i].Cells[1].Value.ToString() == txtTipoDoc.Text)
                    {
                        repetido = 1;
                    }
                }
            }
            else if (cmbdcoccom.SelectedIndex == 1)
            {
                for (int i = 0; i < dgvComprovante.RowCount; i++)
                {
                    if (dgvComprovante.Rows[i].Cells[1].Value.ToString() == txtTipoDoc.Text)
                    {
                        repetido = 1;
                    }
                }
            }
            if (repetido == 1 && txtTipoDoc.Enabled==true)
            {
                MessageBox.Show(this, txtTipoDoc.Text + " ya está registrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTipoDoc.Focus();
                no_error = false;
            }     
       
            return no_error;
        }
        private bool ValidarActualizarTipoDocumento()
        {
            bool no_error = true;

            if (txtIdTipoDoc.Text == string.Empty || txtTipoDoc.Enabled == false)
            {
                MessageBox.Show(this, "Y luego seleccione en la lista", "Click en Limpiar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                errorProvider1.SetError(btnNuevo, "Click en Limpiar");
                no_error = false;
            }

            if (txtTipoDoc.Text == string.Empty)
            {
                errorProvider1.SetError(txtTipoDoc, "Ingrese un dato");
                no_error = false;
            }

            return no_error;
        }
        private void txtTipoDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            varpublic.SoloLetras(e);
        }  
        void Limpiar()
        {
            foreach (Control ctrl in panelMantenimiento.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox text = ctrl as TextBox;
                    text.Clear();
                    text.Enabled = true;
                }
            }
            txtTipoDoc.Focus();
            errorProvider1.Clear();
        }
        
        #endregion

        private void dgvTipoDocumento_CurrentCellChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                if (cmbdcoccom.SelectedIndex == 0)
                {
                    txtIdTipoDoc.Text = Convert.ToString(dgvTipoDocumento.CurrentRow.Cells[0].Value);
                    txtTipoDoc.Text = Convert.ToString(dgvTipoDocumento.CurrentRow.Cells[1].Value);
                }
            }
            catch
            { }
        }

        private void TipoDoc_Load(object sender, EventArgs e)
        {
            cmbdcoccom.SelectedIndex = 0;
            cargartabla();
        }

        private void cmbdcoccom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbdcoccom.SelectedIndex == 0)
            {
                label3.Text = "Tipo Doc";
                dgvComprovante.Enabled = false;
                dgvTipoDocumento.Enabled = true;
            }
            else if (cmbdcoccom.SelectedIndex == 1)
            {
                label3.Text = "Tipo Comp";
                dgvTipoDocumento.Enabled = false;
                dgvComprovante.Enabled = true;
            }
        }

        private void dgvComprovante_CurrentCellChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                if (cmbdcoccom.SelectedIndex == 1)
                {
                    txtIdTipoDoc.Text = Convert.ToString(dgvComprovante.CurrentRow.Cells[0].Value);
                    txtTipoDoc.Text = Convert.ToString(dgvComprovante.CurrentRow.Cells[1].Value);
                }
            }
            catch
            { }
        }
    }
}
