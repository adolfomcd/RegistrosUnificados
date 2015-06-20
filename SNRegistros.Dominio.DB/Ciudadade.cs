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
            Comisarias = new HashSet<Comisaria>();
            Hospitales = new HashSet<Hospitale>();
        }

        [Key]
        public int CiudadID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public int DepartamentoID { get; set; }

        public virtual ICollection<Comisaria> Comisarias { get; set; }

        public virtual ICollection<Hospitale> Hospitales { get; set; }
    }
}
