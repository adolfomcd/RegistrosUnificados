namespace SNRegistros.Dominio.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AccionesJudiciale
    {
        public AccionesJudiciale()
        {
            RegistrosJudiciales = new HashSet<RegistrosJudiciale>();
        }

        [Key]
        public int AccJudID { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreAJ { get; set; }

        public int ProcesoJudID { get; set; }

        public virtual ProcesosJudiciale ProcesosJudiciale { get; set; }

        public virtual ICollection<RegistrosJudiciale> RegistrosJudiciales { get; set; }
    }
}
