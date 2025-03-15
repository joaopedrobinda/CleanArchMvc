using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Dominio.Entidades
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public ICollection<Produto> Productos { get; private set; }


    }
}
