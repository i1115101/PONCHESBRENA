using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidad;

namespace LogicaNegocio
{
    public class LogicaDashboard
    {
        public void Dashboard(EntidadDashboard obj)
        {
            DataDashboard accesDB = new DataDashboard();
            accesDB.ProdPorCategoria(obj);
            accesDB.ProdPreferidos(obj);
            accesDB.SumarioDatos(obj);


        }

    }
}
