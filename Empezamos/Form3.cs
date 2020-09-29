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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        void cargartabla()
        {
            SqlDataAdapter da = new SqlDataAdapter("SV_LisCargo", varpublic.conexion);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            da.Dispose();
        }
        private void Form3_Load(object sender, EventArgs e)
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
            txtcodigo.Select();
        }

        private void cmdgrabar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SV_InsCargo '" + txtcargo.Text.ToUpper() + "'", varpublic.conexion);
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
                SqlDataAdapter da = new SqlDataAdapter("SV_UpCargo'" + txtcodigo.Text + "','" + txtcargo.Text.ToUpper() + "'", varpublic.conexion);
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
                txtcodigo.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                txtcargo.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
             

            }
            catch
            { }
        }
    }
}
