using DotNetDemo.API.Models.Domain;
using DotNetDemo.API.Models.DTO;
using DotNetDemo.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        //POST : /api/Images/Upload
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm]ImageUploadRquestDto request)
        {
            ValidateFileUpload(request);
            if (ModelState.IsValid)
            {

                //Convert DTO to Domain Model
                var imagedomainModel = new Image
                {
                    File = request.File,
                    FileExtention = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length,
                    FileName = request.File.FileName,
                    FileDescription = request.FileDescription
                };


                //user repository to upload image
                await imageRepository.Upload(imagedomainModel);
                return Ok(imagedomainModel);
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
