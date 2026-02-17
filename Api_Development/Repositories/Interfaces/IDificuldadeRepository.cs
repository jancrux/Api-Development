using Api_Development.Models.Domain;

namespace Api_Development.Repositories.Interfaces
{
    public interface IDificuldadeRepository
    {

        Task<List<Dificuldade>> GetAllAsync();
        Task<Dificuldade?> GetByIdAsync(Guid id);
        Task<Dificuldade> CreateDificuldadeAsync(Dificuldade Dificuldade);
        Task<Dificuldade?> UpdateDificuldadeAsync(Guid DificuldadeId, Dificuldade Dificuldade);
        Task<Dificuldade?> DeleteAsync(Guid DificuldadeId);

    }
}
