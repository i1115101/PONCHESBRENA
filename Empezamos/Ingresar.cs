using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using LogicaNegocio;
using Microsoft.Reporting.WinForms;
using Entidad.Cache;

namespace Empezamos
{
    public partial class Ingresar : Form
    {
        string Encriptado;
        int bloqueo = 1;
        public Ingresar()
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
        void AbrirFormulario()
        {
            string cadena;
            cadena = txtContrasena.Text;

            SHA1CryptoServiceProvider contraseña = new SHA1CryptoServiceProvider();
            byte[] vertorBytes = System.Text.Encoding.UTF8.GetBytes(cadena);
            byte[] salida = contraseña.ComputeHash(vertorBytes);
            contraseña.Clear();
            Encriptado = Convert.ToBase64String(salida);

            //--------------------------

            if (validarIngreso())
            {             
                LogicaUsuario usuario = new LogicaUsuario();
                var validLogin = usuario.LoginUser(txtUsuario.Text, Encriptado);
                if (validLogin == true)
                {
                    this.Hide();
                    //----------------
                    Bienvenida splop = new Bienvenida();
                    splop.ShowDialog();

                    SistemaSOFO f = new SistemaSOFO();
                    f.Show();                   
                }
                else
                {
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
        }
        private void btnAcceder_Click(object sender, EventArgs e)
        {            
            AbrirFormulario();
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

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtUsuario, string.Empty);
        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtContrasena, string.Empty);
        }

        #endregion
        private void txtContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AbrirFormulario();
            }
        }

    }
}
