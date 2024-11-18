using Api.Faculdade.H1._2024.Dominio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Faculdade.H1._2024.Dominio.Interfaces.IServico
{
    public interface IServicoAluno
    {
        void CriarAluno(DadosAluno alunoDTO);
        List<DadosAluno> BuscarTodos();
        DadosAluno BuscarPorId(int id);
        void AtualizarAluno(DadosAluno alunoDTO);
        void RemoverAluno(int id);
    }
}
