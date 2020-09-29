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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        void cargartabla()
        {
            SqlDataAdapter da = new SqlDataAdapter("SV_LisEntradas", varpublic.conexion);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            da.Dispose();
        }
        private void Form8_Load(object sender, EventArgs e)
        {
            cargartabla();

        }


        private void dataGridView1_CurrentCellChanged_1(object sender, EventArgs e)
        {
            try
            {
                txtIdEntrada.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                txtTipoDocEntrada.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                txtNumDoc.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                txtFechEntrada.Text= Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                txtIdProveedor.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
                
            }
            catch
            { }
        }

        private void cmdgrabar_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SV_InsEntradas '" + txtTipoDocEntrada.Text.ToUpper() + "','" + txtNumDoc.Text + "','" + txtFechEntrada.Text + "'", varpublic.conexion);
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
                SqlDataAdapter da = new SqlDataAdapter("SV_UpEntradas '" + txtIdEntrada.Text + "','" + txtTipoDocEntrada.Text.ToUpper() + "','" + txtNumDoc.Text + "','" + txtFechEntrada.Text + "','" + txtIdProveedor.Text + "'", varpublic.conexion);
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

        private void cmdnuevo_Click_1(object sender, EventArgs e)
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
