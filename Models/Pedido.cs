namespace DesafioApi.Models
{
    public class Pedido
    {
        public string Numero { get; set; } = string.Empty;
        public List<PedidoItem> Itens { get; set; } = new();
    }
}
