using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace AccesoDatos
{
   public class DataDetalleVenta
    {
       private Conexion ConexionDB = new Conexion();

        public void InsertarDetalleVentaBD(string[] str)
        {
    

            ConexionDB.CerrarConexion();
            ConexionDB.AbrirConexion();
            string proc = "spInserDVenta";

            MySqlCommand sqlC = new MySqlCommand(proc,  ConexionDB.AbrirConexion());
            sqlC.CommandType = CommandType.StoredProcedure;
            sqlC.Parameters.Add("@Idventa", MySqlDbType.Int32).Value = Convert.ToInt32(str[0]);
            sqlC.Parameters.Add("@Idproducto", MySqlDbType.Int32).Value = Convert.ToInt32(str[1]);
            sqlC.Parameters.Add("@Cantidad", MySqlDbType.Int32).Value = Convert.ToInt32(str[2]);
            sqlC.Parameters.Add("@Descuento", MySqlDbType.Decimal).Value = Convert.ToDecimal(str[3]);
            sqlC.Parameters.Add("@Importe", MySqlDbType.Decimal).Value = Convert.ToDecimal(str[4]);
            sqlC.ExecuteNonQuery();


            ConexionDB.CerrarConexion();
            
        }
        public DataTable ListDVenta(string[] str)
        {
            string proc = "spListDetVenta";
            DataTable tabla;

            MySqlDataAdapter p = new MySqlDataAdapter(proc, ConexionDB.AbrirConexion());
            DataTable dt = new DataTable();
            p.SelectCommand.CommandType = CommandType.StoredProcedure;
            p.SelectCommand.Parameters.Add("@Id", MySqlDbType.Int32).Value = str[0];

            p.Fill(dt);
            tabla = dt;
            p.Dispose();

            ConexionDB.CerrarConexion();
            return tabla;
        }
    }
}


