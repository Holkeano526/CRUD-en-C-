using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PRACTICA_CALIFICADA_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TRABAJADOR DatosTrabajador = new TRABAJADOR();

            DatosTrabajador.ActualizarGrid(this.dgvTrabajadores, "SELECT * FROM TRABAJADOR");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-KJPP722;Initial Catalog=PRACTICA;Integrated Security=True");
            conexion.Open();
            string Nombre = txtNombre.Text;
            string Direccion = txtDireccion.Text;
            string Telefono = txtTelefono.Text;
            string cadena = "INSERT INTO TRABAJADOR(NOMBRE,TELEFONO,DIRECCION) VALUES('"+Nombre+"','"+Telefono+"','"+Direccion+"')";

            SqlCommand comando = new SqlCommand(cadena, conexion);

            comando.ExecuteNonQuery();

            MessageBox.Show("Los datos de guardaron correctamente");
            txtDireccion.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            TRABAJADOR DatosTrabajador = new TRABAJADOR();

            DatosTrabajador.ActualizarGrid(this.dgvTrabajadores, "SELECT * FROM TRABAJADOR");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //DELETE FROM TRABAJADOR WHERE NOMBRE = '' 
            SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-KJPP722;Initial Catalog=PRACTICA;Integrated Security=True");
            conexion.Open();
            int flag = 0;
            string cadena ="DELETE FROM TRABAJADOR WHERE NOMBRE ='"+txtNombre.Text+"'";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            flag = comando.ExecuteNonQuery();//positivo 1 | negativo = 0

            if(flag == 1)
            {
                MessageBox.Show("Se elimino correctamente");
            }
            else
            {
                MessageBox.Show("Error al intentar eliminar");
            }
            conexion.Close();
        }
    }
}
