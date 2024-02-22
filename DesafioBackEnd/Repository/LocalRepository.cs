using Parfois.DesafioBackEnd.Models.Dtos.AlterarStatusDoPedido;
using Parfois.DesafioBackEnd.Models.Dtos.CriarPedido;

namespace Parfois.DesafioBackEnd.Repository
{
    public class LocalRepository : IRepository
    {
        protected IList<CriarPedidoRequest> Pedidos { get; set; }

        protected IList<AlterarStatusRequest> StatusDosPedidos { get; set; }

        public LocalRepository()
        {
            Pedidos = new List<CriarPedidoRequest>();
            StatusDosPedidos = new List<AlterarStatusRequest>();
        }

        public bool CriarPedido(CriarPedidoRequest pedido)
        {
            Pedidos.Add(pedido);

            return true;
        }

        public bool PedidoExiste(string codigoDoPedido)
        {
            return Pedidos.Any(pedido => pedido.Codigo.Equals(codigoDoPedido, StringComparison.OrdinalIgnoreCase));
        }

        public bool StatusExiste(string codigoDoPedido)
        {
            return StatusDosPedidos.Any(pedido => pedido.CodigoDoPedido.Equals(codigoDoPedido, StringComparison.OrdinalIgnoreCase));
        }

        public AlterarStatusRequest ObterStatusDoPedido(string codigoDoPedido)
        {
            return StatusDosPedidos.First(status => status.CodigoDoPedido.Equals(codigoDoPedido, StringComparison.OrdinalIgnoreCase));
        }

        public CriarPedidoRequest ObterPedido(string codigoDoPedido)
        {
            return Pedidos.First(status => status.Codigo.Equals(codigoDoPedido, StringComparison.OrdinalIgnoreCase));
        }

        public bool AtualizarPedido(AlterarStatusRequest alterarStatusDoPedido)
        {
            var status = ObterStatusDoPedido(alterarStatusDoPedido.CodigoDoPedido);

            status.ItensAprovados = alterarStatusDoPedido.ItensAprovados;
            status.ValorAprovado = alterarStatusDoPedido.ValorAprovado;

            return true;
        }

        public bool CriarStatus(AlterarStatusRequest alterarStatusDoPedido)
        {
            StatusDosPedidos.Add(alterarStatusDoPedido);

            return true;
        }
    }
}
