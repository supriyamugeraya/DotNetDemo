using DotNetDemo.API.Models.Domain;
using System.Net;

namespace DotNetDemo.API.Repositories
{
    public interface IImageRepository
    {
       Task<Image> Upload(Image image);
    }
}
