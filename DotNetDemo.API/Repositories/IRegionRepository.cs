using DotNetDemo.API.Models.Domain;

namespace DotNetDemo.API.Repositories
{
    public interface IRegionRepository
    {
     Task<List<Region>> GetAllAsync();
    }
}
