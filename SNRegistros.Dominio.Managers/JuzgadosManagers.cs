using SNRegistros.Aplicacion.Dto;
using SNRegistros.Dominio.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNRegistros.Dominio.Managers
{
    public class JuzgadosManagers
    {
        public List<JuzgadoDto> ListadoJuzgados()
        {
            using (var context = new SNRegistroEntities())
            {
                var listado = context.Juzgados
                    .Select(s => new JuzgadoDto()
                    {
                        JuzgadoID = s.JuzgadoID,
                        Nombre = s.Nombre,
                        CiudadID = s.CiudadID
                    }).ToList();
                return listado;
            }
        }
    }
}
