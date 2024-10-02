using APIFuncionarios.Model;

namespace APIFuncionarios.Dto.Pagamentos
{
    public class PagamentosUpdateDto
    {
        public int IdFuncionario { get; set; }
        public double Salario { get; set; }
        public double ValeTransporte { get; set; }
        public double ValeAlimentacao { get; set; }
        public DateTime DataDeAlteracaoSalario { get; set; }
    }
}
