using SNRegistros.Aplicacion.Dto;
using SNRegistros.Dominio.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNRegistros.Dominio.Managers
{
   public class HospitalesManagers
    {
        public List<HospitaleDto> Listado()
        {
            using (var context = new SNRegistroEntities())
            {
                var listado = context.Hospitales
                    .Select(s => new HospitaleDto()
                    {
                        HospitalID = s.HospitalID,
                        Nombre = s.Nombre,
                        CiudadID = s.CiudadID
                    }).ToList();
                return listado;
            }
        }
    }
}
