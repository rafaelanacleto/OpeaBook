using Microsoft.AspNetCore.Mvc;
using OpeaBook.Application.Services;
using OpeaBook.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


[ApiController]
[Route("api/[controller]")]
public class EmprestimosController : ControllerBase
{
    private readonly EmprestimoService _emprestimoService;

    public EmprestimosController(EmprestimoService emprestimoService)
    {
        _emprestimoService = emprestimoService;
    }


    [HttpPost]
    public async Task<ActionResult<Emprestimo>> SolicitarEmprestimo([FromBody] int livroId)
    {
        try
        {
            var emprestimo = await _emprestimoService.SolicitarEmprestimo(livroId);
            return Ok(emprestimo);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}/devolver")]
    public async Task<IActionResult> DevolverEmprestimo(int id)
    {
        try
        {
            await _emprestimoService.DevolverEmprestimo(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Emprestimo>>> ListarEmprestimos()
    {
        var emprestimos = await _emprestimoService.ListarEmprestimos();
        return Ok(emprestimos);
    }
}