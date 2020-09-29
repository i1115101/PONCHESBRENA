using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Empezamos
{
    public partial class SistemaSOFO : Form
    {
        public SistemaSOFO()
        {
            InitializeComponent();
            #region mensaje en los iconos
            this.ttmensaje.SetToolTip(this.btnslide, "Deslizar");
            this.ttmensaje.SetToolTip(this.btnCerrar, "Cerrar");
            this.ttmensaje.SetToolTip(this.btnMaximizar, "Máximizar");
            this.ttmensaje.SetToolTip(this.btnMinimizar, "Mínimizar");
            this.ttmensaje.SetToolTip(this.btnNormal, "Restaurar");
            #endregion
            customizeDesing();//ocultar panel
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        #region grip esquina inferior derecha
        private int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
      
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelContenedor.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {

            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(55, 61, 69));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }
        #endregion    

        #region abrir formulario en panel y el logo,  el usuario
          private void AbrirFormEnPanel(object formHijo)
        {
            if (this.panelFormularios.Controls.Count > 0)
                this.panelFormularios.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panelFormularios.Controls.Add(fh);
            this.panelFormularios.Tag = fh;
            fh.Show();
        }
        private void MostrarFormLogo()
        {
            //AbrirFormEnPanel(new FormLogo());
        }

        private void SistemaSOFO_Load(object sender, EventArgs e)
        {
            MostrarFormLogo();
            try
            {
                lblNombre.Text = varpublic.nombreEmpleado.ToUpper();
                lblApellidosEmpleado.Text = varpublic.apellidosEmpleado.ToUpper();
                lblCargoEmpleado.Text = varpublic.cargo.ToUpper();
            }
            catch { }
           
        }
        private void MostrarFormLogoAlCerrarForms(object sender, FormClosedEventArgs e)
        {
            MostrarFormLogo();
        }
        #endregion

        #region botones
        private void btnProducto_Click(object sender, EventArgs e)
        {
            Producto fm = new Producto();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
            //---invocamos el metodo ocultar
            hideSubMenu();
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {

            Proveedor fm = new Proveedor();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
            //---invocamos el metodo ocultar
            hideSubMenu();

        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            Empleado fm = new Empleado();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
            //---invocamos el metodo ocultar
            hideSubMenu();
        }

        private void btnDocumentos_Click(object sender, EventArgs e)
        {
            TipoDoc fm = new TipoDoc();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
            //---invocamos el metodo ocultar
            hideSubMenu();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            RegistroVentas fm = new RegistroVentas();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
            //---invocamos el metodo ocultar
            hideSubMenu();
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            RegistroEntrada fm = new RegistroEntrada();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
            //---invocamos el metodo ocultar
            hideSubMenu();
            if (MenuVertical.Width == 230)
            {
                this.tmContraerMenu.Start();
                picLogo.Visible = false;
            }

        }
        private void btnCategoria_Click(object sender, EventArgs e)
        {
            Categoria fm = new Categoria();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
            //---invocamos el metodo ocultar
            hideSubMenu();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Cliente fm = new Cliente();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
            //---invocamos el metodo ocultar
            hideSubMenu();
        }
        private void btnVentasyCompras_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuVentas);
        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuMante);
        }
        private void btnReportes_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuReportes);
        }
        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSunMenuEstadistica);
        }
        private void BoletaVentas_Click(object sender, EventArgs e)
        {
            Boleta fm = new Boleta();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
            //showSubMenu(panelSubMenuReportes);
            //---invocamos el metodo ocultar
            hideSubMenu();
        }

        private void Entradas_Click(object sender, EventArgs e)
        {
            ReporteEntrada fm = new ReporteEntrada();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
            //showSubMenu(panelSubMenuReportes);
            //---invocamos el metodo ocultar
            hideSubMenu();
        }        
        private void btnVentasGeneral_Click(object sender, EventArgs e)
        {
            frmEstadisticasVentas fm = new frmEstadisticasVentas();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
            //showSubMenu(panelSubMenuReportes);
            //---invocamos el metodo ocultar
            hideSubMenu();
        }
        #endregion

        #region LOS TIMERS Y LAS FECHAS Y EL BOTON DESLIZAR
        private void tmExpandirMenu_Tick_1(object sender, EventArgs e)
        {
            if (MenuVertical.Width >= 230)
                this.tmExpandirMenu.Stop();
            else
                MenuVertical.Width = MenuVertical.Width + 5;
        }

        private void tmContraerMenu_Tick_1(object sender, EventArgs e)
        {
            if (MenuVertical.Width <= 55)
                this.tmContraerMenu.Stop();
            else
                MenuVertical.Width = MenuVertical.Width - 5;
        }

        private void btnslide_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 230)
            {
             this.tmContraerMenu.Start();
                picLogo.Visible = false;
             
            }
            else if (MenuVertical.Width == 55)
            {
             this.tmExpandirMenu.Start();
                picLogo.Visible = true;
            }
        }

        private void tmFechaHora_Tick_1(object sender, EventArgs e)
        {
            lbFecha.Text = DateTime.Now.ToLongDateString();
            lblHora.Text = DateTime.Now.ToString("HH:mm:ssss");
        }

        #endregion
            
        #region Metodos Sub Menús
        private void customizeDesing()
        {
            panelSubMenuMante.Visible = false;
            panelSubMenuVentas.Visible = false;
            panelSubMenuReportes.Visible = false;
            panelSunMenuEstadistica.Visible = false;
        }
        
        private void hideSubMenu()
        {
            if (panelSubMenuMante.Visible==true)
            {
                panelSubMenuMante.Visible = false;
            }
            if (panelSubMenuVentas.Visible == true)
            {
                panelSubMenuVentas.Visible = false;
            }
            if (panelSubMenuReportes.Visible == true)
            {
                panelSubMenuReportes.Visible = false;
            }
            if (panelSunMenuEstadistica.Visible == true)
            {
                panelSunMenuEstadistica.Visible = false;
            }
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        #endregion

        #region restaurar maximizar minimizar cerrar y movimiento de la barra título
        int lx, ly;
        int sw, sh;
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cerrar?", "Alerta¡¡", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
           btnMaximizar.Visible = false;
           btnNormal.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            
        }
        private void btnNormal_Click(object sender, EventArgs e)
        {
           btnMaximizar.Visible = true;
           btnNormal.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }

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

        #region notificaciones


        protected override void OnClientSizeChanged(EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                TamañoCambiado(e);
            }
            base.OnClientSizeChanged(e);
        }
        protected void TamañoCambiado(EventArgs e)
        {
            notificacion.ShowBalloonTip(0);
        }      

        private void notificacion_BalloonTipClicked(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           WindowState = FormWindowState.Normal;
        }
        private void MaximizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        #endregion
    }
}
