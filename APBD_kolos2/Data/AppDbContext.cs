using APBD_kolos2.Entities;
using Microsoft.EntityFrameworkCore;

namespace APBD_kolos2.Data;
public class AppDbContext : DbContext
{
    protected AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Client> Clients { get; set; }
    public DbSet<Mechanic> Mechanics { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Visit> Visits { get; set; }
    public DbSet<VisitService> VisitServices { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Client>().HasData(
            new Client { ClientId = 1, FirstName = "Jan", LastName = "Kowalski", DateOfBirth = new DateTime(2000, 1, 1) },
            new Client { ClientId = 2, FirstName = "Dawid", LastName = "Zygzak", DateOfBirth = new DateTime(1999, 1, 1) }
        );

        modelBuilder.Entity<Mechanic>().HasData(
            new Mechanic { MechanicId = 1, FirstName = "Jan", LastName = "Kowalski", LicenseNumber = "123456789" },
            new Mechanic { MechanicId = 2, FirstName = "Dawid", LastName = "Zygzak", LicenseNumber = "987654321" });
        
        modelBuilder.Entity<Service>().HasData(
            new Service { ServiceId = 1, Name = "Zmiana oleju", BaseFee = 200m },
            new Service { ServiceId = 2, Name = "Przeglad", BaseFee = 100m });
        
        modelBuilder.Entity<Visit>().HasData(
            new Visit { VisitId = 1, ClientId = 1, MechanicId = 1, Date = new DateTime(2022, 1, 1) },
            new Visit { VisitId = 2, ClientId = 2, MechanicId = 2, Date = new DateTime(2022, 1, 2) });
        
        modelBuilder.Entity<VisitService>().HasData(
            new VisitService { VisitId = 1, ServiceId = 1, ServiceFee = 200m },
            new VisitService { VisitId = 1, ServiceId = 2, ServiceFee = 100m },
            new VisitService { VisitId = 2, ServiceId = 1, ServiceFee = 200m });
    }
}