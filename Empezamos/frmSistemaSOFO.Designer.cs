namespace Empezamos
{
    partial class SistemaSOFO
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SistemaSOFO));
            this.tmContraerMenu = new System.Windows.Forms.Timer(this.components);
            this.tmExpandirMenu = new System.Windows.Forms.Timer(this.components);
            this.tmFechaHora = new System.Windows.Forms.Timer(this.components);
            this.ttmensaje = new System.Windows.Forms.ToolTip(this.components);
            this.Entradas = new System.Windows.Forms.Button();
            this.BoletaVentas = new System.Windows.Forms.Button();
            this.btnEntrada = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnVentasyCompras = new System.Windows.Forms.Button();
            this.btnDocumentos = new System.Windows.Forms.Button();
            this.btnEmpleado = new System.Windows.Forms.Button();
            this.btnProducto = new System.Windows.Forms.Button();
            this.btnCategoria = new System.Windows.Forms.Button();
            this.btnMantenimiento = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnVentasGeneral = new System.Windows.Forms.Button();
            this.notificacion = new System.Windows.Forms.NotifyIcon(this.components);
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MaximizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.btnNormal = new System.Windows.Forms.Button();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnMaximizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MenuVertical = new System.Windows.Forms.Panel();
            this.panelSubMenuReportes = new System.Windows.Forms.Panel();
            this.panelReportes = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panelSubMenuVentas = new System.Windows.Forms.Panel();
            this.panelVentayCompra = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panelSubMenuMante = new System.Windows.Forms.Panel();
            this.panelMantenimiento = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnslide = new System.Windows.Forms.PictureBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.picVaso = new System.Windows.Forms.PictureBox();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panelFormularios = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCargoEmpleado = new System.Windows.Forms.Label();
            this.lblApellidosEmpleado = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lbFecha = new System.Windows.Forms.Label();
            this.picLogo2 = new System.Windows.Forms.PictureBox();
            this.lblHora = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.BarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.MenuVertical.SuspendLayout();
            this.panelSubMenuReportes.SuspendLayout();
            this.panelReportes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panelSubMenuVentas.SuspendLayout();
            this.panelVentayCompra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panelSubMenuMante.SuspendLayout();
            this.panelMantenimiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnslide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVaso)).BeginInit();
            this.panelContenedor.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo2)).BeginInit();
            this.SuspendLayout();
            // 
            // tmContraerMenu
            // 
            this.tmContraerMenu.Interval = 15;
            this.tmContraerMenu.Tick += new System.EventHandler(this.tmContraerMenu_Tick_1);
            // 
            // tmExpandirMenu
            // 
            this.tmExpandirMenu.Interval = 15;
            this.tmExpandirMenu.Tick += new System.EventHandler(this.tmExpandirMenu_Tick_1);
            // 
            // tmFechaHora
            // 
            this.tmFechaHora.Enabled = true;
            this.tmFechaHora.Tick += new System.EventHandler(this.tmFechaHora_Tick_1);
            // 
            // ttmensaje
            // 
            this.ttmensaje.AutoPopDelay = 5000;
            this.ttmensaje.BackColor = System.Drawing.Color.Yellow;
            this.ttmensaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ttmensaje.InitialDelay = 1;
            this.ttmensaje.ReshowDelay = 100;
            // 
            // Entradas
            // 
            this.Entradas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.Entradas.FlatAppearance.BorderSize = 0;
            this.Entradas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.Entradas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Entradas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Entradas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Entradas.ForeColor = System.Drawing.Color.Silver;
            this.Entradas.Image = ((System.Drawing.Image)(resources.GetObject("Entradas.Image")));
            this.Entradas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Entradas.Location = new System.Drawing.Point(0, 42);
            this.Entradas.Name = "Entradas";
            this.Entradas.Size = new System.Drawing.Size(230, 40);
            this.Entradas.TabIndex = 28;
            this.Entradas.Text = "&Almacén";
            this.ttmensaje.SetToolTip(this.Entradas, "Informe Almacén");
            this.Entradas.UseVisualStyleBackColor = false;
            this.Entradas.Click += new System.EventHandler(this.Entradas_Click);
            // 
            // BoletaVentas
            // 
            this.BoletaVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.BoletaVentas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BoletaVentas.FlatAppearance.BorderSize = 0;
            this.BoletaVentas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.BoletaVentas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BoletaVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BoletaVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoletaVentas.ForeColor = System.Drawing.Color.Silver;
            this.BoletaVentas.Image = ((System.Drawing.Image)(resources.GetObject("BoletaVentas.Image")));
            this.BoletaVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BoletaVentas.Location = new System.Drawing.Point(0, 1);
            this.BoletaVentas.Name = "BoletaVentas";
            this.BoletaVentas.Size = new System.Drawing.Size(230, 40);
            this.BoletaVentas.TabIndex = 26;
            this.BoletaVentas.Text = "     &Ventas en General";
            this.ttmensaje.SetToolTip(this.BoletaVentas, "Informe Ventas");
            this.BoletaVentas.UseVisualStyleBackColor = false;
            this.BoletaVentas.Click += new System.EventHandler(this.BoletaVentas_Click);
            // 
            // btnEntrada
            // 
            this.btnEntrada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnEntrada.FlatAppearance.BorderSize = 0;
            this.btnEntrada.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnEntrada.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrada.ForeColor = System.Drawing.Color.Silver;
            this.btnEntrada.Image = ((System.Drawing.Image)(resources.GetObject("btnEntrada.Image")));
            this.btnEntrada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntrada.Location = new System.Drawing.Point(0, 42);
            this.btnEntrada.Name = "btnEntrada";
            this.btnEntrada.Size = new System.Drawing.Size(230, 40);
            this.btnEntrada.TabIndex = 24;
            this.btnEntrada.Text = "E&ntradas";
            this.ttmensaje.SetToolTip(this.btnEntrada, "Registro Entradas");
            this.btnEntrada.UseVisualStyleBackColor = false;
            this.btnEntrada.Click += new System.EventHandler(this.btnEntrada_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnVentas.FlatAppearance.BorderSize = 0;
            this.btnVentas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnVentas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.ForeColor = System.Drawing.Color.Silver;
            this.btnVentas.Image = ((System.Drawing.Image)(resources.GetObject("btnVentas.Image")));
            this.btnVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.Location = new System.Drawing.Point(0, 1);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(230, 40);
            this.btnVentas.TabIndex = 22;
            this.btnVentas.Text = "&Ventas";
            this.ttmensaje.SetToolTip(this.btnVentas, "Registro Ventas");
            this.btnVentas.UseVisualStyleBackColor = false;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnVentasyCompras
            // 
            this.btnVentasyCompras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVentasyCompras.FlatAppearance.BorderSize = 0;
            this.btnVentasyCompras.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnVentasyCompras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnVentasyCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentasyCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentasyCompras.ForeColor = System.Drawing.Color.Silver;
            this.btnVentasyCompras.Image = ((System.Drawing.Image)(resources.GetObject("btnVentasyCompras.Image")));
            this.btnVentasyCompras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentasyCompras.Location = new System.Drawing.Point(2, 0);
            this.btnVentasyCompras.Name = "btnVentasyCompras";
            this.btnVentasyCompras.Size = new System.Drawing.Size(230, 40);
            this.btnVentasyCompras.TabIndex = 22;
            this.btnVentasyCompras.Text = "     Ventas &Y Compras";
            this.ttmensaje.SetToolTip(this.btnVentasyCompras, "Ventas y Compras");
            this.btnVentasyCompras.UseVisualStyleBackColor = true;
            this.btnVentasyCompras.Click += new System.EventHandler(this.btnVentasyCompras_Click);
            // 
            // btnDocumentos
            // 
            this.btnDocumentos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnDocumentos.FlatAppearance.BorderSize = 0;
            this.btnDocumentos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnDocumentos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnDocumentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDocumentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocumentos.ForeColor = System.Drawing.Color.Silver;
            this.btnDocumentos.Image = ((System.Drawing.Image)(resources.GetObject("btnDocumentos.Image")));
            this.btnDocumentos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDocumentos.Location = new System.Drawing.Point(0, 1);
            this.btnDocumentos.Name = "btnDocumentos";
            this.btnDocumentos.Size = new System.Drawing.Size(230, 40);
            this.btnDocumentos.TabIndex = 25;
            this.btnDocumentos.Text = "&Documentos";
            this.ttmensaje.SetToolTip(this.btnDocumentos, "Documentos");
            this.btnDocumentos.UseVisualStyleBackColor = false;
            this.btnDocumentos.Click += new System.EventHandler(this.btnDocumentos_Click);
            // 
            // btnEmpleado
            // 
            this.btnEmpleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnEmpleado.FlatAppearance.BorderSize = 0;
            this.btnEmpleado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnEmpleado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmpleado.ForeColor = System.Drawing.Color.Silver;
            this.btnEmpleado.Image = ((System.Drawing.Image)(resources.GetObject("btnEmpleado.Image")));
            this.btnEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmpleado.Location = new System.Drawing.Point(0, 124);
            this.btnEmpleado.Name = "btnEmpleado";
            this.btnEmpleado.Size = new System.Drawing.Size(230, 40);
            this.btnEmpleado.TabIndex = 21;
            this.btnEmpleado.Text = "&Empleados";
            this.ttmensaje.SetToolTip(this.btnEmpleado, "Empleados");
            this.btnEmpleado.UseVisualStyleBackColor = false;
            this.btnEmpleado.Click += new System.EventHandler(this.btnEmpleado_Click);
            // 
            // btnProducto
            // 
            this.btnProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnProducto.FlatAppearance.BorderSize = 0;
            this.btnProducto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProducto.ForeColor = System.Drawing.Color.Silver;
            this.btnProducto.Image = ((System.Drawing.Image)(resources.GetObject("btnProducto.Image")));
            this.btnProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProducto.Location = new System.Drawing.Point(0, 83);
            this.btnProducto.Name = "btnProducto";
            this.btnProducto.Size = new System.Drawing.Size(230, 40);
            this.btnProducto.TabIndex = 5;
            this.btnProducto.Text = "&Productos";
            this.ttmensaje.SetToolTip(this.btnProducto, "Productos");
            this.btnProducto.UseVisualStyleBackColor = false;
            this.btnProducto.Click += new System.EventHandler(this.btnProducto_Click);
            // 
            // btnCategoria
            // 
            this.btnCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnCategoria.FlatAppearance.BorderSize = 0;
            this.btnCategoria.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnCategoria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategoria.ForeColor = System.Drawing.Color.Silver;
            this.btnCategoria.Image = ((System.Drawing.Image)(resources.GetObject("btnCategoria.Image")));
            this.btnCategoria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategoria.Location = new System.Drawing.Point(0, 42);
            this.btnCategoria.Name = "btnCategoria";
            this.btnCategoria.Size = new System.Drawing.Size(230, 40);
            this.btnCategoria.TabIndex = 20;
            this.btnCategoria.Text = "&Categorías";
            this.ttmensaje.SetToolTip(this.btnCategoria, "Categorías");
            this.btnCategoria.UseVisualStyleBackColor = false;
            this.btnCategoria.Click += new System.EventHandler(this.btnCategoria_Click);
            // 
            // btnMantenimiento
            // 
            this.btnMantenimiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMantenimiento.FlatAppearance.BorderSize = 0;
            this.btnMantenimiento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnMantenimiento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnMantenimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMantenimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMantenimiento.ForeColor = System.Drawing.Color.Silver;
            this.btnMantenimiento.Image = ((System.Drawing.Image)(resources.GetObject("btnMantenimiento.Image")));
            this.btnMantenimiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMantenimiento.Location = new System.Drawing.Point(2, 0);
            this.btnMantenimiento.Name = "btnMantenimiento";
            this.btnMantenimiento.Size = new System.Drawing.Size(230, 40);
            this.btnMantenimiento.TabIndex = 0;
            this.btnMantenimiento.Text = "&Mantenimiento";
            this.ttmensaje.SetToolTip(this.btnMantenimiento, "Mantenimiento");
            this.btnMantenimiento.UseVisualStyleBackColor = true;
            this.btnMantenimiento.Click += new System.EventHandler(this.btnMantenimiento_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnReportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.Color.Silver;
            this.btnReportes.Image = ((System.Drawing.Image)(resources.GetObject("btnReportes.Image")));
            this.btnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.Location = new System.Drawing.Point(2, 0);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(230, 40);
            this.btnReportes.TabIndex = 26;
            this.btnReportes.Text = "&Informes";
            this.ttmensaje.SetToolTip(this.btnReportes, "Informes");
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnVentasGeneral
            // 
            this.btnVentasGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnVentasGeneral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnVentasGeneral.FlatAppearance.BorderSize = 0;
            this.btnVentasGeneral.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnVentasGeneral.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnVentasGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentasGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentasGeneral.ForeColor = System.Drawing.Color.Silver;
            this.btnVentasGeneral.Image = ((System.Drawing.Image)(resources.GetObject("btnVentasGeneral.Image")));
            this.btnVentasGeneral.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentasGeneral.Location = new System.Drawing.Point(0, 83);
            this.btnVentasGeneral.Name = "btnVentasGeneral";
            this.btnVentasGeneral.Size = new System.Drawing.Size(230, 45);
            this.btnVentasGeneral.TabIndex = 27;
            this.btnVentasGeneral.Text = "    &Busqueda Productos";
            this.ttmensaje.SetToolTip(this.btnVentasGeneral, "Busqueda de productos");
            this.btnVentasGeneral.UseVisualStyleBackColor = false;
            this.btnVentasGeneral.Click += new System.EventHandler(this.btnVentasGeneral_Click);
            // 
            // notificacion
            // 
            this.notificacion.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notificacion.BalloonTipText = "Haz un click sobre este aviso para mostrarlo.";
            this.notificacion.BalloonTipTitle = "El programa está minimizado";
            this.notificacion.ContextMenuStrip = this.menu;
            this.notificacion.Icon = ((System.Drawing.Icon)(resources.GetObject("notificacion.Icon")));
            this.notificacion.Text = "SOFO System";
            this.notificacion.Visible = true;
            this.notificacion.BalloonTipClicked += new System.EventHandler(this.notificacion_BalloonTipClicked);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem,
            this.mostrarToolStripMenuItem,
            this.MaximizarToolStripMenuItem});
            this.menu.Name = "menu";
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menu.ShowImageMargin = false;
            this.menu.Size = new System.Drawing.Size(104, 70);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // mostrarToolStripMenuItem
            // 
            this.mostrarToolStripMenuItem.Name = "mostrarToolStripMenuItem";
            this.mostrarToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.mostrarToolStripMenuItem.Text = "Mostrar";
            this.mostrarToolStripMenuItem.Click += new System.EventHandler(this.mostrarToolStripMenuItem_Click);
            // 
            // MaximizarToolStripMenuItem
            // 
            this.MaximizarToolStripMenuItem.Name = "MaximizarToolStripMenuItem";
            this.MaximizarToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.MaximizarToolStripMenuItem.Text = "Maximizar";
            this.MaximizarToolStripMenuItem.Click += new System.EventHandler(this.MaximizarToolStripMenuItem_Click);
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(94)))), ((int)(((byte)(3)))));
            this.BarraTitulo.Controls.Add(this.btnNormal);
            this.BarraTitulo.Controls.Add(this.btnMinimizar);
            this.BarraTitulo.Controls.Add(this.btnMaximizar);
            this.BarraTitulo.Controls.Add(this.btnCerrar);
            this.BarraTitulo.Controls.Add(this.label1);
            this.BarraTitulo.Controls.Add(this.pictureBox1);
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(1284, 43);
            this.BarraTitulo.TabIndex = 5;
            this.BarraTitulo.Paint += new System.Windows.Forms.PaintEventHandler(this.BarraTitulo_Paint);
            this.BarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarraTitulo_MouseDown);
            // 
            // btnNormal
            // 
            this.btnNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNormal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNormal.FlatAppearance.BorderSize = 0;
            this.btnNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNormal.Image = ((System.Drawing.Image)(resources.GetObject("btnNormal.Image")));
            this.btnNormal.Location = new System.Drawing.Point(1195, 0);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(43, 43);
            this.btnNormal.TabIndex = 7;
            this.btnNormal.UseVisualStyleBackColor = true;
            this.btnNormal.Visible = false;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(1148, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(43, 43);
            this.btnMinimizar.TabIndex = 6;
            this.btnMinimizar.UseVisualStyleBackColor = true;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximizar.FlatAppearance.BorderSize = 0;
            this.btnMaximizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximizar.Image")));
            this.btnMaximizar.Location = new System.Drawing.Point(1195, 0);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(43, 43);
            this.btnMaximizar.TabIndex = 5;
            this.btnMaximizar.UseVisualStyleBackColor = true;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(1242, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(39, 39);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(57, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "SOFO SYSTEM";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MenuVertical
            // 
            this.MenuVertical.AutoScroll = true;
            this.MenuVertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.MenuVertical.Controls.Add(this.panelSubMenuReportes);
            this.MenuVertical.Controls.Add(this.panelReportes);
            this.MenuVertical.Controls.Add(this.panelSubMenuVentas);
            this.MenuVertical.Controls.Add(this.panelVentayCompra);
            this.MenuVertical.Controls.Add(this.panelSubMenuMante);
            this.MenuVertical.Controls.Add(this.panelMantenimiento);
            this.MenuVertical.Controls.Add(this.panel2);
            this.MenuVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuVertical.Location = new System.Drawing.Point(0, 43);
            this.MenuVertical.Name = "MenuVertical";
            this.MenuVertical.Size = new System.Drawing.Size(230, 618);
            this.MenuVertical.TabIndex = 6;
            // 
            // panelSubMenuReportes
            // 
            this.panelSubMenuReportes.Controls.Add(this.btnVentasGeneral);
            this.panelSubMenuReportes.Controls.Add(this.Entradas);
            this.panelSubMenuReportes.Controls.Add(this.BoletaVentas);
            this.panelSubMenuReportes.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubMenuReportes.Location = new System.Drawing.Point(0, 517);
            this.panelSubMenuReportes.Name = "panelSubMenuReportes";
            this.panelSubMenuReportes.Size = new System.Drawing.Size(213, 153);
            this.panelSubMenuReportes.TabIndex = 27;
            // 
            // panelReportes
            // 
            this.panelReportes.Controls.Add(this.pictureBox3);
            this.panelReportes.Controls.Add(this.btnReportes);
            this.panelReportes.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelReportes.Location = new System.Drawing.Point(0, 477);
            this.panelReportes.Name = "panelReportes";
            this.panelReportes.Size = new System.Drawing.Size(213, 40);
            this.panelReportes.TabIndex = 27;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Red;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(2, 40);
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // panelSubMenuVentas
            // 
            this.panelSubMenuVentas.Controls.Add(this.btnEntrada);
            this.panelSubMenuVentas.Controls.Add(this.btnVentas);
            this.panelSubMenuVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubMenuVentas.Location = new System.Drawing.Point(0, 395);
            this.panelSubMenuVentas.Name = "panelSubMenuVentas";
            this.panelSubMenuVentas.Size = new System.Drawing.Size(213, 82);
            this.panelSubMenuVentas.TabIndex = 27;
            // 
            // panelVentayCompra
            // 
            this.panelVentayCompra.Controls.Add(this.pictureBox4);
            this.panelVentayCompra.Controls.Add(this.btnVentasyCompras);
            this.panelVentayCompra.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelVentayCompra.Location = new System.Drawing.Point(0, 355);
            this.panelVentayCompra.Name = "panelVentayCompra";
            this.panelVentayCompra.Size = new System.Drawing.Size(213, 40);
            this.panelVentayCompra.TabIndex = 27;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Red;
            this.pictureBox4.Location = new System.Drawing.Point(0, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(2, 40);
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            // 
            // panelSubMenuMante
            // 
            this.panelSubMenuMante.Controls.Add(this.btnDocumentos);
            this.panelSubMenuMante.Controls.Add(this.btnEmpleado);
            this.panelSubMenuMante.Controls.Add(this.btnProducto);
            this.panelSubMenuMante.Controls.Add(this.btnCategoria);
            this.panelSubMenuMante.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubMenuMante.Location = new System.Drawing.Point(0, 192);
            this.panelSubMenuMante.Name = "panelSubMenuMante";
            this.panelSubMenuMante.Size = new System.Drawing.Size(213, 163);
            this.panelSubMenuMante.TabIndex = 26;
            // 
            // panelMantenimiento
            // 
            this.panelMantenimiento.Controls.Add(this.pictureBox2);
            this.panelMantenimiento.Controls.Add(this.btnMantenimiento);
            this.panelMantenimiento.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMantenimiento.Location = new System.Drawing.Point(0, 152);
            this.panelMantenimiento.Name = "panelMantenimiento";
            this.panelMantenimiento.Size = new System.Drawing.Size(213, 40);
            this.panelMantenimiento.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(2, 40);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnslide);
            this.panel2.Controls.Add(this.picLogo);
            this.panel2.Controls.Add(this.picVaso);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(213, 152);
            this.panel2.TabIndex = 27;
            // 
            // btnslide
            // 
            this.btnslide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnslide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnslide.Image = ((System.Drawing.Image)(resources.GetObject("btnslide.Image")));
            this.btnslide.Location = new System.Drawing.Point(175, 3);
            this.btnslide.Name = "btnslide";
            this.btnslide.Size = new System.Drawing.Size(35, 35);
            this.btnslide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnslide.TabIndex = 0;
            this.btnslide.TabStop = false;
            this.btnslide.Click += new System.EventHandler(this.btnslide_Click);
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(3, 3);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(207, 146);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // picVaso
            // 
            this.picVaso.Image = ((System.Drawing.Image)(resources.GetObject("picVaso.Image")));
            this.picVaso.Location = new System.Drawing.Point(2, 33);
            this.picVaso.Name = "picVaso";
            this.picVaso.Size = new System.Drawing.Size(55, 113);
            this.picVaso.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picVaso.TabIndex = 0;
            this.picVaso.TabStop = false;
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelContenedor.Controls.Add(this.panelFormularios);
            this.panelContenedor.Controls.Add(this.panel1);
            this.panelContenedor.Controls.Add(this.MenuVertical);
            this.panelContenedor.Controls.Add(this.BarraTitulo);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1284, 661);
            this.panelContenedor.TabIndex = 0;
            // 
            // panelFormularios
            // 
            this.panelFormularios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelFormularios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormularios.Location = new System.Drawing.Point(230, 43);
            this.panelFormularios.Name = "panelFormularios";
            this.panelFormularios.Size = new System.Drawing.Size(1054, 518);
            this.panelFormularios.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(69)))));
            this.panel1.Controls.Add(this.lblCargoEmpleado);
            this.panel1.Controls.Add(this.lblApellidosEmpleado);
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Controls.Add(this.lbFecha);
            this.panel1.Controls.Add(this.picLogo2);
            this.panel1.Controls.Add(this.lblHora);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(230, 561);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1054, 100);
            this.panel1.TabIndex = 8;
            // 
            // lblCargoEmpleado
            // 
            this.lblCargoEmpleado.AutoSize = true;
            this.lblCargoEmpleado.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargoEmpleado.ForeColor = System.Drawing.Color.LightGray;
            this.lblCargoEmpleado.Location = new System.Drawing.Point(133, 59);
            this.lblCargoEmpleado.Name = "lblCargoEmpleado";
            this.lblCargoEmpleado.Size = new System.Drawing.Size(54, 20);
            this.lblCargoEmpleado.TabIndex = 7;
            this.lblCargoEmpleado.Text = "Cargo";
            // 
            // lblApellidosEmpleado
            // 
            this.lblApellidosEmpleado.AutoSize = true;
            this.lblApellidosEmpleado.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellidosEmpleado.ForeColor = System.Drawing.Color.LightGray;
            this.lblApellidosEmpleado.Location = new System.Drawing.Point(133, 36);
            this.lblApellidosEmpleado.Name = "lblApellidosEmpleado";
            this.lblApellidosEmpleado.Size = new System.Drawing.Size(116, 20);
            this.lblApellidosEmpleado.TabIndex = 6;
            this.lblApellidosEmpleado.Text = "Apellidos User";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.LightGray;
            this.lblNombre.Location = new System.Drawing.Point(133, 13);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(79, 20);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombres ";
            // 
            // lbFecha
            // 
            this.lbFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFecha.AutoSize = true;
            this.lbFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbFecha.ForeColor = System.Drawing.Color.White;
            this.lbFecha.Location = new System.Drawing.Point(731, 67);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(224, 20);
            this.lbFecha.TabIndex = 4;
            this.lbFecha.Text = "Lunes, 26 de septiembre 2018";
            // 
            // picLogo2
            // 
            this.picLogo2.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLogo2.Image = ((System.Drawing.Image)(resources.GetObject("picLogo2.Image")));
            this.picLogo2.Location = new System.Drawing.Point(0, 0);
            this.picLogo2.Name = "picLogo2";
            this.picLogo2.Size = new System.Drawing.Size(127, 100);
            this.picLogo2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo2.TabIndex = 3;
            this.picLogo2.TabStop = false;
            // 
            // lblHora
            // 
            this.lblHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.Color.LightGray;
            this.lblHora.Location = new System.Drawing.Point(735, 14);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(205, 54);
            this.lblHora.TabIndex = 1;
            this.lblHora.Text = "21:49:45";
            // 
            // SistemaSOFO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.panelContenedor);
            this.MinimumSize = new System.Drawing.Size(650, 400);
            this.Name = "SistemaSOFO";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SistemaSOFO";
            this.Load += new System.EventHandler(this.SistemaSOFO_Load);
            this.menu.ResumeLayout(false);
            this.BarraTitulo.ResumeLayout(false);
            this.BarraTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.MenuVertical.ResumeLayout(false);
            this.panelSubMenuReportes.ResumeLayout(false);
            this.panelReportes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panelSubMenuVentas.ResumeLayout(false);
            this.panelVentayCompra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panelSubMenuMante.ResumeLayout(false);
            this.panelMantenimiento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnslide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVaso)).EndInit();
            this.panelContenedor.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmContraerMenu;
        private System.Windows.Forms.Timer tmExpandirMenu;
        private System.Windows.Forms.Timer tmFechaHora;
        private System.Windows.Forms.ToolTip ttmensaje;
        private System.Windows.Forms.NotifyIcon notificacion;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MaximizarToolStripMenuItem;
        private System.Windows.Forms.Panel BarraTitulo;
        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnMaximizar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel MenuVertical;
        private System.Windows.Forms.Button Entradas;
        private System.Windows.Forms.Button BoletaVentas;
        private System.Windows.Forms.Panel panelSubMenuVentas;
        private System.Windows.Forms.Button btnEntrada;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Panel panelVentayCompra;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btnVentasyCompras;
        private System.Windows.Forms.Panel panelSubMenuMante;
        private System.Windows.Forms.Button btnDocumentos;
        private System.Windows.Forms.Button btnEmpleado;
        private System.Windows.Forms.Button btnProducto;
        private System.Windows.Forms.Button btnCategoria;
        private System.Windows.Forms.Panel panelMantenimiento;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnMantenimiento;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox btnslide;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Panel panelFormularios;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCargoEmpleado;
        private System.Windows.Forms.Label lblApellidosEmpleado;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lbFecha;
        private System.Windows.Forms.PictureBox picLogo2;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.PictureBox picVaso;
        private System.Windows.Forms.Panel panelSubMenuReportes;
        private System.Windows.Forms.Panel panelReportes;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnVentasGeneral;
    }
}