using System;
using System.Data;
using System.Windows.Forms;
using LogicaNegocio;
using System.Runtime.InteropServices;


namespace Empezamos
{
    public partial class frmDevolucion : Form
    {
        LogicaDetalleVenta tabladventa = new LogicaDetalleVenta();
        LogicaVenta anulventa = new LogicaVenta();
        LogicaProducto ActDevoStocProd = new LogicaProducto();
        public frmDevolucion()
        {
            InitializeComponent();
        }
        void CargarTabla()
        {
            DataTable TablaRecordProd;
            string[] lsRecordPro = { txtcategoria.Text };
            TablaRecordProd = tabladventa.ParametroDVenta(lsRecordPro);
            dgvAnularVenta.DataSource = TablaRecordProd;
            dgvAnularVenta.Columns[0].Visible = false;
            dgvAnularVenta.Columns[1].Visible = false;
        }
        private void frmDevolucion_Load(object sender, EventArgs e)
        {            
            limpiar();
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarAnulacion())
            {
                CargarTabla();
            }            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvAnularVenta.RowCount > 0)
            {
                if (MessageBox.Show("¿Está seguro de eliminar la venta?", "Alerta¡¡", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string[] venta;
                    venta = new string[] { txtcategoria.Text };
                    anulventa.ParamAnulVenta(venta);
                    for (int c = 0; c <= dgvAnularVenta.RowCount - 1; c++)
                    {
                        ActDevoStocProd.DevoActStoc(Convert.ToInt32(dgvAnularVenta.Rows[c].Cells[1].Value), Convert.ToInt32(dgvAnularVenta.Rows[c].Cells[3].Value));
                    }
                    limpiar();                    
                }
            }
            else
            {
                MessageBox.Show("No se puede anular la venta," + Char.ConvertFromUtf32(13) + "No existen items", "Aviso");
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cerrar?", "Alerta¡¡", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        #region Movimiento del form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void sendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            sendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Validaciones
        private bool ValidarAnulacion()
        {
            bool no_error = true;            
            if (txtcategoria.Text == "")
            {
                errorProvider1.SetError(txtcategoria, "Ingrese un código de venta");
                no_error = false;
            }
            return no_error;
        }       

        private void txtcategoria_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtcategoria, string.Empty);
        }
        void limpiar()
        {
            dgvAnularVenta.DataSource = "";
            txtcategoria.Text = "";            
            errorProvider1.Clear();
            txtcategoria.Focus();
        }
        #endregion
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        
    }
}