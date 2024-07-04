using Microsoft.EntityFrameworkCore;
using si730ebu202212721.API.Inventory.Domain.Model.Aggregates;
using si730ebu202212721.API.Inventory.Domain.Model.ValueObjects;
using si730ebu202212721.API.Observability.Domain.Model.Aggregates;
using si730ebu202212721.API.Observability.Domain.Model.ValueObjects;
using si730ebu202212721.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace si730ebu202212721.API.Shared.Infrastructure.Persistence.EFC.Configuration;

/**
 * AppDbContext class
 * <summary>
 *   - AppDbContext class is a DbContext class that represents the database context.
 *   - It is used to configure the database and its entities.
 * </summary>
 * <remarks>
 *   - Author : U202212721 Mathias Jave Diaz
 *  - Version : 1.0.0
 * </remarks>
 */
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Thing> Things { get; set; }
    public DbSet<ThingState> ThingStates { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        builder.AddInterceptors();
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Thing>().ToTable("things");
        builder.Entity<Thing>().HasKey(thing => thing.Id);
        builder.Entity<Thing>().Property(thing => thing.Id).ValueGeneratedOnAdd();
        builder.Entity<Thing>().Property(thing => thing.Model).IsRequired();
        builder.Entity<Thing>().Property(thing => thing.MaximumTemperatureThreshold).IsRequired();
        builder.Entity<Thing>().Property(thing => thing.MinimumHumidityThreshold).IsRequired();
        builder.Entity<Thing>().Property(thing => thing.OperationMode).IsRequired();
        builder.Entity<Thing>().Property(thing => thing.CreatedDate).IsRequired();
        builder.Entity<Thing>().Property(thing => thing.UpdatedDate);
        builder.Entity<Thing>().OwnsOne<SerialNumber>(thing => thing.SerialNumberValueObject, srn =>
        {
            srn.WithOwner().HasForeignKey("Id");
            srn.Property(serialNumber => serialNumber.Value).HasColumnName("SerialNumber");
        });
        
        builder.Entity<ThingState>().ToTable("thing_states");
        builder.Entity<ThingState>().HasKey(thingState => thingState.Id);
        builder.Entity<ThingState>().Property(thingState => thingState.Id).ValueGeneratedOnAdd();
        builder.Entity<ThingState>().Property(thingState => thingState.CurrentOperationMode).IsRequired();
        builder.Entity<ThingState>().Property(thingState => thingState.CurrentTemperature).IsRequired();
        builder.Entity<ThingState>().Property(thingState => thingState.CurrentHumidity).IsRequired();
        builder.Entity<ThingState>().Property(thingState => thingState.CollectedAt).IsRequired();
        builder.Entity<ThingState>().Property(thingState => thingState.CreatedDate).IsRequired();
        builder.Entity<ThingState>().Property(thingState => thingState.UpdatedDate);
        builder.Entity<ThingState>().HasOne<Thing>(thingState => thingState.Thing).WithMany(thing => thing.ThingStates).HasForeignKey(thingState => thingState.ThingId);
        builder.Entity<ThingState>().OwnsOne<ThingSerialNumber>(thingState => thingState.ThingSerialNumberValueObject, srn =>
        {
            srn.WithOwner().HasForeignKey("Id");
            srn.Property(serialNumber => serialNumber.Value).HasColumnName("ThingSerialNumber");
        });
        
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}