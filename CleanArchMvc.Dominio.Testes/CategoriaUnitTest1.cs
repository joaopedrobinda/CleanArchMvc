using CleanArchMvc.Dominio.Entidades;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Dominio.Testes
{
    public class CategoriaUnitTest1
    {
        [Fact(DisplayName = "Cria categoria e valida o estado")]
        public void CriarCategoria_ComParametroValido_EstadoValidoObjetoResultado()
        {
            Action action = () => new Categoria(1, "Categoria nome ");
            action.Should()
                 .NotThrow<CleanArchMvc.Dominio.Validador.ValidadorExcecaoDominio>();
        }

        [Fact]
        public void CriarCategoria_IdNegativo_DomainExceptionInvalidId()
        {
            Action action = () => new Categoria(-1, "Categoria nome");
            action.Should()
                .Throw<CleanArchMvc.Dominio.Validador.ValidadorExcecaoDominio>()
                 .WithMessage("Valor do Id inválido");
        }

        [Fact]
        public void CriarCategoria_NomeCurto_DomainExceptionShortName()
        {
            Action action = () => new Categoria(1, "Ca");
            action.Should()
                .Throw<CleanArchMvc.Dominio.Validador.ValidadorExcecaoDominio>()
                   .WithMessage("Nome invalido, muito curto, mínimo de 3 caracteres");
        }

        [Fact]
        public void CriarCategoria_NomeSemValor_DomainExceptionRequiredName()
        {
            Action action = () => new Categoria(1, "");
            action.Should()
                .Throw<CleanArchMvc.Dominio.Validador.ValidadorExcecaoDominio>()
                .WithMessage("Nome invalido, nome requerido");
        }

        [Fact]
        public void CriarCategoria_NomeNulo_DomainExceptionInvalidName()
        {
            Action action = () => new Categoria(1, null);
            action.Should()
                .Throw<CleanArchMvc.Dominio.Validador.ValidadorExcecaoDominio>();
        }


    }
}