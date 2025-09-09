using DotNetDemo.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {

        //POST : /api/Images/Upload
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm]ImageUploadRquestDto request)
        {
            ValidateFileUpload(request);
            if (ModelState.IsValid)
            { 
                //user repository to upload image
            }
            return BadRequest(ModelState);

        }

        private void ValidateFileUpload(ImageUploadRquestDto request)
        {
            var allowedextentions = new string[] { ".jpg", ".jpeg", ".png" };
            if (!allowedextentions.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }

            if (request.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size is more than 10MB,Please upload smaller size file");
            }

        }
    }
}
