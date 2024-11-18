using Api.Faculdade.H1._2024.Dominio.Dto;
using Api.Faculdade.H1._2024.Dominio.Interfaces.IServico;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Api.Faculdade.H1._2024.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class NotaAlunoController : ControllerBase
    {
        private readonly IServicoNotaAluno _servicoNotaAluno;

        public NotaAlunoController(IServicoNotaAluno servicoNotaAluno)
        {
            _servicoNotaAluno = servicoNotaAluno;
        }

        [HttpPost]
        public IActionResult InserirNota([FromBody] DadosNotaAluno notaAlunoDTO)
        {
            try
            {
                _servicoNotaAluno.InserirNota(notaAlunoDTO);
                return Ok(new { message = "Nota cadastrada com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("aprovados")]
        public IActionResult ListarAprovados()
        {
            var aprovados = _servicoNotaAluno.ListarAprovados();
            return Ok(aprovados);
        }

        [HttpGet("reprovados")]
        public IActionResult ListarReprovados()
        {
            var reprovados = _servicoNotaAluno.ListarReprovados();
            return Ok(reprovados);
        }
    }

}
