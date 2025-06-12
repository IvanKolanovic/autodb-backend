using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[PrimaryKey("MAKE", "ID", "FROM_YEAR", "MODE")]
public partial class DEFS_Model
{
    [Key]
    public short MAKE { get; set; }

    [Key]
    public short ID { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string? DEF { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string? MODEL_TYPE { get; set; }

    [Unicode(false)]
    public string? INCLUDES { get; set; }

    [Key]
    public short FROM_YEAR { get; set; }

    public short? TO_YEAR { get; set; }

    [Key]
    public short MODE { get; set; }
}
