using SNRegistros.Aplicacion.Dto;
using SNRegistros.Dominio.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNRegistros.Dominio.Managers
{
    public class AccionesPolicialesManagers
    {
        public List<AccionesPolicialeDto> ListadoAccionesPoliciales()
        {
            using (var context = new SNRegistroModel())
            {
                var listado = context.AccionesPoliciales
                    .Select(s => new AccionesPolicialeDto()
                    {
                        AccPolID = s.AccPolID,
                        NombreAP = s.NombreAP,
                        //CiudadID = s.CiudadID
                    }).ToList();
                return listado;
            }
        }
        public List<AccionesPolicialeDto> ListadoAccionesPoliciales(int ProcesoPolicialID)
        {
            using (var context = new SNRegistroModel())
            {
                var listado = context.AccionesPoliciales
                    .Where(t => t.ProcesoPolicialID == ProcesoPolicialID)
                    .Select(s => new AccionesPolicialeDto()
                    {
                        AccPolID = s.AccPolID,
                        NombreAP = s.NombreAP,
                        ProcesosPoliciale = new ProcesosPolicialeDto()
                        {
                            ProcesoPolicialID = s.ProcesoPolicialID,
                            
                           NombrePP= s.ProcesosPoliciale.NombrePP
                        }
                    }).ToList();
                return listado;
            }
        }
        
    }
    }


