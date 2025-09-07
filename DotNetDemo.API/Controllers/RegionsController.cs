using DotNetDemo.API.DbData;
using DotNetDemo.API.Models.Domain;
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
        //GET:https://localhost:7032/api/regions//GET 

        [HttpGet]
        public IActionResult GetAll()
        {

            var regions = dbContext.Regions.ToList();
            return Ok(regions);

        }

        // Get Single region (get region by id)
        //GET:https://localhost:7032/api/regions//GET 
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id) 
        {
            //var region=dbContext.Regions.Find(id);
            var region = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (region == null)
            {
                return NotFound();
            }
            return Ok(region);
        }
    }
}

