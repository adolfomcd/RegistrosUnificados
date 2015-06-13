namespace SNRegistros.Dominio.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RegistrosMedicos")]
    public partial class RegistrosMedico
    {
        [Key]
        public int RegistroMedicoID { get; set; }

        public int Ciudadanoid { get; set; }

        public int MedicoID { get; set; }

        public int HospitalID { get; set; }

        public int AccionID { get; set; }

        public string Comentario { get; set; }

        public virtual Accione Accione { get; set; }

        public virtual Ciudadano Ciudadano { get; set; }

        public virtual Doctore Doctore { get; set; }

        public virtual Hospitale Hospitale { get; set; }
    }
}
