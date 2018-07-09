using projeto_pizzaria.Domain.Funcionalidades.Pedidos;

namespace projeto_pizzaria.Domain.Interfaces.Pedidos
{
    public interface IPedidoRepositorio : IRepositorio<Pedido>
    {
        void AtualizarStatus(Pedido pedido);
    }
}
