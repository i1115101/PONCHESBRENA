using System;
using System.Data;
using Entidad.Cache;
using MySql.Data.MySqlClient;


namespace AccesoDatos
{
   public class DataCliente
    {
       private Conexion ConexionDB = new Conexion();

        public int IdCliente()
        {
            int IdCliente,num;
            num = tablacliente.Rows.Count - 1;
            IdCliente = Convert.ToInt32(tablacliente.Rows[num]["nIdCliente"]);
            return IdCliente;
        }
        public void InsActClienteBD(string[] str)
        {
            ConexionDB.CerrarConexion();
            ConexionDB.AbrirConexion();
            string proc = "spInsUpdCliente";

            MySqlCommand sqlC = new MySqlCommand(proc,  ConexionDB.AbrirConexion());
            sqlC.CommandType = CommandType.StoredProcedure;
            sqlC.Parameters.Add("@IdCliente", MySqlDbType.Int32).Value = Convert.ToInt32(str[0]);
            sqlC.Parameters.Add("@Razonsocial", MySqlDbType.VarChar).Value = str[1];
            sqlC.Parameters.Add("@Idtipodoc", MySqlDbType.Int32).Value = Convert.ToInt32(str[2]);
            sqlC.Parameters.Add("@Nrodoc", MySqlDbType.VarChar).Value = str[3];
            sqlC.Parameters.Add("@Direccion", MySqlDbType.VarChar).Value = str[4];
            sqlC.ExecuteNonQuery();

            RellenarCmbCliente();

            ConexionDB.CerrarConexion();
        }

        DataTable unicli = new DataTable();
        static DataTable tablacliente = new DataTable();
        public DataTable retoCliente()
        {
            return tablacliente;
        }
        public void RellenarCmbCliente()
        {
            MySqlDataAdapter p = new MySqlDataAdapter("spListCliente", ConexionDB.AbrirConexion());
            DataTable dt = new DataTable();
            p.Fill(dt);            
            tablacliente = dt;
            p.Dispose();
        }        
        void colum(DataTable dt)
        {
            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("nIdCliente");
                dt.Columns.Add("cRazonSocial");
                dt.Columns.Add("IdTipoDocumento");
                dt.Columns.Add("cNumeroDocumento");
                dt.Columns.Add("cDireccion");                
                dt.Columns.Add("bEstado");
            }
        }
        public DataTable unidcliente(string id)
        {
            unicli.Clear();
            colum(unicli);

            for (int y = 0; y < tablacliente.Rows.Count; y++)
            {
                if (tablacliente.Rows[y]["nIdCliente"].ToString() == id)
                {
                    DataRow row = unicli.NewRow();

                    row["nIdCliente"] = Convert.ToString(tablacliente.Rows[y]["nIdCliente"]);
                    row["cRazonSocial"] = Convert.ToString(tablacliente.Rows[y]["cRazonSocial"]);
                    row["IdTipoDocumento"] = Convert.ToString(tablacliente.Rows[y]["IdTipoDocumento"]);
                    row["cNumeroDocumento"] = Convert.ToString(tablacliente.Rows[y]["cNumeroDocumento"]);
                    row["cDireccion"] = Convert.ToString(tablacliente.Rows[y]["cDireccion"]);                    
                    row["bEstado"] = Convert.ToString(tablacliente.Rows[y]["bEstado"]);
                    unicli.Rows.Add(row);
                    y = tablacliente.Rows.Count;
                }
            }
            return unicli;
        }        
    }
}
