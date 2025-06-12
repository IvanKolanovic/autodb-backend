using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

public partial class DefaultValue
{
    [Key]
    public int Id { get; set; }

    public int ElementId { get; set; }

    public int VehicleTypeId { get; set; }

    [Column("DefaultValue")]
    [StringLength(500)]
    [Unicode(false)]
    public string? DefaultValue1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedOn { get; set; }

    [ForeignKey("ElementId")]
    [InverseProperty("DefaultValue")]
    public virtual Element Element { get; set; } = null!;

    [ForeignKey("VehicleTypeId")]
    [InverseProperty("DefaultValue")]
    public virtual VehicleType VehicleType { get; set; } = null!;
}
