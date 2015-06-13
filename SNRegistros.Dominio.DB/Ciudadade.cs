namespace SNRegistros.Dominio.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ciudadade
    {
        public Ciudadade()
        {
            Hospitales = new HashSet<Hospitale>();
        }

        [Key]
        public int CiudadID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public int DepartamentoID { get; set; }

        public virtual ICollection<Hospitale> Hospitales { get; set; }
    }
}
