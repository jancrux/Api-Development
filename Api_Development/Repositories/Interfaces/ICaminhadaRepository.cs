using Api_Development.Models.Domain;

namespace Api_Development.Repositories.Interfaces
{
    public interface ICaminhadaRepository
    {
        Task<List<Caminhada>> GetAllAsync();
        Task<Caminhada?> GetByIdAsync(Guid id);
        Task<Caminhada> CreateCaminhadaAsync(Caminhada Caminhada);
        Task<Caminhada?> UpdateCaminhadaAsync(Guid CaminhadaId, Caminhada Caminhada);
        Task<Caminhada?> DeleteAsync(Guid CaminhadaId);
    }
}
