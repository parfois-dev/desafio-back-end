using Parfois.DesafioBackEnd.Models.Dtos.CriarPedido;

namespace Parfois.DesafioBackEnd.Repository
{
    public class LocalRepository : IRepository
    {
        protected IList<CriarPedidoRequest> Pedidos { get; set; }

        public LocalRepository()
        {
            Pedidos = new List<CriarPedidoRequest>();
        }

        public bool CriarPedido(CriarPedidoRequest pedido)
        {
            Pedidos.Add(pedido);

            return true;
        }

        public bool PedidoExiste(string numeroDoPedido)
        {
            return Pedidos.Any(pedido => pedido.Numero.Equals(numeroDoPedido, StringComparison.OrdinalIgnoreCase));
        }

        public CriarPedidoRequest ObterPedido(string numeroDoPedido)
        {
            return Pedidos.First(pedido => pedido.Numero.Equals(numeroDoPedido, StringComparison.OrdinalIgnoreCase));
        }
    }
}
