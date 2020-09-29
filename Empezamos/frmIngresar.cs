using LogicaNegocio;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Empezamos
{
    public partial class frmIngresar : Form
    {
        LogicaProveedor Proveedor = new LogicaProveedor();
        LogicaCategoria Categoria = new LogicaCategoria();
        LogicaTipoDocumento TipoDocumento = new LogicaTipoDocumento();
        LogicaTipoDocumento MostarTipoDoc = new LogicaTipoDocumento();
        LogicaProducto producto = new LogicaProducto();
        LogicaCliente cliente = new LogicaCliente();
        LogicaEmpleado employee = new LogicaEmpleado();

        string Encriptado;
        int bloqueo = 1;
        public frmIngresar()
        {
            InitializeComponent();
        }

        #region Movimiento del form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int Iparam);
        private void Ingresar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion        

        #region Abrir Cerrar Minimizar
        public bool isloginsuccess = false;

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            /*
            string cadena;
            cadena = txtContrasena.Text;

            SHA1CryptoServiceProvider contraseña = new SHA1CryptoServiceProvider();
            byte[] vertorBytes = System.Text.Encoding.UTF8.GetBytes(cadena);
            byte[] salida = contraseña.ComputeHash(vertorBytes);
            contraseña.Clear();
            Encriptado = Convert.ToBase64String(salida);
            Encriptado = txtContrasena.Text;*/
            //--------------------------

            if (validarIngreso())
            {
                LogicaUsuario usuario = new LogicaUsuario();
                var validLogin = usuario.LoginUser(txtUsuario.Text, txtContrasena.Text);
                if (validLogin == true)
                {
                    isloginsuccess = true;
                }
                else
                {
                    isloginsuccess = false;
                    if (bloqueo == 3)
                    {
                        MessageBox.Show("Alcanzo el limite total de intentos, contacte a su administrador");
                        Application.Exit();
                    }
                    MessageBox.Show("Datos Incorrectos,Verifique por favor", "Error");
                    txtUsuario.Clear();
                    txtContrasena.Clear();
                    txtUsuario.Focus();
                    bloqueo++;
                }
            }

            if (isloginsuccess)
            {
                varpublic.usuario = txtUsuario.Text;
                this.Hide();
                frmBienvenida splop = new frmBienvenida();
                splop.ShowDialog();
                SistemaSOFO f = new SistemaSOFO();
                f.Show();
            }
            else
            {
                pcloader.Visible = false;
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("¿Desea Salir?", "Ponches Breña", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (x == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region Text Usuario y Contraseña
        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.Gray;
                lineShape1.BorderColor = Color.Gray;
            }
        }

        private void txtContrasena_Enter_1(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "CONTRASEÑA")
            {
                txtContrasena.Text = "";
                txtContrasena.ForeColor = Color.Gainsboro;
                txtContrasena.UseSystemPasswordChar = true;
                lineShape2.BorderColor = Color.White;
            }
        }

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "")
            {
                txtContrasena.Text = "CONTRASEÑA";
                txtContrasena.ForeColor = Color.Gray;
                txtContrasena.UseSystemPasswordChar = false;
                lineShape2.BorderColor = Color.Gray;
            }
        }
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Gainsboro;
                lineShape1.BorderColor = Color.White;
            }
        }
        #endregion

        #region Validaciones
        private bool validarIngreso()
        {
            bool no_error = true;

            if (txtUsuario.Text == string.Empty || txtUsuario.Text == "USUARIO")
            {
                errorProvider1.SetError(txtUsuario, "Ingrese el nombre Usuario");
                no_error = false;
            }

            if (txtContrasena.Text == string.Empty || txtContrasena.Text == "CONTRASEÑA")
            {
                errorProvider1.SetError(txtContrasena, "Ingrese una contraseña");
                no_error = false;
            }
            return no_error;
        }
        private void txtContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAcceder_Click(sender, e);
            }

        }
        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtUsuario, string.Empty);
        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtContrasena, string.Empty);
        }

        #endregion        

        #region abrir formulario sofo
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            employee.MostrarEmpleado();            
            producto.ProductoId();            
        }
        #endregion

        private void frmIngresar_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.RunWorkerAsync();
            backgroundWorker3.RunWorkerAsync();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {            
            Categoria.RellenarCmbCategoria();
            MostarTipoDoc.MostrarTipoDocumento();
            TipoDocumento.MostrarDocEnt();
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            Proveedor.MostrarProveedor();
            cliente.RellenarCmbCliente();
        }
    }
}
