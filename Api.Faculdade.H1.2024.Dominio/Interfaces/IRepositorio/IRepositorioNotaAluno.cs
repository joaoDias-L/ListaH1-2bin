using Api.Faculdade.H1._2024.Dominio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Faculdade.H1._2024.Dominio.Interfaces.IRepositorio
{
    public interface IRepositorioNotaAluno
    {
        void Adicionar(DadosNotaAluno notaAluno);
        List<DadosNotaAluno> BuscarTodos();
        DadosNotaAluno BuscarPorAlunoEDisciplina(string raAluno, int idDisciplina);
        List<DadosNotaAluno> BuscarAprovados();
        List<DadosNotaAluno> BuscarReprovados();
    }
}
