//using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System;
using System.Data;
namespace AccesoDatos
{
    public class DataEntrada
    {
        private Conexion ConexionDB = new Conexion();

        public string InsertarEntradaBD(string[] str)
        {
            string IdEntrada;

            ConexionDB.CerrarConexion();
            ConexionDB.AbrirConexion();
            string proc = "spInserEntrada";

            MySqlCommand sqlC = new MySqlCommand(proc, ConexionDB.AbrirConexion());
            sqlC.CommandType = CommandType.StoredProcedure;
            sqlC.Parameters.Add("@Idprov", MySqlDbType.Int32).Value = Convert.ToInt32(str[0]);
            sqlC.Parameters.Add("@Fecha", MySqlDbType.Date).Value = Convert.ToDateTime(str[1]);
            sqlC.Parameters.Add("@ComprobanteEntrada", MySqlDbType.Int32).Value = Convert.ToInt32(str[2]);
            sqlC.Parameters.Add("@NroDoc", MySqlDbType.VarChar).Value = str[3];
            sqlC.Parameters.Add("@CTotal", MySqlDbType.Decimal).Value = Convert.ToDecimal(str[4]);
            sqlC.ExecuteNonQuery();

            MySqlDataAdapter da2 = new MySqlDataAdapter("select * from `MEntrada` order by nIdEntrada desc limit 1", ConexionDB.AbrirConexion());
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            IdEntrada = Convert.ToString(dt2.Rows[0]["nIdEntrada"]);
            da2.Dispose();

            ConexionDB.CerrarConexion();

            return IdEntrada;
        }
    }
}
