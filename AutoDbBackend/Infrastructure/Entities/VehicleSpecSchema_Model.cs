using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

public partial class VehicleSpecSchema_Model
{
    [Key]
    public int Id { get; set; }

    public int VehicleSpecSchemaId { get; set; }

    public int ModelId { get; set; }

    [ForeignKey("VehicleSpecSchemaId")]
    public virtual VehicleSpecSchema VehicleSpecSchema { get; set; } = null!;

    [ForeignKey("ModelId")]
    public virtual Model Model { get; set; } = null!;
}
