using DotNetDemo.API.DbData;
using DotNetDemo.API.Models.Domain;

namespace DotNetDemo.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly WalksDbContext dbContext;

        public SQLWalkRepository(WalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }
    }
}
