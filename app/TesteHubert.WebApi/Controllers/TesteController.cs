using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TesteHubert.Interfaces;
using TesteHubert.WebApi.ViewModels;

namespace TesteHubert.WebApi.Controllers
{
    [Route("buscar")]
    [ApiController]
    public class TesteController : Controller
    {
        private readonly ITesteService _testeService;
        public TesteController(ITesteService testeService)
        {
            _testeService = testeService;
        }
        [HttpGet("a")]
        public async Task<ActionResult> BuscarItemA(TesteViewModel model)
        {
            var jsonA = await _testeService.BuscarItemA(model.IdCliente, model.Data);

            return Ok(jsonA);
        }
        [HttpGet("b")]
        public async Task<ActionResult> BuscarItemB(TesteViewModel model)
        {
            var jsonB = await _testeService.BuscarItemB(model.IdCliente, model.DataInicial, model.DataFinal);

            return Ok(jsonB);
        }
        [HttpGet("c")]
        public async Task<ActionResult> BuscarItemC(TesteViewModel model)   
        {
            var jsonC = await _testeService.BuscarItemC(model.IdCliente, model.DataDePagamento, model.ValorPago);

            return Ok(jsonC);
        }
        [HttpGet("d")]
        public async Task<ActionResult> BuscarItemD(TesteViewModel model)
        {
            var jsonD = await _testeService.BuscarItemD(model.IdCliente);

            return Ok(jsonD);
        }
    }
}

