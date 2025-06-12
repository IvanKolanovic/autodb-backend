using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[Index("Name", Name = "U_VehicleTypeName", IsUnique = true)]
public partial class VehicleType
{
    [Key]
    public int Id { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    public int? DisplayOrder { get; set; }

    public int? FormType { get; set; }

    [StringLength(4000)]
    [Unicode(false)]
    public string? Description { get; set; }

    public bool? IncludeInEquipPlant { get; set; }

    [InverseProperty("VehicleType")]
    public virtual ICollection<DefaultValue> DefaultValue { get; set; } = new List<DefaultValue>();

    [InverseProperty("VehicleType")]
    public virtual ICollection<Wmi> Wmi { get; set; } = new List<Wmi>();
}
