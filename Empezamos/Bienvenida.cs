using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad.Cache;
//using System.Threading;

namespace Empezamos
{
    public partial class Bienvenida : Form
    {
        public Bienvenida()
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
            if (this.Opacity==0)
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
            varpublic.usuario = UserLoginCache.Usuario;
            varpublic.cargo = UserLoginCache.Cargo;
            varpublic.nombreEmpleado = UserLoginCache.NombreEmpleado;
            varpublic.apellidosEmpleado = UserLoginCache.ApellidosEmpleado;
            varpublic.idEmpleado = UserLoginCache.IdEmpleado;
        }
    }
}
