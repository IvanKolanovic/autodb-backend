using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[Index("Name", Name = "U_AdaptiveCruiseControlName", IsUnique = true)]
public partial class AdaptiveCruiseControl
{
    [Key]
    public int Id { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string Name { get; set; } = null!;
}
