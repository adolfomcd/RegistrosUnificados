namespace SNRegistros.Dominio.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Doctore
    {
        public Doctore()
        {
            RegistrosMedicos = new HashSet<RegistrosMedico>();
        }

        [Key]
        public int MedicoID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        public int HospitalId { get; set; }

        public virtual ICollection<RegistrosMedico> RegistrosMedicos { get; set; }
    }
}
