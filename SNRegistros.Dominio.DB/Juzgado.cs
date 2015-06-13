namespace SNRegistros.Dominio.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Juzgados")]
    public partial class Juzgado
    {
        public Juzgado()
        {
            RegistrosJudiciales = new HashSet<RegistrosJudiciale>();
        }

        public int JuzgadoID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public int CiudadID { get; set; }

        public virtual ICollection<RegistrosJudiciale> RegistrosJudiciales { get; set; }
    }
}
