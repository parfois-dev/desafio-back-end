using DesafioApi.Models;

namespace DesafioApi;

public class PedidoContext
{
    private readonly Dictionary<string, Pedido> _pedidos = new();

    public IEnumerable<Pedido> List() => _pedidos.Values;

    public Pedido? Get(string numero)
    {
        _pedidos.TryGetValue(numero, out var pedido);
        return pedido;
    }

    public void Add(Pedido pedido) => _pedidos[pedido.Numero] = pedido;

    public void Update(Pedido pedido) => _pedidos[pedido.Numero] = pedido;

    public void Delete(string numero) => _pedidos.Remove(numero);
}
