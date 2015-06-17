namespace SNRegistros.Dominio.DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SNRegistroModel : DbContext
    {
        public SNRegistroModel()
            : base("name=SNRegistroModel")
        {
        }

        public virtual DbSet<Accione> Acciones { get; set; }
        public virtual DbSet<AccionesPoliciale> AccionesPoliciales { get; set; }
        public virtual DbSet<AccionJudicial> AccionJudicials { get; set; }
        public virtual DbSet<Ciudadade> Ciudadades { get; set; }
        public virtual DbSet<Ciudadano> Ciudadanos { get; set; }
        public virtual DbSet<Comisaria> Comisarias { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Doctore> Doctores { get; set; }
        public virtual DbSet<FuncionarioJudicial> FuncionarioJudicials { get; set; }
        public virtual DbSet<Hospitale> Hospitales { get; set; }
        public virtual DbSet<Juzgado> Juzgados { get; set; }
        public virtual DbSet<Policia> Policias { get; set; }
        public virtual DbSet<Proceso> Procesos { get; set; }
        public virtual DbSet<ProcesosJudiciale> ProcesosJudiciales { get; set; }
        public virtual DbSet<ProcesosPoliciale> ProcesosPoliciales { get; set; }
        public virtual DbSet<RegistroPolicial> RegistroPolicials { get; set; }
        public virtual DbSet<RegistrosJudiciale> RegistrosJudiciales { get; set; }
        public virtual DbSet<RegistrosMedico> RegistrosMedicos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accione>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Accione>()
                .HasMany(e => e.RegistrosMedicos)
                .WithRequired(e => e.Accione)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AccionesPoliciale>()
                .Property(e => e.NombreAP)
                .IsUnicode(false);

            modelBuilder.Entity<AccionesPoliciale>()
                .HasMany(e => e.RegistroPolicials)
                .WithRequired(e => e.AccionesPoliciale)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AccionJudicial>()
                .Property(e => e.NombreAJ)
                .IsUnicode(false);

            modelBuilder.Entity<AccionJudicial>()
                .HasMany(e => e.RegistrosJudiciales)
                .WithRequired(e => e.AccionJudicial)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ciudadade>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Ciudadade>()
                .HasMany(e => e.Hospitales)
                .WithRequired(e => e.Ciudadade)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ciudadano>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Ciudadano>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Ciudadano>()
                .HasMany(e => e.RegistroPolicials)
                .WithRequired(e => e.Ciudadano)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ciudadano>()
                .HasMany(e => e.RegistrosJudiciales)
                .WithRequired(e => e.Ciudadano)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ciudadano>()
                .HasMany(e => e.RegistrosMedicos)
                .WithRequired(e => e.Ciudadano)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comisaria>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Comisaria>()
                .HasMany(e => e.RegistroPolicials)
                .WithRequired(e => e.Comisaria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Departamento>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Doctore>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Doctore>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Doctore>()
                .HasMany(e => e.RegistrosMedicos)
                .WithRequired(e => e.Doctore)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FuncionarioJudicial>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<FuncionarioJudicial>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<FuncionarioJudicial>()
                .HasMany(e => e.RegistrosJudiciales)
                .WithRequired(e => e.FuncionarioJudicial)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hospitale>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Hospitale>()
                .HasMany(e => e.RegistrosMedicos)
                .WithRequired(e => e.Hospitale)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Juzgado>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Juzgado>()
                .HasMany(e => e.RegistrosJudiciales)
                .WithRequired(e => e.Juzgado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Policia>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Policia>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Policia>()
                .HasMany(e => e.RegistroPolicials)
                .WithRequired(e => e.Policia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proceso>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Proceso>()
                .HasMany(e => e.Acciones)
                .WithRequired(e => e.Proceso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProcesosJudiciale>()
                .Property(e => e.NombreProcJud)
                .IsUnicode(false);

            modelBuilder.Entity<ProcesosJudiciale>()
                .HasMany(e => e.AccionJudicials)
                .WithRequired(e => e.ProcesosJudiciale)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProcesosPoliciale>()
                .Property(e => e.NombrePP)
                .IsUnicode(false);

            modelBuilder.Entity<ProcesosPoliciale>()
                .HasMany(e => e.AccionesPoliciales)
                .WithRequired(e => e.ProcesosPoliciale)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RegistroPolicial>()
                .Property(e => e.Comentario)
                .IsUnicode(false);

            modelBuilder.Entity<RegistrosJudiciale>()
                .Property(e => e.Comentario)
                .IsUnicode(false);

            modelBuilder.Entity<RegistrosMedico>()
                .Property(e => e.Comentario)
                .IsUnicode(false);
        }
    }
}
