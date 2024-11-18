using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Faculdade.H1._2024.Dominio.Dto
{
    public class DadosNotaAluno
    {
        public string RaAluno { get; set; }
        public int IdDisciplina { get; set; }
        public double Nota { get; set; }
        public double Frequencia { get; set; }
    }
}
