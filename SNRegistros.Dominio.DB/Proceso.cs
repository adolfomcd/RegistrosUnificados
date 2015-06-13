namespace SNRegistros.Dominio.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Procesos")]
    public partial class Proceso
    {
        public Proceso()
        {
            Acciones = new HashSet<Accione>();
        }

        public int ProcesoID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public virtual ICollection<Accione> Acciones { get; set; }
    }
}
