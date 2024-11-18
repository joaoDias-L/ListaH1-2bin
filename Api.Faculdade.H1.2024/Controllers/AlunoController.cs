using Api.Faculdade.H1._2024.Dominio.Dto;
using Api.Faculdade.H1._2024.Dominio.Interfaces.IServico;
using Microsoft.AspNetCore.Mvc;

namespace Api.Faculdade.H1._2024.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunoController : ControllerBase
{
    private readonly IServicoAluno _servicoAluno;

    public AlunoController(IServicoAluno servicoAluno)
    {
        _servicoAluno = servicoAluno;
    }

    /// <summary>
    /// Cria um novo aluno.
    /// </summary>
    /// <param name="alunoDTO">Dados do aluno.</param>
    /// <returns>Mensagem de sucesso ou erro.</returns>
    [HttpPost]
    public IActionResult CriarAluno([FromBody] DadosAluno alunoDTO)
    {
        try
        {
            _servicoAluno.CriarAluno(alunoDTO);
            return Ok(new { message = "Aluno criado com sucesso." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    /// <summary>
    /// Busca todos os alunos.
    /// </summary>
    /// <returns>Lista de alunos.</returns>
    [HttpGet]
    public IActionResult ListarTodos()
    {
        var alunos = _servicoAluno.BuscarTodos();
        return Ok(alunos);
    }

    /// <summary>
    /// Busca um aluno por ID.
    /// </summary>
    /// <param name="id">ID do aluno.</param>
    /// <returns>Dados do aluno ou mensagem de erro.</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        try
        {
            var aluno = _servicoAluno.BuscarPorId(id);
            return Ok(aluno);
        }
        catch (Exception ex)
        {
            return NotFound(new { error = ex.Message });
        }
    }

    /// <summary>
    /// Atualiza um aluno existente.
    /// </summary>
    /// <param name="id">ID do aluno.</param>
    /// <param name="alunoDTO">Novos dados do aluno.</param>
    /// <returns>Mensagem de sucesso ou erro.</returns>
    [HttpPut("{id}")]
    public IActionResult AtualizarAluno(int id, [FromBody] DadosAluno alunoDTO)
    {
        try
        {
            if (id != alunoDTO.Id)
                return BadRequest(new { error = "O ID da URL não corresponde ao ID do aluno." });

            _servicoAluno.AtualizarAluno(alunoDTO);
            return Ok(new { message = "Aluno atualizado com sucesso." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    /// <summary>
    /// Remove um aluno por ID.
    /// </summary>
    /// <param name="id">ID do aluno.</param>
    /// <returns>Mensagem de sucesso ou erro.</returns>
    [HttpDelete("{id}")]
    public IActionResult RemoverAluno(int id)
    {
        try
        {
            _servicoAluno.RemoverAluno(id);
            return Ok(new { message = "Aluno removido com sucesso." });
        }
        catch (Exception ex)
        {
            return NotFound(new { error = ex.Message });
        }
    }
}

