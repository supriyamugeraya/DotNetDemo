using AutoMapper;
using DotNetDemo.API.Models.Domain;
using DotNetDemo.API.Models.DTO;
using DotNetDemo.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetDemo.API.Controllers
{
    // /api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper,IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }


        // Create Walk
        //POST:/Api/walks

        [HttpPost]
        public async Task<IActionResult> Create( [FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            //Map DTO TO Domain Model
            var WalkDomainModel= mapper.Map<Walk>(addWalkRequestDto);
            await walkRepository.CreateAsync(WalkDomainModel);

            //Map Domain Model to DTO

            return Ok(mapper.Map<WalkDto>(WalkDomainModel));


         }
    }
}
