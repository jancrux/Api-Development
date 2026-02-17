using Api_Development.Models.Domain;
using Api_Development.Models.DTOs;
using Api_Development.Models.Entities;
using Api_Development.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Development.Repositories
{
    public class RegiaoRepository : IRegiaoRepository
    {

        //injecao de dependecia do dbContext
        private readonly AppDbContext dbContext;

        public RegiaoRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Regiao> CreateRegiaoAsync(Regiao regiao)
        {
            await dbContext.Regioes.AddAsync(regiao);
            await dbContext.SaveChangesAsync();
            return regiao;
        }

        public async Task<Regiao?> DeleteAsync(Guid ID_Regiao)
        {
            var regionModel = await dbContext.Regioes.FirstOrDefaultAsync(a => a.RegiaoId == ID_Regiao);
            if (regionModel == null)
            {
                return null;
            }

            dbContext.Regioes.Remove(regionModel);
            await dbContext.SaveChangesAsync();
            return regionModel;

        }

        public async Task<List<Regiao>> GetAllAsync()
        {
            return await dbContext.Regioes.ToListAsync();
        }

        public async Task<Regiao?> GetByIdAsync(Guid id)
        {
            return await dbContext.Regioes.FirstOrDefaultAsync(a => a.RegiaoId == id);
        }

        public async Task<Regiao?> UpdateRegiaoAsync(Guid ID_Regiao, Regiao regiao)
        {
             var existingRegionDomain =  await dbContext.Regioes.FirstOrDefaultAsync(a => a.RegiaoId == ID_Regiao);

            if(existingRegionDomain == null)
            {
                return null;
            }

            existingRegionDomain.Nome = regiao.Nome;
            existingRegionDomain.Codigo = regiao.Codigo;
            existingRegionDomain.ImagemRegiaoUrl = regiao.ImagemRegiaoUrl;

            await dbContext.SaveChangesAsync();

            return existingRegionDomain;
        }
    }
}
