using APIFuncionarios.Enums;
using System.ComponentModel.DataAnnotations;

namespace APIFuncionarios.Model
{
    public class FuncionarioModel
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public DepartamentoEnum Departamento { get; set; }
        public bool Ativo { get; set; }
        public TurnoEnum Turno { get; set; }
        public DateTime DataDeCriacao { get; set; } = DateTime.Now;
        public DateTime DataDeAlteracao { get; set; }
        public PagamentosModel? Pagamento { get; set; }
        public ChamadoModel? Chamados { get; set; }

    }
}
