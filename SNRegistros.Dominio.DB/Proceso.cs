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
    
    public partial class Proceso
    {
        public Proceso()
        {
            this.Acciones = new HashSet<Accione>();
        }
    
        public int ProcesoID { get; set; }
        public string Nombre { get; set; }
    
        public virtual ICollection<Accione> Acciones { get; set; }
    }
}
