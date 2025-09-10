using AutoMapper;
using DotNetDemo.API.CustomActionFilters;
using DotNetDemo.API.DbData;
using DotNetDemo.API.Models.Domain;
using DotNetDemo.API.Models.DTO;
using DotNetDemo.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace DotNetDemo.API.Controllers
{
    //https://localhost:7032/api/regions

    [Route("api/[controller]")]
    [ApiController]
    
    public class RegionController : ControllerBase
    {
        private readonly WalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        private readonly ILogger<RegionController> logger;

        public RegionController(WalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper,
            ILogger<RegionController>logger)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        //GET ALL REGIONS 
        //GET:https://localhost:7032/api/regions

        [HttpGet]
        //[Authorize(Roles ="Reader")]
        public async Task<IActionResult> GetAll()
        {
                   // get data from datbase domain model.
                var regionsDomain = await regionRepository.GetAllAsync();
               
                 //Return DTOs
               
                return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
                  

        }

        // Get Single region (get region by id)
        //GET:https://localhost:7032/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var region=dbContext.Regions.Find(id);
            //Get Region Domain model from database
            var regionDomain = await regionRepository.GetByIdAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }

            //Return DTO back to Client
            return Ok(mapper.Map<RegionDto>(regionDomain));
        }


        //POST TO Create New Region
        //POST:https://localhost:7032/api/regions
        [HttpPost]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {

            
                //Map or convert DTO into Domain Model
                var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

                //Map Domain model back to DTO

                var regionDto = mapper.Map<RegionDto>(regionDomainModel);
                return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
            

        }



        //Update Region 
        //PUT :https://localhost:7032/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            
                
                //Map DTO to Domain Model
                var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);
                //Check if region Exsists
                regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

                if (regionDomainModel == null)
                {
                    return NotFound();

                }

                return Ok(mapper.Map<RegionDto>(regionDomainModel));


        }


        //Delete Region
        //DELETE: https://localhost:7032/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer,Reader")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel=await regionRepository.DeleteAsync(id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }
         
            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }

    }
}

