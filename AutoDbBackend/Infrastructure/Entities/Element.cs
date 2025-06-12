using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[Index("Id", "Name", Name = "IX_Element")]
[Index("Code", Name = "NonClusteredIndex-20150710-115000")]
public partial class Element
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? Code { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LookupTable { get; set; }

    [Unicode(false)]
    public string? Description { get; set; }

    public bool? IsPrivate { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? GroupName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? DataType { get; set; }

    public int? MinAllowedValue { get; set; }

    public int? MaxAllowedValue { get; set; }

    public bool? IsQS { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Decode { get; set; }

    public int? weight { get; set; }

    [InverseProperty("Element")]
    public virtual ICollection<DefaultValue> DefaultValue { get; set; } = new List<DefaultValue>();

    [InverseProperty("Element")]
    public virtual ICollection<Pattern> Pattern { get; set; } = new List<Pattern>();

    [InverseProperty("Element")]
    public virtual ICollection<VehicleSpecPattern> VehicleSpecPattern { get; set; } = new List<VehicleSpecPattern>();
}
