using SNRegistros.Aplicacion.Dto;
using SNRegistros.Dominio.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SNRegistros.Dominio.Managers
{
    public class CiudadanosManagers
    {
        public List<CiudadanoDto> Listado()
        {
            using (var context = new SNRegistroModel())
            {
                var listado = context.Ciudadanos
                    .Select(s => new CiudadanoDto()
                    {
                        CiudadanoID = s.CiudadanoID,
                        Nombre = s.Nombre,
                        Apellido = s.Apellido
                    }).ToList();
                return listado;
            }
        }

       
    }
}
