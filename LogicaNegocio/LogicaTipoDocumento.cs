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
   public class LogicaTipoDocumento
    {        
       public DataTipoDocumento dataTipoDocumento = new DataTipoDocumento();
        public void InsUpdDocumento(string[] str)
        {
            dataTipoDocumento.InsUpdDocumentoBD(str);
        }
        public void desabDocumento(int num)
        {
            dataTipoDocumento.DesabDocumentoBD(num);
        }
        
        public void MostrarTipoDocumento()
        {
            dataTipoDocumento.MostrarTipoDocumento();            
        }

        public void MostrarDocEnt()
        {
            dataTipoDocumento.MostarDocEntrada();
        }

        public DataTable ListDocEnt()
        {
            return dataTipoDocumento.retDocEnt();
        }

        public DataTable ListDocumentos()
        {
            return dataTipoDocumento.retoDocu();
        }
    }
}
