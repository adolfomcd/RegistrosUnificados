//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SNRegistros.Dominio.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hospitale
    {
        public Hospitale()
        {
            this.RegistrosMedicos = new HashSet<RegistrosMedico>();
        }
    
        public int HospitalID { get; set; }
        public string Nombre { get; set; }
        public int CiudadID { get; set; }
    
        public virtual Ciudadade Ciudadade { get; set; }
        public virtual ICollection<RegistrosMedico> RegistrosMedicos { get; set; }
    }
}
