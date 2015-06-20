using SNRegistros.Aplicacion.Dto;
using SNRegistros.Dominio.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNRegistros.Dominio.Managers
{
    public class ComisariasManagers
    {
        public List<ComisariaDto> Listado()
        {
            using (var context = new SNRegistroModel())
            {
                var listado = context.Comisarias
                    .Select(s => new ComisariaDto()
                    {
                        ComisariaID = s.ComisariaID,
                        Nombre = s.Nombre,
                        CiudadID = s.CiudadID
                    }).ToList();
                return listado;
            }
        }
    
    }
}
