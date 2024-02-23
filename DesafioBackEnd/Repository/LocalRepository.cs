using Microsoft.EntityFrameworkCore;
using Parfois.DesafioBackEnd.Models;
using Parfois.DesafioBackEnd.Models.Dtos.CriarPedido;

namespace Parfois.DesafioBackEnd.Repository
{
    public class LocalRepository : IRepository
    {
        private readonly DesafioContext _desafioContext;

        public LocalRepository(DesafioContext desafioContext)
        {
            _desafioContext = desafioContext;
        }

        public async Task<bool> CriarPedido(CriarPedidoRequest pedido)
        {
            await _desafioContext.Pedidos.AddAsync(pedido.ConvertToPedido());

            await _desafioContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> PedidoExisteAsync(string codigoDoPedido)
        {
            return await _desafioContext.Pedidos.AnyAsync(pedido => pedido.Codigo.Equals(codigoDoPedido, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Pedido> ObterPedidoAsync(string codigoDoPedido)
        {
            return await _desafioContext.Pedidos
                .Include(pedido => pedido.Itens)
                .FirstAsync(status => status.Codigo.Equals(codigoDoPedido, StringComparison.OrdinalIgnoreCase));
        }
    }
}
