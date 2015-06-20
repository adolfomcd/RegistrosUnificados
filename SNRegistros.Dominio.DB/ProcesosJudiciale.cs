namespace SNRegistros.Dominio.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProcesosJudiciale
    {
        public ProcesosJudiciale()
        {
            AccionesJudiciales = new HashSet<AccionesJudiciale>();
        }

        [Key]
        public int ProcesoJudID { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreProcJud { get; set; }

        public virtual ICollection<AccionesJudiciale> AccionesJudiciales { get; set; }
    }
}
