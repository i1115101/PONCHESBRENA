using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using System.Data.SqlClient;
using System.Data;

namespace LogicaNegocio
{
    public class LogicaEmpleado
    {
        public  DataEmpleado dataEmpleado = new DataEmpleado();        
        public void InsAtcEmpleado(string[] str)
        {
            dataEmpleado.InsActEmpleadoBD(str);
        }

        public void MostrarEmpleado()
        {
            dataEmpleado.MostrarEmpleado();            
        }

        public DataTable retorEmple()
        {
            return dataEmpleado.retoEmpl();
        }
    }
}
