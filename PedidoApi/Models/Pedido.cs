using System.Collections.Generic;

namespace PedidoApi.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Numero { get; set; } = string.Empty;
        public ICollection<Item> Itens { get; set; } = new List<Item>();
    }
}
