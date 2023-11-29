using System;
using System.Collections.Generic;

namespace AlquilerPeliculas.Models;

public partial class Pelicula
{
    public int IdPelicula { get; set; }

    public string? NombrePelicula { get; set; }

    public decimal? Precio { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    public virtual ICollection<Usuario> IdUsuarios { get; set; } = new List<Usuario>();
}
