using Api.Faculdade.H1._2024.Dominio.Dto;
using Api.Faculdade.H1._2024.Dominio.Interfaces.IRepositorio;
using Api.Faculdade.H1._2024.Dominio.Interfaces.IServico;

namespace Api.Faculdade.H1._2024.Servicos
{
    public class ServicoNotaAluno : IServicoNotaAluno
    {
        private readonly IRepositorioNotaAluno _repositorioNotaAluno;
        private readonly IServicoAluno _servicoAluno;
        private readonly IServicoDisciplina _servicoDisciplina;

        public ServicoNotaAluno(IRepositorioNotaAluno repositorioNotaAluno, IServicoAluno servicoAluno, IServicoDisciplina servicoDisciplina)
        {
            _repositorioNotaAluno = repositorioNotaAluno;
            _servicoAluno = servicoAluno;
            _servicoDisciplina = servicoDisciplina;
        }

        public void InserirNota(DadosNotaAluno notaAlunoDTO)
        {
            // Validações
            if (_servicoAluno.BuscarPorId(int.Parse(notaAlunoDTO.RaAluno)) == null)
                throw new Exception("Aluno não encontrado.");
            if (_servicoDisciplina.BuscarPorId(notaAlunoDTO.IdDisciplina) == null)
                throw new Exception("Disciplina não encontrada.");
            if (_repositorioNotaAluno.BuscarPorAlunoEDisciplina(notaAlunoDTO.RaAluno, notaAlunoDTO.IdDisciplina) != null)
                throw new Exception("Nota já cadastrada para este aluno nesta disciplina.");

            // Adiciona a nota
            var notaAluno = new DadosNotaAluno
            {
                RaAluno = notaAlunoDTO.RaAluno,
                IdDisciplina = notaAlunoDTO.IdDisciplina,
                Nota = notaAlunoDTO.Nota,
                Frequencia = notaAlunoDTO.Frequencia
            };

            _repositorioNotaAluno.Adicionar(notaAluno);
        }

        public List<DadosNotaAluno> ListarAprovados()
        {
            return _repositorioNotaAluno.BuscarAprovados()
                .Select(n => new DadosNotaAluno
                {
                    RaAluno = n.RaAluno,
                    IdDisciplina = n.IdDisciplina,
                    Nota = n.Nota,
                    Frequencia = n.Frequencia
                }).ToList();
        }

        public List<DadosNotaAluno> ListarReprovados()
        {
            return _repositorioNotaAluno.BuscarReprovados()
                .Select(n => new DadosNotaAluno
                {
                    RaAluno = n.RaAluno,
                    IdDisciplina = n.IdDisciplina,
                    Nota = n.Nota,
                    Frequencia = n.Frequencia
                }).ToList();
        }
    }
}
