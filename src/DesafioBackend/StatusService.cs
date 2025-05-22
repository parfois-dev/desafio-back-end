namespace DesafioBackend;

public class StatusService
{
    public List<string> Avaliar(Pedido pedido, StatusRequest request)
    {
        var result = new List<string>();
        if (request.Status == "REPROVADO")
        {
            result.Add("REPROVADO");
            return result;
        }

        if (request.Status == "APROVADO")
        {
            if (request.ValorAprovado == pedido.ValorTotal && request.ItensAprovados == pedido.QuantidadeTotal)
            {
                result.Add("APROVADO");
                return result;
            }
            if (request.ValorAprovado < pedido.ValorTotal)
            {
                result.Add("APROVADO_VALOR_A_MENOR");
            }
            else if (request.ValorAprovado > pedido.ValorTotal)
            {
                result.Add("APROVADO_VALOR_A_MAIOR");
            }
            if (request.ItensAprovados < pedido.QuantidadeTotal)
            {
                result.Add("APROVADO_QTD_A_MENOR");
            }
            else if (request.ItensAprovados > pedido.QuantidadeTotal)
            {
                result.Add("APROVADO_QTD_A_MAIOR");
            }
        }
        return result;
    }
}
