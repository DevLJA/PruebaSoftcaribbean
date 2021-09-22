using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Models;

#nullable disable

namespace Data.Implementation.Generic
{
    public partial class DesarrolloContext : DbContext
    {
        public DesarrolloContext()
        {
        }

        public DesarrolloContext(DbContextOptions<DesarrolloContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<TiposPersona> TiposPersonas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost;Database=Desarrollo;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.ToTable("Genero");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.Nmid);

                entity.Property(e => e.Nmid).HasColumnName("nmid");

                entity.Property(e => e.Cdusuario)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cdusuario");

                entity.Property(e => e.Dsarl)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("dsarl");

                entity.Property(e => e.Dscondicion)
                    .HasColumnType("text")
                    .HasColumnName("dscondicion");

                entity.Property(e => e.Dseps)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("dseps");

                entity.Property(e => e.Febaja)
                    .HasColumnType("datetime")
                    .HasColumnName("febaja");

                entity.Property(e => e.Feregistro)
                    .HasColumnType("datetime")
                    .HasColumnName("feregistro");

                entity.Property(e => e.NmidMedicotra).HasColumnName("nmid_medicotra");

                entity.Property(e => e.NmidPersona).HasColumnName("nmid_persona");

                entity.HasOne(d => d.NmidMedicotraNavigation)
                    .WithMany(p => p.PacienteNmidMedicotraNavigations)
                    .HasForeignKey(d => d.NmidMedicotra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK02_Pacientes_Personas");

                entity.HasOne(d => d.NmidPersonaNavigation)
                    .WithMany(p => p.PacienteNmidPersonaNavigations)
                    .HasForeignKey(d => d.NmidPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK01_Pacientes_Personas");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Nmid);

                entity.Property(e => e.Nmid).HasColumnName("nmid");

                entity.Property(e => e.Cddocumento)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cddocumento");

                entity.Property(e => e.Cdgenero).HasColumnName("cdgenero");

                entity.Property(e => e.CdtelefonoMovil)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cdtelefono_movil");

                entity.Property(e => e.CdtelfonoFijo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cdtelfono_fijo");

                entity.Property(e => e.Cdtipo).HasColumnName("cdtipo");

                entity.Property(e => e.Cdusuario)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cdusuario");

                entity.Property(e => e.DsEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ds_email");

                entity.Property(e => e.Dsapellidos)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("dsapellidos");

                entity.Property(e => e.Dsdireccion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("dsdireccion");

                entity.Property(e => e.Dsnombres)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("dsnombres");

                entity.Property(e => e.Dsphoto)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("dsphoto");

                entity.Property(e => e.Febaja)
                    .HasColumnType("datetime")
                    .HasColumnName("febaja");

                entity.Property(e => e.Fenacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fenacimiento");

                entity.Property(e => e.Feregistro)
                    .HasColumnType("datetime")
                    .HasColumnName("feregistro");

                entity.HasOne(d => d.CdgeneroNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.Cdgenero)
                    .HasConstraintName("FK01_Personas_Genero");

                entity.HasOne(d => d.CdtipoNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.Cdtipo)
                    .HasConstraintName("FK01_Personas_TiposPersonas");
            });

            modelBuilder.Entity<TiposPersona>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
