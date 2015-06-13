namespace SNRegistros.Dominio.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RegistroPolicial")]
    public partial class RegistroPolicial
    {
        public int RegistroPolicialID { get; set; }

        public int CiudadanoID { get; set; }

        public int PoliciaID { get; set; }

        public int ComisariaID { get; set; }

        public int AccPolID { get; set; }

        [Required]
        public string Comentario { get; set; }

        public virtual AccionesPoliciale AccionesPoliciale { get; set; }

        public virtual Ciudadano Ciudadano { get; set; }

        public virtual Comisaria Comisaria { get; set; }

        public virtual Policia Policia { get; set; }
    }
}
