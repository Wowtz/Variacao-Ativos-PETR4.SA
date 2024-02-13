using VariacaoAtivoApi.Models;

namespace VariacaoAtivoApi.Repositories
{
    public interface IVariacaoAtivosRepository
    {
        public Task<VariacaoAtivos> ObterPorIdAsync(Guid id);
        public Task<Guid> AdicionarAsync(VariacaoAtivos variacaoAtivos);
        public Task<bool> Exists(string nome, DateTime data);
        public Task SaveChangesAsync();
    }
}
