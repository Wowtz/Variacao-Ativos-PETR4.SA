using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace VariacaoAtivoApi.Controllers
{
    public class MainController : Controller
    {
        protected ICollection<string> Errors = new List<string>();


        protected ActionResult ResponseCustomizada(object result = null)
        {
            if (ValidarOperacao())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", Errors.ToArray() }
            }));
        }

        protected ActionResult ResponseCustomizada(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);

            foreach (var erro in erros)
            {
                AddErros(erro.ErrorMessage);
            }

            return ResponseCustomizada();
        }

        protected bool ValidarOperacao()
        {
            return !Errors.Any();
        }

        protected void LimparErros()
        {
            Errors.Clear();
        }

        protected void AddErros(string erro)
        {
            Errors.Add(erro);
        }
    }
}
