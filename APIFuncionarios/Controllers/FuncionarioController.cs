using APIFuncionarios.Model;
using APIFuncionarios.Service.FuncionarioService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIFuncionarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _IFuncionarioInterface;
        public FuncionarioController(IFuncionarioInterface funcionarioInterface) 
        {
            _IFuncionarioInterface = funcionarioInterface;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            return Ok(await _IFuncionarioInterface.CreateFuncionario(novoFuncionario));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> DeleteFuncionario(int id)
        {
            return Ok(await _IFuncionarioInterface.DeleteFuncionario(id));
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionarios()
        {
            return Ok(await _IFuncionarioInterface.GetFuncionarios());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> GetFuncionarioByID(int id)
        {
            return Ok( await _IFuncionarioInterface.GetFuncionarioById(id));
        }

        [HttpPut("inativaFuncionario")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> InativaFuncionario(int id)
        {
            return Ok(await _IFuncionarioInterface.InativaFuncionario(id));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
        {
            return Ok(await _IFuncionarioInterface.UpdateFuncionario(editadoFuncionario));
        }
    }
}
