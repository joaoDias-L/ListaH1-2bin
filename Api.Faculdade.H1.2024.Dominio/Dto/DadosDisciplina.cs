using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Faculdade.H1._2024.Dominio.Dto
{
    public class DadosDisciplina
    {
        [Required]
        public int IdDisciplina { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Curso { get; set; }
    }
}
