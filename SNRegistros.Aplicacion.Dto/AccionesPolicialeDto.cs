using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNRegistros.Aplicacion.Dto
{
    public class AccionesPolicialeDto
    {
        public int AccPolID { get; set; }

   
        public string NombreAP { get; set; }

        public ProcesosPolicialeDto ProcesosPoliciale { get; set; }
    }
}
