using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[Index("WMI", Name = "IX_WMIValidChars")]
[Index("WMI", "Year", Name = "IX_WMIYearValidChars")]
public partial class WMIYearValidChars
{
    [Key]
    public int id { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string WMI { get; set; } = null!;

    public int Year { get; set; }

    public int? Position { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? Char { get; set; }
}
