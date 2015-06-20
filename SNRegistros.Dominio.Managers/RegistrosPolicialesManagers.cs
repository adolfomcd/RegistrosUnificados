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
   public class RegistrosPolicialesManagers
    {
        public List<RegistrosPolicialeDto> ListadoRegistroPolicial()
        {
            using (var context = new SNRegistroModel())
            {
                var listado = context.RegistrosPoliciales
                    .Select(s => new RegistrosPolicialeDto()
                    {
                        RegistroPolicialID = s.RegistroPolicialID,
                        Policia = new PoliciaDto()
                        {
                            PoliciaID = s.PoliciaID,
                            Nombre = s.Policia.Nombre,
                            Apellido = s.Policia.Apellido
                        },
                        Ciudadano = new CiudadanoDto()
                        {
                            CiudadanoID = s.CiudadanoID,
                            Nombre = s.Ciudadano.Nombre
                        },
                        Comisaria = new ComisariaDto()
                        {
                            ComisariaID = s.ComisariaID,
                            Nombre = s.Comisaria.Nombre
                        },
                        AccionesPoliciale = new AccionesPolicialeDto()
                        {
                            AccPolID = s.AccPolID,
                            NombreAP = s.AccionesPoliciale.NombreAP,
                            ProcesosPoliciale = new ProcesosPolicialeDto()
                            {
                                ProcesoPolicialID = s.AccionesPoliciale.ProcesoPolicialID,
                                NombrePP = s.AccionesPoliciale.ProcesosPoliciale.NombrePP
                            }
                        },
                        Comentario = s.Comentario
                    }).ToList();
                return listado;
            }
        }

        public MensajeDto CargarRegistroPolicial(RegistrosPolicialeDto mDto)
        {
            if (mDto.RegistroPolicialID > 0)
            {
                return EditarMovimiento(mDto);
            }
            using (var context = new SNRegistroModel())
            {
                MensajeDto mensajeDto = null;
                var RegistroPolicialDb = new RegistrosPoliciale();
                RegistroPolicialDb.CiudadanoID = mDto.Ciudadano.CiudadanoID;
                RegistroPolicialDb.PoliciaID = mDto.Policia.PoliciaID;
                RegistroPolicialDb.ComisariaID = mDto.Comisaria.ComisariaID;
                RegistroPolicialDb.ComisariaID = mDto.AccionesPoliciale.AccPolID;
                RegistroPolicialDb.Comentario = mDto.Comentario;

                context.RegistrosPoliciales.Add(RegistroPolicialDb);
                mensajeDto = AgregarModificar.Hacer(context, mensajeDto);
                if (mensajeDto != null) { return mensajeDto; }
                mDto.RegistroPolicialID = RegistroPolicialDb.RegistroPolicialID;

                return new MensajeDto()
                {
                    Error = false,
                    MensajeDelProceso = "Se cargo el movimiento : " + RegistroPolicialDb.RegistroPolicialID,
                    ObjetoDto = mDto
                };
            }
        }

        private MensajeDto EditarMovimiento(RegistrosPolicialeDto mDto)
        {
            using (var context = new SNRegistroModel())
            {
                MensajeDto mensajeDto = null;
                var movimientoDb = context.RegistrosPoliciales
                    .Where(m => m.RegistroPolicialID == mDto.RegistroPolicialID)
                    .First();
                //Se actualiza
                movimientoDb.CiudadanoID = mDto.Ciudadano.CiudadanoID;
                movimientoDb.PoliciaID = mDto.Policia.PoliciaID;
                movimientoDb.ComisariaID = mDto.Comisaria.ComisariaID;
                movimientoDb.ComisariaID = mDto.AccionesPoliciale.AccPolID;
                movimientoDb.Comentario = mDto.Comentario;
                //da la orden de actualizacion al EF
                context.Entry(movimientoDb).State = System.Data.Entity.EntityState.Modified;
                mensajeDto = AgregarModificar.Hacer(context, mensajeDto);
                if (mensajeDto != null) { return mensajeDto; }
                return new MensajeDto()
                {
                    Error = false,
                    MensajeDelProceso = "Se Edito el movimiento : " + mDto.RegistroPolicialID,
                    ObjetoDto = mDto
                };

            }
        }

        public MensajeDto EliminarMovimiento(int id)
        {
            using (var context = new SNRegistroModel())
            {
                MensajeDto mensajeDto = null;
                var movimientoDb = context.RegistrosPoliciales
                    .Where(m => m.RegistroPolicialID == id)
                    .First();

                context.RegistrosPoliciales.Remove(movimientoDb);
                mensajeDto = AgregarModificar.Hacer(context, mensajeDto);
                if (mensajeDto != null) { return mensajeDto; }

                return new MensajeDto()
                {
                    Error = false,
                    MensajeDelProceso = "Se elimino el movimiento : " + movimientoDb.RegistroPolicialID
                };
            }
        }
    }
}
