using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using sweetmanager.API.Clients.Domain.Model.Aggregates;
using sweetmanager.API.Communication.Domain.Model.Aggregates;
using sweetmanager.API.Communication.Domain.Model.Aggregates.Alerts;
using sweetmanager.API.IAM.Domain.Model.Aggregates.Management;
using sweetmanager.API.IAM.Domain.Model.Aggregates.Work;
using sweetmanager.API.IAM.Domain.Model.Entities.Credential;
using sweetmanager.API.IAM.Domain.Model.Entities.Roles.Standard;
using sweetmanager.API.IAM.Domain.Model.Entities.Roles.SupervisionAreas;
using sweetmanager.API.IAM.Domain.Model.Entities.Roles.WorkerAreas;
using sweetmanager.API.Payments.Domain.Model.Aggregates;
using sweetmanager.API.Reports.Domain.Model.Aggregates;
using sweetmanager.API.Rooms.Domain.Model.Aggregates;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using sweetmanager.API.Subscriptions.Domain.Model.Aggregates;
using Task = sweetmanager.API.Inspection.Domain.Model.Aggregates.Assignments.Task;

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

        // Monitoring Context
        builder.Entity<Report>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            entity.Property(c => c.Title).IsRequired();
            entity.Property(c => c.Content).IsRequired();
            entity.Property(c => c.Image);
            entity.Property(c => c.ReportType).IsRequired().HasConversion<string>();
        });

        builder.Entity<Bedroom>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();

            entity.Property(e => e.TypeBedroom).IsRequired().HasConversion<string>();

            entity.Property(e => e.BedroomStatus).IsRequired().HasConversion<string>();
            
            entity.Property(e => e.BedroomState).IsRequired().HasConversion<string>();

            entity.OwnsOne(e => e.Information, i =>
            {
                i.WithOwner().HasForeignKey("Id");
                i.Property(b => b.TotalBathroom).HasColumnName("TotalBathroom");
                i.Property(b => b.TotalBed).HasColumnName("TotalBed");
                i.Property(b => b.TotalTelevision).HasColumnName("TotalTelevision");
                i.Property(b => b.Description).HasColumnName("Description");
                i.Property(b => b.Price).HasColumnName("Price");
            });

            entity.OwnsOne(e => e.Personnel,
                n =>
                {
                    n.WithOwner().HasForeignKey("Id");
                    n.Property(e => e.Worker).HasColumnName("Worker");
                    n.Property(e => e.Client).HasColumnName("Client");
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

            entity.Property(e => e.BookingStatus)
                .HasColumnName("state")
                .IsRequired()
                .HasMaxLength(50);
        });

        // Subscriptions
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
        builder.Entity<Client>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            entity.Property(c => c.Name).IsRequired();
            entity.Property(c => c.LastName).IsRequired();
            entity.Property(c => c.Age).IsRequired();
            entity.Property(c => c.Genre).IsRequired();
            entity.Property(c => c.Phone).IsRequired();
            entity.Property(c => c.Email).IsRequired();
            entity.Property(c => c.State).IsRequired();
        });

        builder.Entity<Notification>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            entity.Property(c => c.Title).IsRequired();
            entity.Property(c => c.Message).IsRequired();
        });
        
      builder.Entity<Alerts>(entity =>
      {
          entity.HasKey(c => c.Id);
          entity.Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
          entity.Property(c => c.Title).IsRequired();
          entity.Property(c => c.Description).IsRequired();
      });

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

        // IAM Context
        
        /*builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired().HasMaxLength(25);
        builder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(35);
        // Will save the Role id in the Database because is a one-to-many relationship
        builder.Entity<User>().HasOne(u => u.Role).WithMany();
        builder.Entity<Role>(entity =>
        {
            entity.HasKey(r => r.Id);
            entity.Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
            entity.Property(r => r.Name).IsRequired().HasConversion<string>();
        });*/

        builder.Entity<Role>(a =>
        {
            a.HasKey(r => r.Id);
            a.Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
            a.Property(r => r.Name).IsRequired().HasConversion<string>();
        });

        builder.Entity<WorkerRole>(a =>
        {
            a.HasKey(r => r.Id);
            a.Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
            a.Property(r => r.Role).IsRequired().HasConversion<string>();
        });

        builder.Entity<AdministratorWorkerRole>(a =>
        {
            a.HasKey(mwr => new { mwr.AdministratorId, mwr.WorkerRoleId });
            a.HasOne(mwr => mwr.Administrator)
                .WithMany(c => c.SupervisionAreaManagerWorkerRoles)
                .HasForeignKey(mwr => mwr.AdministratorId);

            a.HasOne(r => r.WorkerRole)
                .WithMany(c => c.Administrators)
                .HasForeignKey(mwr => mwr.WorkerRoleId);
        });
        
        builder.Entity<Administrator>(entity =>
        {
            entity.HasKey(m => m.Id);
            entity.Property(m => m.Id).IsRequired().ValueGeneratedOnAdd();
            entity.Property(u => u.Username).IsRequired();
            entity.Property(u => u.Email).IsRequired();
            entity.Property(u => u.AccountStatus).IsRequired().HasMaxLength(15);
            entity.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(20);
            // Will save the Role id in the Database because is a one-to-many relationship
            entity.HasOne(u => u.Role).WithMany();
            entity.OwnsOne(e => e.Name, n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(c => c.Name).HasColumnName("Name");
                n.Property(c => c.Surname).HasColumnName("Surname");
            });
        });
        
        builder.Entity<Worker>(entity =>
        {
            entity.HasKey(m => m.Id);
            entity.Property(m => m.Id).IsRequired().ValueGeneratedOnAdd();
            entity.Property(u => u.Username).IsRequired();
            entity.Property(u => u.Email).IsRequired();
            // entity.Property(u => u.RoleArea).IsRequired().HasConversion<string>(); // Less Efficiency, better readable database
            entity.Property(u => u.ActiveAccount).IsRequired();
            entity.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(20);
            entity.Property(u => u.RoleArea).IsRequired();
            entity.HasOne(w => w.WorkArea)
                .WithMany(wr => wr.Workers)
                .HasForeignKey(w => w.RoleArea);
            entity.OwnsOne(e => e.Name, n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(c => c.Name).HasColumnName("Name");
                n.Property(c => c.Surname).HasColumnName("Surname");
            });
            
            // Will save the Role id in the Database because is a one-to-many relationship
            entity.HasOne(u => u.Role).WithMany();
            
        });

        builder.Entity<WorkerCredential>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
            entity.Property(e => e.WorkerId).IsRequired();
            entity.Property(e => e.Argon2IdUserHash).IsRequired().HasMaxLength(50);

            entity.HasOne(w => w.Worker).WithOne(p => p.WorkerCredential)
                .HasForeignKey<WorkerCredential>(wc => wc.WorkerId).OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_worker_credentials_worker_id");
        });

        builder.Entity<AdministratorCredential>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
            entity.Property(e => e.AdminId).IsRequired();
            entity.Property(e => e.Argon2IdUserHash).IsRequired().HasMaxLength(50);

            entity.HasOne(a => a.Admin).WithOne(wc => wc.AdministratorCredential)
                .HasForeignKey<AdministratorCredential>(ac => ac.AdminId).OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_admin_credentials_admin_id");
        });
        
        builder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
            entity.Property(e => e.Title).IsRequired();
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.WorkerId).IsRequired();
        });
        
        // Apply SnakeCase Naming Convention
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}