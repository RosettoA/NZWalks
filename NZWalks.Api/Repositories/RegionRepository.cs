using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Data;
using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _dbContext;
        public RegionRepository(NZWalksDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _dbContext.Regions.ToListAsync();
        }
    }
}
