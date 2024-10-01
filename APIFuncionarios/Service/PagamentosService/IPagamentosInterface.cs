using APIFuncionarios.Dto.Pagamentos;
using APIFuncionarios.Model;

namespace APIFuncionarios.Service.PagamentosService
{
    public interface IPagamentosInterface
    {
        Task<ServiceResponse<List<PagamentosModel>>> GetPagamentos();
        Task<ServiceResponse<PagamentosModel>> GetPagamentosByIdFuncionario(int id);
        Task<ServiceResponse<List<PagamentosModel>>> UpdatePagamentos(int id, PagamentosUpdateDto pagamentoNovo);
        Task<ServiceResponse<List<PagamentosModel>>> DeletePagamentosByIdFuncionario(int id);
    }
}
