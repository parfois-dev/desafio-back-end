using System.Text.Json.Serialization;

namespace Parfois.DesafioBackEnd.Models.Dtos.AlterarStatusDoPedido
{
    public class AlterarStatusResponse
    {
        [JsonPropertyName("pedido")]
        public string CodigoDoPedido { get; set; }

        public IEnumerable<string> Status { get; set; }
    }
}
