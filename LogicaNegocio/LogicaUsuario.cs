using AccesoDatos;
using Entidad.Cache;

namespace LogicaNegocio
{
    public class LogicaUsuario
    {
        DataUsuario dataUsuario = new DataUsuario();
        public bool LoginUser(string Usuario, string Clave)
        {
            return dataUsuario.Login(Usuario, Clave);
        }

        public void AnyMethod()
        {
            //seguridad y permisos
            if (EUserLoginCache.cCargo == ECargos.Administrador)
            {

            }
            if (EUserLoginCache.cCargo == ECargos.Cajero || EUserLoginCache.cCargo == ECargos.Gerente)
            {

            }
        }
    }
}
