using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[Index("MakeId", "ModelId", Name = "IX_Make_Model")]
[Index("MakeId", Name = "IX_Make_Model_MakeId")]
[Index("ModelId", Name = "IX_Make_Model_ModelId")]
public partial class Make_Model
{
    [Key]
    public int Id { get; set; }

    public int MakeId { get; set; }

    public int ModelId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedOn { get; set; }

    [ForeignKey("MakeId")]
    [InverseProperty("Make_Model")]
    public virtual Make Make { get; set; } = null!;

    [ForeignKey("ModelId")]
    [InverseProperty("Make_Model")]
    public virtual Model Model { get; set; } = null!;
}
