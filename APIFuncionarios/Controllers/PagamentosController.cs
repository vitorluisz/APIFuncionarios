using APIFuncionarios.Dto.Pagamentos;
using APIFuncionarios.Model;
using APIFuncionarios.Service.FuncionarioService;
using APIFuncionarios.Service.PagamentosService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIFuncionarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
        private readonly IPagamentosInterface _IPagamentosInterface;
        public PagamentosController(IPagamentosInterface pagamentosInterface)
        {
            _IPagamentosInterface = pagamentosInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<PagamentosModel>>>> GetPagamentos()
        {
            return Ok(await _IPagamentosInterface.GetPagamentos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<PagamentosModel>>> GetPagamentosByIdFuncionario(int id)
        {
            return Ok(await _IPagamentosInterface.GetPagamentosByIdFuncionario(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<PagamentosModel>>>> UpdatePagamentos(int id, PagamentosUpdateDto pagamentoNovo)
        {
            return Ok(await _IPagamentosInterface.UpdatePagamentos(id, pagamentoNovo));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<PagamentosModel>>>> DeletePagamentosByIdFuncionario(int id)
        {
            return Ok(await _IPagamentosInterface.DeletePagamentosByIdFuncionario(id));
        }
    }
}
