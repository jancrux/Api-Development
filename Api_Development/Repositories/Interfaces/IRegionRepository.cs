using Api_Development.Models.Domain;
using Api_Development.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api_Development.Repositories.Interfaces
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        
        Task<Region?> GetByIdAsync(Guid id);

        Task<Region> CreateRegionAsync(Region Region);

        Task<Region?> UpdateRegionAsync(Guid ID_Region, Region Region);

        Task<Region?> DeleteAsync(Guid ID_Region);
    }
}
