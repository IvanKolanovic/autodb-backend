using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[Index("EngineModelId", "ElementId", Name = "IX_EngineModelPattern_KeyElement_Unique", IsUnique = true)]
public partial class EngineModelPattern
{
    [Key]
    public int Id { get; set; }

    public int EngineModelId { get; set; }

    public int ElementId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string AttributeId { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedOn { get; set; }

    [ForeignKey("EngineModelId")]
    [InverseProperty("EngineModelPattern")]
    public virtual EngineModel EngineModel { get; set; } = null!;
}
