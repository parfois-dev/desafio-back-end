const { getOrderById } = require('../orders');

function computeTotals(order) {
  const totalItems = order.itens.reduce((sum, i) => sum + i.qtd, 0);
  const totalValue = order.itens.reduce((sum, i) => sum + i.precoUnitario * i.qtd, 0);
  return { totalItems, totalValue };
}

function process(request) {
  const order = getOrderById(request.pedido);
  if (!order) {
    return { pedido: request.pedido, status: ['CODIGO_PEDIDO_INVALIDO'] };
  }
  const { totalItems, totalValue } = computeTotals(order);
  const statuses = [];

  if (request.status === 'REPROVADO') {
    statuses.push('REPROVADO');
  }

  if (request.status === 'APROVADO') {
    if (request.itensAprovados === totalItems && request.valorAprovado === totalValue) {
      statuses.push('APROVADO');
    } else {
      if (request.valorAprovado < totalValue) statuses.push('APROVADO_VALOR_A_MENOR');
      if (request.valorAprovado > totalValue) statuses.push('APROVADO_VALOR_A_MAIOR');
      if (request.itensAprovados < totalItems) statuses.push('APROVADO_QTD_A_MENOR');
      if (request.itensAprovados > totalItems) statuses.push('APROVADO_QTD_A_MAIOR');
    }
  }

  return { pedido: request.pedido, status: statuses };
}

module.exports = { process };
