using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

public partial class Conversion
{
    [Key]
    public int Id { get; set; }

    public int FromElementId { get; set; }

    public int ToElementId { get; set; }

    [StringLength(1000)]
    public string Formula { get; set; } = null!;
}
