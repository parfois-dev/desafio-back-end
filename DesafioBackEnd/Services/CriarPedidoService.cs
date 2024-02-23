using Parfois.DesafioBackEnd.Models.Dtos.CriarPedido;
using Parfois.DesafioBackEnd.Repository;
using Parfois.DesafioBackEnd.Services.Interfaces;

namespace Parfois.DesafioBackEnd.Services
{
    public class CriarPedidoService : ICriarPedidoService
    {
        private readonly IRepository _repository;
        public CriarPedidoService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CriarPedidoAsync(CriarPedidoRequest request)
        {
            var pedidoExiste = await _repository.PedidoExisteAsync(request.Codigo);
            if (pedidoExiste)
            {
                return false;
            }

            return await _repository.CriarPedido(request);
        }
    }
}
