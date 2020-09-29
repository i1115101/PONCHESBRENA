
using AccesoDatos;
using System.Data;

namespace LogicaNegocio
{
   public class LogicaCliente
    {
       public DataCliente dataCliente = new DataCliente();
        public int IdCliente()
        {
            return dataCliente.IdCliente();
        }        
        public void insActCliente(string[] str)
        {
            dataCliente.InsActClienteBD(str);
        }
        public DataTable ListaCliente()
        {
            return dataCliente.retoCliente();
        }
        public void RellenarCmbCliente()
        {
            dataCliente.RellenarCmbCliente();
        }
        public DataTable unidcliente(string IdCliente)
        {
            return dataCliente.unidcliente(IdCliente);
        }

    }
}
