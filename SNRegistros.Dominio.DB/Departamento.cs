namespace SNRegistros.Dominio.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Departamentos")]
    public partial class Departamento
    {
        public int DepartamentoID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
    }
}
