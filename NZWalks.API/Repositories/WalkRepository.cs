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
            return await _dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }
    }
}
