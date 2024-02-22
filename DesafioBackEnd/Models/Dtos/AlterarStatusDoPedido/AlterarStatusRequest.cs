using System.Text.Json.Serialization;

namespace Parfois.DesafioBackEnd.Models.Dtos.AlterarStatusDoPedido
{
    public class AlterarStatusRequest
    {
        [JsonPropertyName("pedido")]
        public string CodigoDoPedido { get; set; }

        public int ItensAprovados { get; set; }

        public decimal ValorAprovado { get; set; }

        public string Status { get; set; }
    }
}
