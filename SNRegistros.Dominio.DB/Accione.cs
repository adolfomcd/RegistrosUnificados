namespace SNRegistros.Dominio.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Accione
    {
        public Accione()
        {
            RegistrosMedicos = new HashSet<RegistrosMedico>();
        }

        [Key]
        public int AccionID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public int ProcesoID { get; set; }

        public virtual Proceso Proceso { get; set; }

        public virtual ICollection<RegistrosMedico> RegistrosMedicos { get; set; }
    }
}
