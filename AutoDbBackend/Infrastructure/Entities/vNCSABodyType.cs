using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[Keyless]
public partial class vNCSABodyType
{
    public short Id { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Name { get; set; }
}
