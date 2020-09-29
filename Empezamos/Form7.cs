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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        void cargartabla()
        {
            SqlDataAdapter da = new SqlDataAdapter("SV_LisEmpleado", varpublic.conexion);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            da.Dispose();
        }

        private void cmdgrabar_Click(object sender, EventArgs e)
        {
                        try
            {
                SqlDataAdapter da = new SqlDataAdapter("SV_InsEmpleado '" + txtNombres.Text.ToUpper() + "','" + txtApellidos.Text.ToUpper() + "','" + txtUsuario.Text.ToUpper() + "','" + txtClave.Text.ToUpper() + "','" + txtDireccion.Text.ToUpper() + "','" + txtTelefono.Text + "','" + txtNDoc.Text + "','" + txtSexo.Text.ToUpper() + "','" + txtTurno.Text.ToUpper() + "','" + txtFechaNac.Text + "'", varpublic.conexion);
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

        private void Form7_Load(object sender, EventArgs e)
        {
            cargartabla();
        }

        private void cmdactualizar_Click(object sender, EventArgs e)
        {
                        try
            {
                SqlDataAdapter da = new SqlDataAdapter("SV_UpEmpleado'"+ txtIdEmpleado.Text + "','" + txtNombres.Text + "','" + txtApellidos.Text + "','" + txtUsuario.Text + "','" + txtClave.Text + "','" + txtDireccion.Text + "','" + txtTelefono.Text +"','" + txtNDoc.Text +"','" + txtSexo.Text +"','" + txtIdCargo.Text + "','" + txtIdProducto.Text +"','" + txtTurno.Text +"','" + txtFechaNac.Text + "'", varpublic.conexion);
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
                txtIdEmpleado.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                txtNombres.Text  = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                txtApellidos.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                txtUsuario.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                txtClave.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
                txtDireccion.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
                txtTelefono.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value);
                           txtNDoc.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[7].Value);
                            txtSexo.Text= Convert.ToString(dataGridView1.CurrentRow.Cells[8].Value);
                            txtIdCargo.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[9].Value);
                            txtIdProducto.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[10].Value);
                            txtTurno.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[11].Value);
                            txtFechaNac.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[12].Value);
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

