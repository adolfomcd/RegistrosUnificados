namespace SNRegistros.Dominio.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProcesosPoliciale
    {
        public ProcesosPoliciale()
        {
            AccionesPoliciales = new HashSet<AccionesPoliciale>();
        }

        [Key]
        public int ProcesoPolicialID { get; set; }

        [Required]
        [StringLength(50)]
        public string NombrePP { get; set; }

        public virtual ICollection<AccionesPoliciale> AccionesPoliciales { get; set; }
    }
}
