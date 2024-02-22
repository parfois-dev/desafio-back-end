using System.Text.Json.Serialization;

namespace Parfois.DesafioBackEnd.Models.Dtos.CriarPedido
{
    public class Item
    {
        public string Descricao { get; set; }

        public decimal PrecoUnitario { get; set; }

        [JsonPropertyName("qtd")]
        public int Quantidade { get; set; }
    }
}