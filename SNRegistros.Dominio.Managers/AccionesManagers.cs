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
    public class AccionesManagers
    {
        public List<AccioneDto> ListadoAcciones()
        {
            using (var context = new SNRegistroModel())
            {
                var listado = context.Acciones
                    .Select(s => new AccioneDto()
                    {
                        AccionID = s.AccionID,
                        Nombre = s.Nombre,
                        //CiudadID = s.CiudadID
                    }).ToList();
                return listado;
            }
        }
        public List<AccioneDto> ListadoAcciones(int ProcesoID)
        {
            using (var context = new SNRegistroModel())
            {
                var listado = context.Acciones
                    .Where(t => t.ProcesoID == ProcesoID)
                    .Select(s => new AccioneDto()
                    {
                        AccionID = s.AccionID,
                        Nombre = s.Nombre,
                        Proceso = new ProcesoDto()
                        {
                            ProcesoID = s.ProcesoID,
                            Nombre = s.Proceso.Nombre
                        }
                    }).ToList();
                return listado;
            }
        }
        
    }
}
