using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Domain.Models;

namespace NZWalks.API.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext _dbContext;

        public WalkRepository(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Walk> CreateAsync(Walk Walk)
        {
            await _dbContext.Walks.AddAsync(Walk);
            await _dbContext.SaveChangesAsync();
            return Walk;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await _dbContext.Walks
                .Include("Difficulty")
                .Include("Region")
                .ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Walks
                .Include("Difficulty")
                .Include("Region")
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk Walk)
        {
            var existingWalk = await _dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWalk == null)
            {
                return null;
            }

            existingWalk.Name = Walk.Name;
            existingWalk.Description = Walk.Description;
            existingWalk.LengthInKm = Walk.LengthInKm;
            existingWalk.WalkImageUrl = Walk.WalkImageUrl;
            existingWalk.DifficultyId = Walk.DifficultyId;
            existingWalk.RegionId = Walk.RegionId;

            await _dbContext.SaveChangesAsync();

            return existingWalk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingWalk = await _dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWalk == null)
            {
                return null;
            }

            _dbContext.Walks.Remove(existingWalk);
            await _dbContext.SaveChangesAsync();

            return existingWalk;
        }
    }
}
