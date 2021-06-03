using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PRACTICA_CALIFICADA_1
{
    class TRABAJADOR
    {
        SqlConnection MiConexion;

        //conectarnos con la BD
        public void Conectar()
        {
            MiConexion = new SqlConnection("Data Source=DESKTOP-KJPP722;Initial Catalog=PRACTICA;Integrated Security=True");
            MiConexion.Open();
        }

        //cerrar bd
        public void Desconectar()
        {
            MiConexion.Close();
        }

        //visualizar la info
        public void EjecutarSQL(String Query)
        {
            SqlCommand MiComando = new SqlCommand(Query, MiConexion);
            int Filas = MiComando.ExecuteNonQuery();

            if (Filas > 0)
            {
                MessageBox.Show("Operacion exitosa");
            }
            else
            {
                MessageBox.Show("No se pudo realizar la operacion");
            }
        }
        //mostrar info de la bd
        public void ActualizarGrid(DataGridView dg, String Query)
        {
            this.Conectar();

            System.Data.DataSet MiDataSet = new System.Data.DataSet();
            SqlDataAdapter MiAdapter = new SqlDataAdapter(Query, MiConexion);

            MiAdapter.Fill(MiDataSet, "TRABAJADOR");

            dg.DataSource = MiDataSet;
            dg.DataMember = "TRABAJADOR";

            this.Desconectar();
        } 
    }
}
