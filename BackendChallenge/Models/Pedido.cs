// Models/Pedido.cs
namespace BackendChallenge.Models
{
    public class Pedido
    {
        public string PedidoId { get; set; }
        public List<Item> Itens { get; set; } = new();
    }
}
