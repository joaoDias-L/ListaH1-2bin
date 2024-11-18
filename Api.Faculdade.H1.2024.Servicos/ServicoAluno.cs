using Api.Faculdade.H1._2024.Dominio.Dto;
using Api.Faculdade.H1._2024.Dominio.Interfaces.IRepositorio;
using Api.Faculdade.H1._2024.Dominio.Interfaces.IServico;
using Api.Faculdade.H1._2024.Infra.Repositorio;

namespace Api.Faculdade.H1._2024.Servicos
{
    public class ServicoAluno : IServicoAluno
    {
        private readonly IRepositorioAluno _repositorioAluno;

        public ServicoAluno(IRepositorioAluno repositorioAluno) 
        { 
            _repositorioAluno = repositorioAluno;
        }

        public void CriarAluno(DadosAluno dadosAluno)
        {
            if (_repositorioAluno.BuscarPorRA(dadosAluno.RA) != null)
            {
                throw new Exception("Já existe um aluno com esse RA.");
            }

            var aluno = new DadosAluno
            {
                Id = dadosAluno.Id,
                Nome = dadosAluno.Nome,
                RA = dadosAluno.RA
            };

            _repositorioAluno.Adicionar(aluno);
        }
        public List<DadosAluno> BuscarTodos()
        {
            return _repositorioAluno.BuscarTodos()
                .Select(a => new DadosAluno { Id = a.Id, Nome = a.Nome, RA = a.RA })
                .ToList();
        }
        public DadosAluno BuscarPorId(int id)
        {
            var aluno = _repositorioAluno.BuscarPorId(id);
            if (aluno == null)
            {
                throw new Exception("Aluno não encontrado.");
            }

            return new DadosAluno { Id = aluno.Id, Nome = aluno.Nome, RA = aluno.RA };
        }
        public void AtualizarAluno(DadosAluno alunoDTO)
        {
            var alunoExistente = _repositorioAluno.BuscarPorId(alunoDTO.Id);
            if (alunoExistente == null)
            {
                throw new Exception("Aluno não encontrado.");
            }

            alunoExistente.Nome = alunoDTO.Nome;
            alunoExistente.RA = alunoDTO.RA;

            _repositorioAluno.Atualizar(alunoExistente);
        }
        public void RemoverAluno(int id)
        {
            _repositorioAluno.Remover(id);
        }
    }
}
