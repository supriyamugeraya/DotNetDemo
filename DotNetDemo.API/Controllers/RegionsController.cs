using DotNetDemo.API.DbData;
using DotNetDemo.API.Models.Domain;
using DotNetDemo.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetDemo.API.Controllers
{
    //https://localhost:7032/api/regions

    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly WalksDbContext dbContext;
        public RegionController(WalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        //GET ALL REGIONS 
        //GET:https://localhost:7032/api/regions

        [HttpGet]
        public IActionResult GetAll()
        {
            // Get Data From Database - Domain models
            var regionsDomain=dbContext.Regions.ToList();

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
        public IActionResult GetById([FromRoute] Guid id) 
        {
            //var region=dbContext.Regions.Find(id);
            //Get Region Domain model from database
            var regionDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id);
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
        public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Map or convert DTO into Domain Model
            var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };
            //Use Domain Model to Create Region
            dbContext.Regions.Add(regionDomainModel);
            dbContext.SaveChanges();

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

    }
}

