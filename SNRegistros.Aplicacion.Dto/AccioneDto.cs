using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNRegistros.Aplicacion.Dto
{
   public class AccioneDto
    {
       
        public int AccionID { get; set; }

       
        public string Nombre { get; set; }

        public ProcesoDto Proceso { get; set; }
    }
}
