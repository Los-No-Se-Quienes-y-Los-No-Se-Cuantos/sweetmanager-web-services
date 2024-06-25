using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using sweetmanager.API.Clients.Domain.Model.Aggregates;
using sweetmanager.API.Communication.Domain.Model.Aggregates;
using sweetmanager.API.Payments.Domain.Model.Aggregates;
using sweetmanager.API.Payments.Domain.Model.ValueObjects;
using sweetmanager.API.Rooms.Domain.Model.Aggregates;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using sweetmanager.API.Subscriptions.Domain.Model.Aggregates;

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

        // Suscriptions
        builder.Entity<Subscription>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();

            entity.Property(e => e.Title).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Price).IsRequired();
            entity.Property(e => e.Features).IsRequired();
            entity.Property(e => e.Features).HasConversion(
                v => string.Join("%-%", v),
                v => v.Split("%-%", StringSplitOptions.RemoveEmptyEntries).ToList());
        });
        builder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();

            entity.Property(e => e.Email)
                .IsRequired();

            entity.OwnsOne(e => e.CardInfo, i =>
            {
                i.WithOwner().HasForeignKey("Id");
                i.Property(c => c.CardNumber).HasColumnName("CardNumber");
                i.Property(c => c.CardHolderName).HasColumnName("CardHolderName");
                i.Property(c => c.ExpiryDate).HasColumnName("ExpiryDate");
                i.Property(c => c.Cvv).HasColumnName("Cvv");
            });

            entity.Property(e => e.Amount)
                .IsRequired();

            entity.OwnsOne(e => e.ProfileId, i =>
            {
                i.WithOwner().HasForeignKey("Id");
                i.Property(p => p.Identifier).HasColumnName("Identifier");
            });
        });
        builder.Entity<Client>().HasKey(c => c.Id);
        builder.Entity<Client>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Client>().Property(c => c.Name).IsRequired();
        builder.Entity<Client>().Property(c => c.LastName).IsRequired();
        builder.Entity<Client>().Property(c => c.Age).IsRequired();
        builder.Entity<Client>().Property(c => c.Genre).IsRequired();
        builder.Entity<Client>().Property(c => c.Phone).IsRequired();
        builder.Entity<Client>().Property(c => c.Email).IsRequired();
        builder.Entity<Client>().Property(c => c.State).IsRequired();

        builder.Entity<Notification>().HasKey(c => c.Id);
        builder.Entity<Notification>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Notification>().Property(c => c.Title).IsRequired();
        builder.Entity<Notification>().Property(c => c.Message).IsRequired();
        
        builder.Entity<Supply.Domain.Model.Aggregates.Supply>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Product)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Quantity)
                .IsRequired()
                .HasDefaultValue(0);

            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(e => e.ExpireDate)
                .IsRequired()
                .HasMaxLength(10);

            entity.Property(e => e.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
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