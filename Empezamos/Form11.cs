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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        void cargartabla()
        {
            SqlDataAdapter da = new SqlDataAdapter("SV_LisVenta", varpublic.conexion);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            da.Dispose();
        }
        private void Form11_Load(object sender, EventArgs e)
        {
            cargartabla();
        }

        private void cmdgrabar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SV_InsVenta '" + txtFechEmision.Text + "','" + txtTotal.Text + "','"  + txtDescuento.Text +  "'", varpublic.conexion);
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
                SqlDataAdapter da = new SqlDataAdapter("SV_UpVenta '" + txtIdVenta.Text + "','" + txtFechEmision.Text + "','" + txtTotal.Text + "','" + txtIdEmpleado.Text + "','" + txtDescuento.Text +  "'", varpublic.conexion);
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
                txtIdVenta.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                txtFechEmision.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                txtTotal.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                txtIdEmpleado.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                txtDescuento.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
               
            }
            catch
            { }
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
