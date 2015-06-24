using SNRegistros.Aplicacion.Dto;
using SNRegistros.Dominio.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNRegistros.Dominio.Managers
{
    public class ProcesosManagers
    {
        public List<ProcesoDto> Listado()
        {
            using (var context = new SNRegistroEntities())
            {
                var listado = context.Procesos
                    .Select(s => new ProcesoDto()
                    {
                        ProcesoID=s.ProcesoID,
                        Nombre = s.Nombre,
                        //CiudadID = s.CiudadID
                    }).ToList();
                return listado;
            }
        }
    }
}
