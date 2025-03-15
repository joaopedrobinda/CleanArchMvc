using CleanArchMvc.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Dominio.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<IEnumerable<Produto>> GetProdutosAsync();
        Task<Produto> GetByIdAsync(int? id);

        Task<Produto> GetProdutoCategoriaAsync(int? id);

        Task<Produto> Criar(Produto produto);
        Task<Produto> Update(Produto produto);
        Task<Produto> Remover(Produto produto);
    }
}