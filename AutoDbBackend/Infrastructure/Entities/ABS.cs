using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[Index("Name", Name = "U_ABSName", IsUnique = true)]
public partial class ABS
{
    [Key]
    public int Id { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string Name { get; set; } = null!;
}
