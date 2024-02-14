using Microsoft.EntityFrameworkCore;
using VariacaoAtivoApi.Data;
using VariacaoAtivoApi.Models;
using VariacaoAtivoApi.Repositories;

namespace VariacaoAtivosApi.Repositories
{
    public class VariacaoAtivosRepository : IVariacaoAtivosRepository
    {
        private readonly ApplicationDbContext _context;

        public VariacaoAtivosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<VariacaoAtivos> ObterPorIdAsync(Guid id)
        {
            return await _context.VariacaoAtivos.FindAsync(id);
        }

        public async Task<Guid> AdicionarAsync(VariacaoAtivos VariacaoAtivos)
        {
            _context.VariacaoAtivos.Add(VariacaoAtivos);
            return VariacaoAtivos.Id;
        }

        public async Task<bool> Exists(string nome, DateTime data)
        {
            try
            {
                return await _context.VariacaoAtivos
                .AnyAsync(x => x.Nome == nome && x.Data == data);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao consultar o ativo.", ex);
            }
            
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
