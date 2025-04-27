using NZWalks.API.Domain.Models;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk Walk);
        Task<List<Walk>> GetAllAsync();
        Task<Walk?> GetByIdAsync(Guid id);
        Task<Walk?> UpdateAsync(Guid id, Walk Walk);
        Task<Walk?> DeleteAsync(Guid id);
    }
}
