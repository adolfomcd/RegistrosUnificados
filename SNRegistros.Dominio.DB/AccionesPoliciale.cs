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
    
    public partial class AccionesPoliciale
    {
        public AccionesPoliciale()
        {
            this.RegistrosPoliciales = new HashSet<RegistrosPoliciale>();
        }
    
        public int AccPolID { get; set; }
        public string NombreAP { get; set; }
        public int ProcesoPolicialID { get; set; }
    
        public virtual ProcesosPoliciale ProcesosPoliciale { get; set; }
        public virtual ICollection<RegistrosPoliciale> RegistrosPoliciales { get; set; }
    }
}
