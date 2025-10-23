using System;
using System.Collections.Generic;

namespace RegistroDeTickets.Data.Entidades;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? PasswordHash { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
