using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[Keyless]
[Index("WMI", Name = "IX_WMIYearValidChars_CacheExceptions_WMI")]
public partial class WMIYearValidChars_CacheExceptions
{
    [StringLength(6)]
    [Unicode(false)]
    public string WMI { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedOn { get; set; }

    public int Id { get; set; }
}
