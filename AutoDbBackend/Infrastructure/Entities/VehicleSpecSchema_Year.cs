using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[Index("VehicleSpecSchemaId", "Year", Name = "IX_VehicleSpecSchema_Year")]
public partial class VehicleSpecSchema_Year
{
    [Key]
    public int Id { get; set; }

    public int VehicleSpecSchemaId { get; set; }

    public int Year { get; set; }

    [ForeignKey("VehicleSpecSchemaId")]
    public virtual VehicleSpecSchema VehicleSpecSchema { get; set; } = null!;
}
