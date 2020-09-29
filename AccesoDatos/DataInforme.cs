using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace AccesoDatos
{
   public class DataInforme
    {

        private Conexion ConexionDB = new Conexion();

        public DataTable InformeVentas(string[] str)
        {
            string proc = "spInformVentas";
            DataTable tabla;

            MySqlDataAdapter p = new MySqlDataAdapter(proc, ConexionDB.AbrirConexion());
            DataTable dt = new DataTable();
            p.SelectCommand.CommandType = CommandType.StoredProcedure;
            p.SelectCommand.Parameters.Add("@fromDate", MySqlDbType.Date).Value = Convert.ToDateTime(str[0]);
            p.SelectCommand.Parameters.Add("@toDate", MySqlDbType.Date).Value = Convert.ToDateTime(str[1]);

            p.Fill(dt);
            tabla = dt;
            p.Dispose();

            ConexionDB.CerrarConexion();
            return tabla;
        }
        public DataTable RecordProductos(string[] str)
        {
            string proc = "spRecordProductos";
            DataTable tabla;

            MySqlDataAdapter p = new MySqlDataAdapter(proc, ConexionDB.AbrirConexion());
            DataTable dt = new DataTable();
            p.SelectCommand.CommandType = CommandType.StoredProcedure;
            p.SelectCommand.Parameters.Add("@fromDate", MySqlDbType.Date).Value = Convert.ToDateTime(str[0]);
            p.SelectCommand.Parameters.Add("@toDate", MySqlDbType.Date).Value = Convert.ToDateTime(str[1]);

            p.Fill(dt);
            tabla = dt;
            p.Dispose();

            ConexionDB.CerrarConexion();
            return tabla;
        }
        public DataTable RecordClientes(string[] str)
        {
            string proc = "spRecordClientes";
            DataTable tabla;

            MySqlDataAdapter p = new MySqlDataAdapter(proc, ConexionDB.AbrirConexion());
            DataTable dt = new DataTable();
            p.SelectCommand.CommandType = CommandType.StoredProcedure;
            p.SelectCommand.Parameters.Add("@fromDate", MySqlDbType.Date).Value = Convert.ToDateTime(str[0]);
            p.SelectCommand.Parameters.Add("@toDate", MySqlDbType.Date).Value = Convert.ToDateTime(str[1]);

            p.Fill(dt);
            tabla = dt;
            p.Dispose();

            ConexionDB.CerrarConexion();
            return tabla;
        }
        public DataTable ListProductos(string[] str)
        {
            string proc = "FinalProductosPorFecha";
            DataTable tabla;

            MySqlDataAdapter p = new MySqlDataAdapter(proc, ConexionDB.AbrirConexion());
            DataTable dt = new DataTable();
            p.SelectCommand.CommandType = CommandType.StoredProcedure;
            p.SelectCommand.Parameters.Add("@fechaInicio", MySqlDbType.Date).Value = Convert.ToDateTime(str[0]);
            p.SelectCommand.Parameters.Add("@fechaFin", MySqlDbType.Date).Value = Convert.ToDateTime(str[1]);

            p.Fill(dt);
            tabla = dt;
            p.Dispose();

            ConexionDB.CerrarConexion();
            return tabla;
        }
        public DataTable ListProducNombre(string[] str)
        {
            string proc = "BuscarNombre";
            DataTable tabla;

            MySqlDataAdapter p = new MySqlDataAdapter(proc, ConexionDB.AbrirConexion());
            DataTable dt = new DataTable();
            p.SelectCommand.CommandType = CommandType.StoredProcedure;
            p.SelectCommand.Parameters.Add("@cadena", MySqlDbType.String).Value = str[0];

            p.Fill(dt);
            tabla = dt;
            p.Dispose();

            ConexionDB.CerrarConexion();
            return tabla;
        }
        public DataTable BuscProdCategoria(string[] str)
        {
            string proc = "BuscarCategoria";
            DataTable tabla;

            MySqlDataAdapter p = new MySqlDataAdapter(proc, ConexionDB.AbrirConexion());
            DataTable dt = new DataTable();
            p.SelectCommand.CommandType = CommandType.StoredProcedure;
            p.SelectCommand.Parameters.Add("@cad", MySqlDbType.String).Value = str[0];

            p.Fill(dt);
            tabla = dt;
            p.Dispose();

            ConexionDB.CerrarConexion();
            return tabla;
        }
        public DataTable MostarInfoAlmacen()
        {
            string proc = "spInformeAlmacen";
            DataTable tabla;
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(proc, ConexionDB.AbrirConexion());
            da.Fill(dt);

            tabla = dt;
            da.Dispose();

            ConexionDB.CerrarConexion();
            return tabla;
        }       
        public DataTable InfomeProveedor()
        {
            string proc = "spListProveedor";
            DataTable tabla;
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(proc, ConexionDB.AbrirConexion());
            da.Fill(dt);

            tabla = dt;
            da.Dispose();

            ConexionDB.CerrarConexion();
            return tabla;
        }     
        public DataTable RecordProveedor()
        {
            string proc = "spRecordProveedor";
            DataTable tabla;
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(proc, ConexionDB.AbrirConexion());
            da.Fill(dt);

            tabla = dt;
            da.Dispose();

            ConexionDB.CerrarConexion();
            return tabla;
        }       
        public DataTable TablaBoleta()
        {
            string proc = "ListarUltimaVenta";
            DataTable tabla;
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(proc, ConexionDB.AbrirConexion());
            da.Fill(dt);

            tabla = dt;
            da.Dispose();

            ConexionDB.CerrarConexion();
            return tabla;
        }
        public DataTable TablaComprobEntrada()
        {
            string proc = "Listar_Ultima_Entrada";
            DataTable tabla;
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(proc, ConexionDB.AbrirConexion());
            da.Fill(dt);

            tabla = dt;
            da.Dispose();

            ConexionDB.CerrarConexion();
            return tabla;
        }
    }
}
