using APIFuncionarios.DataContext;
using APIFuncionarios.Dto.Chamado;
using APIFuncionarios.Logs;
using APIFuncionarios.Migrations;
using APIFuncionarios.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace APIFuncionarios.Service.ChamadoService
{
    public class ChamadoService : IChamadoInterface
    {
        readonly private ApplicationDbContext _db;

        public ChamadoService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<ServiceResponse<List<ChamadoModel>>> CreateChamado(ChamadoCreateDto chamado)
        {
            ServiceResponse<List<ChamadoModel>> serviceResponse = new ServiceResponse<List<ChamadoModel>>();

            try
            {
                if (chamado == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados.";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                var funcionarioPedinte = await _db.Funcionarios.FirstOrDefaultAsync(x => x.Id == chamado.IdFuncionarioPedinte);

                if (funcionarioPedinte == null)
                {
                    serviceResponse.Mensagem = "Funcionario pedinte não existe.";
                    return serviceResponse;
                }

                var chamadoNovo = new ChamadoModel()
                {
                    NomeFuncionarioPedinte = funcionarioPedinte.Nome,
                    Departamento = funcionarioPedinte.Departamento,
                    IdFuncionarioPedinte = chamado.IdFuncionarioPedinte,
                    Título = chamado.Título,
                    Detalhes = chamado.Detalhes
                };

                funcionarioPedinte.Chamados = chamadoNovo;

                _db.Chamados.Add(chamadoNovo);
                _db.Funcionarios.Update(funcionarioPedinte);
                await _db.SaveChangesAsync();

                serviceResponse.Dados = _db.Chamados.ToList();
                Log.LogToFile("Criar Chamado - Sucesso", "Criação de chamado realizada com sucesso");
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
                Log.LogToFile("Criar Chamado - Fracasso", ex.Message);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ChamadoModel>>> DeleteChamado(int id)
        {
            ServiceResponse<List<ChamadoModel>> serviceResponse = new ServiceResponse<List<ChamadoModel>>();

            try
            {
                ChamadoModel chamado = await _db.Chamados.FirstOrDefaultAsync(x => x.Id == id);

                if (chamado == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Chamado não existe.";
                    serviceResponse.Sucesso = false;
                }
                Log.LogToFile("Deletar Chamado - Sucesso", "Remoção de chamado realizada com sucesso");
                _db.Chamados.Remove(chamado);
                await _db.SaveChangesAsync();

                serviceResponse.Dados = _db.Chamados.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
                Log.LogToFile("Deletar Chamado - Fracasso", ex.Message);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ChamadoModel>>> GetChamados()
        {
            ServiceResponse<List<ChamadoModel>> serviceResponse = new ServiceResponse<List<ChamadoModel>>();

            try
            {
                serviceResponse.Dados = _db.Chamados.ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Sem dados encontrados.";
                }
                Log.LogToFile("Listar Chamados - Sucesso", "Chamados listados com sucesso");
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
                Log.LogToFile("Listar Chamados - Fracasso", ex.Message);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ChamadoModel>>> GetChamadosByIdPedinte(int id)
        {
            ServiceResponse<List<ChamadoModel>> serviceResponse = new ServiceResponse<List<ChamadoModel>>();

            try
            {
                List<ChamadoModel> chamados = _db.Chamados.Where(x => x.Id == id).ToList();
                serviceResponse.Dados = chamados;

                if (chamados == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Chamado não localizado.";
                    serviceResponse.Sucesso = false;
                }
                Log.LogToFile("Listar Chamado - Sucesso", "Chamado listado com sucesso");
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
                Log.LogToFile("Listar Chamado - Fracasso", ex.Message);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<ChamadoModel>> ResolverChamado(ChamadoResolverDto chamado)
        {
            ServiceResponse<ChamadoModel> serviceResponse = new ServiceResponse<ChamadoModel>();

            try
            {
                if (chamado == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados.";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                var chamadoFinalizado = await _db.Chamados.FirstOrDefaultAsync(x => x.Id == chamado.IdChamado);

                if (chamadoFinalizado == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Chamado não existe.";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                var funcionarioRecebedor = await _db.Funcionarios.FirstOrDefaultAsync(x => x.Id == chamado.IdFuncionarioRecebedor);

                if (funcionarioRecebedor == null)
                {
                    serviceResponse.Mensagem = "Funcionario recebedor não existe.";
                    return serviceResponse;
                }

                chamadoFinalizado.IdFuncionarioRecebedor = chamado.IdFuncionarioRecebedor;
                chamadoFinalizado.NomeFuncionarioRecebedor = funcionarioRecebedor.Nome;
                chamadoFinalizado.Finalizado = chamado.Finalizado;
                chamadoFinalizado.Comentarios = chamado.Comentarios;

                serviceResponse.Dados = chamadoFinalizado;

                _db.Chamados.Update(chamadoFinalizado);
                await _db.SaveChangesAsync();

                Log.LogToFile("Resolver Chamado - Sucesso", "Resolução de chamado realizada com sucesso");
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
                Log.LogToFile("Resolver Chamado - Fracasso", ex.Message);
            }

            return serviceResponse;
        }
    }
}
