﻿using System;
using System.Collections.Generic;

namespace RegistroDeTickets.Data.Entidades;

public partial class Administrador
{
    public int Id { get; set; }

    public virtual Usuario IdNavigation { get; set; } = null!;
}
