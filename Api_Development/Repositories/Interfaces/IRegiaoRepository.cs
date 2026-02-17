using Api_Development.Models.Domain;
using Api_Development.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api_Development.Repositories.Interfaces
{
    public interface IRegiaoRepository
    {
        Task<List<Regiao>> GetAllAsync();
        
        Task<Regiao?> GetByIdAsync(Guid id);

        Task<Regiao> CreateRegiaoAsync(Regiao Regiao);

        Task<Regiao?> UpdateRegiaoAsync(Guid RegiaoId, Regiao Regiao);

        Task<Regiao?> DeleteAsync(Guid RegiaoId);
    }
}
