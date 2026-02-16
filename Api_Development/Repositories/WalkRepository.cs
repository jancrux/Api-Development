using Api_Development.Models.Domain;
using Api_Development.Models.Entities;
using Api_Development.Repositories.Interfaces;
using System.Runtime.CompilerServices;

namespace Api_Development.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly AppDbContext dbContext;

        public WalkRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        
        }

        public async Task<Walk> CreateWalkAsync(Walk Walk)
        {
            await dbContext.Walks.AddAsync(Walk);
            await dbContext.SaveChangesAsync();
            return Walk;


        }
    }
}
