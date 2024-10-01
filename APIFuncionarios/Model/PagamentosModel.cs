using APIFuncionarios.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIFuncionarios.Model

{
    public class PagamentosModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Funcionario")]
        public int IdFuncionario { get; set; }
        public FuncionarioModel? Funcionario { get; set; }
        public double Salario { get; set; }
        public double ValeTransporte { get; set; }
        public double ValeAlimentacao { get; set; }
        public DateTime DataDeAlteracaoSalario { get; set; }
    }
}
