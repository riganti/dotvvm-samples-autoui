using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeetupManager.Core.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{

    public DbSet<Country> Countries => Set<Country>();

    public DbSet<Location> Locations => Set<Location>();

    public DbSet<Meetup> Meetups => Set<Meetup>();
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=meetups.sqlite");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>()
            .HasData(
                new Country() { Id = 1, Name = "Austria" },
                new Country() { Id = 2, Name = "Belgium" },
                new Country() { Id = 3, Name = "Bulgaria" },
                new Country() { Id = 4, Name = "Croatia" },
                new Country() { Id = 5, Name = "Cyprus" },
                new Country() { Id = 6, Name = "Czech Republic" },
                new Country() { Id = 7, Name = "Denmark" },
                new Country() { Id = 8, Name = "Estonia" },
                new Country() { Id = 9, Name = "Finland" },
                new Country() { Id = 10, Name = "France" },
                new Country() { Id = 11, Name = "Germany" },
                new Country() { Id = 12, Name = "Greece" },
                new Country() { Id = 13, Name = "Hungary" },
                new Country() { Id = 14, Name = "Ireland" },
                new Country() { Id = 15, Name = "Italy" },
                new Country() { Id = 16, Name = "Latvia" },
                new Country() { Id = 17, Name = "Lithuania" },
                new Country() { Id = 18, Name = "Luxembourg" },
                new Country() { Id = 19, Name = "Malta" },
                new Country() { Id = 20, Name = "Netherlands" },
                new Country() { Id = 21, Name = "Poland" },
                new Country() { Id = 22, Name = "Portugal" },
                new Country() { Id = 23, Name = "Romania" },
                new Country() { Id = 24, Name = "Slovakia" },
                new Country() { Id = 25, Name = "Slovenia" },
                new Country() { Id = 26, Name = "Spain" },
                new Country() { Id = 27, Name = "Sweden" }
            );

        modelBuilder.Entity<Location>()
            .HasData(
                new Location() { Id = 1, Name = "RIGANTI Prague", Address = "Sokolovska 352/215", City = "Praha", Zip = "190 00", CountryId = 6 },
                new Location() { Id = 2, Name = "RIGANTI Brno", Address = "Hybesova 61", City = "Brno", Zip = "602 00", CountryId = 6 },
                new Location() { Id = 3, Name = "Bratislava Startup Hub", City = "Bratislava", CountryId = 24 },
                new Location() { Id = 4, Name = "Berlin Cowork", City = "Berlin", CountryId = 11 },
                new Location() { Id = 5, Name = "Community Hub Dresden", City = "Dresden", CountryId = 11 }
            );

        base.OnModelCreating(modelBuilder);
    }
}