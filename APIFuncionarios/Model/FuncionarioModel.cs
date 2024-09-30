using APIFuncionarios.Enums;
using System.ComponentModel.DataAnnotations;

namespace APIFuncionarios.Model
{
    public class FuncionarioModel
    {
        [Key]
        public int Id { get; set; }
        public int Nome { get; set; }
        public int Sobrenome { get; set; }
        public DepartamentoEnum Departamento { get; set; }
        public bool Ativo { get; set; }
        public TurnoEnum Turno { get; set; }
        public DateTime DataDeCriacao { get; set; } = DateTime.Now;
        public int DataDeAlteracao { get; set; }

    }
}
