﻿using APIFuncionarios.DataContext;
using APIFuncionarios.Dto.Pagamentos;
using APIFuncionarios.Logs;
using APIFuncionarios.Migrations;
using APIFuncionarios.Model;
using Microsoft.EntityFrameworkCore;

namespace APIFuncionarios.Service.PagamentosService
{
    public class PagamentosService : IPagamentosInterface
    {
        readonly private ApplicationDbContext _db;

        public PagamentosService(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public async Task<ServiceResponse<List<PagamentosModel>>> DeletePagamentosByIdFuncionario(int id)
        {
            ServiceResponse<List<PagamentosModel>> serviceResponse = new ServiceResponse<List<PagamentosModel>>();

            try
            {
                var pagamentos = _db.Pagamentos.FirstOrDefault(p => p.IdFuncionario == id);
                var funcionario = await _db.Funcionarios.FirstOrDefaultAsync(x => x.Id == id);

                if (pagamentos == null)
                {
                    serviceResponse.Mensagem = "Sem dados encontrados.";
                    serviceResponse.Dados = null;
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                _db.Pagamentos.RemoveRange(pagamentos);
                await _db.SaveChangesAsync();

                Log.LogToFile("Deletar Pagamento - Sucesso", "Pagamento removido com sucesso");
                serviceResponse.Dados = _db.Pagamentos.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
                Log.LogToFile("Deletar Pagamento - Fracasso", ex.Message);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PagamentosModel>>> GetPagamentos()
        {
            ServiceResponse<List<PagamentosModel>> serviceResponse = new ServiceResponse<List<PagamentosModel>>();

            try
            {
                serviceResponse.Dados = _db.Pagamentos.ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Sem dados encontrados.";
                    serviceResponse.Dados = null;
                    serviceResponse.Sucesso = false;
                }
                Log.LogToFile("Listar Pagamentos - Sucesso", "Pagamentos listados com sucesso");
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
                Log.LogToFile("Listar Pagamentos - Fracasso", ex.Message);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<PagamentosModel>> GetPagamentosByIdFuncionario(int id)
        {
            ServiceResponse<PagamentosModel> serviceResponse = new ServiceResponse<PagamentosModel>();

            try
            {
                PagamentosModel pagamento = _db.Pagamentos.Where(p => p.IdFuncionario == id).ToList().FirstOrDefault();
                serviceResponse.Dados = pagamento;

                if (pagamento == null)
                {
                    serviceResponse.Mensagem = "Sem dados encontrados.";
                    serviceResponse.Dados = null;
                    serviceResponse.Sucesso = false;
                }
                Log.LogToFile("Listar Pagamento - Sucesso", "Pagamento listados com sucesso");
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
                Log.LogToFile("Listar Pagamento - Fracasso", ex.Message);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PagamentosModel>>> UpdatePagamentos(PagamentosUpdateDto pagamento)
        {
            ServiceResponse<List<PagamentosModel>> serviceResponse = new ServiceResponse<List<PagamentosModel>>();

            try
            {
                if (pagamento == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados.";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                var funcionario = await _db.Funcionarios.FirstOrDefaultAsync(x => x.Id == pagamento.IdFuncionario);

                if (funcionario == null)
                {
                    serviceResponse.Mensagem = "Funcionario não existe.";
                    return serviceResponse;
                }

                var pagamentoNovo = new PagamentosModel()
                {
                    Salario = pagamento.Salario,
                    ValeTransporte = pagamento.ValeTransporte,
                    ValeAlimentacao = pagamento.ValeAlimentacao,
                    DataDeAlteracaoSalario = DateTime.Now,
                    IdFuncionario = funcionario.Id,
                    NomeFuncionario = funcionario.Nome,
                    SobrenomeFuncionario = funcionario.Sobrenome
                };

                funcionario.Pagamento = pagamentoNovo;

                serviceResponse.Dados = _db.Pagamentos.ToList();
                Log.LogToFile("Editar Pagamento - Sucesso", "Pagamento editado com sucesso");

                var pagamentos = _db.Pagamentos.FirstOrDefault(p => p.IdFuncionario == pagamento.IdFuncionario);

                _db.Pagamentos.Update(pagamentoNovo);
                _db.Funcionarios.Update(funcionario);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
                Log.LogToFile("Editar Pagamento - Fracasso", ex.Message);
            }

            return serviceResponse;
        }
    }
}
