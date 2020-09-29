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

namespace Empezamos
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
                void cargartabla()
        {
            SqlDataAdapter da = new SqlDataAdapter("SV_LisDetalleEntrada", varpublic.conexion);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            da.Dispose();
        }
        private void cmdgrabar_Click(object sender, EventArgs e)
        {
                        try
            {
                SqlDataAdapter da = new SqlDataAdapter("SV_InsDetalleEntrada '" + txtPrecioCompra.Text + "','" + txtFechVenc.Text + "','" + txtCantidad.Text +  "'", varpublic.conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                cargartabla();
                MessageBox.Show("Registro insertado exitosamente");

            }
            catch 
            {
                MessageBox.Show("Error, no se inserto registro");
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
        cargartabla();
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                txtPrecioCompra.Text= Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
               txtIdEntrada.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                txtIdProducto.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                txtFechVenc.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                txtCantidad.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
              
            }
            catch
            { }
        }

        private void cmdactualizar_Click(object sender, EventArgs e)
        {
            try
            {
                
                SqlDataAdapter da = new SqlDataAdapter("SV_UpDetalleEntrada '" + txtPrecioCompra.Text + "','" + txtIdEntrada.Text + "','" + txtIdProducto.Text + "','" + txtFechVenc.Text + "','" + txtCantidad.Text + "'", varpublic.conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                cargartabla();
                MessageBox.Show("Registro actualizado exitosamente");
            }
            catch
            {
                MessageBox.Show("Error, no se actualizó registro");
            }
        }

        private void cmdnuevo_Click(object sender, EventArgs e)
        {
                        foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox text = ctrl as TextBox;
                    text.Clear();
                    
                }

            }
            
        }
        }
        }
    


