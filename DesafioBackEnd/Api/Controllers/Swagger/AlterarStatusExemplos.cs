using Parfois.DesafioBackEnd.Models;
using Parfois.DesafioBackEnd.Models.Dtos.AlterarStatusDoPedido;
using Swashbuckle.AspNetCore.Filters;

namespace Parfois.DesafioBackEnd.Api.Controllers.Swagger
{
    public class AlterarStatusExemplos : IMultipleExamplesProvider<AlterarStatusRequest>
    {
        IEnumerable<SwaggerExample<AlterarStatusRequest>> IMultipleExamplesProvider<AlterarStatusRequest>.GetExamples()
        {
            yield return SwaggerExample.Create(
                "Copo & Prato Aprovado request example",
                new AlterarStatusRequest
                {
                    CodigoDoPedido = CriarPedidioExemplos.CodigoDoPedido,
                    ItensAprovados = CriarPedidioExemplos.TotalDeItens,
                    ValorAprovado = CriarPedidioExemplos.ValorTotal,
                    Status = Status.Aprovado
                });

            yield return SwaggerExample.Create(
                "Copo & Prato Reprovado request example",
                new AlterarStatusRequest
                {
                    CodigoDoPedido = CriarPedidioExemplos.CodigoDoPedido,
                    ItensAprovados = CriarPedidioExemplos.TotalDeItens,
                    ValorAprovado = CriarPedidioExemplos.ValorTotal,
                    Status = Status.Reprovado
                });

            yield return SwaggerExample.Create(
                "Codigo inexistente request example",
                new AlterarStatusRequest
                {
                    CodigoDoPedido = "",
                    ItensAprovados = CriarPedidioExemplos.TotalDeItens,
                    ValorAprovado = CriarPedidioExemplos.ValorTotal,
                    Status = Status.Aprovado
                });

            yield return SwaggerExample.Create(
                "Copo & Prato Aprovado valor maior request example",
                new AlterarStatusRequest
                {
                    CodigoDoPedido = CriarPedidioExemplos.CodigoDoPedido,
                    ItensAprovados = CriarPedidioExemplos.TotalDeItens,
                    ValorAprovado = 100,
                    Status = Status.Aprovado
                });

            yield return SwaggerExample.Create(
                "Copo & Prato Aprovado valor menor request example",
                new AlterarStatusRequest
                {
                    CodigoDoPedido = CriarPedidioExemplos.CodigoDoPedido,
                    ItensAprovados = CriarPedidioExemplos.TotalDeItens,
                    ValorAprovado = 1,
                    Status = Status.Aprovado
                });

            yield return SwaggerExample.Create(
                "Copo & Prato Aprovado quantidade maior request example",
                new AlterarStatusRequest
                {
                    CodigoDoPedido = CriarPedidioExemplos.CodigoDoPedido,
                    ItensAprovados = 100,
                    ValorAprovado = CriarPedidioExemplos.ValorTotal,
                    Status = Status.Aprovado
                });

            yield return SwaggerExample.Create(
                "Copo & Prato Aprovado quantidade menor request example",
                new AlterarStatusRequest
                {
                    CodigoDoPedido = CriarPedidioExemplos.CodigoDoPedido,
                    ItensAprovados = 1,
                    ValorAprovado = CriarPedidioExemplos.ValorTotal,
                    Status = Status.Aprovado
                });

            yield return SwaggerExample.Create(
                "Copo & Prato Aprovado valor e quantidade maior request example",
                new AlterarStatusRequest
                {
                    CodigoDoPedido = CriarPedidioExemplos.CodigoDoPedido,
                    ItensAprovados = 100,
                    ValorAprovado = 100,
                    Status = Status.Aprovado
                });

            yield return SwaggerExample.Create(
                "Copo & Prato Aprovado valor e quantidade menor request example",
                new AlterarStatusRequest
                {
                    CodigoDoPedido = CriarPedidioExemplos.CodigoDoPedido,
                    ItensAprovados = 1,
                    ValorAprovado = 1,
                    Status = Status.Aprovado
                });

            yield return SwaggerExample.Create(
                "Copo & Prato Aprovado valor maior e quantidade menor request example",
                new AlterarStatusRequest
                {
                    CodigoDoPedido = CriarPedidioExemplos.CodigoDoPedido,
                    ItensAprovados = 1,
                    ValorAprovado = 100,
                    Status = Status.Aprovado
                });

            yield return SwaggerExample.Create(
                "Copo & Prato Aprovado valor menor e quantidade maior request example",
                new AlterarStatusRequest
                {
                    CodigoDoPedido = CriarPedidioExemplos.CodigoDoPedido,
                    ItensAprovados = 100,
                    ValorAprovado = 1,
                    Status = Status.Aprovado
                });
        }
    }
}
