using Parfois.DesafioBackEnd.Models.Dtos.AlterarStatusDoPedido;
using Parfois.DesafioBackEnd.Models.Dtos.CriarPedido;

namespace Parfois.DesafioBackEnd.Repository
{
    public interface IRepository
    {
        bool PedidoExiste(string codigoDoPedido);

        bool CriarPedido(CriarPedidoRequest pedido);

        bool AtualizarPedido(AlterarStatusRequest alterarStatusDoPedido);

        CriarPedidoRequest ObterPedido(string codigoDoPedido);
    }
}
