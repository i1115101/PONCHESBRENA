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
    public partial class DetalleEntrada : Form
    {
        public DetalleEntrada()
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
        void rellenarcombo()
        {
            SqlDataAdapter da = new SqlDataAdapter("SV_LisEntradas", varpublic.conexion);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbIdEntrada.DataSource = dt;
            cmbIdEntrada.DisplayMember = "Identrada";
            cmbIdEntrada.ValueMember = "Identrada";
            da.Dispose();

            SqlDataAdapter da1 = new SqlDataAdapter("SV_LisProducto", varpublic.conexion);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            cmbIdProducto.DataSource = dt1;
            cmbIdProducto.DisplayMember = "idProducto";
            cmbIdProducto.ValueMember = "idProducto";
            da1.Dispose();

        }
        private void cmdgrabar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SV_InsDetalleEntrada '"+ txtStockMinimo.Text+"','" + txtPrecioCompra.Text +"','"+txtPrecioVenta.Text + "','" + Convert.ToInt32(cmbIdEntrada.SelectedValue) + "','" + Convert.ToInt32(cmbIdProducto.SelectedValue) + "','" + dtpFechaVenci.Value.ToString("MM-dd-yyyy") + "','" + txtCantidad.Text + "'", varpublic.conexion);
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
            rellenarcombo();
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                txtStockMinimo.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                txtPrecioCompra.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                txtPrecioVenta.Text= Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                cmbIdEntrada.SelectedValue = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                cmbIdProducto.SelectedValue = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
                dtpFechaVenci.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
                txtCantidad.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value);

            }
            catch
            { }
        }

        private void cmdactualizar_Click(object sender, EventArgs e)
        {
            try
            {

                SqlDataAdapter da = new SqlDataAdapter("SV_UpDetalleEntrada '"+ txtStockMinimo.Text+"','" + Convert.ToDouble(txtPrecioCompra.Text) + "','"+txtPrecioVenta.Text+"','" + Convert.ToInt32(cmbIdEntrada.SelectedValue) + "','" + Convert.ToInt32(cmbIdProducto.SelectedValue) + "','" + dtpFechaVenci.Value.ToString("MM-dd-yyyy") + "','" + Convert.ToInt32(txtCantidad.Text) + "'", varpublic.conexion);
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
                if (ctrl is ComboBox)
                {
                    ComboBox cmb = ctrl as ComboBox;
                    cmb.SelectedIndex = -1;
                }

            }
            txtPrecioCompra.Select();
        }

        private void DetalleEntrada_Load(object sender, EventArgs e)
        {

        }

        private void cmdgrabar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
