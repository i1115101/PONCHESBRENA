using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace AccesoDatos
{
    public class DataEmpleado
    {
        private Conexion ConexionDB = new Conexion();

        public void InsActEmpleadoBD(string[] str)
        {

            ConexionDB.CerrarConexion();
            ConexionDB.AbrirConexion();
            string proc = "spInsUpdEmpleado";

            MySqlCommand sqlC = new MySqlCommand(proc, ConexionDB.AbrirConexion());
            sqlC.CommandType = CommandType.StoredProcedure;
            sqlC.Parameters.Add("@Idempl", MySqlDbType.Int32).Value = Convert.ToInt32(str[0]);            
            sqlC.Parameters.Add("@Nombre", MySqlDbType.VarChar).Value = str[1];
            sqlC.Parameters.Add("@Apellidos", MySqlDbType.VarChar).Value = str[2];
            sqlC.Parameters.Add("@Tipodoc", MySqlDbType.Int32).Value = Convert.ToInt32(str[3]);
            sqlC.Parameters.Add("@NroDoc", MySqlDbType.VarChar).Value = str[4];
            sqlC.Parameters.Add("@Usuario", MySqlDbType.VarChar).Value = str[5];
            sqlC.Parameters.Add("@Clave", MySqlDbType.VarChar).Value = str[6];
            sqlC.Parameters.Add("@Cargo", MySqlDbType.VarChar).Value = str[7];
            sqlC.Parameters.Add("@Turno", MySqlDbType.VarChar).Value = str[8];
            sqlC.Parameters.Add("@Direccion", MySqlDbType.VarChar).Value = str[9];
            sqlC.Parameters.Add("@Telefono", MySqlDbType.VarChar).Value = str[10];
            sqlC.Parameters.Add("@Sexo", MySqlDbType.VarChar).Value = str[11];
            sqlC.ExecuteNonQuery();

            ConexionDB.CerrarConexion();
            MostrarEmpleado();
        }

        static DataTable tabla = new DataTable();
        public void MostrarEmpleado()
        {
            MySqlDataAdapter p = new MySqlDataAdapter("spListEmplComplet", ConexionDB.AbrirConexion());
            DataTable dt = new DataTable();
            p.Fill(dt);
            tabla = dt;
            p.Dispose();
        }
        public DataTable retoEmpl()
        {
            return tabla;
        }
    }
}
