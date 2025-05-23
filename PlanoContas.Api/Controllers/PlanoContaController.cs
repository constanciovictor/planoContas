using Azure;
using Microsoft.AspNetCore.Mvc;
using PlanoContas.Application.DTOs.PlanoContas.Request;
using PlanoContas.Application.DTOs.PlanoContas.Response;
using PlanoContas.Application.Interfaces;
using PlanoContas.Domain.Models.Base;

namespace PlanoContas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanoContaController : ControllerBase
    {
        private readonly IPlanoContaApplication _planoContaApplication;

        public PlanoContaController(IPlanoContaApplication planoContaApplication)
        {
            _planoContaApplication = planoContaApplication;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetPlanoContasResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<ReportErrors>))]
        public async Task<IActionResult> GetPlanosContasAsync()
        {
            return Ok(await _planoContaApplication.ObterTodosAsync());
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetPlanoContasResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<ReportErrors>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<ReportErrors>))]
        public async Task<IActionResult> GetPlanoContaByIdAsync(int id)
        {
            var response = await _planoContaApplication.ObterPorIdAsync(id);

            if (response.Errors.Any())
                return BadRequest(response.Errors);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseBase))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<ReportErrors>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<ReportErrors>))]
        public async Task<IActionResult> PostPlanoContaAsync([FromBody] CreatePlanoContasRequest request)
        {
            var response = await _planoContaApplication.AdicionarAsync(request);

            if (response.Errors.Any())
                return UnprocessableEntity(response.Errors);
             
            return Ok(response);
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseBase))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<ReportErrors>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<ReportErrors>))]
        public async Task<IActionResult> PatchPlanoContaAsync([FromBody] PatchPlanoContasRequest request)
        {
            var response = await _planoContaApplication.AtualizarAsync(request);

            if (response.Errors.Any())
                return UnprocessableEntity(response.Errors);

            return Ok(response);
        }

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseBase))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<ReportErrors>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<ReportErrors>))]
        public async Task<IActionResult> DeletePlanoContaAsync(int id)
        {
            var response = await _planoContaApplication.RemoverAsync(id);

            if (response.Errors.Any())
                return UnprocessableEntity(response.Errors);

            return Ok(response);
        }
    }
}
