using SNRegistros.Aplicacion.Dto;
using SNRegistros.Dominio.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNRegistros.Dominio.Managers
{
    public class ProcesosJudicialesManagers
    {
        public List<ProcesosJudicialeDto> Listado()
        {
            using (var context = new SNRegistroEntities())
            {
                var listado = context.ProcesosJudiciales
                    .Select(s => new ProcesosJudicialeDto()
                    {
                        ProcesoJudID = s.ProcesoJudID,
                        NombreProcJud = s.NombreProcJud
                        //CiudadID = s.CiudadID
                    }).ToList();
                return listado;
            }
        }
    
    }
}
