using Parfois.DesafioBackEnd.Models;
using Parfois.DesafioBackEnd.Models.Dtos.CriarPedido;

namespace Parfois.DesafioBackEnd.Repository
{
    public interface IRepository
    {
        Task<bool> PedidoExisteAsync(string codigoDoPedido);

        Task<bool> CriarPedido(CriarPedidoRequest pedido);

        Task<Pedido> ObterPedidoAsync(string codigoDoPedido);
    }
}
