using System;
using System.Collections.Generic;

namespace RegistroDeTickets.Data.Entidades;

public partial class Ticket
{
    public int Id { get; set; }

    public string? Motivo { get; set; }

    public string? Tipo { get; set; }

    public string? Descripcion { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public int IdUsuario { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
