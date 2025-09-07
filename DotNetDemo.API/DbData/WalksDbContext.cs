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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Difficulties
            //Easy , medium , Hard
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id=Guid.Parse("4143d42d-7be9-4363-8069-a123470ca381"),
                    Name="Easy"
                },
                new Difficulty()
                {
                    Id=Guid.Parse("3b5f62f5-1c41-4393-9a8a-bd559cbc188d"),
                    Name="Medium"
                },
                new Difficulty()
                {
                    Id=Guid.Parse("d9154729-7057-421f-9eb6-0ff2159d3dd7"),
                    Name="Hard"
                },
            };

            //seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for Regions
            var regions = new List<Region>
            {
                new Region
                {
                    Id=Guid.Parse("65a5490a-d2ff-4163-ae3c-c34cc42350c0"),
                    Name="Auckland",
                    Code="AKL",
                    RegionImageUrl="https://cdn.holidayguru.ch/wp-content/uploads/2017/03/skyline-von-auckland-istock_49893056_large-2.jpg"
                },
                new Region
                {
                    Id=Guid.Parse("cb7682a7-76b3-43b1-900a-c7f6f33ea915"),
                    Name="Northland",
                    Code="NTL",
                    RegionImageUrl=null
                },
                new Region
                {
                    Id=Guid.Parse("b8ccb03b-7c2a-4335-9735-2b13be4aa34b"),
                    Name="Bay of Plenty",
                    Code="BOP",
                    RegionImageUrl=null
                 },
                new Region
                {
                    Id=Guid.Parse("a0a5c0ae-9a84-4110-a925-0c44e74ed31c"),
                    Name="Wellington",
                    Code="WGN",
                    RegionImageUrl="https://datacom.com/content/dam/images/admin/insights/experience/ai-attitudes-research-report/nz/WellingtonCity.jpg"
                 },
                new Region
                {
                    Id=Guid.Parse("fba177f6-df80-4918-9a16-1a0f55a2a020"),
                    Name="Nelson",
                    Code="NSN",
                    RegionImageUrl="https://i.natgeofe.com/n/6784d56f-a792-4d57-9a05-f6a9500dd2f2/68382.jpg"
                 },
                new Region
                {
                    Id=Guid.Parse("bd4b05e3-0e09-4d7e-bb74-6c684aca998e"),
                    Name="Southland",
                    Code="STL",
                    RegionImageUrl=null
                 },
            };
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}


 