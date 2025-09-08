using DotNetDemo.API.Models.Domain;

namespace DotNetDemo.API.Repositories
{
    public interface IWalkRepository
    {
       Task<Walk> CreateAsync(Walk walk);
       Task<List<Walk>> GetAllAsync();
    }

       
}
