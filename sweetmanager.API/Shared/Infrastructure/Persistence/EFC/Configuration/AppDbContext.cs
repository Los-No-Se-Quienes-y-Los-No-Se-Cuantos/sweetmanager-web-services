using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using sweetmanager.API.Rooms.Domain.Model.Aggregates;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Bedroom>(entity =>
        {
            entity.HasKey(e => e.Id);
            
            entity.OwnsOne(e => e.Information, i =>
            {
                i.WithOwner().HasForeignKey("Id");
                i.Property(b => b.TotalBathroom).HasColumnName("TotalBathroom");
                i.Property(b => b.TotalBed).HasColumnName("TotalBed");
                i.Property(b => b.TotalTelevision).HasColumnName("TotalTelevision");
            });
            
            entity.Property(e => e.BedroomStatus)
                .HasColumnName("state")
                .IsRequired()
                .HasMaxLength(50);
        });

        builder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id);
            
            entity.HasOne<Bedroom>()
                .WithMany()
                .HasForeignKey(e => e.BedroomId);
            
            entity.OwnsOne(e => e.Detail, i =>
            {
                i.WithOwner().HasForeignKey("Id");
                i.Property(d => d.StartDate).HasColumnName("StartDate");
                i.Property(d => d.FinalDate).HasColumnName("FinalDate");
                i.Property(d => d.Discount).HasColumnName("Discount");
                i.Property(d => d.TotalPrice).HasColumnName("TotalPrice");
            });

            /*entity.HasOne<Client>()
                .WithMany()
                .HasForeignKey(e => e.ClientId);*/
            
            entity.Property(e => e.BookingStatus)
                .HasColumnName("state")
                .IsRequired()
                .HasMaxLength(50);
        });
        
        /*
        // Place here your entities configuration

        builder.Entity<Category>().HasKey(c => c.Id);
        builder.Entity<Category>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(30);

        builder.Entity<Tutorial>().HasKey(t => t.Id);
        builder.Entity<Tutorial>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Tutorial>().Property(t => t.Title).IsRequired().HasMaxLength(50);
        builder.Entity<Tutorial>().Property(t => t.Summary).HasMaxLength(240);

        builder.Entity<Asset>().HasDiscriminator(a => a.Type);
        builder.Entity<Asset>().HasKey(p => p.Id);
        builder.Entity<Asset>().HasDiscriminator<string>("asset_type")
            .HasValue<Asset>("asset_base")
            .HasValue<ImageAsset>("asset_image")
            .HasValue<VideoAsset>("asset_video")
            .HasValue<ReadableContentAsset>("asset_readable_content");

        builder.Entity<Asset>().OwnsOne(i => i.AssetIdentifier,
            ai =>
            {
                ai.WithOwner().HasForeignKey("Id");
                ai.Property(p => p.Identifier).HasColumnName("AssetIdentifier");
            });
        builder.Entity<ImageAsset>().Property(p => p.ImageUri).IsRequired();
        builder.Entity<VideoAsset>().Property(p => p.VideoUri).IsRequired();
        builder.Entity<ReadableContentAsset>().Property(p => p.ReadableContent).IsRequired();
        builder.Entity<Tutorial>().HasMany(t => t.Assets);
        
        // Category Relationships
        builder.Entity<Category>()
            .HasMany(c => c.Tutorials)
            .WithOne(t => t.Category)
            .HasForeignKey(t => t.CategoryId)
            .HasPrincipalKey(t => t.Id);
        
        // Profiles Context
        
        builder.Entity<Profile>().HasKey(p => p.Id);
        builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Profile>().OwnsOne(p => p.Name,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.FirstName).HasColumnName("FirstName");
                n.Property(p => p.LastName).HasColumnName("LastName");
            });

        builder.Entity<Profile>().OwnsOne(p => p.Email,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.Address).HasColumnName("EmailAddress");
            });

        builder.Entity<Profile>().OwnsOne(p => p.Address,
            a =>
            {
                a.WithOwner().HasForeignKey("Id");
                a.Property(s => s.Street).HasColumnName("AddressStreet");
                a.Property(s => s.Number).HasColumnName("AddressNumber");
                a.Property(s => s.City).HasColumnName("AddressCity");
                a.Property(s => s.PostalCode).HasColumnName("AddressPostalCode");
                a.Property(s => s.Country).HasColumnName("AddressCountry");
            });

        
        // Apply SnakeCase Naming Convention
        
        */
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}