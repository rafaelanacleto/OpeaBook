using Microsoft.AspNetCore.Mvc;
using OpeaBook.Application.Services;
using OpeaBook.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


[ApiController]
[Route("api/[controller]")]
public class LivrosController : ControllerBase
{
    private readonly LivroService _livroService;

    public LivrosController(LivroService livroService)
    {
        _livroService = livroService;
    }

    [HttpPost]
    public async Task<ActionResult<Livro>> CriarLivro([FromBody] LivroDto livroDto)
    {
        var livro = await _livroService.CriarLivro(livroDto.Titulo, livroDto.Autor, livroDto.AnoPublicacao);
        return CreatedAtAction(nameof(ObterLivroPorId), new { id = livro.Id }, livro);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Livro>> ObterLivroPorId(int id)
    {
        var livro = await _livroService.ObterLivroPorId(id);
        if (livro == null)
        {
            return NotFound();
        }
        return Ok(livro);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Livro>>> ListarLivros()
    {
        var livros = await _livroService.ListarLivros();
        return Ok(livros);
    }
}

public class LivroDto
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int AnoPublicacao { get; set; }
}