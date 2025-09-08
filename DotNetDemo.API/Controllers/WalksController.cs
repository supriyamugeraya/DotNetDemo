using AutoMapper;
using DotNetDemo.API.CustomActionFilters;
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
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
           
                //Map DTO TO Domain Model
                var WalkDomainModel = mapper.Map<Walk>(addWalkRequestDto);
                await walkRepository.CreateAsync(WalkDomainModel);

                //Map Domain Model to DTO

                return Ok(mapper.Map<WalkDto>(WalkDomainModel));
        }


        //Get Walks
        //GET: /api/walks?filterOn=Name&filterQuery=Track&sortBy=Name&isAscending=true
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery]string? filterOn, [FromQuery]string?filterQuery,
            [FromQuery]string? sortBy, [FromQuery]bool? isAscending)
        {
           var walkDomainModel= await walkRepository.GetAllAsync(filterOn,filterQuery,sortBy,isAscending??true);

            //Map Domain Model to DTO
            return Ok(mapper.Map<List<WalkDto>>(walkDomainModel));
        }


        //Get Walk By Id

        //Get:/api/Walks/{id}

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel=await walkRepository.GetByIdAsync(id);

            if (walkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }


        //Update Walk By Id

        //PUT: /api/Walks/{id}

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {
                    //map DTO to Domain Model
                    var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);

                    walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);
                    if (walkDomainModel == null)
                    {
                        return NotFound();
                    }

                    //Map Domain Model To DTO
                    return Ok(mapper.Map<WalkDto>(walkDomainModel));
                
        }

        //delete a walk id
        //DELETE: /api/Walks/{id}

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
          var deletedWalkDomainModel=  await walkRepository.DeleteAsync(id);   
            if(deletedWalkDomainModel == null)
            {
                return NotFound();
            }

            //Map Domain Model To DTO
            return Ok(mapper.Map<WalkDto>(deletedWalkDomainModel));
        }
    }
}
