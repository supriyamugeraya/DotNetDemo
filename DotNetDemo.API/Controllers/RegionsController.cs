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


    }

    


}



//Hard coded list for controller and Action method.

//public class RegionsController : ControllerBase
//{
//    //GET ALL REGIONS 
//    //GET:https://localhost:7032/api/regions
//    [HttpGet]
//    public IActionResult GetAll()
//    {
//        var regions = new List<Region>
//        {
//            new Region
//            {
//                Id = Guid.NewGuid(),
//                Name = "Auckland region",
//                Code = "AKL",
//                RegionImageUrl = "https://www.pexels.com/photo/sunset-over-coconut-palms-by-the-ocean-in-thailand-31953957/"
//            },

//            new Region
//            {
//                Id = Guid.NewGuid(),
//                Name = "Wellington region",
//                Code = "WLG",
//                RegionImageUrl = "https://www.pexels.com/photo/charming-rooftop-view-of-caen-normandy-32429483/"
//            }

//        };
//        return Ok(regions);

//}

