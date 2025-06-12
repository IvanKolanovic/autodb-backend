using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[Index("MakeId", "ManufacturerId", Name = "IX_Manufacturer_Make", IsUnique = true)]
public partial class Manufacturer_Make
{
    [Key]
    public int Id { get; set; }

    public int ManufacturerId { get; set; }

    public int MakeId { get; set; }
}
