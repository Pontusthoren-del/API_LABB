using API_LABB.Models;
using Microsoft.EntityFrameworkCore;
namespace API_LABB.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Interest> Interests { get; set; }
    public DbSet<PersonInterest> PersonInterests { get; set; }
    public DbSet<Link> Links { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonInterest>()
            .HasKey(pi => new { pi.PersonId, pi.InterestId });

        modelBuilder.Entity<PersonInterest>()
            .HasOne(pi => pi.Person)
            .WithMany(p => p.PersonInterests)
            .HasForeignKey(pi => pi.PersonId);

        modelBuilder.Entity<PersonInterest>()
            .HasOne(pi => pi.Interest)
            .WithMany(i => i.PersonInterests)
            .HasForeignKey(pi => pi.InterestId);

        modelBuilder.Entity<Link>()
            .HasOne(l => l.Person)
            .WithMany(p => p.Links)
            .HasForeignKey(l => l.PersonId);

        modelBuilder.Entity<Link>()
            .HasOne(l => l.PersonName)
            .WithMany(i => i.Links)
            .HasForeignKey(l => l.InterestId);

        modelBuilder.Entity<Person>().HasData(
            new Person { Id = 1, Name = "Anna Svensson", Phone = "070-123 45 67" },
            new Person { Id = 2, Name = "Erik Lindqvist", Phone = "073-987 65 43" },
            new Person { Id = 3, Name = "Maria Johansson", Phone = "076-555 12 34" },
            new Person { Id = 4, Name = "Oskar Bergström", Phone = "072-444 98 76" },
            new Person { Id = 5, Name = "Lina Karlsson", Phone = "070-333 21 09" },
            new Person { Id = 6, Name = "David Nilsson", Phone = "073-222 87 65" },
            new Person { Id = 7, Name = "Sara Eriksson", Phone = "076-111 54 32" },
            new Person { Id = 8, Name = "Johan Petersson", Phone = "072-999 43 21" },
            new Person { Id = 9, Name = "Emma Lundgren", Phone = "070-888 76 54" },
            new Person { Id = 10, Name = "Felix Magnusson", Phone = "073-777 65 43" }
        );

        modelBuilder.Entity<Interest>().HasData(
            new Interest { Id = 1, Title = "Skidåkning", Description = "Alpint och längdskidor" },
            new Interest { Id = 2, Title = "Programmering", Description = "Webb- och apputveckling" },
            new Interest { Id = 3, Title = "Matlagning", Description = "Laga mat från olika kulturer" },
            new Interest { Id = 4, Title = "Fotografi", Description = "Landskap och porträttfoto" },
            new Interest { Id = 5, Title = "Löpning", Description = "Motionslöpning och tävling" },
            new Interest { Id = 6, Title = "Musik", Description = "Spela och lyssna på musik" },
            new Interest { Id = 7, Title = "Läsning", Description = "Skönlitteratur och facklitteratur" },
            new Interest { Id = 8, Title = "Gaming", Description = "PC- och konsolspel" },
            new Interest { Id = 9, Title = "Yoga", Description = "Rörlighet och mindfulness" },
            new Interest { Id = 10, Title = "Cykling", Description = "Landsvägscykling och MTB" },
            new Interest { Id = 11, Title = "Klättring", Description = "Inomhus- och utomhusklättring" },
            new Interest { Id = 12, Title = "Filmklubb", Description = "Se och diskutera film" }
        );

        modelBuilder.Entity<PersonInterest>().HasData(
            new PersonInterest { PersonId = 1, InterestId = 1 },
            new PersonInterest { PersonId = 1, InterestId = 2 },
            new PersonInterest { PersonId = 1, InterestId = 5 },
            new PersonInterest { PersonId = 2, InterestId = 2 },
            new PersonInterest { PersonId = 2, InterestId = 3 },
            new PersonInterest { PersonId = 2, InterestId = 8 },
            new PersonInterest { PersonId = 3, InterestId = 4 },
            new PersonInterest { PersonId = 3, InterestId = 7 },
            new PersonInterest { PersonId = 3, InterestId = 9 },
            new PersonInterest { PersonId = 4, InterestId = 5 },
            new PersonInterest { PersonId = 4, InterestId = 10 },
            new PersonInterest { PersonId = 4, InterestId = 11 },
            new PersonInterest { PersonId = 5, InterestId = 6 },
            new PersonInterest { PersonId = 5, InterestId = 7 },
            new PersonInterest { PersonId = 5, InterestId = 12 },
            new PersonInterest { PersonId = 6, InterestId = 2 },
            new PersonInterest { PersonId = 6, InterestId = 8 },
            new PersonInterest { PersonId = 6, InterestId = 11 },
            new PersonInterest { PersonId = 7, InterestId = 3 },
            new PersonInterest { PersonId = 7, InterestId = 9 },
            new PersonInterest { PersonId = 7, InterestId = 12 },
            new PersonInterest { PersonId = 8, InterestId = 1 },
            new PersonInterest { PersonId = 8, InterestId = 4 },
            new PersonInterest { PersonId = 8, InterestId = 10 },
            new PersonInterest { PersonId = 9, InterestId = 5 },
            new PersonInterest { PersonId = 9, InterestId = 6 },
            new PersonInterest { PersonId = 9, InterestId = 7 },
            new PersonInterest { PersonId = 10, InterestId = 2 },
            new PersonInterest { PersonId = 10, InterestId = 8 },
            new PersonInterest { PersonId = 10, InterestId = 12 }
        );


        modelBuilder.Entity<Link>().HasData(
            new Link { Id = 1, PersonId = 1, InterestId = 1, Url = "https://skistar.com", Label = "SkiStar" },
            new Link { Id = 2, PersonId = 1, InterestId = 2, Url = "https://github.com/anna", Label = "Annas GitHub" },
            new Link { Id = 3, PersonId = 1, InterestId = 5, Url = "https://runnersworld.com", Label = "Runners World" },
            new Link { Id = 4, PersonId = 2, InterestId = 2, Url = "https://stackoverflow.com", Label = "Stack Overflow" },
            new Link { Id = 5, PersonId = 2, InterestId = 3, Url = "https://alltommat.se", Label = "Allt om Mat" },
            new Link { Id = 6, PersonId = 2, InterestId = 8, Url = "https://store.steampowered.com", Label = "Steam" },
            new Link { Id = 7, PersonId = 3, InterestId = 4, Url = "https://500px.com", Label = "500px" },
            new Link { Id = 8, PersonId = 3, InterestId = 7, Url = "https://goodreads.com", Label = "Goodreads" },
            new Link { Id = 9, PersonId = 3, InterestId = 9, Url = "https://yogajournal.com", Label = "Yoga Journal" },
            new Link { Id = 10, PersonId = 4, InterestId = 5, Url = "https://strava.com", Label = "Strava" },
            new Link { Id = 11, PersonId = 4, InterestId = 10, Url = "https://cyclingweekly.com", Label = "Cycling Weekly" },
            new Link { Id = 12, PersonId = 4, InterestId = 11, Url = "https://thebmc.co.uk", Label = "The BMC" },
            new Link { Id = 13, PersonId = 5, InterestId = 6, Url = "https://spotify.com", Label = "Spotify" },
            new Link { Id = 14, PersonId = 5, InterestId = 7, Url = "https://bokus.com", Label = "Bokus" },
            new Link { Id = 15, PersonId = 5, InterestId = 12, Url = "https://filmtipset.se", Label = "Filmtipset" },
            new Link { Id = 16, PersonId = 6, InterestId = 2, Url = "https://leetcode.com", Label = "LeetCode" },
            new Link { Id = 17, PersonId = 6, InterestId = 8, Url = "https://twitch.tv", Label = "Twitch" },
            new Link { Id = 18, PersonId = 6, InterestId = 11, Url = "https://climbingwall.com", Label = "Climbing Wall" },
            new Link { Id = 19, PersonId = 7, InterestId = 3, Url = "https://koket.se", Label = "Köket.se" },
            new Link { Id = 20, PersonId = 7, InterestId = 9, Url = "https://downdogapp.com", Label = "Down Dog" },
            new Link { Id = 21, PersonId = 7, InterestId = 12, Url = "https://imdb.com", Label = "IMDb" },
            new Link { Id = 22, PersonId = 8, InterestId = 1, Url = "https://skidresor.se", Label = "Skidresor.se" },
            new Link { Id = 23, PersonId = 8, InterestId = 4, Url = "https://unsplash.com", Label = "Unsplash" },
            new Link { Id = 24, PersonId = 8, InterestId = 10, Url = "https://bikeradar.com", Label = "BikeRadar" },
            new Link { Id = 25, PersonId = 9, InterestId = 5, Url = "https://garmin.com", Label = "Garmin Connect" },
            new Link { Id = 26, PersonId = 9, InterestId = 6, Url = "https://soundcloud.com", Label = "SoundCloud" },
            new Link { Id = 27, PersonId = 9, InterestId = 7, Url = "https://adlibris.com", Label = "Adlibris" },
            new Link { Id = 28, PersonId = 10, InterestId = 2, Url = "https://docs.microsoft.com", Label = "Microsoft Docs" },
            new Link { Id = 29, PersonId = 10, InterestId = 8, Url = "https://ign.com", Label = "IGN" },
            new Link { Id = 30, PersonId = 10, InterestId = 12, Url = "https://letterboxd.com", Label = "Letterboxd" }  
        );
    }
}
