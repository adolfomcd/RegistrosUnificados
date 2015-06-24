using SNRegistros.Aplicacion.Dto;
using SNRegistros.Dominio.DB;
using SNRegistros.Dominio.Managers.Utilidadades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNRegistros.Dominio.Managers {
    public class RegistrosMedicosManagers {
        public List<RegistroMedicoDto> ListadoRegistroMedico() {
            using (var context = new SNRegistroEntities()) {
                var listado = context.RegistrosMedicos
                    .Select(s => new RegistroMedicoDto() {
                        RegistroMedicoID = s.RegistroMedicoID,
                        Doctore = new DoctoreDto() {
                            MedicoID = s.MedicoID,
                            Nombre = s.Doctore.Nombre,
                            Apellido = s.Doctore.Apellido
                        },
                        Ciudadano = new CiudadanoDto() {
                            CiudadanoID = s.Ciudadanoid,
                            Nombre = s.Ciudadano.Nombre
                        },
                        Hospitale = new HospitaleDto() {
                            HospitalID = s.HospitalID,
                            Nombre = s.Hospitale.Nombre
                        },
                        Accione = new AccioneDto() {
                            AccionID = s.AccionID,
                            Nombre = s.Accione.Nombre,
                            Proceso = new ProcesoDto() {
                                ProcesoID = s.Accione.ProcesoID,
                                Nombre = s.Accione.Proceso.Nombre
                            }
                        },
                        Comentario = s.Comentario
                    }).ToList();
                return listado;
            }
        }

        public MensajeDto CargarRegistroMedico(RegistroMedicoDto mDto) {
            if (mDto.RegistroMedicoID > 0) {
                return EditarMovimiento(mDto);
            }
            using (var context = new SNRegistroEntities()) {
                MensajeDto mensajeDto = null;
                var RegistroMedicoDb = new RegistrosMedico();
                RegistroMedicoDb.Ciudadanoid = mDto.Ciudadano.CiudadanoID;
                RegistroMedicoDb.MedicoID = mDto.Doctore.MedicoID;
                RegistroMedicoDb.HospitalID = mDto.Hospitale.HospitalID;
                RegistroMedicoDb.AccionID = mDto.Accione.AccionID;
                RegistroMedicoDb.Comentario = mDto.Comentario;
                RegistroMedicoDb.Momento = DateTime.Now;

                context.RegistrosMedicos.Add(RegistroMedicoDb);
                mensajeDto = AgregarModificar.Hacer(context, mensajeDto);
                if (mensajeDto != null) { return mensajeDto; }
                mDto.RegistroMedicoID = RegistroMedicoDb.RegistroMedicoID;

                return new MensajeDto() {
                    Error = false,
                    MensajeDelProceso = "Se cargo el movimiento : " + RegistroMedicoDb.RegistroMedicoID,
                    ObjetoDto = mDto
                };
            }
        }

        private MensajeDto EditarMovimiento(RegistroMedicoDto mDto) {
            using (var context = new SNRegistroEntities()) {
                MensajeDto mensajeDto = null;
                var movimientoDb = context.RegistrosMedicos
                    .Where(m => m.RegistroMedicoID == mDto.RegistroMedicoID)
                    .First();
                //Se actualiza
                movimientoDb.MedicoID = mDto.Doctore.MedicoID;
                movimientoDb.Ciudadanoid = mDto.Ciudadano.CiudadanoID;
                movimientoDb.HospitalID = mDto.Hospitale.HospitalID;
                movimientoDb.AccionID = mDto.Accione.AccionID;
                movimientoDb.Comentario = mDto.Comentario;
                //da la orden de actualizacion al EF
                context.Entry(movimientoDb).State = System.Data.Entity.EntityState.Modified;
                mensajeDto = AgregarModificar.Hacer(context, mensajeDto);
                if (mensajeDto != null) { return mensajeDto; }
                return new MensajeDto() {
                    Error = false,
                    MensajeDelProceso = "Se Edito el movimiento : " + mDto.RegistroMedicoID,
                    ObjetoDto = mDto
                };

            }
        }

        public MensajeDto EliminarMovimiento(int id) {
            using (var context = new SNRegistroEntities()) {
                MensajeDto mensajeDto = null;
                var movimientoDb = context.RegistrosMedicos
                    .Where(m => m.RegistroMedicoID == id)
                    .First();

                context.RegistrosMedicos.Remove(movimientoDb);
                mensajeDto = AgregarModificar.Hacer(context, mensajeDto);
                if (mensajeDto != null) { return mensajeDto; }

                return new MensajeDto() {
                    Error = false,
                    MensajeDelProceso = "Se elimino el movimiento : " + movimientoDb.RegistroMedicoID
                };
            }
        }

        public MensajeDto ListadoRegistroMedico(RegistroMedicoDto rDto) {
            using (var context = new SNRegistroEntities()) {
                var listado = context.RegistrosMedicos
                         .Select(s => new RegistroMedicoDto() {
                             RegistroMedicoID = s.RegistroMedicoID,
                             Doctore = new DoctoreDto() {
                                 MedicoID = s.MedicoID,
                                 Nombre = s.Doctore.Nombre,
                                 Apellido = s.Doctore.Apellido
                             },
                             Ciudadano = new CiudadanoDto() {
                                 CiudadanoID = s.Ciudadanoid,
                                 Nombre = s.Ciudadano.Nombre
                             },
                             Hospitale = new HospitaleDto() {
                                 HospitalID = s.HospitalID,
                                 Nombre = s.Hospitale.Nombre
                             },
                             Accione = new AccioneDto() {
                                 AccionID = s.AccionID,
                                 Nombre = s.Accione.Nombre,
                                 Proceso = new ProcesoDto() {
                                     ProcesoID = s.Accione.ProcesoID,
                                     Nombre = s.Accione.Proceso.Nombre
                                 }
                             },
                             Comentario = s.Comentario
                         }).AsQueryable();

                if (rDto.Ciudadano != null) {
                    listado = listado
                        .Where(s => s.Ciudadano.CiudadanoID == rDto.Ciudadano.CiudadanoID);
                }

                return new MensajeDto() {
                    Error = false,
                    MensajeDelProceso = "Listado generado: " ,
                    ObjetoDto = listado.ToList()                    
                };
            }
        }

        public MensajeDto EliminarRegistroMedico(int id)
        {
            using (var context = new SNRegistroEntities())
            {
                MensajeDto mensajeDto = null;
                var registroMedicoDb = context.RegistrosMedicos
                    .Where(s => s.RegistroMedicoID == id)
                    .First();

                context.RegistrosMedicos.Remove(registroMedicoDb);
                mensajeDto = AgregarModificar.Hacer(context, mensajeDto);
                if (mensajeDto != null) { return mensajeDto; }

                return new MensajeDto()
                {
                    Error = false,
                    MensajeDelProceso = "Se elimino el registro medico : " + id
                };
            }
        }
    }
}
