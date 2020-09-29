using AccesoDatos;
using System.Data;

namespace LogicaNegocio
{
    public class LogicaCategoria
    {
        public DataCategoria dataCategoria = new DataCategoria();
        public void InsUpdCategoria(string[] str)
        {
            dataCategoria.InsUpdCategoriaBD(str);
        }
        public DataTable ListCategoria()
        {
            return dataCategoria.retoCate();
        }
        public void RellenarCmbCategoria()
        {
            dataCategoria.RellenarCmbCategoria();
        }
    }
}
