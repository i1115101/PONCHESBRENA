using Entidad.Cache;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Data;

namespace AccesoDatos
{
    public class DataUsuario
    {
        Conexion ConexionDB = new Conexion();
        DataEmpleado empleado = new DataEmpleado();
        DataTable empl;

        public bool Login(string Usuario, string Clave)
        {
            empl = empleado.retoEmpl();
            int afirmacion=0;
            for (int i = 0; i < empl.Rows.Count; i++)
            {
                if (Usuario == Convert.ToString(empl.Rows[i]["cUsuario"]) && Clave == Convert.ToString(empl.Rows[i]["cClave"]))
                {
                    EUserLoginCache.nIdEmpleado = Convert.ToInt32(empl.Rows[i]["nIdEmpleado"]);
                    EUserLoginCache.cNombre = Convert.ToString(empl.Rows[i]["cNombre"]);
                    EUserLoginCache.cApellidos = Convert.ToString(empl.Rows[i]["cApellidos"]);
                    EUserLoginCache.cUsuario = Convert.ToString(empl.Rows[i]["cUsuario"]);
                    EUserLoginCache.cCargo = Convert.ToString(empl.Rows[i]["cCargo"]);
                    afirmacion = 1;
                    i= empl.Rows.Count;
                }
            }
            if (afirmacion == 1) return true;
            else return false;            
        }
        public void AnyMethod()
        {
            if (EUserLoginCache.cCargo == ECargos.Administrador)
            {

            }
            if (EUserLoginCache.cCargo == ECargos.Cajero || EUserLoginCache.cCargo == ECargos.Gerente)
            {

            }
        }
    }
}
