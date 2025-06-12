using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[Keyless]
public partial class vNCSAModel
{
    public int? Id { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string? Name { get; set; }

    public short MakeId { get; set; }

    public short OriginalId { get; set; }
}
