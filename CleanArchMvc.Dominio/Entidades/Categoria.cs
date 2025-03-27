using CleanArchMvc.Dominio.Validador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Dominio.Entidades
{
    public sealed class Categoria : EntidadeBase
    {
        public string Nome { get; private set; }
        public ICollection<Produto> Productos { get; private set; }

        public Categoria(string nome)
        {
            ValidadorDominio(nome);
        }

        public void Update(string nome)
        {
            ValidadorDominio(nome);
        }

        public Categoria(int id, string nome)
        {
            ValidadorExcecaoDominio.Onde(id < 0, "Valor do Id inválido");
            Id = id;
            ValidadorDominio(nome);
        }

        private void ValidadorDominio (string nome)
        {
            ValidadorExcecaoDominio.Onde(string.IsNullOrEmpty(nome), "Nome invalido, nome requerido");
            ValidadorExcecaoDominio.Onde(nome.Length < 3, "Nome invalido, muito curto, mínimo de 3 caracteres");

            Nome = nome;
        }
    }
}
