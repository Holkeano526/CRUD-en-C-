using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PRACTICA_CALIFICADA_1
{
    class Conexion
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        public Conexion()
        {
            try
            {
                cn = new SqlConnection("Data Source=DESKTOP-KJPP722;Initial Catalog=PRACTICA;Integrated Security=True");
                cn.Open();
                MessageBox.Show("Conectado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conecto con la BD: " + ex.ToString());
            }
      
        }
        public string insertar(int CODIGO , string NOMBRE, string TELEFONO, string DIRECCION)
        {
            string salida = "Se inserto";
            try
            {
                cmd = new SqlCommand("Insert into TRABAJADOR(CODIGO,NOMBRE,TELEFONO,DIRECCION) VALUES(" + CODIGO + ",'" + NOMBRE + "','" + TELEFONO + "','" + DIRECCION + "')", cn);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                salida = "No se conecto: " + ex.ToString();
            }
            return salida;
        }

        public int personaRegistrada(int CODIGO)
        {
            int contador = 0;
            try
            {
                cmd = new SqlCommand("SELECT * FROM TRABAJADOR WHERE CODIGO="+CODIGO+"", cn);
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    contador++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo consultar: " + ex.ToString());
            }
            return contador;
        }

        public void Conectar()
        {
            cn = new SqlConnection("Data Source=DESKTOP-KJPP722;Initial Catalog=PRACTICA;Integrated Security=True");
            cn.Open();
        }
        public void Desconectar()
        {
            cn.Close();
        }

        public void ActualizarGrid(DataGridView dg, String Query)
        {
            this.Conectar();

            System.Data.DataSet MiDataSet = new System.Data.DataSet();
            SqlDataAdapter MiAdapter = new SqlDataAdapter(Query, cn);

            MiAdapter.Fill(MiDataSet, "TRABAJADOR");

            dg.DataSource = MiDataSet;
            dg.DataMember = "TRABAJADOR";

            this.Desconectar();
        }
    }
}
