using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNRegistros.Aplicacion.Dto
{
   public  class RegistrosJudicialeDto
    {
        public int RegistroJudicialID { get; set; }

        public CiudadanoDto Ciudadano { get; set; }

        public FuncionariosJudicialesDto FuncionariosJudiciale { get; set; }

        public JuzgadoDto Juzgado { get; set; }

        public AccionesJudicialeDto AccionesJudiciale { get; set; }

       
        public string Comentario { get; set; }
    }
}
