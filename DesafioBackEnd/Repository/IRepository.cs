using Parfois.DesafioBackEnd.Models.Dtos.CriarPedido;

namespace Parfois.DesafioBackEnd.Repository
{
    public interface IRepository
    {
        bool PedidoExiste(string numeroDoPedido);

        bool CriarPedido(CriarPedidoRequest pedido);
    }
}
