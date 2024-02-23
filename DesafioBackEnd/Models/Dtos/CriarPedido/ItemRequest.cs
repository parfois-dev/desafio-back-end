using System.Text.Json.Serialization;

namespace Parfois.DesafioBackEnd.Models.Dtos.CriarPedido
{
    public class ItemRequest
    {
        public string Descricao { get; set; }

        public decimal PrecoUnitario { get; set; }

        [JsonPropertyName("qtd")]
        public int Quantidade { get; set; }

        public Item ConvertToItem()
        {
            return new Item
            {
                Descricao = Descricao,
                PrecoUnitario = PrecoUnitario,
                Quantidade = Quantidade
            };
        }
    }
}