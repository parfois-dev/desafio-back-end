using Parfois.DesafioBackEnd.Models.Dtos.CriarPedido;
using Swashbuckle.AspNetCore.Filters;

namespace Parfois.DesafioBackEnd.Api.Controllers.Swagger
{
    public class CriarPedidioExemplos : IMultipleExamplesProvider<CriarPedidoRequest>
    {
        IEnumerable<SwaggerExample<CriarPedidoRequest>> IMultipleExamplesProvider<CriarPedidoRequest>.GetExamples()
        {
            yield return SwaggerExample.Create(
                "Copo & Prato request example",
                new CriarPedidoRequest
                {
                    Codigo = "123456",
                    Itens =
                [
                    new Item
                    {
                        Descricao = "Copo",
                        PrecoUnitario = 3,
                        Quantidade = 10
                    },
                    new Item
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
