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
            var pedidoExiste = _repository.PedidoExiste(request.Codigo);
            if (pedidoExiste)
            {
                return false;
            }

            return _repository.CriarPedido(request);
        }
    }
}
