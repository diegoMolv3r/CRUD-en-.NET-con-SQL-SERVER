﻿using System;
using System.Collections.Generic;

namespace RegistroDeTickets.Data.Entidades;

public partial class Usuario
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? TokenHashRecuperacion { get; set; }

    public DateTime? TokenHashRecuperacionExpiracion { get; set; }

    public virtual Administrador? Administrador { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Tecnico? Tecnico { get; set; }
}
