using Entidad.Cache;
//using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace AccesoDatos
{
    public class DataDetalleEntrada
    {
        private Conexion ConexionDB = new Conexion();

        public void InsertarDetalleEntradaBD(string[] str)
        {
            ConexionDB.CerrarConexion();
            ConexionDB.AbrirConexion();
            string proc = "spInserDEntrada";

            MySqlCommand sqlC = new MySqlCommand(proc, ConexionDB.AbrirConexion());
            sqlC.CommandType = CommandType.StoredProcedure;
            sqlC.Parameters.Add("@IdEnt", MySqlDbType.Int32).Value = Convert.ToInt32(str[0]);
            sqlC.Parameters.Add("@IdProd", MySqlDbType.Int32).Value = Convert.ToInt32(str[1]);
            sqlC.Parameters.Add("@FechaVen", MySqlDbType.Date).Value = Convert.ToDateTime(str[2]);
            sqlC.Parameters.Add("@PrecCompra", MySqlDbType.Decimal).Value = Convert.ToDecimal(str[3]);
            sqlC.Parameters.Add("@PrecVenta", MySqlDbType.Decimal).Value = Convert.ToDecimal(str[4]);
            sqlC.Parameters.Add("@Cantidad", MySqlDbType.Int32).Value = Convert.ToInt32(str[5]);
            sqlC.Parameters.Add("@Descuento", MySqlDbType.Decimal).Value = Convert.ToDecimal(str[6]);
            sqlC.Parameters.Add("@Importe", MySqlDbType.Decimal).Value = Convert.ToDecimal(str[7]);
            sqlC.ExecuteNonQuery();

            ConexionDB.CerrarConexion();
        }
        public bool ListarFechaVencimiento(int IdProducto)
        {
            ConexionDB.CerrarConexion();
            ConexionDB.AbrirConexion();
            using (var command = new MySqlCommand())
            {
                command.Connection = ConexionDB.AbrirConexion();
                command.CommandText = "SELECT Top 1 DetalleEntrada.* FROM  DetalleEntrada  where  IdProducto = @idproducto  order by IdEntrada desc";
                command.Parameters.AddWithValue("@idproducto", IdProducto);
                command.CommandType = CommandType.Text;

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        EDetalleEntrada.FechaVencimiento = reader.GetDateTime(2);

                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
