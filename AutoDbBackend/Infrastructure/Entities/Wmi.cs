using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[Index("Wmi1", Name = "IX_Wmi", IsUnique = true)]
[Index("ManufacturerId", Name = "NonClusteredIndex-20150710-115134")]
[Index("VehicleTypeId", Name = "NonClusteredIndex-20150710-115154")]
[Index("Wmi1", "PublicAvailabilityDate", Name = "NonClusteredIndex-20150726-231147")]
[Index("Wmi1", Name = "NonClusteredIndex-20150726-231207")]
public partial class Wmi
{
    [Key]
    public int Id { get; set; }

    [Column("Wmi")]
    [StringLength(6)]
    [Unicode(false)]
    public string Wmi1 { get; set; } = null!;

    public int? ManufacturerId { get; set; }

    public int? MakeId { get; set; }

    public int? VehicleTypeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedOn { get; set; }

    public int? CountryId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PublicAvailabilityDate { get; set; }

    public int? TruckTypeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ProcessedOn { get; set; }

    public bool? NonCompliant { get; set; }

    [StringLength(4000)]
    [Unicode(false)]
    public string? NonCompliantReason { get; set; }

    public bool? NonCompliantSetByOVSC { get; set; }

    [ForeignKey("ManufacturerId")]
    [InverseProperty("Wmi")]
    public virtual Manufacturer? Manufacturer { get; set; }

    [ForeignKey("VehicleTypeId")]
    [InverseProperty("Wmi")]
    public virtual VehicleType? VehicleType { get; set; }

    [InverseProperty("Wmi")]
    public virtual ICollection<Wmi_VinSchema> Wmi_VinSchema { get; set; } = new List<Wmi_VinSchema>();

    [ForeignKey("WmiId")]
    [InverseProperty("Wmi")]
    public virtual ICollection<Make> Make { get; set; } = new List<Make>();
}
