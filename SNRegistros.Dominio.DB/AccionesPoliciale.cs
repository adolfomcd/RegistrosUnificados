namespace SNRegistros.Dominio.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AccionesPoliciale
    {
        public AccionesPoliciale()
        {
            RegistrosPoliciales = new HashSet<RegistrosPoliciale>();
        }

        [Key]
        public int AccPolID { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreAP { get; set; }

        public int ProcesoPolicialID { get; set; }

        public virtual ProcesosPoliciale ProcesosPoliciale { get; set; }

        public virtual ICollection<RegistrosPoliciale> RegistrosPoliciales { get; set; }
    }
}
