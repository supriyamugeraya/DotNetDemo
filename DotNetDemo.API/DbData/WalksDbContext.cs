using DotNetDemo.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DotNetDemo.API.DbData
{
    public class WalksDbContext:DbContext
    {
        public WalksDbContext(DbContextOptions<WalksDbContext> dbContextOptions):base(dbContextOptions)
        {

        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
    }
}


 