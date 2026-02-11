using Api_Development.Models.Domain;

namespace Api_Development.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();

        Task<Region> GetByIdAsync(Guid id);

    }
}
