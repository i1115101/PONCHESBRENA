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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        void cargartabla()
        {
            SqlDataAdapter da = new SqlDataAdapter("SV_LisProducto", varpublic.conexion);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            da.Dispose();
        }
        private void Form9_Load(object sender, EventArgs e)
        {
            cargartabla();
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

        private void cmdgrabar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SV_InsProducto '" + txtProducto.Text.ToUpper() + "','" + txtDescripcion.Text.ToUpper() + "','" + txtStockActual.Text + "','" + txtEstado.Text.ToUpper() + "','" + txtPrecioVenta.Text + "'", varpublic.conexion);
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

        private void cmdactualizar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SV_UpProducto '" + txtIdProducto.Text + "','" + txtProducto.Text.ToUpper() + "','" + txtDescripcion.Text.ToUpper() + "','" + txtStockActual.Text + "','" + txtEstado.Text + "','" + txtIdCategoria.Text + "','" + txtPrecioVenta.Text + "'", varpublic.conexion);
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

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                txtIdProducto.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                txtProducto.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                txtDescripcion.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                txtStockActual.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                txtEstado.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
                txtIdCategoria.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
                txtPrecioVenta.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value);
            }
            catch
            { }
        }
    }
}
