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
    public partial class form5 : Form
    {
        public form5()
        {
            InitializeComponent();
        }
        void cargartabla()
        {
            SqlDataAdapter da = new SqlDataAdapter("SV_LisBoleta", varpublic.conexion);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            da.Dispose();
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
            txtCodigo.Select();
        }

        private void cmdgrabar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SV_InsBoleta '" + txtRazonSocial.Text.ToUpper() + "','" + txtRUC.Text + "','" + txtDescripcion.Text.ToUpper() + "','" + txtBoleta.Text + "'", varpublic.conexion);
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

        private void form5_Load(object sender, EventArgs e)
        {
            cargartabla();
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                txtCodigo.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                txtRazonSocial.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                txtRUC.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                txtDescripcion.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                txtBoleta.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
               
            }
            catch
            {

            }
        }

        private void cmdactualizar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SV_UpBoleta '" + txtCodigo.Text + "','" + txtRazonSocial.Text.ToUpper() + "','" + txtRUC.Text + "','" + txtDescripcion.Text.ToUpper() + "','" + txtBoleta.Text + "'", varpublic.conexion);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
