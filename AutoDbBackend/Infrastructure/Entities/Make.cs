using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[Index("Name", Name = "IX_Make")]
[Index("Name", Name = "U_MakeName", IsUnique = true)]
public partial class Make
{
    [Key]
    public int Id { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedOn { get; set; }

    [InverseProperty("Make")]
    public virtual ICollection<Make_Model> Make_Model { get; set; } = new List<Make_Model>();

    [ForeignKey("MakeId")]
    [InverseProperty("Make")]
    public virtual ICollection<Wmi> Wmi { get; set; } = new List<Wmi>();
}
