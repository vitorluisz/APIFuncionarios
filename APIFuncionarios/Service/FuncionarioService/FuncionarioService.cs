﻿using APIFuncionarios.DataContext;
using APIFuncionarios.Dto.Pagamentos;
using APIFuncionarios.Logs;
using APIFuncionarios.Migrations;
using APIFuncionarios.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace APIFuncionarios.Service.FuncionarioService
{
    public class FuncionarioService : IFuncionarioInterface
    {
        readonly private ApplicationDbContext _db;

        public FuncionarioService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                if(novoFuncionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados.";
                    serviceResponse.Sucesso = false;
                }

                _db.Funcionarios.Add(novoFuncionario);
                await _db.SaveChangesAsync();

                novoFuncionario.Pagamento.IdFuncionario = novoFuncionario.Id;

                var pagamentoNovo = new PagamentosModel()
                {
                    Salario = novoFuncionario.Pagamento.Salario,
                    ValeTransporte = novoFuncionario.Pagamento.ValeTransporte,
                    ValeAlimentacao = novoFuncionario.Pagamento.ValeAlimentacao,
                    DataDeAlteracaoSalario = DateTime.Now,
                    IdFuncionario = novoFuncionario.Pagamento.Id
                };

                _db.Pagamentos.Update(pagamentoNovo);
                await _db.SaveChangesAsync();

                Log.LogToFile("Criar Funcionário - Sucesso", "Criação de funcionário realizada com sucesso");
                serviceResponse.Dados = _db.Funcionarios.ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Sem dados encontrados.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
                Log.LogToFile("Criar Funcionário - Fracasso", ex.Message);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _db.Funcionarios.FirstOrDefault(x => x.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado.";
                    serviceResponse.Sucesso = false;
                }

                _db.Funcionarios.Remove(funcionario);
                await _db.SaveChangesAsync();

                Log.LogToFile("Deletar Funcionário - Sucesso", "Remoção de funcionário realizada com sucesso");
                serviceResponse.Dados = _db.Funcionarios.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
                Log.LogToFile("Deletar Funcionário - Fracasso", ex.Message);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try
            {
                FuncionarioModel funcionario = _db.Funcionarios.FirstOrDefault(x => x.Id == id);
                serviceResponse.Dados = funcionario;

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado.";
                    serviceResponse.Sucesso = false;
                }
                Log.LogToFile("Listar Funcionário - Sucesso", "Funcionário listado com sucesso");
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
                Log.LogToFile("Listar Funcionário - Fracasso", ex.Message);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                serviceResponse.Dados = _db.Funcionarios.ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Sem dados encontrados.";
                }
                Log.LogToFile("Listar Funcionários - Sucesso", "Funcionários listados com sucesso");
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
                Log.LogToFile("Listar Funcionários - Fracasso", ex.Message);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _db.Funcionarios.FirstOrDefault(x => x.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Sem dados encontrados.";
                    serviceResponse.Sucesso = false;
                }

                funcionario.Ativo = false;
                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _db.Funcionarios.Update(funcionario);
                await _db.SaveChangesAsync();

                Log.LogToFile("Inativar Funcionário - Sucesso", "Funcionário inativado com sucesso");
                serviceResponse.Dados = _db.Funcionarios.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
                Log.LogToFile("Inativar Funcionário - Fracasso", ex.Message);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _db.Funcionarios.AsNoTracking().FirstOrDefault(x => x.Id == editadoFuncionario.Id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Sem dados encontrados.";
                    serviceResponse.Sucesso = false;
                }

                editadoFuncionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _db.Funcionarios.Update(editadoFuncionario);
                await _db.SaveChangesAsync();

                Log.LogToFile("Editar Funcionário - Sucesso", "Funcionário editado com sucesso");
                serviceResponse.Dados = _db.Funcionarios.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
                Log.LogToFile("Editar Funcionário - Fracasso", ex.Message);
            }

            return serviceResponse;
        }
    }
}
