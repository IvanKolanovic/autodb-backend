using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[Keyless]
public partial class vMakeModelYear
{
    public int MakeId { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string MakeName { get; set; } = null!;

    public int ModelId { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string ModelName { get; set; } = null!;

    public int Year { get; set; }
}