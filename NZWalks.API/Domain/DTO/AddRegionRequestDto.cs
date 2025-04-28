using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Domain.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be maximum of 100 characters.")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MinLength(2, ErrorMessage = "Code has to be minimum of 2 characters.")]
        [MaxLength(4, ErrorMessage = "Code has to be maximum of 4 characters.")]
        public string Code { get; set; } = string.Empty;
        public string? RegionImageUrl { get; set; }
    }
}
