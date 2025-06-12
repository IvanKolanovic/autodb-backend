using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

public partial class VinSchema
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(6)]
    [Unicode(false)]
    public string? sourcewmi { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedOn { get; set; }

    [Unicode(false)]
    public string? Notes { get; set; }

    public bool? TobeQCed { get; set; }

    [InverseProperty("VinSchema")]
    public virtual ICollection<Pattern> Pattern { get; set; } = new List<Pattern>();

    [InverseProperty("VinSchema")]
    public virtual ICollection<Wmi_VinSchema> Wmi_VinSchema { get; set; } = new List<Wmi_VinSchema>();
}
