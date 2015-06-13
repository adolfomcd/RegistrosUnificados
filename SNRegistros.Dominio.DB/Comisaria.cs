namespace SNRegistros.Dominio.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comisaria
    {
        public Comisaria()
        {
            RegistroPolicials = new HashSet<RegistroPolicial>();
        }

        public int ComisariaID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public int? CiudadID { get; set; }

        public virtual ICollection<RegistroPolicial> RegistroPolicials { get; set; }
    }
}
