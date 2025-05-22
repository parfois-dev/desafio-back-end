namespace DesafioBackend;

public class PedidoService
{
    private readonly PedidoRepository _repo;

    public PedidoService(PedidoRepository repo)
    {
        _repo = repo;
    }

    public void Criar(Pedido pedido) => _repo.Add(pedido);

    public Pedido? Obter(string numero) => _repo.Get(numero);

    public void Atualizar(Pedido pedido) => _repo.Update(pedido);

    public void Remover(string numero) => _repo.Delete(numero);
}
