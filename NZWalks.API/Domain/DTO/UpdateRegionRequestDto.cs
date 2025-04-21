namespace NZWalks.API.Domain.DTO
{
    public class UpdateRegionRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? RegionImageUrl { get; set; }
    }
}
