using DotNetDemo.API.DbData;
using DotNetDemo.API.Models.Domain;
using DotNetDemo.API.Models.DTO;
using DotNetDemo.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetDemo.API.Controllers
{
    //https://localhost:7032/api/regions

    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly WalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;

        public RegionController(WalksDbContext dbContext,IRegionRepository regionRepository)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
        }


        //GET ALL REGIONS 
        //GET:https://localhost:7032/api/regions

        [HttpGet]
         public async Task<IActionResult> GetAll()
        {
            // Get Data From Database - Domain models
            var regionsDomain = await regionRepository.GetAllAsync(); 

            // Map Domain Models to DTOs
            var regionsDto=new List<RegionDto>();
            foreach (var regionDomain in regionsDomain) 
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl
                });

              }

            //Return DTOs
            return Ok(regionsDto);

        }

        // Get Single region (get region by id)
        //GET:https://localhost:7032/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) 
        {
            //var region=dbContext.Regions.Find(id);
            //Get Region Domain model from database
            var regionDomain =await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (regionDomain == null)
            {
                return NotFound();
            }

            //Map/Convert Region Doamin Model to DTO
            var regionsDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };
            //Return DTO back to Client
            return Ok(regionsDto);
        }

        //POST TO Create New Region
        //POST:https://localhost:7032/api/regions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Map or convert DTO into Domain Model
            var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };
            //Use Domain Model to Create Region
            await  dbContext.Regions.AddAsync(regionDomainModel);
            await  dbContext.SaveChangesAsync();

            //Map Domain model back to DTO

            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl

            };
            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        //Update Region 
        //PUT :https://localhost:7032/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody] UpdateRegionrRquest updateRegionRequest)
        {
            var regionDomainmodel=await dbContext.Regions.FirstOrDefaultAsync(x=>x.Id==id);
            if (regionDomainmodel == null)
            {
                return NotFound();

            }
            //Map DTO to Domain Model
            regionDomainmodel.Code = updateRegionRequest.Code;
            regionDomainmodel.Name=updateRegionRequest.Name;
            regionDomainmodel.RegionImageUrl = updateRegionRequest.RegionImageUrl;

             await  dbContext.SaveChangesAsync();


            //Convert Domain Model to Dto
            var regionDto = new Region
            {
                Id = regionDomainmodel.Id,
                Code = regionDomainmodel.Code,
                Name = regionDomainmodel.Name,
                RegionImageUrl = regionDomainmodel.RegionImageUrl
            };

            return Ok(regionDto);


        }


        //Delete Region
        //DELETE: https://localhost:7032/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);  
            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //Delete the region
            dbContext.Regions.Remove(regionDomainModel);
            await dbContext.SaveChangesAsync();
            //return the deleted region back
            
            //Map Domain model back to DTO

            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl

            };
            return Ok(regionDto);
        }

    }
}

