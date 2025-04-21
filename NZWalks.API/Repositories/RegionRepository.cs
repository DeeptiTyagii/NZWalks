using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Domain.Models;

namespace NZWalks.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        public readonly NZWalksDbContext _dbContext;
        public RegionRepository(NZWalksDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> CreateAsync(Region Region)
        {
            await _dbContext.AddAsync(Region);
            await _dbContext.SaveChangesAsync();
            return Region;
        }

        public async Task<Region?> UpdateAsync(Guid id, Region Region)
        {
            var existingRegion = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if(existingRegion == null)
            {
                return null;
            }
            existingRegion.Code = Region.Code;
            existingRegion.Name = Region.Name;
            existingRegion.RegionImageUrl = Region.RegionImageUrl;

            await _dbContext.SaveChangesAsync();

            return existingRegion;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var existingRegion = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRegion == null)
            {
                return null;
            }

            _dbContext.Regions.Remove(existingRegion);
            await _dbContext.SaveChangesAsync();

            return existingRegion;
        }
    }
}
