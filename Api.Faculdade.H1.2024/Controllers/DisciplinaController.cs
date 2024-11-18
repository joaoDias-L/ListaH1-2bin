using Api.Faculdade.H1._2024.Dominio.Dto;
using Api.Faculdade.H1._2024.Dominio.Interfaces.IServico;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Api.Faculdade.H1._2024.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DisciplinaController : ControllerBase
    {
        private readonly IServicoDisciplina _servicoDisciplina;

        public DisciplinaController(IServicoDisciplina servicoDisciplina)
        {
            _servicoDisciplina = servicoDisciplina;
        }

        /// <summary>
        /// Cria uma nova disciplina.
        /// </summary>
        /// <param name="disciplinaDTO">Dados do aluno.</param>
        /// <returns>Mensagem de sucesso ou erro.</returns>
        [HttpPost]
        public IActionResult CriarDisciplina([FromBody] DadosDisciplina disciplinaDTO)
        {
            try
            {
                _servicoDisciplina.CriarDisciplina(disciplinaDTO);
                return Ok(new { message = "Disciplina criada com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Busca todas as disciplinas.
        /// </summary>
        /// <returns>Mensagem de sucesso ou erro.</returns>
        [HttpGet]
        public IActionResult BuscarTodas()
        {
            var disciplinas = _servicoDisciplina.BuscarTodas();
            return Ok(disciplinas);
        }

        /// <summary>
        /// Busca uma disciplina por Id.
        /// </summary>
        /// <param name="id">Dados do aluno.</param>
        /// <returns>Mensagem de sucesso ou erro.</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var disciplina = _servicoDisciplina.BuscarPorId(id);
                return Ok(disciplina);
            }
            catch (Exception ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Atualiza uma disciplina.
        /// </summary>
        /// <param name="disciplinaDTO">Dados do aluno.</param>
        /// <returns>Mensagem de sucesso ou erro.</returns>
        [HttpPut("{id}")]
        public IActionResult AtualizarDisciplina(int id, [FromBody] DadosDisciplina disciplinaDTO)
        {
            try
            {
                if (id != disciplinaDTO.IdDisciplina)
                    return BadRequest(new { error = "O ID da URL não corresponde ao ID da disciplina." });

                _servicoDisciplina.AtualizarDisciplina(disciplinaDTO);
                return Ok(new { message = "Disciplina atualizada com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Deleta uma disciplina por id.
        /// </summary>
        /// <param name="id">Dados do aluno.</param>
        /// <returns>Mensagem de sucesso ou erro.</returns>
        [HttpDelete("{id}")]
        public IActionResult RemoverDisciplina(int id)
        {
            try
            {
                _servicoDisciplina.RemoverDisciplina(id);
                return Ok(new { message = "Disciplina removida com sucesso." });
            }
            catch (Exception ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }
    }

}
