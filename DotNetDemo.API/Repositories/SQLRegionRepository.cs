using DotNetDemo.API.DbData;
using DotNetDemo.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DotNetDemo.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly WalksDbContext dbContext;

        public SQLRegionRepository(WalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Region>> GetAllAsync()
        {
          return await dbContext.Regions.ToListAsync();
        }
    }
}
