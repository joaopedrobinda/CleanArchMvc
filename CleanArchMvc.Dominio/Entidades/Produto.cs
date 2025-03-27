using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using CleanArchMvc.Dominio.Validador;

namespace CleanArchMvc.Dominio.Entidades
{
    public class Produto : EntidadeBase
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }
        public string Imagem { get; private set; }

        public Produto(string nome, string descricao, decimal preco, int estoque, string imagem)
        {
            ValidadorDominio(nome, descricao, preco, estoque, imagem);
        }

        public Produto(int id, string nome, string descricao, decimal preco, int estoque, string Imagem)
        {
            ValidadorExcecaoDominio.Onde(id < 0, "Valor do Id invalido.");
            Id = id;
            ValidadorDominio(nome, descricao, preco, estoque, Imagem);
        }

        public void Update(string nome, string descricao, decimal preco, int estoque, string imagem, int categoriaId)
        {
            ValidadorDominio(nome, descricao, preco, estoque, Imagem);
            CategoriaId = categoriaId;
        }


        private void ValidadorDominio(string nome, string descricao, decimal preco, int estoque, string imagem)
        {
            ValidadorExcecaoDominio.Onde(string.IsNullOrEmpty(nome), "Nome invalido, nome é requerido");
            ValidadorExcecaoDominio.Onde(nome.Length < 3, "Nome invalido, muito curto, mínimo de 3 caracteres");
            ValidadorExcecaoDominio.Onde(string.IsNullOrEmpty(descricao), "Descrição inválida, descrição requerida");
            ValidadorExcecaoDominio.Onde(descricao.Length < 5, "Descrição inválida, muito curto, mínimo de 5 caracteres");
            ValidadorExcecaoDominio.Onde(preco < 0, "Preço inválido");
            ValidadorExcecaoDominio.Onde(estoque < 0, "Valor de estoque invalido");
            ValidadorExcecaoDominio.Onde(imagem?.Length > 250, "Nome da imagem inválido, muito grande, máximo de 250 caracteres");

            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
            Imagem = imagem;
        }

         
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
