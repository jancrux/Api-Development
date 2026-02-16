using Api_Development.Models.Domain;

namespace Api_Development.Repositories.Interfaces
{
    public interface IWalkRepository
    {

        Task<Walk> CreateWalkAsync(Walk Walk);

    }
}
