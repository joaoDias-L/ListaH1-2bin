using Api.Faculdade.H1._2024.Dominio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Faculdade.H1._2024.Dominio.Interfaces.IRepositorio
{
    public interface IRepositorioAluno
    {
        void Adicionar(DadosAluno aluno);
        List<DadosAluno> BuscarTodos();
        DadosAluno BuscarPorId(int id);
        DadosAluno BuscarPorRA(string ra);
        void Atualizar(DadosAluno aluno);
        void Remover(int id);
    }
}
