using Parfois.DesafioBackEnd.Models;

namespace Parfois.DesafioBackEnd.Services.Helpers
{
    public static class StatusDoPedidoHelper
    {
        public static string[] ObterStatusDoPedido(string? codigoDoPedido, decimal valorTotalDoPedido, decimal totalDeItensDoPedido, decimal valorAprovado, int itensAprovados, string status)
        {
            if (IsCodigoDoPedidoInvalido(codigoDoPedido))
            {
                return [Status.CodigoDoPedidoInvalido];
            }

            if (IsPedidoReprovado(status))
            {
                return [Status.Reprovado];
            }

            if (IsPedidoAprovado(valorTotalDoPedido, totalDeItensDoPedido, itensAprovados, valorAprovado, status))
            {
                return [Status.Aprovado];
            }

            var statusDoPedido = new List<string>();

            if (IsPedidoAprovadoComQuantidadeMaior(totalDeItensDoPedido, itensAprovados, status))
            {
                statusDoPedido.Add(Status.AprovadoQuantidadeMaior);
            }

            if (IsPedidoAprovadoComQuantidadeMenor(totalDeItensDoPedido, itensAprovados, status))
            {
                statusDoPedido.Add(Status.AprovadoQuantidadeMenor);
            }

            if (IsPedidoAprovadoComValorMaior(valorTotalDoPedido, valorAprovado, status))
            {
                statusDoPedido.Add(Status.AprovadoValorMaior);
            }

            if (IsPedidoAprovadoComValorMenor(valorTotalDoPedido, valorAprovado, status))
            {
                statusDoPedido.Add(Status.AprovadoValorMenor);
            }

            return statusDoPedido.ToArray();
        }

        private static bool IsPedidoAprovado(decimal valorTotalDoPedido, decimal totalDeItensDoPedido, int itensAprovados, decimal valorAprovado, string status)
        {
            return Status.Aprovado.Equals(status, StringComparison.OrdinalIgnoreCase) && valorAprovado == valorTotalDoPedido && itensAprovados == totalDeItensDoPedido;
        }

        private static bool IsPedidoAprovadoComValorMenor(decimal valorTotalDoPedido, decimal valorAprovado, string status)
        {
            return Status.Aprovado.Equals(status, StringComparison.OrdinalIgnoreCase) && valorAprovado < valorTotalDoPedido;
        }

        private static bool IsPedidoAprovadoComValorMaior(decimal valorTotalDoPedido, decimal valorAprovado, string status)
        {
            return Status.Aprovado.Equals(status, StringComparison.OrdinalIgnoreCase) && valorAprovado > valorTotalDoPedido;
        }

        private static bool IsPedidoAprovadoComQuantidadeMenor(decimal totalDeItensDoPedido, int itensAprovados, string status)
        {
            return Status.Aprovado.Equals(status, StringComparison.OrdinalIgnoreCase) && itensAprovados < totalDeItensDoPedido;
        }

        private static bool IsPedidoAprovadoComQuantidadeMaior(decimal totalDeItensDoPedido, int itensAprovados, string status)
        {
            return Status.Aprovado.Equals(status, StringComparison.OrdinalIgnoreCase) && itensAprovados > totalDeItensDoPedido;
        }

        private static bool IsPedidoReprovado(string status)
        {
            return Status.Reprovado.Equals(status, StringComparison.OrdinalIgnoreCase);
        }

        private static bool IsCodigoDoPedidoInvalido(string? codigoDoPedido)
        {
            return string.IsNullOrEmpty(codigoDoPedido);
        }
    }
}
