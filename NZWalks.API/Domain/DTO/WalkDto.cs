namespace NZWalks.API.Domain.DTO
{
    public class WalkDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        //since we get the id info in the dto 
         
        //public Guid DifficultyId { get; set; }
        //public Guid RegionId { get; set; }
        public RegionDto Region { get; set; }
        public DifficultyDto Difficulty { get; set; }
    }
}
