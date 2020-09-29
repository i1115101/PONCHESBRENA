using AccesoDatos;

namespace LogicaNegocio
{
   public class LogicaVenta
    {
      public DataVenta dataVenta = new DataVenta();
       

        public int InsertarVenta(string[] str)
        {
            return dataVenta.InsertarVentaBD(str);
        }
        public void ParamAnulVenta(string[] str)
        {
            dataVenta.AnularVenta(str);
        }
    }
}
