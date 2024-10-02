using APIFuncionarios.Dto.Chamado;
using APIFuncionarios.Model;

namespace APIFuncionarios.Service.ChamadoService
{
    public interface IChamadoInterface
    {
        Task<ServiceResponse<List<ChamadoModel>>> GetChamados();
        Task<ServiceResponse<List<ChamadoModel>>> GetChamadosByIdPedinte(int id);
        Task<ServiceResponse<List<ChamadoModel>>> CreateChamado(ChamadoCreateDto chamado);
        Task<ServiceResponse<ChamadoModel>> ResolverChamado(ChamadoResolverDto chamado);
        Task<ServiceResponse<List<ChamadoModel>>> DeleteChamado(int id);
    }
}
