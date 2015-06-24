using SNRegistros.Aplicacion.Dto;
using SNRegistros.Dominio.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNRegistros.Dominio.Managers
{
    public class PoliciasManagers
    {
        public List<PoliciaDto> Listado()
        {
            using (var context = new SNRegistroEntities())
            {
                var listado = context.Policias
                    .Select(s => new PoliciaDto()
                    {
                        PoliciaID = s.PoliciaID,
                        Nombre = s.Nombre,
                        Apellido = s.Apellido
                    }).ToList();
                return listado;
            }
        }
    }
}
