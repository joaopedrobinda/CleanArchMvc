using CleanArchMvc.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Dominio.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task<IEnumerable<Categoria>> GetCategorias();
        Task<Categoria> GetById(int? id);

        Task<Categoria> Criar(Categoria categoria);
        Task<Categoria> Update(Categoria categoria);
        Task<Categoria> Remover(Categoria categoria);
    }
}
