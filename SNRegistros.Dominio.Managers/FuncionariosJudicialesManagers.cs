using SNRegistros.Aplicacion.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SNRegistros.Dominio.DB;
namespace SNRegistros.Dominio.Managers
{
    public class FuncionariosJudicialesManagers
    {
        public List<FuncionariosJudicialesDto> Listado()
        {
            using (var context = new SNRegistroEntities())
            {
                var listado = context.FuncionariosJudiciales
                    .Select(s => new FuncionariosJudicialesDto()
                    {
                        FuncJudicialId = s.FuncJudicialId,
                        Nombre = s.Nombre,
                        Apellido = s.Apellido
                    }).ToList();
                return listado;
            }        
        }
    }
    }

