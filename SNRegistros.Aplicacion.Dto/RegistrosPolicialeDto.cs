using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNRegistros.Aplicacion.Dto
{
   public class RegistrosPolicialeDto
    {
        public int RegistroPolicialID { get; set; }

        public CiudadanoDto Ciudadano { get; set; }

        public PoliciaDto Policia { get; set; }

        public ComisariaDto Comisaria { get; set; }

        public AccionesPolicialeDto AccionesPoliciale { get; set; }

        
        public string Comentario { get; set; }
    }
}
