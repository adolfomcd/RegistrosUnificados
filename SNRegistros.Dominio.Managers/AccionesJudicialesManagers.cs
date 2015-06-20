using SNRegistros.Aplicacion.Dto;
using SNRegistros.Dominio.DB;
using SNRegistros.Dominio.Managers.Utilidadades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SNRegistros.Dominio.Managers
{
    public class AccionesJudicialesManagers
    {
    public List<AccionesJudicialeDto> ListadoAccionesJudiciales()
        {
            using (var context = new SNRegistroModel())
            {
                var listado = context.AccionesJudiciales
                    .Select(s => new AccionesJudicialeDto()
                    {
                        AccJudID = s.AccJudID,
                        NombreAJ = s.NombreAJ,
                        //CiudadID = s.CiudadID
                    }).ToList();
                return listado;
            }
        }
    public List<AccionesJudicialeDto> ListadoAccionesJudiciales(int ProcesoJudID)
        {
            using (var context = new SNRegistroModel())
            {
                var listado = context.AccionesJudiciales
                    .Where(t => t.ProcesoJudID == ProcesoJudID)
                    .Select(s => new AccionesJudicialeDto()
                    {
                        AccJudID = s.AccJudID,
                        NombreAJ = s.NombreAJ,
                        ProcesosJudiciale = new ProcesosJudicialeDto()
                        {
                            ProcesoJudID = s.ProcesoJudID,
                            NombreProcJud = s.ProcesosJudiciale.NombreProcJud
                        }
                    }).ToList();
                return listado;
            }
        }
        
    }
}
