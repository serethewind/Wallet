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
    }
}
