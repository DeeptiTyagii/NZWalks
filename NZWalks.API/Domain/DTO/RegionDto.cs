namespace NZWalks.API.Domain.DTO
{
    public class RegionDto
    {
        //will have properties we want to expose to client
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? RegionImageUrl { get; set; }
    }
}
