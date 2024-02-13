using VariacaoAtivoApi.DTOs;
using VariacaoAtivoApi.Models;

namespace VariacaoAtivoApi.Services
{
    public interface IConsultarAtivosServices
    {
        public Task<List<VariacaoAtivos>> ConsultarAtivo(ConsultarAtivoQueryDto consultaAtivo);
    }
}
