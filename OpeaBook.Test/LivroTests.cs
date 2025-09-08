using OpeaBook.Domain.Entities;
using Xunit;
using System;

public class LivroTests
{
    [Fact]
    public void Livro_DeveLancarExcecao_QuandoTituloVazio()
    {
        Assert.Throws<ArgumentException>(() => new Livro("", "Autor Teste", 2023));
    }

    [Fact]
    public void Livro_DeveLancarExcecao_QuandoAutorVazio()
    {
        Assert.Throws<ArgumentException>(() => new Livro("Título Teste", "", 2023));
    }

    [Fact]
    public void ReduzirQuantidade_DeveLancarExcecao_QuandoNaoHaExemplares()
    {
        var livro = new Livro("Título Teste", "Autor Teste", 2023);
        // Inicialmente QuantidadeDisponivel é 0
        Assert.Throws<InvalidOperationException>(() => livro.ReduzirQuantidade());
    }

    [Fact]
    public void AumentarQuantidade_DeveIncrementarQuantidadeDisponivel()
    {
        var livro = new Livro("Título Teste", "Autor Teste", 2023);
        livro.AdicionarExemplares(5);
        livro.ReduzirQuantidade(); // A quantidade disponível deve ser 4
        Assert.Equal(4, livro.QuantidadeDisponivel);
    }
}