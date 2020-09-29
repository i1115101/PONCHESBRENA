using AccesoDatos;
using System.Data;
using System;

namespace LogicaNegocio
{
   public class LogicaInforme
    {
        DataInforme DataInformeVentas = new DataInforme();

        public DataTable ParametrosInforme(string[] str)
        {
            return DataInformeVentas.InformeVentas(str);
        }
        public DataTable ParametrosRecordProd(string[] str)
        {
            return DataInformeVentas.RecordProductos(str);
        }
        public DataTable ParametrosRecordCli(string[] str)
        {
            return DataInformeVentas.RecordClientes(str);
        }
        DataTable tabla = new DataTable();
        DataTable tablaprov = new DataTable();
        public DataTable MostrarInformeAlmacen()
        {

            tabla = DataInformeVentas.MostarInfoAlmacen();
            return tabla;
        }
        public DataTable MostrarInformeProveedor()
        {

            tablaprov = DataInformeVentas.InfomeProveedor();
            return tablaprov;
        }
        public DataTable RecordProveedor()
        {

            tablaprov = DataInformeVentas.RecordProveedor();
            return tablaprov;
        }        
        public DataTable RellenarBoleta()
        {

            tablaprov = DataInformeVentas.TablaBoleta();
            return tablaprov;
        }
        public DataTable RellComprobEntra()
        {
            tablaprov = DataInformeVentas.TablaComprobEntrada();
            return tablaprov;
        }
        public DataTable ParametrosProductos(string[] str)
        {
            return DataInformeVentas.ListProductos(str);
        }
        public DataTable ParamNomProductos(string[] str)
        {
            return DataInformeVentas.ListProducNombre(str);
        }
        public DataTable ParamCategriaProduc(string[] str)
        {
            return DataInformeVentas.BuscProdCategoria(str);
        }
    }
}
