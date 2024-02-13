using VariacaoAtivoApi.DTOs;
using VariacaoAtivoApi.Models;

namespace VariacaoAtivoApi.Services
{
    public interface IVariacaoAtivosService
    {
        public Task<List<VariacaoAtivos>> ConvertToVariacaoAtivosList(AtivosResponseDto adto);
        public Task SaveVariacoesAtivosIfNotExists(List<VariacaoAtivos> variacoesAtivos);
    }
}
