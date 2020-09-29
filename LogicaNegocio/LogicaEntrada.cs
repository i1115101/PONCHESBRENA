using AccesoDatos;
using System.Data;

namespace LogicaNegocio
{
    public class LogicaEntrada
    {
        public DataEntrada dataEntrada = new DataEntrada();
        public string InsertarEntrada(string[] str)
        {
            return dataEntrada.InsertarEntradaBD(str);
        }
        //public DataTable ProductoId(int IdCategoria)
        //{
        //    DataTable tabla = new DataTable();
        //    tabla = dataEntrada.IdProducto(IdCategoria);
        //    return tabla;
        //}
    }
}
