using apbd_kl_2.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_kl_2.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Items> Items { get; set; }
    public DbSet<Backpacks> Backpacks { get; set; }
    public DbSet<Characters> Characters { get; set; }
    public DbSet<CharacterTitles> CharacterTitles{ get; set; }
    public DbSet<Titles> Titles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Items>().HasData(new List<Items>
        {
            new Items
            {
                Id = 1,
                Name = "Pickaxe",
                Weight = 5
            },
            new Items
            {
                Id = 2,
                Name = "Sword",
                Weight = 3
            }
        });
        
        modelBuilder.Entity<Titles>().HasData(new List<Titles>
        {
            new Titles
            {
                Id = 1,
                Name = "Title 1"
            },
            new Titles
            {
                Id = 2,
                Name = "Title 2"
            }
        });
        
        modelBuilder.Entity<Characters>().HasData(new List<Characters>
        {
            new Characters
            {
                Id = 1,
                FirstName = "Saul",
                LastName = "Hudson",
                CurrentWeight = 10,
                MaxWeight = 50
            },
            new Characters
            {
                Id = 2,
                FirstName = "James",
                LastName = "Hetfield",
                CurrentWeight = 5,
                MaxWeight = 60
            }
        });
        
        modelBuilder.Entity<Backpacks>().HasData(new List<Backpacks>
        {
            new Backpacks
            {
                CharacterId = 1,
                ItemId = 1,
                Amount = 1
            },
            new Backpacks()
            {
                CharacterId = 2,
                ItemId = 2,
                Amount = 1
            }
        });
        
        modelBuilder.Entity<CharacterTitles>().HasData(new List<CharacterTitles>
        {
            new CharacterTitles
            {
                CharacterId = 1,
                TitleId = 1,
                AcquiredAt = DateTime.Parse("2024-06-11")
            },
            new CharacterTitles
            {
                CharacterId = 2,
                TitleId = 2,
                AcquiredAt = DateTime.Parse("2024-06-10")
            }
        });
        
        
        
        

    }
}