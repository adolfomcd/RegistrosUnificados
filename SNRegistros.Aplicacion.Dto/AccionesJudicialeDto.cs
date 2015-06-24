using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNRegistros.Aplicacion.Dto
{
    public class AccionesJudicialeDto
    {
        public int AccJudID { get; set; }

        
        public string NombreAJ { get; set; }

        public ProcesosJudicialeDto ProcesosJudiciale { get; set; }
    }
}
