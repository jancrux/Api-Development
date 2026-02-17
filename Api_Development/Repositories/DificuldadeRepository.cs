using Api_Development.Models.Domain;
using Api_Development.Models.Entities;
using Api_Development.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api_Development.Repositories
{
    public class DificuldadeRepository : IDificuldadeRepository
    {
        private readonly AppDbContext dbContext;
        public DificuldadeRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Dificuldade> CreateDificuldadeAsync(Dificuldade Dificuldade)
        {
            await dbContext.Dificuldades.AddAsync(Dificuldade);
            await dbContext.SaveChangesAsync();
            return Dificuldade;
        }

        public async Task<Dificuldade?> DeleteAsync(Guid DificuldadeId)
        {
            var dificuldadeModel = await dbContext.Dificuldades.FirstOrDefaultAsync(a => a.DificuldadeId == DificuldadeId);

            if(dificuldadeModel == null)
            {
                return null;
            }

            dbContext.Dificuldades.Remove(dificuldadeModel);
            await dbContext.SaveChangesAsync();

            return dificuldadeModel;

        }

        public async Task<List<Dificuldade>> GetAllAsync()
        {
            var dificuldades = await dbContext.Dificuldades.ToListAsync();

            return dificuldades;
        }

        public async Task<Dificuldade?> GetByIdAsync(Guid id)
        {
            var dificuldade = await dbContext.Dificuldades.FirstOrDefaultAsync(a => a.DificuldadeId == id);

            if(dificuldade == null)
            {
                return null;
            }

            return dificuldade;
        }

        public async Task<Dificuldade?> UpdateDificuldadeAsync(Guid DificuldadeId, Dificuldade Dificuldade)
        {
            //vamos buscar o objeto existente no banco de dados
            var dificuldadeExistente = await dbContext.Dificuldades.FirstOrDefaultAsync(a => a.DificuldadeId == DificuldadeId);

            if(dificuldadeExistente == null)
            {
                return null;
            }

            dificuldadeExistente.Nome = Dificuldade.Nome;

            await dbContext.SaveChangesAsync();
            return dificuldadeExistente;

        }
    }
}
