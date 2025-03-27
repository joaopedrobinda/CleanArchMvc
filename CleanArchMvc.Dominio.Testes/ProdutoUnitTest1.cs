using CleanArchMvc.Dominio.Entidades;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Dominio.Testes
{
    public class ProdutoUnitTest1
    {
        [Fact]
        public void CriarProduto_ParametrosEstadoValido_ResultObjectValidState()
        {
            Action action = () => new Produto(1, "Produto nome", "Produto Descrição", 9.99m,
                99, "produto imagem");
            action.Should()
                .NotThrow<CleanArchMvc.Dominio.Validador.ValidadorExcecaoDominio>();
        }
        [Fact]
        public void CriarProduto_ValorIdNegativo_DomainExceptionInvalidId()
        {
            Action action = () => new Produto(-1, "Produto nome", "Produto Descrição", 9.99m,
                99, "produto imagem");

            action.Should().Throw<CleanArchMvc.Dominio.Validador.ValidadorExcecaoDominio>()
                .WithMessage("Valor do Id invalido.");
        }
        [Fact]
        public void CriarProduto_ValorNomeCurto_DomainExceptionShortName()
        {
            Action action = () => new Produto(1, "Pr", "Produto Descrição", 9.99m,
                99, "produto imagem");
            action.Should().Throw<CleanArchMvc.Dominio.Validador.ValidadorExcecaoDominio>()
                 .WithMessage("Nome invalido, muito curto, mínimo de 3 caracteres");
        }
        [Fact]
        public void CriarProduto_NomeImagemGrande_DomainExceptionLongImageName()
        {
            Action action = () => new Produto(1, "Produto nome", "Produto Descrição", 9.99m,
                99, "product image toooooooooooooooooooooooooooooooooooooooooooo " +
                "loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo" +
                "gggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");

            action.Should()
                .Throw<CleanArchMvc.Dominio.Validador.ValidadorExcecaoDominio>()
                 .WithMessage("Nome da imagem inválido, muito grande, máximo de 250 caracteres");
        }

        [Fact]
        public void CriarProduto_NomeImagemNulo_NoDomainException()
        {
            Action action = () => new Produto(1, "Produto nome", "Produto Descrição", 9.99m, 99, null);
            action.Should().NotThrow<CleanArchMvc.Dominio.Validador.ValidadorExcecaoDominio>();
        }
        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Produto(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should().NotThrow<NullReferenceException>();
        }

        [Fact]
        public void CriarProduto_NomeImagemVazio_SemExceçãoDominio()
        {
            Action action = () => new Produto(1, "Produto nome", "Produto Descrição", 9.99m, 99, "");
            action.Should().NotThrow<CleanArchMvc.Dominio.Validador.ValidadorExcecaoDominio>();
        }
        [Fact]
        public void CriarProduto_VaorPrecoInvalido_DomainException()
        {
            Action action = () => new Produto(1, "Produto nome", "Produto Descrição", -9.99m,
                99, "Produto imagem");
            action.Should().Throw<CleanArchMvc.Dominio.Validador.ValidadorExcecaoDominio>()
                 .WithMessage("Preço inválido");
        }

        [Theory]
        [InlineData(-5)]
        public void CriarProduto_ValorEstoqueInvalido_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Produto(1, "Produto nome", "Produto Descrição", 9.99m, value, "Produto imagem");
            action.Should().Throw<CleanArchMvc.Dominio.Validador.ValidadorExcecaoDominio>()
                   .WithMessage("Valor de estoque invalido");
        }


    }
}
