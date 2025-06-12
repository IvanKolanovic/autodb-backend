using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[Index("MakeId", "VehicleTypeId", Name = "IX_VehicleSpecSchema_VehicleTypeId_MakeId")]
public partial class VehicleSpecSchema
{
    [Key]
    public int Id { get; set; }

    public int MakeId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedOn { get; set; }

    public int? VehicleTypeId { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? Source { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SourceDate { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? URL { get; set; }

    public bool? TobeQCed { get; set; }

    [InverseProperty("Schema")]
    public virtual ICollection<VSpecSchemaPattern> VSpecSchemaPattern { get; set; } = new List<VSpecSchemaPattern>();

    [ForeignKey("VehicleTypeId")]
    public virtual VehicleType? VehicleType { get; set; }

    [ForeignKey("MakeId")]
    public virtual Make Make { get; set; } = null!;

    [InverseProperty("VehicleSpecSchema")]
    public virtual ICollection<VehicleSpecSchema_Year> VehicleSpecSchema_Years { get; set; } = new List<VehicleSpecSchema_Year>();

    [InverseProperty("VehicleSpecSchema")]
    public virtual ICollection<VehicleSpecSchema_Model> VehicleSpecSchema_Models { get; set; } = new List<VehicleSpecSchema_Model>();
}
