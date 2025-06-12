using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[PrimaryKey("ID", "FROM_YEAR", "MODE")]
public partial class DEFS_Body
{
    [Key]
    public short ID { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? DEF { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string? BODY_TYPE { get; set; }

    [Key]
    public short FROM_YEAR { get; set; }

    public short? TO_YEAR { get; set; }

    [Key]
    public short MODE { get; set; }
}
