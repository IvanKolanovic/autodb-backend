using System.Diagnostics.CodeAnalysis;
using Infrastructure.Entities;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using DriveType = Infrastructure.Entities.DriveType;

namespace Infrastructure.Context;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public virtual DbSet<ABS> ABS { get; set; }

    public virtual DbSet<AdaptiveCruiseControl> AdaptiveCruiseControl { get; set; }

    public virtual DbSet<AdaptiveDrivingBeam> AdaptiveDrivingBeam { get; set; }

    public virtual DbSet<AirBagLocFront> AirBagLocFront { get; set; }

    public virtual DbSet<AirBagLocKnee> AirBagLocKnee { get; set; }

    public virtual DbSet<AirBagLocations> AirBagLocations { get; set; }

    public virtual DbSet<AutoBrake> AutoBrake { get; set; }

    public virtual DbSet<AutoReverseSystem> AutoReverseSystem { get; set; }

    public virtual DbSet<AutomaticPedestrainAlertingSound> AutomaticPedestrainAlertingSound { get; set; }

    public virtual DbSet<AxleConfiguration> AxleConfiguration { get; set; }

    public virtual DbSet<BatteryType> BatteryType { get; set; }

    public virtual DbSet<BedType> BedType { get; set; }

    public virtual DbSet<BlindSpotIntervention> BlindSpotIntervention { get; set; }

    public virtual DbSet<BlindSpotMonitoring> BlindSpotMonitoring { get; set; }

    public virtual DbSet<BodyCab> BodyCab { get; set; }

    public virtual DbSet<BodyStyle> BodyStyle { get; set; }

    public virtual DbSet<BrakeSystem> BrakeSystem { get; set; }

    public virtual DbSet<BusFloorConfigType> BusFloorConfigType { get; set; }

    public virtual DbSet<BusType> BusType { get; set; }

    public virtual DbSet<CAN_AACN> CAN_AACN { get; set; }

    public virtual DbSet<ChargerLevel> ChargerLevel { get; set; }

    public virtual DbSet<CombinedBrakingSystem> CombinedBrakingSystem { get; set; }

    public virtual DbSet<Conversion> Conversion { get; set; }

    public virtual DbSet<CoolingType> CoolingType { get; set; }

    public virtual DbSet<Country> Country { get; set; }

    public virtual DbSet<CustomMotorcycleType> CustomMotorcycleType { get; set; }

    public virtual DbSet<DEFS_Body> DEFS_Body { get; set; }

    public virtual DbSet<DEFS_Make> DEFS_Make { get; set; }

    public virtual DbSet<DEFS_Model> DEFS_Model { get; set; }

    public virtual DbSet<DaytimeRunningLight> DaytimeRunningLight { get; set; }

    public virtual DbSet<DecodingOutput> DecodingOutput { get; set; }

    public virtual DbSet<DefaultValue> DefaultValue { get; set; }

    public virtual DbSet<DestinationMarket> DestinationMarket { get; set; }

    public virtual DbSet<DriveType> DriveType { get; set; }

    public virtual DbSet<DynamicBrakeSupport> DynamicBrakeSupport { get; set; }

    public virtual DbSet<ECS> ECS { get; set; }

    public virtual DbSet<EDR> EDR { get; set; }

    public virtual DbSet<EVDriveUnit> EVDriveUnit { get; set; }

    public virtual DbSet<ElectrificationLevel> ElectrificationLevel { get; set; }

    public virtual DbSet<Element> Element { get; set; }

    public virtual DbSet<EngineConfiguration> EngineConfiguration { get; set; }

    public virtual DbSet<EngineModel> EngineModel { get; set; }

    public virtual DbSet<EngineModelPattern> EngineModelPattern { get; set; }

    public virtual DbSet<EntertainmentSystem> EntertainmentSystem { get; set; }

    public virtual DbSet<ErrorCode> ErrorCode { get; set; }

    public virtual DbSet<ForwardCollisionWarning> ForwardCollisionWarning { get; set; }

    public virtual DbSet<FuelDeliveryType> FuelDeliveryType { get; set; }

    public virtual DbSet<FuelTankMaterial> FuelTankMaterial { get; set; }

    public virtual DbSet<FuelTankType> FuelTankType { get; set; }

    public virtual DbSet<FuelType> FuelType { get; set; }

    public virtual DbSet<GrossVehicleWeightRating> GrossVehicleWeightRating { get; set; }

    public virtual DbSet<KeylessIgnition> KeylessIgnition { get; set; }

    public virtual DbSet<LaneCenteringAssistance> LaneCenteringAssistance { get; set; }

    public virtual DbSet<LaneDepartureWarning> LaneDepartureWarning { get; set; }

    public virtual DbSet<LaneKeepSystem> LaneKeepSystem { get; set; }

    public virtual DbSet<LowerBeamHeadlampLightSource> LowerBeamHeadlampLightSource { get; set; }

    public virtual DbSet<Make> Make { get; set; }

    public virtual DbSet<Make_Model> Make_Model { get; set; }

    public virtual DbSet<Manufacturer> Manufacturer { get; set; }

    public virtual DbSet<Manufacturer_Make> Manufacturer_Make { get; set; }

    public new virtual DbSet<Model> Model { get; set; }

    public virtual DbSet<MotorcycleChassisType> MotorcycleChassisType { get; set; }

    public virtual DbSet<MotorcycleSuspensionType> MotorcycleSuspensionType { get; set; }

    public virtual DbSet<NonLandUse> NonLandUse { get; set; }

    public virtual DbSet<ParkAssist> ParkAssist { get; set; }

    public virtual DbSet<Pattern> Pattern { get; set; }

    public virtual DbSet<PedestrianAutomaticEmergencyBraking> PedestrianAutomaticEmergencyBraking { get; set; }

    public virtual DbSet<Pretensioner> Pretensioner { get; set; }

    public virtual DbSet<RearAutomaticEmergencyBraking> RearAutomaticEmergencyBraking { get; set; }

    public virtual DbSet<RearCrossTrafficAlert> RearCrossTrafficAlert { get; set; }

    public virtual DbSet<RearVisibilityCamera> RearVisibilityCamera { get; set; }

    public virtual DbSet<SeatBeltsAll> SeatBeltsAll { get; set; }

    public virtual DbSet<SemiautomaticHeadlampBeamSwitching> SemiautomaticHeadlampBeamSwitching { get; set; }

    public virtual DbSet<Steering> Steering { get; set; }

    public virtual DbSet<TPMS> TPMS { get; set; }

    public virtual DbSet<TractionControl> TractionControl { get; set; }

    public virtual DbSet<TrailerBodyType> TrailerBodyType { get; set; }

    public virtual DbSet<TrailerType> TrailerType { get; set; }

    public virtual DbSet<Transmission> Transmission { get; set; }

    public virtual DbSet<Turbo> Turbo { get; set; }

    public virtual DbSet<VSpecSchemaPattern> VSpecSchemaPattern { get; set; }

    public virtual DbSet<ValvetrainDesign> ValvetrainDesign { get; set; }

    public virtual DbSet<VehicleSpecPattern> VehicleSpecPattern { get; set; }

    public virtual DbSet<VehicleSpecSchema> VehicleSpecSchema { get; set; }

    public virtual DbSet<VehicleSpecSchema_Model> VehicleSpecSchema_Model { get; set; }

    public virtual DbSet<VehicleSpecSchema_Year> VehicleSpecSchema_Year { get; set; }

    public virtual DbSet<VehicleType> VehicleType { get; set; }

    public virtual DbSet<VinDescriptor> VinDescriptor { get; set; }

    public virtual DbSet<VinException> VinException { get; set; }

    public virtual DbSet<VinSchema> VinSchema { get; set; }

    public virtual DbSet<WMIYearValidChars> WMIYearValidChars { get; set; }

    public virtual DbSet<WMIYearValidChars_CacheExceptions> WMIYearValidChars_CacheExceptions { get; set; }

    public virtual DbSet<WheelBaseType> WheelBaseType { get; set; }

    public virtual DbSet<WheelieMitigation> WheelieMitigation { get; set; }

    public virtual DbSet<Wmi> Wmi { get; set; }

    public virtual DbSet<Wmi_VinSchema> Wmi_VinSchema { get; set; }

    public virtual DbSet<vNCSABodyType> vNCSABodyType { get; set; }

    public virtual DbSet<vNCSAMake> vNCSAMake { get; set; }

    public virtual DbSet<vNCSAModel> vNCSAModel { get; set; }

    public virtual DbSet<vMakeModelYear> vMakeModelYear { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=vPICList_Lite;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdaptiveDrivingBeam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Adaptive__3214EC0753F971CF");
        });

        modelBuilder.Entity<AutoReverseSystem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AutoReve__3214EC07D99B9C79");
        });

        modelBuilder.Entity<AutomaticPedestrainAlertingSound>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Automati__3214EC079A150E03");
        });

        modelBuilder.Entity<CAN_AACN>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CAN_AACN__3214EC079657DF7C");
        });

        modelBuilder.Entity<Country>(entity => { entity.Property(e => e.displayorder).HasDefaultValue(999); });

        modelBuilder.Entity<DEFS_Body>(entity =>
        {
            entity.Property(e => e.FROM_YEAR).HasDefaultValue((short)1994);
            entity.Property(e => e.MODE).HasDefaultValue((short)-1);
        });

        modelBuilder.Entity<DEFS_Make>(entity =>
        {
            entity.Property(e => e.FROM_YEAR).HasDefaultValue((short)1994);
            entity.Property(e => e.MODE).HasDefaultValue((short)-1);
        });

        modelBuilder.Entity<DEFS_Model>(entity =>
        {
            entity.Property(e => e.FROM_YEAR).HasDefaultValue((short)1994);
            entity.Property(e => e.MODE).HasDefaultValue((short)-1);
        });

        modelBuilder.Entity<DaytimeRunningLight>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DaytimeR__3214EC07E6E39743");
        });

        modelBuilder.Entity<DecodingOutput>(entity =>
        {
            entity.Property(e => e.AddedOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<DefaultValue>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Element).WithMany(p => p.DefaultValue)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DefaultValue_ElementId");

            entity.HasOne(d => d.VehicleType).WithMany(p => p.DefaultValue)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DefaultValue_VehicleTypeId");
        });

        modelBuilder.Entity<DynamicBrakeSupport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DynamicB__3214EC07A7D5E8A9");
        });

        modelBuilder.Entity<EDR>(entity => { entity.HasKey(e => e.Id).HasName("PK__EDR__3214EC07273A4B03"); });

        modelBuilder.Entity<Element>(entity => { entity.Property(e => e.Id).ValueGeneratedNever(); });

        modelBuilder.Entity<EngineModelPattern>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.EngineModel).WithMany(p => p.EngineModelPattern)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EngineModelPattern_EngineModel");
        });

        modelBuilder.Entity<KeylessIgnition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KeylessI__3214EC0729E1CCCB");
        });

        modelBuilder.Entity<LowerBeamHeadlampLightSource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LowerBea__3214EC077A78C7A5");
        });

        modelBuilder.Entity<Make>(entity => { entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())"); });

        modelBuilder.Entity<Make_Model>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Make).WithMany(p => p.Make_Model)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Make_Model_Make");

            entity.HasOne(d => d.Model).WithMany(p => p.Make_Model)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Make_Model_Model");
        });

        modelBuilder.Entity<Model>(entity => { entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())"); });

        modelBuilder.Entity<Pattern>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Element).WithMany(p => p.Pattern)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pattern_Element");

            entity.HasOne(d => d.VinSchema).WithMany(p => p.Pattern)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pattern_VinSchema");
        });

        modelBuilder.Entity<PedestrianAutomaticEmergencyBraking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pedestri__3214EC07A638BA23");
        });

        modelBuilder.Entity<SemiautomaticHeadlampBeamSwitching>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Semiauto__3214EC071068B17A");
        });

        modelBuilder.Entity<VSpecSchemaPattern>(entity =>
        {
            entity.HasOne(d => d.Schema).WithMany(p => p.VSpecSchemaPattern)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VSpecSchema_VSpecPattern_VehicleSpecSchema");
        });

        modelBuilder.Entity<VehicleSpecPattern>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_VehicleData_NotWmiRelated");

            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Element).WithMany(p => p.VehicleSpecPattern)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VehicleData_NotWmiRelated_Element");
        });

        modelBuilder.Entity<VehicleSpecSchema>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_VehicleSpec");

            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<VinDescriptor>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<VinException>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<WMIYearValidChars_CacheExceptions>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Wmi>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NonCompliant).HasDefaultValue(false);
            entity.Property(e => e.NonCompliantSetByOVSC).HasDefaultValue(false);

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Wmi).HasConstraintName("FK_Wmi_Manufacturer");

            entity.HasOne(d => d.VehicleType).WithMany(p => p.Wmi).HasConstraintName("FK_Wmi_VehicleType");

            entity.HasMany(d => d.Make).WithMany(p => p.Wmi)
                .UsingEntity<Dictionary<string, object>>(
                    "Wmi_Make",
                    r => r.HasOne<Make>().WithMany()
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Wmi_Make_Make"),
                    l => l.HasOne<Wmi>().WithMany()
                        .HasForeignKey("WmiId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Wmi_Make_Wmi"),
                    j =>
                    {
                        j.HasKey("WmiId", "MakeId");
                        j.HasIndex(new[] { "MakeId" }, "IX_Wmi_Make_MakeId");
                    });
        });

        modelBuilder.Entity<Wmi_VinSchema>(entity =>
        {
            entity.HasOne(d => d.VinSchema).WithMany(p => p.Wmi_VinSchema)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Wmi_VinSchema_VinSchema");

            entity.HasOne(d => d.Wmi).WithMany(p => p.Wmi_VinSchema)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Wmi_VinSchema_Wmi");
        });

        modelBuilder.Entity<vNCSABodyType>(entity => { entity.ToView("vNCSABodyType"); });

        modelBuilder.Entity<vNCSAMake>(entity => { entity.ToView("vNCSAMake"); });

        modelBuilder.Entity<vNCSAModel>(entity => { entity.ToView("vNCSAModel"); });
    }
}