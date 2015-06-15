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

        public MensajeDto CargarCiudadano(CiudadanoDto cDto)
        {
            using (var context = new SNRegistroModel())
            {
                MensajeDto mensajeDto = null;
                var CiudadanoDB = new Ciudadano();
                CiudadanoDB.Nombre = cDto.Nombre;

                context.Ciudadanos.Add(CiudadanoDB);
                mensajeDto = AgregarModificar.Hacer(context, mensajeDto);
                if (mensajeDto != null) { return mensajeDto; }
                cDto.CiudadanoID = CiudadanoDB.CiudadanoID;

                return new MensajeDto()
                {
                    Error = false,
                    MensajeDelProceso = "Se cargo el Doctor : " + cDto.CiudadanoID,
                    ObjetoDto = cDto
                };
            }
        }
    }
}
