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
            RegistrosPoliciales = new HashSet<RegistrosPoliciale>();
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

        public virtual ICollection<RegistrosPoliciale> RegistrosPoliciales { get; set; }

        public virtual ICollection<RegistrosJudiciale> RegistrosJudiciales { get; set; }

        public virtual ICollection<RegistrosMedico> RegistrosMedicos { get; set; }
    }
}
