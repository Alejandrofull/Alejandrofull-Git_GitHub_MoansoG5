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

namespace GIT_GITHUB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MostrarClientes(dataGridView1);
        }

        public void InsertarClientes(TextBox paramCodigo, TextBox paramNombre, TextBox paramApellido, TextBox paramDNI, TextBox paramDireccion, TextBox paramTelefono)
        {
            string consulta = "INSERT INTO Clientes (Codigo, Nombre, Apellido, Dni, Direccion, Telefono) VALUES (@Codigo, @Nombre, @Apellido, @DNI, @Direccion, @Telefono);";

            try
            {
                using (SqlConnection conexion = Conexion.GetConexion())
                {
                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Codigo", paramCodigo.Text);
                        cmd.Parameters.AddWithValue("@Nombre", paramNombre.Text);
                        cmd.Parameters.AddWithValue("@Apellido", paramApellido.Text);
                        cmd.Parameters.AddWithValue("@DNI", paramDNI.Text);
                        cmd.Parameters.AddWithValue("@Direccion", paramDireccion.Text);
                        cmd.Parameters.AddWithValue("@Telefono", paramTelefono.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("SE GUARDÓ CORRECTAMENTE");
            }
            catch (Exception e)
            {
                MessageBox.Show("NO SE PUDO GUARDAR: " + e.Message);
            }
        }




        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertarClientes(txtCodigo, txtNombre, txtApellido, txtDNI, txtDireccion, txtTelefono);
            MostrarClientes(dataGridView1);

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CargarDatosOrdenados(dataGridView1);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        public void CargarDatosOrdenados(DataGridView dgvClientes)
        {
            string sql = "SELECT * FROM Clientes ORDER BY Nombre ASC";

            using (SqlConnection conexion = Conexion.GetConexion())
            {
                if (conexion != null)
                {
                    try
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, conexion);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        dgvClientes.Rows.Clear();
                        foreach (DataRow row in dataTable.Rows)
                        {
                            dgvClientes.Rows.Add(
                                row["Codigo"].ToString(),
                                row["Nombre"].ToString(),
                                row["Apellido"].ToString(),
                                row["DNI"].ToString(),
                                row["Direccion"].ToString(),
                                row["Telefono"].ToString()
                            );
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar los datos: " + ex.Message);
                    }
                }
            }
        }

        public void MostrarClientes(DataGridView dataGridView1)
        {
           dataGridView1.Rows.Clear();
            string sql = "SELECT * FROM Clientes;";

            using (SqlConnection conexion = Conexion.GetConexion())
            {
                if (conexion != null)
                {
                    try
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, conexion);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            dataGridView1.Rows.Add(
                                row["CODIGO"].ToString(),
                                row["NOMBRE"].ToString(),
                                row["APELLIDO"].ToString(),
                                row["DNI"].ToString(),
                                row["DIRECCION"].ToString(),
                                row["TELEFONO"].ToString()
                            );
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se mostraron los registros, error: " + ex.Message);
                    }
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
