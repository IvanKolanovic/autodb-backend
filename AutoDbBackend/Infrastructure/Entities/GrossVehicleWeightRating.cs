using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[Index("Name", Name = "U_GVWRName", IsUnique = true)]
public partial class GrossVehicleWeightRating
{
    [Key]
    public int Id { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    public int? SortOrder { get; set; }

    public int? MinRangeWeight { get; set; }

    public int? MaxRangeWeight { get; set; }
}
