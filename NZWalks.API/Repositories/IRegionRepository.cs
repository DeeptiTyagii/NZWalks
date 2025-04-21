using NZWalks.API.Domain.Models;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetByIdAsync(Guid id);
        Task<Region> CreateAsync(Region Region);
        Task<Region?> UpdateAsync(Guid id, Region Region);
        Task<Region?> DeleteAsync(Guid id);
    }
}
