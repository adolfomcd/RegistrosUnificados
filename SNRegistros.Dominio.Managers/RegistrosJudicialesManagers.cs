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
   public class RegistrosJudicialesManagers
    {
       public List<RegistrosJudicialeDto> ListadoRegistroMedico()
        {
            using (var context = new SNRegistroEntities())
            {
                var listado = context.RegistrosJudiciales
                    .Select(s => new RegistrosJudicialeDto()
                    {
                        RegistroJudicialID = s.RegistroJudicialID,
                        FuncionariosJudiciale = new FuncionariosJudicialesDto()
                        {
                            FuncJudicialId = s.FuncJudicialId,
                            Nombre = s.FuncionariosJudiciale.Nombre,
                            Apellido = s.FuncionariosJudiciale.Apellido
                        },
                        Ciudadano = new CiudadanoDto()
                        {
                            CiudadanoID = s.CiudadanoID,
                            Nombre = s.Ciudadano.Nombre
                        },
                        Juzgado = new JuzgadoDto()
                        {
                            JuzgadoID = s.JuzgadoID,
                            Nombre = s.Juzgado.Nombre
                        },
                        AccionesJudiciale = new AccionesJudicialeDto()
                        {
                            AccJudID = s.AccJudID,
                            NombreAJ = s.AccionesJudiciale.NombreAJ,
                            ProcesosJudiciale = new ProcesosJudicialeDto()
                            {
                                ProcesoJudID = s.AccionesJudiciale.ProcesoJudID,
                               NombreProcJud = s.AccionesJudiciale.ProcesosJudiciale.NombreProcJud
                            }
                        },
                        Comentario = s.Comentario
                    }).ToList();
                return listado;
            }
        }

        public MensajeDto CargarRegistroJudicial(RegistrosJudicialeDto mDto)
        {
            if (mDto.RegistroJudicialID > 0)
            {
                return EditarMovimiento(mDto);
            }
            using (var context = new SNRegistroEntities())
            {
                MensajeDto mensajeDto = null;
                var RegistroJudicialDb = new RegistrosJudiciale();
                RegistroJudicialDb.CiudadanoID = mDto.Ciudadano.CiudadanoID;
                RegistroJudicialDb.FuncJudicialId = mDto.FuncionariosJudiciale.FuncJudicialId;
                RegistroJudicialDb.JuzgadoID = mDto.Juzgado.JuzgadoID;
                RegistroJudicialDb.AccJudID= mDto.AccionesJudiciale.AccJudID;
                RegistroJudicialDb.Comentario = mDto.Comentario;

                context.RegistrosJudiciales.Add(RegistroJudicialDb);
                mensajeDto = AgregarModificar.Hacer(context, mensajeDto);
                if (mensajeDto != null) { return mensajeDto; }
                mDto.RegistroJudicialID = RegistroJudicialDb.RegistroJudicialID;

                return new MensajeDto()
                {
                    Error = false,
                    MensajeDelProceso = "Se cargo el movimiento : " + RegistroJudicialDb.RegistroJudicialID,
                    ObjetoDto = mDto
                };
            }
        }

        private MensajeDto EditarMovimiento(RegistrosJudicialeDto mDto)
        {
            using (var context = new SNRegistroEntities())
            {
                MensajeDto mensajeDto = null;
                var judicialDb = context.RegistrosJudiciales
                    .Where(m => m.RegistroJudicialID == mDto.RegistroJudicialID)
                    .First();
                //Se actualiza
                judicialDb.CiudadanoID = mDto.Ciudadano.CiudadanoID;
                judicialDb.FuncJudicialId = mDto.FuncionariosJudiciale.FuncJudicialId;
                judicialDb.JuzgadoID = mDto.Juzgado.JuzgadoID;
                judicialDb.AccJudID = mDto.AccionesJudiciale.AccJudID;
                judicialDb.Comentario = mDto.Comentario;
                //da la orden de actualizacion al EF
                context.Entry(judicialDb).State = System.Data.Entity.EntityState.Modified;
                mensajeDto = AgregarModificar.Hacer(context, mensajeDto);
                if (mensajeDto != null) { return mensajeDto; }
                return new MensajeDto()
                {
                    Error = false,
                    MensajeDelProceso = "Se Edito el movimiento : " + mDto.RegistroJudicialID,
                    ObjetoDto = mDto
                };

            }
        }

        public MensajeDto EliminarMovimiento(int id)
        {
            using (var context = new SNRegistroEntities())
            {
                MensajeDto mensajeDto = null;
                var movimientoDb = context.RegistrosJudiciales
                    .Where(m => m.RegistroJudicialID == id)
                    .First();

                context.RegistrosJudiciales.Remove(movimientoDb);
                mensajeDto = AgregarModificar.Hacer(context, mensajeDto);
                if (mensajeDto != null) { return mensajeDto; }

                return new MensajeDto()
                {
                    Error = false,
                    MensajeDelProceso = "Se elimino el movimiento : " + movimientoDb.RegistroJudicialID
                };
            }
        }
    }
}
