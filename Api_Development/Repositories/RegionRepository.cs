using Api_Development.Models.Domain;
using Api_Development.Models.DTOs;
using Api_Development.Models.Entities;
using Api_Development.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Development.Repositories
{
    public class RegionRepository : IRegionRepository
    {

        //injecao de dependecia do dbContext
        private readonly AppDbContext dbContext;

        public RegionRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Region> CreateRegionAsync(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid ID_Region)
        {
            var regionModel = await dbContext.Regions.FirstOrDefaultAsync(a => a.Id == ID_Region);
            if (regionModel == null)
            {
                return null;
            }

            dbContext.Regions.Remove(regionModel);
            await dbContext.SaveChangesAsync();
            return regionModel;

        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Region?> UpdateRegionAsync(Guid ID_Region, Region region)
        {
             var existingRegionDomain =  await dbContext.Regions.FirstOrDefaultAsync(a => a.Id == ID_Region);

            if(existingRegionDomain == null)
            {
                return null;
            }

            existingRegionDomain.Name = region.Name;
            existingRegionDomain.Code = region.Code;
            existingRegionDomain.RegionImageUrl = region.RegionImageUrl;

            await dbContext.SaveChangesAsync();

            return existingRegionDomain;
        }
    }
}
