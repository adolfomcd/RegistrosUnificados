using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNRegistros.Aplicacion.Dto
{
    public class RegistroMedicoDto
    {
        public int RegistroMedicoID { get; set; }
        
        public  CiudadanoDto Ciudadano { get; set; }

        public  DoctoreDto Doctore { get; set; }

        public  HospitaleDto Hospitale { get; set; }

        public ProcesoDto Proceso { get; set; }
        public AccioneDto Accione { get; set; }
        public string Comentario { get; set; }
    }
}
