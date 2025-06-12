using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[PrimaryKey("ID", "FROM_YEAR")]
public partial class DEFS_Make
{
    [Key]
    public short ID { get; set; }

    [StringLength(35)]
    [Unicode(false)]
    public string? DEF { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? NCIC_CODE { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? MAKE_TYPE { get; set; }

    [Key]
    public short FROM_YEAR { get; set; }

    public short? TO_YEAR { get; set; }

    public short MODE { get; set; }
}
