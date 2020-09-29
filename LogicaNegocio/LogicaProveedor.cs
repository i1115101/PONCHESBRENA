using AccesoDatos;
using System.Data;

namespace LogicaNegocio
{
    public class LogicaProveedor
    {
        public DataProveedor dataProveedor = new DataProveedor();
        public string InsActProveedor(string[] str)
        {
            return dataProveedor.InsActProveedorBD(str);
        }

        //public bool ActualizarProveedor(int IdProveedor, int IdTipoDocumento, string NroDocumento, string RazonSocial, string Direccion, string Telefono,
        //    string Web, string Email)
        //{
        //    bool resultado = false;
        //    resultado = dataProveedor.ActualizarProveedorBD(IdProveedor, IdTipoDocumento, NroDocumento, RazonSocial, Direccion, Telefono, Web, Email);
        //    return resultado;
        //}
        public DataTable ListProveedor()
        {
            return dataProveedor.retoprov();
        }
        public void MostrarProveedor()
        {
            dataProveedor.MostrarProveedor();
        }
    }
}
