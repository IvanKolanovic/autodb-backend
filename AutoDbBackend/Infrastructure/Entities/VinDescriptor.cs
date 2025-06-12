using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[Index("Descriptor", Name = "IX_VinDescriptor_Descriptor", IsUnique = true)]
public partial class VinDescriptor
{
    [Key]
    public int Id { get; set; }

    [StringLength(17)]
    [Unicode(false)]
    public string Descriptor { get; set; } = null!;

    public int ModelYear { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedOn { get; set; }
}
