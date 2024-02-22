using System.Text.Json.Serialization;

namespace Parfois.DesafioBackEnd.Models.Dtos.CriarPedido
{
    public class CriarPedidoRequest
    {
        [JsonPropertyName("pedido")]
        public string Codigo { get; set; }

        public IEnumerable<Item> Itens { get; set; }

        [JsonIgnore]
        public decimal ValorTotal => Itens.Sum(item => item.PrecoUnitario * item.Quantidade);

        [JsonIgnore]
        public decimal TotalDeItens => Itens.Count();
    }
}
