using NUnit.Framework;
using Parfois.DesafioBackEnd.Models;
using Assert = NUnit.Framework.Assert;

namespace Parfois.DesafioBackEnd.Services.Helpers.Tests
{
    [TestFixture()]
    public class StatusDoPedidoHelperTests
    {
        [Test()]
        [TestCase("", default, default, default, default, Status.Aprovado, new[] { Status.CodigoDoPedidoInvalido })]
        [TestCase("", 1, 2, 3, 4, Status.Aprovado, new[] { Status.CodigoDoPedidoInvalido })]
        [TestCase(null, default, default, default, default, Status.Aprovado, new[] { Status.CodigoDoPedidoInvalido })]
        [TestCase(null, 1, 2, 3, 4, Status.Aprovado, new[] { Status.CodigoDoPedidoInvalido })]
        public void When_PedidoNaoExiste_Entao_CodigoInvalido(string? codigoDoPedido, decimal valorTotalDoPedido, decimal totalDeItensDoPedido, decimal valorAprovado, int itensAprovados, string status, string[] expectedStatus)
        {
            var statusGerado = StatusDoPedidoHelper.ObterStatusDoPedido(codigoDoPedido, valorTotalDoPedido, totalDeItensDoPedido, valorAprovado, itensAprovados, status);

            Assert.AreEqual(statusGerado, expectedStatus);
        }

        [Test()]
        [TestCase("12345", 10, 20, 10, 20, Status.Aprovado, new[] { Status.Aprovado })]
        [TestCase("54321", 20, 10, 20, 10, Status.Aprovado, new[] { Status.Aprovado })]
        public void When_PedidoAprovado_E_Dados_Iguais_Entao_Aprovado(string? codigoDoPedido, decimal valorTotalDoPedido, decimal totalDeItensDoPedido, decimal valorAprovado, int itensAprovados, string status, string[] expectedStatus)
        {
            var statusGerado = StatusDoPedidoHelper.ObterStatusDoPedido(codigoDoPedido, valorTotalDoPedido, totalDeItensDoPedido, valorAprovado, itensAprovados, status);

            Assert.AreEqual(statusGerado, expectedStatus);
        }

        [Test()]
        [TestCase("12345", 10, 20, 20, 20, Status.Aprovado, new[] { Status.AprovadoValorMaior })]
        [TestCase("54321", 20, 10, 30, 10, Status.Aprovado, new[] { Status.AprovadoValorMaior })]
        public void When_PedidoAprovado_E_Valor_Maior_Entao_Aprovado_Valor_Maior(string? codigoDoPedido, decimal valorTotalDoPedido, decimal totalDeItensDoPedido, decimal valorAprovado, int itensAprovados, string status, string[] expectedStatus)
        {
            var statusGerado = StatusDoPedidoHelper.ObterStatusDoPedido(codigoDoPedido, valorTotalDoPedido, totalDeItensDoPedido, valorAprovado, itensAprovados, status);

            Assert.AreEqual(statusGerado, expectedStatus);
        }

        [Test()]
        [TestCase("12345", 10, 20, 5, 20, Status.Aprovado, new[] { Status.AprovadoValorMenor })]
        [TestCase("54321", 20, 10, 10, 10, Status.Aprovado, new[] { Status.AprovadoValorMenor })]
        public void When_PedidoAprovado_E_Valor_Menor_Entao_Aprovado_Valor_Menor(string? codigoDoPedido, decimal valorTotalDoPedido, decimal totalDeItensDoPedido, decimal valorAprovado, int itensAprovados, string status, string[] expectedStatus)
        {
            var statusGerado = StatusDoPedidoHelper.ObterStatusDoPedido(codigoDoPedido, valorTotalDoPedido, totalDeItensDoPedido, valorAprovado, itensAprovados, status);

            Assert.AreEqual(statusGerado, expectedStatus);
        }

        [Test()]
        [TestCase("12345", 10, 20, 10, 30, Status.Aprovado, new[] { Status.AprovadoQuantidadeMaior })]
        [TestCase("54321", 20, 10, 20, 20, Status.Aprovado, new[] { Status.AprovadoQuantidadeMaior })]
        public void When_PedidoAprovado_E_Quantidade_Maior_Entao_Aprovado_Quantidade_Maior(string? codigoDoPedido, decimal valorTotalDoPedido, decimal totalDeItensDoPedido, decimal valorAprovado, int itensAprovados, string status, string[] expectedStatus)
        {
            var statusGerado = StatusDoPedidoHelper.ObterStatusDoPedido(codigoDoPedido, valorTotalDoPedido, totalDeItensDoPedido, valorAprovado, itensAprovados, status);

            Assert.AreEqual(statusGerado, expectedStatus);
        }

        [Test()]
        [TestCase("12345", 10, 20, 10, 10, Status.Aprovado, new[] { Status.AprovadoQuantidadeMenor })]
        [TestCase("54321", 20, 10, 20, 5, Status.Aprovado, new[] { Status.AprovadoQuantidadeMenor })]
        public void When_PedidoAprovado_E_Quantidade_Menor_Entao_Aprovado_Quantidade_Menor(string? codigoDoPedido, decimal valorTotalDoPedido, decimal totalDeItensDoPedido, decimal valorAprovado, int itensAprovados, string status, string[] expectedStatus)
        {
            var statusGerado = StatusDoPedidoHelper.ObterStatusDoPedido(codigoDoPedido, valorTotalDoPedido, totalDeItensDoPedido, valorAprovado, itensAprovados, status);

            Assert.AreEqual(statusGerado, expectedStatus);
        }

        [Test()]
        [TestCase("12345", 10, 20, 5, 10, Status.Aprovado, new[] { Status.AprovadoQuantidadeMenor, Status.AprovadoValorMenor })]
        [TestCase("54321", 20, 10, 10, 5, Status.Aprovado, new[] { Status.AprovadoQuantidadeMenor, Status.AprovadoValorMenor })]
        public void When_PedidoAprovado_E_Quantidade_Menor_E_Valor_Menor_Entao_Aprovado_Quantidade_Menor_E_Aprovado_Valor_Menor(string? codigoDoPedido, decimal valorTotalDoPedido, decimal totalDeItensDoPedido, decimal valorAprovado, int itensAprovados, string status, string[] expectedStatus)
        {
            var statusGerado = StatusDoPedidoHelper.ObterStatusDoPedido(codigoDoPedido, valorTotalDoPedido, totalDeItensDoPedido, valorAprovado, itensAprovados, status);

            Assert.AreEqual(statusGerado, expectedStatus);
        }

        [Test()]
        [TestCase("12345", 10, 20, 20, 30, Status.Aprovado, new[] { Status.AprovadoQuantidadeMaior, Status.AprovadoValorMaior })]
        [TestCase("54321", 20, 10, 30, 20, Status.Aprovado, new[] { Status.AprovadoQuantidadeMaior, Status.AprovadoValorMaior })]
        public void When_PedidoAprovado_E_Quantidade_Maior_E_Valor_Maior_Entao_Aprovado_Quantidade_Maior_E_Aprovado_Valor_Maior(string? codigoDoPedido, decimal valorTotalDoPedido, decimal totalDeItensDoPedido, decimal valorAprovado, int itensAprovados, string status, string[] expectedStatus)
        {
            var statusGerado = StatusDoPedidoHelper.ObterStatusDoPedido(codigoDoPedido, valorTotalDoPedido, totalDeItensDoPedido, valorAprovado, itensAprovados, status);

            Assert.AreEqual(statusGerado, expectedStatus);
        }

        [Test()]
        [TestCase("12345", 10, 20, 5, 30, Status.Aprovado, new[] { Status.AprovadoQuantidadeMaior, Status.AprovadoValorMenor })]
        [TestCase("54321", 20, 10, 10, 20, Status.Aprovado, new[] { Status.AprovadoQuantidadeMaior, Status.AprovadoValorMenor })]
        public void When_PedidoAprovado_E_Quantidade_Maior_E_Valor_Menor_Entao_Aprovado_Quantidade_Maior_E_Aprovado_Valor_Menor(string? codigoDoPedido, decimal valorTotalDoPedido, decimal totalDeItensDoPedido, decimal valorAprovado, int itensAprovados, string status, string[] expectedStatus)
        {
            var statusGerado = StatusDoPedidoHelper.ObterStatusDoPedido(codigoDoPedido, valorTotalDoPedido, totalDeItensDoPedido, valorAprovado, itensAprovados, status);

            Assert.AreEqual(statusGerado, expectedStatus);
        }

        [Test()]
        [TestCase("12345", 10, 20, 20, 10, Status.Aprovado, new[] { Status.AprovadoQuantidadeMenor, Status.AprovadoValorMaior })]
        [TestCase("54321", 20, 10, 30, 5, Status.Aprovado, new[] { Status.AprovadoQuantidadeMenor, Status.AprovadoValorMaior })]
        public void When_PedidoAprovado_E_Quantidade_Menor_E_Valor_Maior_Entao_Aprovado_Quantidade_Menor_E_Aprovado_Valor_Maior(string? codigoDoPedido, decimal valorTotalDoPedido, decimal totalDeItensDoPedido, decimal valorAprovado, int itensAprovados, string status, string[] expectedStatus)
        {
            var statusGerado = StatusDoPedidoHelper.ObterStatusDoPedido(codigoDoPedido, valorTotalDoPedido, totalDeItensDoPedido, valorAprovado, itensAprovados, status);

            Assert.AreEqual(statusGerado, expectedStatus);
        }
    }
}