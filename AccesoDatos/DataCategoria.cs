using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace AccesoDatos
{
    public class DataCategoria
    {
        private Conexion ConexionDB = new Conexion();

        public void InsUpdCategoriaBD(string[] str)
        {
            ConexionDB.CerrarConexion();
            ConexionDB.AbrirConexion();
            string proc = "spInsUpdCategoria";

            MySqlCommand sqlC = new MySqlCommand(proc, ConexionDB.AbrirConexion());
            sqlC.CommandType = CommandType.StoredProcedure;
            sqlC.Parameters.Add("@IdCategoria", MySqlDbType.Int32).Value = Convert.ToInt32(str[0]);
            sqlC.Parameters.Add("@cNomCate", MySqlDbType.VarChar).Value = str[1];
            sqlC.ExecuteNonQuery();

            ConexionDB.CerrarConexion();

            RellenarCmbCategoria();
        }

        static DataTable tabla = new DataTable();

        public DataTable retoCate()
        {
            return tabla;
        }

        public void RellenarCmbCategoria()
        {
            MySqlDataAdapter p = new MySqlDataAdapter("spListCategoria", ConexionDB.AbrirConexion());
            DataTable dt = new DataTable();
            p.Fill(dt);
            tabla = dt;
            p.Dispose();
        }
    }
}
