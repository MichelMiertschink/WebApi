using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RedeFrotaController : ControllerBase
    {
        public readonly IRedeFrotaService _redeFrotaService;

        public RedeFrotaController(IRedeFrotaService redeFrotaService)
        {
            _redeFrotaService = redeFrotaService;
        }

        [HttpPost("&cliente={cliente}&dta_inicio={dta_inicio}&dta_final={dta_final}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarRedefrota([FromRoute] string dta_inicio, string dta_final)
        {
            var response = await _redeFrotaService.BuscarRedefrota(dta_inicio, dta_final);

            if (response.CodigoHttp == System.Net.HttpStatusCode.OK)
            {
                return Ok(response.DadosRetorno);
            }
            else
            {
                return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
            }
        }
    }
}
