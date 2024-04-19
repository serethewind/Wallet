using Microsoft.EntityFrameworkCore;
using WalletApi.Models.Domains;

namespace WalletApi.Data
{
    public class WalletDbContext : DbContext
    {

        public WalletDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seeding data into db which involves writing the create table and the insert into queries in sql is simplified in the entitycore framework
            //first the object instances that correpsond to rows in the db table are created

            var difficulties = new List<Difficulty>(){
                new Difficulty
                {
                    Id = Guid.Parse("006d4c13-a079-42f8-8603-4abf778b3cf8"),
                    Name = "Easy"
                },
                new Difficulty
                {
                    Id = Guid.Parse("4e080aec-ddba-42c2-bc25-a4da2c72c705"),
                    Name = "Medium"
                },
                new Difficulty
                {
                    Id = Guid.Parse("7c2cc3dd-c3af-473f-9c63-8ecc72bbabc7") ,
                    Name = "Hard"
                }
            };

            //secondly the list is passed into the HasData method.
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var walks = new List<Walk>()
            {
                new Walk
                {

                    Id = Guid.NewGuid(),
                    Name = "Ring road walk",
                    Description = "A walk at the city center",
                    LengthInKm = 5,
                    WalkImageUrl = null,
                    RegionId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    DifficultyId = Guid.Parse("4E080AEC-DDBA-42C2-BC25-A4DA2C72C705")
                 
        //public Guid Id { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public double LengthInKm { get; set; }
        //public string? WalkImageUrl { get; set; }
        //public Guid RegionId { get; set; }

        //public Guid DifficultyId { get; set; }

        //public Difficulty Difficulty { get; set; }
        //public Region Region { get; set; }
    },
                new Walk
                {
                    Id = Guid.NewGuid(),
                    Name = "Visit Calabar Festival",
                    Description = "Take a visit to the largest carnival",
                    LengthInKm = 15,
                    WalkImageUrl = null,
                    RegionId = Guid.Parse("1D5716E5-FBCB-4210-8B02-B74E6926D13C"),
                    DifficultyId = Guid.Parse("4E080AEC-DDBA-42C2-BC25-A4DA2C72C705")
                },
                new Walk
                {
                    Id = Guid.NewGuid(),
                    Name = "Kaduna Education Institute",
                    Description = "Study in the south and north of Kaduna",
                    LengthInKm = 20,
                    WalkImageUrl = null,
                    RegionId = Guid.Parse("D8D64EDA-F5E9-45CB-8D5A-3C96F991AFCB"),
                    DifficultyId = Guid.Parse("7C2CC3DD-C3AF-473F-9C63-8ECC72BBABC7")
                },
                new Walk
                {
                    Id = Guid.NewGuid(),
                    Name = "Kano Commerce Center",
                    Description = "Take a visit to the largest carnival",
                    LengthInKm = 15,
                    WalkImageUrl = null,
                    RegionId = Guid.Parse("FF756D93-71FD-4ACC-A6D3-D5F5023CD25F"),
                    DifficultyId = Guid.Parse("4E080AEC-DDBA-42C2-BC25-A4DA2C72C705")
                }
            };

            modelBuilder.Entity<Walk>().HasData(walks);

            var regions = new List<Region>() { 
                new Region
                {
                    Id = Guid.Parse("ff756d93-71fd-4acc-a6d3-d5f5023cd25f"),
                    Code = "Kan",
                    Name = "Kano",
                    RegionImageUrl = "https://www.bellanaija.com/wp-content/uploads/2023/09/IMG-20230909-WA0022.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("d8d64eda-f5e9-45cb-8d5a-3c96f991afcb"),
                    Code = "Kad",
                    Name = "Kaduna",
                    RegionImageUrl = "https://momaa.org/wp-content/uploads/2019/10/zazzau-gate-1024x568.png"
                },
                new Region
                {
                    Id = Guid.Parse("edec48ed-f6b3-4cb9-b1c7-f133ea2d6133"),
                    Code = "Kas",
                    Name = "Kastina",
                    RegionImageUrl = "https://freedomradionig.com/wp-content/uploads/2020/07/katsina.jpg"
                }
            
            }; 

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
