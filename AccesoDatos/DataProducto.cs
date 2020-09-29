using Entidad.Cache;
using MySql.Data.MySqlClient;
using System;
using System.Data;
//
namespace AccesoDatos
{
    public class DataProducto
    {
        private Conexion ConexionDB = new Conexion();
        
        public void InsActProductoBD(string[] str)
        {

            ConexionDB.CerrarConexion();
            ConexionDB.AbrirConexion();
            string proc = "spInsUpdProducto";

            MySqlCommand sqlC = new MySqlCommand(proc, ConexionDB.AbrirConexion());
            sqlC.CommandType = CommandType.StoredProcedure;
            sqlC.Parameters.Add("@IdProd", MySqlDbType.Int32).Value = Convert.ToInt32(str[0]);
            sqlC.Parameters.Add("@IdTCate", MySqlDbType.Int32).Value = Convert.ToInt32(str[1]);
            sqlC.Parameters.Add("@NomProd", MySqlDbType.VarChar).Value = str[2];
            sqlC.Parameters.Add("@Descripcion", MySqlDbType.VarChar).Value = str[3];
            sqlC.Parameters.Add("@Stock", MySqlDbType.Int32).Value = Convert.ToInt32(str[4]);
            sqlC.Parameters.Add("@Stockmin", MySqlDbType.Int32).Value = Convert.ToInt32(str[5]);
            sqlC.Parameters.Add("@UltPreCosto", MySqlDbType.Decimal).Value = Convert.ToDecimal(str[6]);
            sqlC.Parameters.Add("@UltPreVenta", MySqlDbType.Decimal).Value = Convert.ToDecimal(str[7]);
            sqlC.Parameters.Add("@Ganancia", MySqlDbType.Decimal).Value = Convert.ToDecimal(str[8]);
            sqlC.ExecuteNonQuery();

            ConexionDB.CerrarConexion();
            IdProducto();
        }
       
        DataTable Tabla = new DataTable();
        static DataTable tablaproducto = new DataTable();
        DataTable PXC = new DataTable();
        DataTable unitP = new DataTable();
        public void IdProducto()
        {
            MySqlDataAdapter p = new MySqlDataAdapter("spListProducto", ConexionDB.AbrirConexion());
            DataTable dt = new DataTable();
            p.Fill(dt);
            tablaproducto = dt;
            p.Dispose();
        }

        public DataTable retoProduc()
        {
            return tablaproducto;
        }

        void colum(DataTable dt)
        {
            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("nIdProducto");
                dt.Columns.Add("IdTCategoria");
                dt.Columns.Add("cNombreProducto");
                dt.Columns.Add("cDescripcion");
                dt.Columns.Add("nStock");
                dt.Columns.Add("nStockMinimo");
                dt.Columns.Add("nUltPrecioCosto");
                dt.Columns.Add("nUltPrecioVenta");
                dt.Columns.Add("nGanancia");
                dt.Columns.Add("bEstado");
            }
        }

        public DataTable prodxcate(string id)
        {
            PXC.Clear();
            colum(PXC);

            for (int y = 0; y < tablaproducto.Rows.Count; y++)
            {
                if (tablaproducto.Rows[y]["IdTCategoria"].ToString() == id)
                {
                    DataRow row = PXC.NewRow();

                    row["nIdProducto"] = Convert.ToString(tablaproducto.Rows[y]["nIdProducto"]);
                    row["IdTCategoria"] = Convert.ToString(tablaproducto.Rows[y]["IdTCategoria"]);
                    row["cNombreProducto"] = Convert.ToString(tablaproducto.Rows[y]["cNombreProducto"]);
                    row["cDescripcion"] = Convert.ToString(tablaproducto.Rows[y]["cDescripcion"]);
                    row["nStock"] = Convert.ToString(tablaproducto.Rows[y]["nStock"]);
                    row["nStockMinimo"] = Convert.ToString(tablaproducto.Rows[y]["nStockMinimo"]);
                    row["nUltPrecioCosto"] = Convert.ToString(tablaproducto.Rows[y]["nUltPrecioCosto"]);
                    row["nUltPrecioVenta"] = Convert.ToString(tablaproducto.Rows[y]["nUltPrecioVenta"]);
                    row["nGanancia"] = Convert.ToString(tablaproducto.Rows[y]["nGanancia"]);
                    row["bEstado"] = Convert.ToString(tablaproducto.Rows[y]["bEstado"]);
                    PXC.Rows.Add(row);
                }
            }
            return PXC;
        }
        public DataTable unidprod(string id)
        {
            unitP.Clear();
            colum(unitP);

            for (int y = 0; y < tablaproducto.Rows.Count; y++)
            {
                if (tablaproducto.Rows[y]["nIdProducto"].ToString() == id)
                {
                    DataRow row = unitP.NewRow();

                    row["nIdProducto"] = Convert.ToString(tablaproducto.Rows[y]["nIdProducto"]);
                    row["IdTCategoria"] = Convert.ToString(tablaproducto.Rows[y]["IdTCategoria"]);
                    row["cNombreProducto"] = Convert.ToString(tablaproducto.Rows[y]["cNombreProducto"]);
                    row["cDescripcion"] = Convert.ToString(tablaproducto.Rows[y]["cDescripcion"]);
                    row["nStock"] = Convert.ToString(tablaproducto.Rows[y]["nStock"]);
                    row["nStockMinimo"] = Convert.ToString(tablaproducto.Rows[y]["nStockMinimo"]);
                    row["nUltPrecioCosto"] = Convert.ToString(tablaproducto.Rows[y]["nUltPrecioCosto"]);
                    row["nUltPrecioVenta"] = Convert.ToString(tablaproducto.Rows[y]["nUltPrecioVenta"]);
                    row["nGanancia"] = Convert.ToString(tablaproducto.Rows[y]["nGanancia"]);
                    row["bEstado"] = Convert.ToString(tablaproducto.Rows[y]["bEstado"]);
                    unitP.Rows.Add(row);
                    y = tablaproducto.Rows.Count;
                }
            }
            return unitP;
        }            
        
        public void ActStockProd(int num1, int num2)
        {            
            string proc = "spUpStockProd";

            MySqlCommand sqlC = new MySqlCommand(proc, ConexionDB.AbrirConexion());
            sqlC.CommandType = CommandType.StoredProcedure;
            sqlC.Parameters.Add("@Idproducto", MySqlDbType.Int32).Value = num1;
            sqlC.Parameters.Add("@stock", MySqlDbType.Int32).Value = num2;
            sqlC.ExecuteNonQuery();

            ConexionDB.CerrarConexion();            
        }
        public void ResStockProd(int IdProducto, int nCantidad)     
        {           
            string proc = "spResStockProd";
            MySqlCommand sqlC = new MySqlCommand(proc, ConexionDB.AbrirConexion());
            sqlC.CommandType = CommandType.StoredProcedure;
            sqlC.Parameters.Add("@Idproducto", MySqlDbType.Int32).Value = IdProducto;
            sqlC.Parameters.Add("@stock", MySqlDbType.Int32).Value = nCantidad;
            sqlC.ExecuteNonQuery();

            ConexionDB.CerrarConexion();
        }

        public void DevoStock(int IdProducto, int Cantidad)
        {
            string proc = "sp_devoluciones_Stock";

            MySqlCommand sqlC = new MySqlCommand(proc, ConexionDB.AbrirConexion());
            sqlC.CommandType = CommandType.StoredProcedure;
            sqlC.Parameters.Add("@idproduc", MySqlDbType.Int32).Value = IdProducto;
            sqlC.Parameters.Add("@cantidad", MySqlDbType.Int32).Value = Cantidad;
            sqlC.ExecuteNonQuery();

            ConexionDB.CerrarConexion();
        }
    }
}
