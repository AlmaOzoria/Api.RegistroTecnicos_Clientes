﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecnico.Domain.DTO;

public class ClienteDTO
{

    public int ClientesId { get; set; }
    public string? Nombres { get; set; }
    public string? WhatsApp { get; set; }
}