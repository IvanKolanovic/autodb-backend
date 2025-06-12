using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

public partial class DecodingOutput
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime AddedOn { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? GroupName { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Variable { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Value { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Keys { get; set; }

    public int? WmiId { get; set; }

    public int? PatternId { get; set; }

    public int? VinSchemaId { get; set; }

    public int? ElementId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? AttributeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Code { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? DataType { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Decode { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Source { get; set; }
}
