using Api.Faculdade.H1._2024.Dominio.Dto;

namespace Api.Faculdade.H1._2024.Dominio.Interfaces.IServico
{
    public interface IServicoNotaAluno
    {
        void InserirNota(DadosNotaAluno notaAlunoDTO);
        List<DadosNotaAluno> ListarAprovados();
        List<DadosNotaAluno> ListarReprovados();
    }
}
