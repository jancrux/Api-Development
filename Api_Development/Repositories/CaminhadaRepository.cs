using Api_Development.Models.Domain;
using Api_Development.Models.Entities;
using Api_Development.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Api_Development.Repositories
{
    public class CaminhadaRepository : ICaminhadaRepository
    {
        private readonly AppDbContext dbContext;
        public CaminhadaRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Caminhada> CreateCaminhadaAsync(Caminhada Caminhada)
        {
            await dbContext.Caminhadas.AddAsync(Caminhada);
            await dbContext.SaveChangesAsync();
            return Caminhada;


        }
        public async Task<Caminhada?> DeleteAsync(Guid CaminhadaId)
        {
            //vai-se buscar o objecto à base de dados
            var caminhadaModel = await dbContext.Caminhadas.FirstOrDefaultAsync(a => a.CaminhadaId == CaminhadaId);

            //se não existir o objecto, retorna-se null
            if (caminhadaModel == null)
            {
                return null;
            }

            //se existir o objecto, remove-se da base de dados e retorna-se o objecto removido
            dbContext.Caminhadas.Remove(caminhadaModel);
            await dbContext.SaveChangesAsync();
            return caminhadaModel;
        }
        public async Task<List<Caminhada>> GetAllAsync()
        {
            var caminhadas = await dbContext.Caminhadas.ToListAsync();

            return caminhadas;
        }
        public async Task<Caminhada?> GetByIdAsync(Guid id)
        {
            var caminhada = await dbContext.Caminhadas.FirstOrDefaultAsync(a => a.CaminhadaId == id);

            if (caminhada == null)
            {
                return null;
            }

            return caminhada;
        }
        public async Task<Caminhada?> UpdateCaminhadaAsync(Guid CaminhadaId, Caminhada Caminhada)
        {
            //Vai-se buscar o objecto existente à base de dados

            var caminhadaModel = await dbContext.Caminhadas.FirstOrDefaultAsync(a => a.CaminhadaId == CaminhadaId);

            if (caminhadaModel == null)
            {
                return null;
            }

            //caso exista mapeamos os novos valores para o objecto existente

            caminhadaModel.Nome = Caminhada.Nome;
            caminhadaModel.Descricao = Caminhada.Descricao;
            caminhadaModel.DistanciaKm = Caminhada.DistanciaKm;
            caminhadaModel.CaminhadaImagemUrl = Caminhada.CaminhadaImagemUrl;
            caminhadaModel.DificuldadeId = Caminhada.DificuldadeId;
            caminhadaModel.RegiaoId = Caminhada.RegiaoId;

            //no Fim colocamos o objeto atualizado na base de dados e retornamos o objecto atualizado

            await dbContext.SaveChangesAsync();
            return caminhadaModel;

        }
    }
}
