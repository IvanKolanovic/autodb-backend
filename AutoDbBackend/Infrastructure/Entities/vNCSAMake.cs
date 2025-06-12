using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[Keyless]
public partial class vNCSAMake
{
    public short Id { get; set; }

    [StringLength(35)]
    [Unicode(false)]
    public string? Name { get; set; }
}
