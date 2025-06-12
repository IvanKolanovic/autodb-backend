using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[Index("IsKey", "ElementId", "AttributeId", Name = "IX_VehicleSpecPattern")]
[Index("VSpecSchemaPatternId", Name = "IX_VehicleSpecPattern_IsKey_EID_AttrID")]
public partial class VehicleSpecPattern
{
    [Key]
    public int Id { get; set; }

    public int VSpecSchemaPatternId { get; set; }

    public bool IsKey { get; set; }

    public int ElementId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string AttributeId { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedOn { get; set; }

    [ForeignKey("ElementId")]
    public virtual Element Element { get; set; } = null!;

    [ForeignKey("VSpecSchemaPatternId")]
    public virtual VSpecSchemaPattern VSpecSchemaPatternNavigation { get; set; } = null!;
}
