using System.ComponentModel.DataAnnotations;

namespace DotNetDemo.API.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(3,ErrorMessage ="Code has to be a minimum of 3 charactors")]
        [MaxLength(3,ErrorMessage ="Code has to be a maximum of 3 charactors")]
        public string Code { get; set; }
        
        
        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be a maximum of 100 charactors")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
