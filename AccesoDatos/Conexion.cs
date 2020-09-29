using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace AccesoDatos
{
    public class Conexion
    {
        //public MySqlConnection ConexionBD = new MySqlConnection(" Server=sofosystemserve.mysql.database.azure.com; Port=3306; Database=dbsofosystem; Uid=Leandro@sofosystemserve; Pwd=Sofosystem123; SslMode=Preferred;");
        //Server=sofosystemserve.mysql.database.azure.com; Port=3306; Database={your_database}; Uid=Leandro @sofosystemserve; Pwd={your_password}; SslMode = Preferred;
        //public MySqlConnection ConexionBD = new MySqlConnection("Server = mysql-leandrovegaabraham.alwaysdata.net; Database=leandrovegaabraham_sofoapp;Uid=200915;Pwd=sofosystem");
        public MySqlConnection ConexionBD = new MySqlConnection("Server = mysql-sofo.alwaysdata.net; Database=sofo_ponchesbrenadb;Uid=sofo;Pwd=Continent@l2020");
        //string sp;

        MySqlDataAdapter Dtpt;
        MySqlCommand Comm;


        public MySqlConnection AbrirConexion()
        {
            if (ConexionBD.State == ConnectionState.Closed)

                ConexionBD.Open();
            return ConexionBD;
        }
        public MySqlConnection CerrarConexion()
        {
            if (ConexionBD.State == ConnectionState.Open)

                ConexionBD.Close();
            return ConexionBD;
        }    

        
        protected DataSet dtsRetProcedimiento(string proc, params object[] Args)
        {
            CerrarConexion();
            AbrirConexion();
            DataSet dts = new DataSet();
            //Dtpt = new SqlDataAdapter(proc, conectarBD.ConnectionString);

            Dtpt.SelectCommand.CommandType = CommandType.StoredProcedure;


            if ((Args != null))
            {
                Dtpt.SelectCommand.Parameters.AddWithValue("@cNumDocumento", Args[0]);
            }

            Comm = Dtpt.SelectCommand;
            Dtpt.Fill(dts, proc);
            CerrarConexion();
            return dts;
        }
        public DataSet dtsEjecutarSp(string proc, params object[] Args)
        {
            DataSet dts = null;
            dts = this.dtsRetProcedimiento(proc, Args);

            return dts;
        }
        protected DataSet dtsRetProcedimientoEstado(string proc, params object[] Args)
        {
            CerrarConexion();
            AbrirConexion();
            DataSet dts = new DataSet();
            //Dtpt = new SqlDataAdapter(proc, conectarBD.ConnectionString);

            Dtpt.SelectCommand.CommandType = CommandType.StoredProcedure;


            if ((Args != null))
            {
                Dtpt.SelectCommand.Parameters.AddWithValue("@cNombreEstado", Args[0]);
            }

            Comm = Dtpt.SelectCommand;
            Dtpt.Fill(dts, proc);
            CerrarConexion();
            return dts;
        }

        public DataSet dtsEjecutarSpEstado(string proc, params object[] Args)
        {
            DataSet dts = null;
            dts = this.dtsRetProcedimientoEstado(proc, Args);

            return dts;
        }

        protected void CargarParametros(string Proc, MySqlCommand Comando, DataSet ds, params object[] Args)
        {
            Int16 i;
            string p;

            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            Comando.CommandText = Proc;
            Comando.CommandType = CommandType.StoredProcedure;

            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                p = dt.Rows[i]["parameter_name"].ToString();
                Comando.Parameters.Add(new MySqlParameter(p, MySqlDbType.VarChar, 8000)).Value = Args[i];
            }

        }

        
    }
}
