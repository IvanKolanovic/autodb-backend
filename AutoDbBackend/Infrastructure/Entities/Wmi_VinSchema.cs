using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[Index("VinSchemaId", "WmiId", "YearFrom", Name = "IX_Wmi_VinSchema", IsUnique = true)]
[Index("WmiId", Name = "NonClusteredIndex-20150710-115058")]
[Index("VinSchemaId", Name = "NonClusteredIndex-20150710-115235")]
[Index("VinSchemaId", Name = "NonClusteredIndex-20221116-134353")]
public partial class Wmi_VinSchema
{
    [Key]
    public int Id { get; set; }

    public int WmiId { get; set; }

    public int VinSchemaId { get; set; }

    public int YearFrom { get; set; }

    public int? YearTo { get; set; }

    public int? OrgId { get; set; }

    [ForeignKey("VinSchemaId")]
    [InverseProperty("Wmi_VinSchema")]
    public virtual VinSchema VinSchema { get; set; } = null!;

    [ForeignKey("WmiId")]
    [InverseProperty("Wmi_VinSchema")]
    public virtual Wmi Wmi { get; set; } = null!;
}
