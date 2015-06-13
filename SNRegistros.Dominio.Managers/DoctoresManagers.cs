using SNRegistros.Aplicacion.Dto;
using SNRegistros.Dominio.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNRegistros.Dominio.Managers
{
    public class DoctoresManagers
    {
        public List<DoctoreDto> Listado() {
            using (var context = new SNRegistroModel())
            {
                var listado = context.Doctores
                    .Select(s => new DoctoreDto()
                    {
                        MedicoID = s.MedicoID,
                        Nombre = s.Nombre,
                        Apellido = s.Apellido
                    }).ToList();
                return listado;
            }        
        }
    }
}
