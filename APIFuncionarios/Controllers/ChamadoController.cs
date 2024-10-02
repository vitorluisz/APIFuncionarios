using APIFuncionarios.Dto.Chamado;
using APIFuncionarios.Dto.Pagamentos;
using APIFuncionarios.Model;
using APIFuncionarios.Service.ChamadoService;
using APIFuncionarios.Service.PagamentosService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIFuncionarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChamadoController : ControllerBase
    {
        private readonly IChamadoInterface _IChamadosInterface;
        public ChamadoController(IChamadoInterface pagamentosInterface)
        {
            _IChamadosInterface = pagamentosInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ChamadoModel>>>> GetChamados()
        {
            return Ok(await _IChamadosInterface.GetChamados());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<ChamadoModel>>>> GetChamadosByIdPedinte(int id)
        {
            return Ok(await _IChamadosInterface.GetChamadosByIdPedinte(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<ChamadoModel>>>> CreateChamado(ChamadoCreateDto chamado)
        {
            return Ok(await _IChamadosInterface.CreateChamado(chamado));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<ChamadoModel>>>> ResolverChamado(ChamadoResolverDto chamado)
        {
            return Ok(await _IChamadosInterface.ResolverChamado(chamado));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<ChamadoModel>>>> DeleteChamado(int id)
        {
            return Ok(await _IChamadosInterface.DeleteChamado(id));
        }
    }
}
