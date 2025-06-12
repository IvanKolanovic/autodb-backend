using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

public partial class VSpecSchemaPattern
{
    [Key]
    public int Id { get; set; }

    public int SchemaId { get; set; }

    [ForeignKey("SchemaId")]
    [InverseProperty("VSpecSchemaPattern")]
    public virtual VehicleSpecSchema Schema { get; set; } = null!;

    [InverseProperty("VSpecSchemaPatternNavigation")]
    public virtual ICollection<VehicleSpecPattern> VehicleSpecPatterns { get; set; } = new List<VehicleSpecPattern>();
}
