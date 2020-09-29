using AccesoDatos;
using System.Data;

namespace LogicaNegocio
{
    public class LogicaProducto
    {
        DataProducto dataProducto = new DataProducto();
        
        public void InsActProducto(string[] str)
        {
             dataProducto.InsActProductoBD(str);
        }       
       
        public void ProductoId()
        {
            dataProducto.IdProducto();
        }

        public DataTable productotable()
        {
            return dataProducto.retoProduc();
        }

        public DataTable produxcate(string IdCategoria)
        {
            return dataProducto.prodxcate(IdCategoria);
        }

        public DataTable unidproduc(string Idproducto)
        {
            return dataProducto.unidprod(Idproducto);
        }

        public void actStock(int num1, int num2)
        {
            dataProducto.ActStockProd(num1, num2);
        }
        public void resStock(int IdProducto, int nCantidad)
        {
            dataProducto.ResStockProd(IdProducto, nCantidad);
        }
        public void DevoActStoc(int IdProducto, int Cantidad)
        {
            dataProducto.DevoStock(IdProducto, Cantidad);
        }

    }
}
