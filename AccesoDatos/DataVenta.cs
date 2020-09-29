using System;
using MySql.Data.MySqlClient;
using System.Data;
using Entidad.Cache;

namespace AccesoDatos
{
   public class DataVenta
    {
       private Conexion ConexionDB = new Conexion();

        public int InsertarVentaBD(string[] str)
        {
            int IdVenta;
                     
            string proc = "spInserVenta";

            MySqlCommand sqlC = new MySqlCommand(proc, ConexionDB.AbrirConexion());
            sqlC.CommandType = CommandType.StoredProcedure;
            sqlC.Parameters.Add("@Idcliente", MySqlDbType.Int32).Value = Convert.ToInt32(str[0]);
            sqlC.Parameters.Add("@Idempleado", MySqlDbType.Int32).Value = Convert.ToInt32(str[1]);
            sqlC.Parameters.Add("@Fecha", MySqlDbType.Date).Value = Convert.ToDateTime(str[2]);
            sqlC.Parameters.Add("@Idcomprobante", MySqlDbType.Int32).Value = Convert.ToInt32(str[3]);
            sqlC.Parameters.Add("@Serieventa", MySqlDbType.VarChar).Value = str[4];
            sqlC.Parameters.Add("@Subtotal", MySqlDbType.Decimal).Value = Convert.ToDecimal(str[5]);
            sqlC.Parameters.Add("@Total", MySqlDbType.Decimal).Value = Convert.ToDecimal(str[6]);
            sqlC.Parameters.Add("@Ganancia", MySqlDbType.Decimal).Value = Convert.ToDecimal(str[7]);
            sqlC.ExecuteNonQuery();

            MySqlDataAdapter da3 = new MySqlDataAdapter("SELECT nIdVenta FROM `MVenta` ORDER BY nIdVenta DESC LIMIT 1", ConexionDB.AbrirConexion());
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            da3.Dispose();
            IdVenta = Convert.ToInt32(dt3.Rows[0]["nIdVenta"]);
            da3.Dispose();

            ConexionDB.CerrarConexion();
            return IdVenta;
        }
        public void AnularVenta(string[] str)
        {                       
            string proc = "sp_anulacion_venta";

            MySqlCommand sqlC = new MySqlCommand(proc, ConexionDB.AbrirConexion());
            sqlC.CommandType = CommandType.StoredProcedure;
            sqlC.Parameters.Add("@idvent", MySqlDbType.Int32).Value = Convert.ToInt32(str[0]);
            sqlC.ExecuteNonQuery();

            ConexionDB.CerrarConexion();            
        }
    }
}
