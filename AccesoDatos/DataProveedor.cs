//using System.Data.SqlClient;45
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace AccesoDatos
{
    public class DataProveedor
    {
        private Conexion ConexionDB = new Conexion();

        //public int InsertarProveedorBD(string[] str)
        //{
        //    int IdProveedor;

        //    ConexionDB.CerrarConexion();
        //    ConexionDB.AbrirConexion();
        //    string proc = "spInserProveedor";

        //    MySqlCommand sqlC = new MySqlCommand(proc, ConexionDB.AbrirConexion());
        //    sqlC.CommandType = CommandType.StoredProcedure;
        //    sqlC.Parameters.Add("@RazonSocial", MySqlDbType.VarChar).Value = str[0];
        //    sqlC.Parameters.Add("@Ruc", MySqlDbType.VarChar).Value = str[1];
        //    sqlC.Parameters.Add("@Representante", MySqlDbType.VarChar).Value = str[2];
        //    sqlC.Parameters.Add("@Telefono", MySqlDbType.VarChar).Value = str[3];
        //    sqlC.ExecuteNonQuery();

        //    MySqlDataAdapter p = new MySqlDataAdapter("select * from `MProveedor` order by nIdProveedor desc limit 1", ConexionDB.AbrirConexion());
        //    DataTable pr = new DataTable();
        //    p.Fill(pr);
        //    IdProveedor = Convert.ToInt32(pr.Rows[0]["nIdProveedor"]);
        //    p.Dispose();

        //    ConexionDB.CerrarConexion();

        //    MostrarProveedor();

        //    return IdProveedor;
        //}

        public string InsActProveedorBD(string[] str)
        {
            string IdProveedor;
            ConexionDB.CerrarConexion();
            ConexionDB.AbrirConexion();
            string proc = "spInsUpdProveedor";

            MySqlCommand sqlC = new MySqlCommand(proc, ConexionDB.AbrirConexion());
            sqlC.CommandType = CommandType.StoredProcedure;
            sqlC.Parameters.Add("@IdProv", MySqlDbType.Int32).Value = Convert.ToInt32(str[0]);
            sqlC.Parameters.Add("@RazonSocial", MySqlDbType.VarChar).Value = str[1];
            sqlC.Parameters.Add("@Ruc", MySqlDbType.VarChar).Value = str[2];
            sqlC.Parameters.Add("@Representante", MySqlDbType.VarChar).Value = str[3];
            sqlC.Parameters.Add("@Telefono", MySqlDbType.VarChar).Value = str[4];
            sqlC.ExecuteNonQuery();

            ConexionDB.CerrarConexion();
            MostrarProveedor();
            if (Convert.ToInt32(str[0]) == 0)
            {
                int num = tabla.Rows.Count - 1;
                IdProveedor = Convert.ToString(tabla.Rows[num]["nIdProveedor"]);
            }else
            {
                IdProveedor = str[0];
            }
                return IdProveedor; 
        }

        static DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();
        public void MostrarProveedor()
        {
            MySqlDataAdapter p = new MySqlDataAdapter("spListProveedor", ConexionDB.AbrirConexion());
            DataTable dt = new DataTable();
            p.Fill(dt);
            tabla = dt;
            p.Dispose();
        }
        public DataTable retoprov()
        {
            return tabla;
        }
    }
}
