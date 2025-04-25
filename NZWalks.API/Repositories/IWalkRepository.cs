using NZWalks.API.Domain.Models;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk Walk);
    }
}
