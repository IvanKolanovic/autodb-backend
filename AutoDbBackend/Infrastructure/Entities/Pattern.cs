using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[Index("VinSchemaId", Name = "IX_Pattern")]
[Index("VinSchemaId", "Keys", "ElementId", Name = "IX_Pattern_KeyElement_Unique", IsUnique = true)]
[Index("ElementId", Name = "NonClusteredIndex-20150710-113712")]
[Index("CreatedOn", "UpdatedOn", Name = "NonClusteredIndex-20160721-081119")]
public partial class Pattern
{
    [Key]
    public int Id { get; set; }

    public int VinSchemaId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Keys { get; set; } = null!;

    public int ElementId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string AttributeId { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedOn { get; set; }

    [ForeignKey("ElementId")]
    [InverseProperty("Pattern")]
    public virtual Element Element { get; set; } = null!;

    [ForeignKey("VinSchemaId")]
    [InverseProperty("Pattern")]
    public virtual VinSchema VinSchema { get; set; } = null!;
}
