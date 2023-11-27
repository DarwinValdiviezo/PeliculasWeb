using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebPeliculas.Models;

public partial class PeliculasContext : DbContext
{
    public PeliculasContext()
    {
    }

    public PeliculasContext(DbContextOptions<PeliculasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pelicula> Peliculas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
       // => optionsBuilder.UseSqlServer("server=DESKTOP-PQVEJI8\\SQLEXPRESS; database=peliculas; integrated security=true; TrustServerCertificate=Yes");

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.IdPelicula).HasName("PK__Pelicula__E239B742CD31CD6D");

            entity.Property(e => e.IdPelicula).HasColumnName("Id_Pelicula");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NombrePelicula)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Pelicula");
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasMany(d => d.IdUsuarios).WithMany(p => p.IdPeliculas)
                .UsingEntity<Dictionary<string, object>>(
                    "PeliculaUsuario",
                    r => r.HasOne<Usuario>().WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Pelicula___Id_Us__6EF57B66"),
                    l => l.HasOne<Pelicula>().WithMany()
                        .HasForeignKey("IdPelicula")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Pelicula___Id_Pe__6E01572D"),
                    j =>
                    {
                        j.HasKey("IdPelicula", "IdUsuario").HasName("PK__Pelicula__D405C1FC83B5ECA5");
                        j.ToTable("Pelicula_Usuario");
                        j.IndexerProperty<int>("IdPelicula").HasColumnName("Id_Pelicula");
                        j.IndexerProperty<int>("IdUsuario").HasColumnName("Id_Usuario");
                    });
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__63C76BE271C733BE");

            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaFinal).HasColumnName("Fecha_Final");
            entity.Property(e => e.FechaInicio).HasColumnName("Fecha_Inicio");
            entity.Property(e => e.IdPelicula).HasColumnName("Id_Pelicula");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPeliculaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPelicula)
                .HasConstraintName("FK__Usuarios__Id_Pel__6B24EA82");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
