using Api.Faculdade.H1._2024.Dominio.Dto;
using Api.Faculdade.H1._2024.Dominio.Interfaces.IRepositorio;
using Api.Faculdade.H1._2024.Dominio.Interfaces.IServico;
using Api.Faculdade.H1._2024.Infra.Repositorio;

namespace Api.Faculdade.H1._2024.Servicos
{
    public class ServicoDisciplina : IServicoDisciplina
    {
        private readonly IRepositorioDisciplina _repositorioDisciplina;

        public ServicoDisciplina(IRepositorioDisciplina repositorioDisciplina)
        {
            _repositorioDisciplina = repositorioDisciplina;
        }

        public void CriarDisciplina(DadosDisciplina dadosDisciplina)
        {
            if (_repositorioDisciplina.BuscarPorNome(dadosDisciplina.Nome) != null)
            {
                throw new Exception("Já existe uma disciplina com esse nome.");
            }

            var disciplina = new DadosDisciplina
            {
                IdDisciplina = dadosDisciplina.IdDisciplina,
                Nome = dadosDisciplina.Nome,
                Curso = dadosDisciplina.Curso
            };

            _repositorioDisciplina.Adicionar(disciplina);
        }
        public List<DadosDisciplina> BuscarTodas()
        {
            return _repositorioDisciplina.BuscarTodas()
                .Select(d => new DadosDisciplina
                {
                    IdDisciplina = d.IdDisciplina,
                    Nome = d.Nome,
                    Curso = d.Curso
                }).ToList();
        }
        public DadosDisciplina BuscarPorId(int id)
        {
            var disciplina = _repositorioDisciplina.BuscarPorId(id);
            if (disciplina == null)
            {
                throw new Exception("Disciplina não encontrada.");
            }

            return new DadosDisciplina
            {
                IdDisciplina = disciplina.IdDisciplina,
                Nome = disciplina.Nome,
                Curso = disciplina.Curso
            };
        }
        public void AtualizarDisciplina(DadosDisciplina disciplinaDTO)
        {
            var disciplinaExistente = _repositorioDisciplina.BuscarPorId(disciplinaDTO.IdDisciplina);
            if (disciplinaExistente == null)
            {
                throw new Exception("Disciplina não encontrada.");
            }

            disciplinaExistente.Nome = disciplinaDTO.Nome;
            disciplinaExistente.Curso = disciplinaDTO.Curso;

            _repositorioDisciplina.Atualizar(disciplinaExistente);
        }
        public void RemoverDisciplina(int id)
        {
            _repositorioDisciplina.Remover(id);
        }
    }
}
