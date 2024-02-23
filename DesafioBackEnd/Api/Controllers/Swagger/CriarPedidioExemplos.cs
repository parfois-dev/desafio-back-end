using Parfois.DesafioBackEnd.Models.Dtos.CriarPedido;
using Swashbuckle.AspNetCore.Filters;

namespace Parfois.DesafioBackEnd.Api.Controllers.Swagger
{
    public class CriarPedidioExemplos : IMultipleExamplesProvider<CriarPedidoRequest>
    {
        public const string CodigoDoPedido = "123456";
        public const int TotalDeItens = 16;
        public const int ValorTotal = 54;

        IEnumerable<SwaggerExample<CriarPedidoRequest>> IMultipleExamplesProvider<CriarPedidoRequest>.GetExamples()
        {
            yield return SwaggerExample.Create(
                "Copo & Prato request example",
                new CriarPedidoRequest
                {
                    Codigo = CodigoDoPedido,
                    Itens =
                [
                    new ItemRequest
                    {
                        Descricao = "Copo",
                        PrecoUnitario = 3,
                        Quantidade = 10
                    },
                    new ItemRequest
                    {
                        Descricao = "Prato",
                        PrecoUnitario = 4,
                        Quantidade = 6
                    }
                ]
                });

        }
    }
}
