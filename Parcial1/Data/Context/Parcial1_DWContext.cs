using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Parcial1.Data.Models;

namespace Parcial1.Data.Context;

public partial class Parcial1_DWContext : DbContext
{
    public Parcial1_DWContext()
    {
    }

    public Parcial1_DWContext(DbContextOptions<Parcial1_DWContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Carrera> Carreras { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AS");

        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.CarneAlumno);

            entity.ToTable("Alumno");

            entity.Property(e => e.CarneAlumno)
                .HasMaxLength(15)
                .HasColumnName("carne_alumno");
            entity.Property(e => e.Apellido1Alumno)
                .HasMaxLength(50)
                .HasColumnName("apellido1_alumno");
            entity.Property(e => e.Apellido2Alumno)
                .HasMaxLength(50)
                .HasColumnName("apellido2_alumno");
            entity.Property(e => e.CodigoCarrera).HasColumnName("codigo_carrera");
            entity.Property(e => e.CorreoAlumno)
                .HasMaxLength(100)
                .HasColumnName("correo_alumno");
            entity.Property(e => e.DireccionAlumno)
                .HasMaxLength(150)
                .HasColumnName("direccion_alumno");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nombre1Alumno)
                .HasMaxLength(50)
                .HasColumnName("nombre1_alumno");
            entity.Property(e => e.Nombre2Alumno)
                .HasMaxLength(50)
                .HasColumnName("nombre2_alumno");
            entity.Property(e => e.TelefonoAlumno)
                .HasMaxLength(12)
                .HasColumnName("telefono_alumno");

            entity.HasOne(d => d.CodigoCarreraNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.CodigoCarrera)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumno_Carrera");
        });

        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasKey(e => e.CodigoCarrera);

            entity.ToTable("Carrera");

            entity.Property(e => e.CodigoCarrera)
                .ValueGeneratedNever()
                .HasColumnName("codigo_carrera");
            entity.Property(e => e.NombreCarrera)
                .HasMaxLength(150)
                .HasColumnName("nombre_carrera");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
