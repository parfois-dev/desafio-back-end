using System.Text.Json.Serialization;

namespace Parfois.DesafioBackEnd.Models.Dtos.CriarPedido
{
    public class CriarPedidoRequest
    {
        [JsonPropertyName("pedido")]
        public string Numero { get; set; }

        public IEnumerable<Item> Itens { get; set; }
    }
}
