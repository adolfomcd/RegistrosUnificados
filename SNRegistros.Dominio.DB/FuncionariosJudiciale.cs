namespace SNRegistros.Dominio.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FuncionariosJudiciale
    {
        public FuncionariosJudiciale()
        {
            RegistrosJudiciales = new HashSet<RegistrosJudiciale>();
        }

        [Key]
        public int FuncJudicialId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        public int JuzgadoID { get; set; }

        public virtual ICollection<RegistrosJudiciale> RegistrosJudiciales { get; set; }
    }
}
