using System.Collections.Concurrent;

namespace DesafioBackend;

public class PedidoRepository
{
    private readonly ConcurrentDictionary<string, Pedido> _data = new();

    public void Add(Pedido pedido) => _data[pedido.Numero] = pedido;

    public Pedido? Get(string numero) => _data.TryGetValue(numero, out var p) ? p : null;

    public void Update(Pedido pedido) => _data[pedido.Numero] = pedido;

    public void Delete(string numero) => _data.TryRemove(numero, out _);
}
