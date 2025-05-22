const orders = [
  {
    pedido: '123456',
    itens: [
      { descricao: 'Item A', precoUnitario: 10, qtd: 1 },
      { descricao: 'Item B', precoUnitario: 5, qtd: 2 }
    ]
  }
];

function getOrderById(id) {
  return orders.find(o => o.pedido === id);
}

module.exports = { orders, getOrderById };
