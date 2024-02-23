using System.Text.Json.Serialization;

namespace Parfois.DesafioBackEnd.Models.Dtos.CriarPedido
{
    public class CriarPedidoRequest
    {
        [JsonPropertyName("pedido")]
        public string Codigo { get; set; }

        public IEnumerable<ItemRequest> Itens { get; set; }

        public Pedido ConvertToPedido()
        {
            return new Pedido
            {
                Codigo = Codigo,
                Itens = Itens.Select(item => item.ConvertToItem()).ToArray(),
            };
        }
    }
}
