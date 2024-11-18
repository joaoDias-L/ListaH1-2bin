using Api.Faculdade.H1._2024.Dominio.Dto;

namespace Api.Faculdade.H1._2024.Dominio.Interfaces.IServico
{
    public interface IServicoDisciplina
    {
        void CriarDisciplina(DadosDisciplina disciplinaDTO);
        List<DadosDisciplina> BuscarTodas();
        DadosDisciplina BuscarPorId(int id);
        void AtualizarDisciplina(DadosDisciplina disciplinaDTO);
        void RemoverDisciplina(int id);
    }
}
