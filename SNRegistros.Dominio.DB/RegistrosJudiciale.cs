namespace SNRegistros.Dominio.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RegistrosJudiciale
    {
        [Key]
        public int RegistroJudicialID { get; set; }

        public int CiudadanoID { get; set; }

        public int FuncJudicialId { get; set; }

        public int JuzgadoID { get; set; }

        public int AccJudID { get; set; }

        [Required]
        public string Comentario { get; set; }

        public virtual AccionJudicial AccionJudicial { get; set; }

        public virtual Ciudadano Ciudadano { get; set; }

        public virtual FuncionarioJudicial FuncionarioJudicial { get; set; }

        public virtual Juzgado Juzgado { get; set; }
    }
}
