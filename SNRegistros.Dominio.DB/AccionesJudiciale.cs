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
    
    public partial class AccionesJudiciale
    {
        public AccionesJudiciale()
        {
            this.RegistrosJudiciales = new HashSet<RegistrosJudiciale>();
        }
    
        public int AccJudID { get; set; }
        public string NombreAJ { get; set; }
        public int ProcesoJudID { get; set; }
    
        public virtual ProcesosJudiciale ProcesosJudiciale { get; set; }
        public virtual ICollection<RegistrosJudiciale> RegistrosJudiciales { get; set; }
    }
}