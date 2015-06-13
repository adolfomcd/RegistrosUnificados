namespace SNRegistros.Dominio.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hospitale
    {
        public Hospitale()
        {
            RegistrosMedicos = new HashSet<RegistrosMedico>();
        }

        [Key]
        public int HospitalID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public int CiudadID { get; set; }

        public virtual Ciudadade Ciudadade { get; set; }

        public virtual ICollection<RegistrosMedico> RegistrosMedicos { get; set; }
    }
}
