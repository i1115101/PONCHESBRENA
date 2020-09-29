using System.Data;
using AccesoDatos;

namespace LogicaNegocio
{
   public class LogicaDetalleVenta
    {
       public DataDetalleVenta dataDetalleVenta = new DataDetalleVenta();
       
        public void  InsertarDetalleVenta(string[] str)
        {
             dataDetalleVenta.InsertarDetalleVentaBD(str);
        }
        public DataTable ParametroDVenta(string[] str)
        {
            return dataDetalleVenta.ListDVenta(str);
        }
    }
}
