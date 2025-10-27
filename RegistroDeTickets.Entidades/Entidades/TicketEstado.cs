﻿using System;
using System.Collections.Generic;

namespace RegistroDeTickets.Data.Entidades;

public partial class TicketEstado
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
