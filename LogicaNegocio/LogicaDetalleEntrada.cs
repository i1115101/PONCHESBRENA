using AccesoDatos;

namespace LogicaNegocio
{
    public class LogicaDetalleEntrada
    {
        DataDetalleEntrada dataDetalleEntrada = new DataDetalleEntrada();
        public void InsertarDetalleEntrada(string[] str)
        {
            dataDetalleEntrada.InsertarDetalleEntradaBD(str);
        }

        public bool FechVencimiento(int IdProducto)
        {
            return dataDetalleEntrada.ListarFechaVencimiento(IdProducto);
        }
    }

}
