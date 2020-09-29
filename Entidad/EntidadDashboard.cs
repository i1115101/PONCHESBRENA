using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Entidad
{
   public class EntidadDashboard
    {
        ArrayList Categoria = new ArrayList();
        ArrayList CantProd = new ArrayList();
        ArrayList Producto = new ArrayList();
        ArrayList Cant = new ArrayList();

      string TotalVentas;
        string CantProductos;
        string CantCateg;
        string CantEmple;
        string CantProv;
        string CantClient;

        public ArrayList Categoria1 { get => Categoria; set => Categoria = value; }
        public ArrayList CantProd1 { get => CantProd; set => CantProd = value; }
        public ArrayList Producto1 { get => Producto; set => Producto = value; }
        public ArrayList Cant1 { get => Cant; set => Cant = value; }
        public string TotalVentas1 { get => TotalVentas; set => TotalVentas = value; }
        public string CantProductos1 { get => CantProductos; set => CantProductos = value; }
        public string CantCateg1 { get => CantCateg; set => CantCateg = value; }
        public string CantEmple1 { get => CantEmple; set => CantEmple = value; }
        public string CantProv1 { get => CantProv; set => CantProv = value; }
        public string CantClient1 { get => CantClient; set => CantClient = value; }
    }
}
