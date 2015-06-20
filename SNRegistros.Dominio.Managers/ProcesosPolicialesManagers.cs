using SNRegistros.Aplicacion.Dto;
using SNRegistros.Dominio.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNRegistros.Dominio.Managers
{
   public class ProcesosPolicialesManagers
    {
       public List<ProcesosPolicialeDto> Listado()
       {
           using (var context = new SNRegistroModel())
           {
               var listado = context.ProcesosPoliciales
                   .Select(s => new ProcesosPolicialeDto()
                   {
                       ProcesoPolicialID = s.ProcesoPolicialID,
                       NombrePP = s.NombrePP
                       //CiudadID = s.CiudadID
                   }).ToList();
               return listado;
           }
       }
    
    }
}
