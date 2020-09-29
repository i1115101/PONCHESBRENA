using Entidad.Cache;
using System;
using System.Windows.Forms;

namespace Empezamos
{
    public partial class frmBienvenida : Form
    {
        public frmBienvenida()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (this.Opacity < 1) this.Opacity += 0.05;
            bunifuCircleProgressbar1.Value += 5;
            bunifuCircleProgressbar1.Text = bunifuCircleProgressbar1.Value.ToString();
            if (bunifuCircleProgressbar1.Value == 100)
            {
                timer1.Stop();
                timer2.Start();
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity == 0)
            {
                timer2.Stop();
                this.Close();
            }
        }
        private void Bienvenida_Load(object sender, EventArgs e)
        {
            LoadUserData();
            lblUsuario.Text = varpublic.usuario.ToUpper();
            this.Opacity = 0.0;
            timer1.Start();
        }
        private void LoadUserData()
        {
            varpublic.usuario = EUserLoginCache.cUsuario;
            varpublic.cargo = EUserLoginCache.cCargo;
            varpublic.nombreEmpleado = EUserLoginCache.cNombre;
            varpublic.apellidosEmpleado = EUserLoginCache.cApellidos;
            varpublic.idEmpleado = EUserLoginCache.nIdEmpleado;
        }
    }
}
