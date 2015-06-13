namespace SNRegistros.Dominio.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ciudadanos")]
    public partial class Ciudadano
    {
        public Ciudadano()
        {
            RegistroPolicials = new HashSet<RegistroPolicial>();
            RegistrosJudiciales = new HashSet<RegistrosJudiciale>();
            RegistrosMedicos = new HashSet<RegistrosMedico>();
        }

        public int CiudadanoID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        public virtual ICollection<RegistroPolicial> RegistroPolicials { get; set; }

        public virtual ICollection<RegistrosJudiciale> RegistrosJudiciales { get; set; }

        public virtual ICollection<RegistrosMedico> RegistrosMedicos { get; set; }
    }
}
