using System;
using System.Collections.Generic;

namespace AlquilerPeliculas.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFinal { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public int? IdPelicula { get; set; }

    public virtual Pelicula? IdPeliculaNavigation { get; set; }

    public virtual ICollection<Pelicula> IdPeliculas { get; set; } = new List<Pelicula>();
}
