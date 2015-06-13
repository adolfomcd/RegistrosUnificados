namespace SNRegistros.Dominio.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Policia
    {
        public Policia()
        {
            RegistroPolicials = new HashSet<RegistroPolicial>();
        }

        public int PoliciaID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        public int ComisariaID { get; set; }

        public virtual ICollection<RegistroPolicial> RegistroPolicials { get; set; }
    }
}
