using Business.Models;

namespace Business.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor( Guid fornecedorId );
        Task<IEnumerable<Produto>> ObterProdutosFornecedor();
        Task<Produto> ObterProdutoFornecedor( Guid id );
    }
}
