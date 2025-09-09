using System.ComponentModel.DataAnnotations;

namespace DotNetDemo.API.Models.DTO
{
    public class ImageUploadRquestDto
    {
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public string FileName { get; set; }

        public string? FileDescription { get; set; }
    }
}
