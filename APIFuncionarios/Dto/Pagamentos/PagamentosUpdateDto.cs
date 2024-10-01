using APIFuncionarios.Model;

namespace APIFuncionarios.Dto.Pagamentos
{
    public class PagamentosUpdateDto
    {
        public FuncionarioModel? Funcionario { get; set; }
        public double Salario { get; set; }
        public double ValeTransporte { get; set; }
        public double ValeAlimentacao { get; set; }
        public DateTime DataDeAlteracaoSalario { get; set; }
    }
}
