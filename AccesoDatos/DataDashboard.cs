using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
//using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Entidad;


namespace AccesoDatos
{    
   public class DataDashboard
    {
        private Conexion ConexionDB = new Conexion(); 
        MySqlCommand cmd;
        MySqlDataReader dr;

        public void ProdPorCategoria(EntidadDashboard obj)
        {
            cmd = new MySqlCommand("ProdPorCategoria", ConexionDB.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            ConexionDB.AbrirConexion();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               obj.Categoria1.Add(dr.GetString(0));
               obj.CantProd1.Add(dr.GetInt32(1));
            }
           
            dr.Close();
            ConexionDB.CerrarConexion();
        }
        public void ProdPreferidos(EntidadDashboard obj)
        {
            cmd = new MySqlCommand("ProdPreferidos", ConexionDB.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            ConexionDB.AbrirConexion();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                obj.Producto1.Add(dr.GetString(0));
               obj.Cant1.Add(dr.GetInt32(1));
            }
            
            dr.Close();
            ConexionDB.AbrirConexion();
        }
        public void SumarioDatos(EntidadDashboard obj)
        {
            cmd = new MySqlCommand("Dashboard", ConexionDB.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlParameter total = new MySqlParameter("@totVentas", 0); total.Direction = ParameterDirection.Output;
            MySqlParameter cantpro = new MySqlParameter("@cantProd", 0); cantpro.Direction = ParameterDirection.Output;
            MySqlParameter cantCateg = new MySqlParameter("@cantCateg", 0); cantCateg.Direction = ParameterDirection.Output;
            MySqlParameter cantEmple = new MySqlParameter("@cantEmple", 0); cantEmple.Direction = ParameterDirection.Output;
            MySqlParameter cantProve = new MySqlParameter("@cantProve", 0); cantProve.Direction = ParameterDirection.Output;
            MySqlParameter cantClient = new MySqlParameter("@cantClient", 0); cantClient.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(total);
            cmd.Parameters.Add(cantpro);
            cmd.Parameters.Add(cantCateg);
            cmd.Parameters.Add(cantEmple);
            cmd.Parameters.Add(cantProve);
            cmd.Parameters.Add(cantClient);

            ConexionDB.AbrirConexion();
            cmd.ExecuteNonQuery();

            obj.TotalVentas1= cmd.Parameters["@totVentas"].Value.ToString();
            obj.CantProductos1 = cmd.Parameters["@cantProd"].Value.ToString();
            obj.CantCateg1 = cmd.Parameters["@cantCateg"].Value.ToString();
            obj.CantEmple1 = cmd.Parameters["@cantEmple"].Value.ToString();
            obj.CantProv1= cmd.Parameters["@cantProve"].Value.ToString();
            obj.CantClient1 = cmd.Parameters["@cantClient"].Value.ToString();

            ConexionDB.CerrarConexion();
        }
    }
}
