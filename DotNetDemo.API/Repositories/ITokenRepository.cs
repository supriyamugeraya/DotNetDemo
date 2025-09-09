using Microsoft.AspNetCore.Identity;

namespace DotNetDemo.API.Repositories
{
    public interface ITokenRepository
    {
       string CreateJWTToken(IdentityUser user,List<string>roles );
    }
}
