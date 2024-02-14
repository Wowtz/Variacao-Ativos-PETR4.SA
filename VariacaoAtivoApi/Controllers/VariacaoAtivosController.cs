using Microsoft.AspNetCore.Mvc;
using VariacaoAtivoApi.DTOs;
using VariacaoAtivoApi.Models;
using VariacaoAtivoApi.Services;

namespace VariacaoAtivoApi.Controllers
{
    [Route("v1/[controller]")]
    public class VariacaoAtivosController : MainController
    {
        private readonly IConsultarAtivosServices _consultarAtivosServices;

        public VariacaoAtivosController(IConsultarAtivosServices consultarAtivosServices)
        {
            _consultarAtivosServices = consultarAtivosServices;
        }

        [HttpGet("{nome}")]
        public async Task<ActionResult<List<VariacaoAtivos>>> ColetarDados(string nome)
        {
            try
            {
                var consulta = new ConsultarAtivoQueryDto(nome);

                var listaAtivos = await _consultarAtivosServices.ConsultarAtivo(consulta);
                if (listaAtivos == null)
                {
                    AddErros("Ativo não encontrado.");
                    return ResponseCustomizada();
                }

                return ResponseCustomizada(listaAtivos);
            }
            catch (Exception ex)
            {
                AddErros("Ocorreu um na requisição: " + ex.Message);
                return ResponseCustomizada();
            }
        }
    }
}
