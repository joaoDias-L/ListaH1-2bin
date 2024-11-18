using Api.Faculdade.H1._2024.Dominio.Dto;

namespace Api.Faculdade.H1._2024.Dominio.Interfaces.IRepositorio
{
    public interface IRepositorioDisciplina
    {
        void Adicionar(DadosDisciplina disciplina);
        List<DadosDisciplina> BuscarTodas();
        DadosDisciplina BuscarPorId(int id);
        DadosDisciplina BuscarPorNome(string nome);
        void Atualizar(DadosDisciplina disciplina);
        void Remover(int id);
    }
}
