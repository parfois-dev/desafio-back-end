using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Parfois.DesafioBackEnd.Api.Controllers.Swagger;
using Parfois.DesafioBackEnd.Api.Helpers;
using Parfois.DesafioBackEnd.Models.Dtos.AlterarStatusDoPedido;
using Parfois.DesafioBackEnd.Models.Dtos.CriarPedido;
using Parfois.DesafioBackEnd.Services.Interfaces;
using Swashbuckle.AspNetCore.Filters;

namespace Parfois.DesafioBackEnd.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class PedidosController : ControllerBase
    {
        private readonly ILogger<PedidosController> _logger;
        private readonly AbstractValidator<CriarPedidoRequest> _criarPedidoValidator;
        private readonly AbstractValidator<AlterarStatusRequest> _alterarStatusValidator;
        private readonly ICriarPedidoService _criarPedidoService;
        private readonly IAlterarStatusDoPedidoService _alterarStatusDoPedidoService;

        public PedidosController(
            ILogger<PedidosController> logger,
            AbstractValidator<CriarPedidoRequest> criarPedidoValidator,
            AbstractValidator<AlterarStatusRequest> alterarStatusValidator,
            ICriarPedidoService criarPedidoService,
            IAlterarStatusDoPedidoService alterarStatusDoPedidoService)
        {
            _logger = logger;
            _criarPedidoValidator = criarPedidoValidator;
            _alterarStatusValidator = alterarStatusValidator;
            _criarPedidoService = criarPedidoService;
            _alterarStatusDoPedidoService = alterarStatusDoPedidoService;
        }

        [HttpPost]
        [Route("pedido")]
        public async Task<IActionResult> CriarPedidoAsync(CriarPedidoRequest request)
        {
            try
            {
                var resultadoDaValidacao = await _criarPedidoValidator.ValidateAsync(request);
                if (!resultadoDaValidacao.IsValid)
                {
                    return BadRequest(ErroHelper.FormatarErros(resultadoDaValidacao));
                }

                await _criarPedidoService.CriarPedidoAsync(request);

                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"{nameof(PedidosController)}.{nameof(CriarPedidoAsync)} - Erro ao criar pedido.{Environment.NewLine}" +
                    $"Motivo: {exception.Message}");

                return Problem();
            }
        }

        [HttpPut]
        [Route("status")]
        public async Task<IActionResult> AlterarStatusAsync(AlterarStatusRequest request)
        {
            try
            {
                var resultadoDaValidacao = await _alterarStatusValidator.ValidateAsync(request);
                if (!resultadoDaValidacao.IsValid)
                {
                    return BadRequest(ErroHelper.FormatarErros(resultadoDaValidacao));
                }

                var resposta = await _alterarStatusDoPedidoService.AlterarStatusDoPedidoAsync(request);

                return Ok(resposta);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"{nameof(PedidosController)}.{nameof(AlterarStatusAsync)} - Erro ao alterar status.{Environment.NewLine}" +
                    $"Motivo: {exception.Message}");

                return Problem();
            }
        }
    }
}
