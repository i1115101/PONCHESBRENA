using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace AccesoDatos
{
   public class DataTipoDocumento
    {        
        private Conexion ConexionDB = new Conexion();

        public void InsUpdComprobanteBD(string[] str)
        {
            ConexionDB.CerrarConexion();
            ConexionDB.AbrirConexion();

            string proc = "spInsUpdComprobante";
            MySqlCommand sqlC = new MySqlCommand(proc, ConexionDB.AbrirConexion());
            sqlC.CommandType = CommandType.StoredProcedure;
            sqlC.Parameters.Add("@IdComp", MySqlDbType.Int32).Value = Convert.ToInt32(str[0]);
            sqlC.Parameters.Add("@NomComp", MySqlDbType.VarChar).Value = str[1];
            sqlC.ExecuteNonQuery();

            ConexionDB.CerrarConexion();
            MostarDocEntrada();
        }

        public void InsUpdDocumentoBD(string[] str)
        {            
            ConexionDB.CerrarConexion();
            ConexionDB.AbrirConexion(); 

            string proc = "spInsUpdDocumento";
            MySqlCommand sqlC = new MySqlCommand(proc, ConexionDB.AbrirConexion());
            sqlC.CommandType = CommandType.StoredProcedure;
            sqlC.Parameters.Add("@IdTDoc", MySqlDbType.Int32).Value = Convert.ToInt32(str[0]);
            sqlC.Parameters.Add("@NomDoc", MySqlDbType.VarChar).Value = str[1];
            sqlC.ExecuteNonQuery();

            ConexionDB.CerrarConexion();
            MostrarTipoDocumento();
        }

        static DataTable tabla=new DataTable();
        static DataTable tabladocEnt = new DataTable();

        public void MostrarTipoDocumento()
        {
            MySqlDataAdapter p = new MySqlDataAdapter("spListDocumento", ConexionDB.AbrirConexion());
            DataTable dt = new DataTable();
            p.Fill(dt);
            tabla = dt;
            p.Dispose();
        }
        
        public void MostarDocEntrada()
        {
            MySqlDataAdapter p = new MySqlDataAdapter("spListComprovante", ConexionDB.AbrirConexion());
            DataTable dt = new DataTable();
            p.Fill(dt);
            tabladocEnt = dt;
            p.Dispose();
        }

        public DataTable retDocEnt()
        {
            return tabladocEnt;
        }

        public DataTable retoDocu()
        {
            return tabla;
        }
    }
}
