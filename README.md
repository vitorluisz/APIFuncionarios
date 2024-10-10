# Sobre o projeto

ECommerce é uma API Web desenvolvida em ASP.NET, essa API contém funcionalidades de gerenciamento de funcionários, pagamentos, chamados e criação de logs.

![Layout 1](https://raw.githubusercontent.com/vitorluisz/APIFuncionarios/master/APIFuncionarios/img/Screenshot_206.png)

## Tecnologias utilizadas
- C#
- Entity Framework
- **Framework:** ASP.NET Core Web API
- **IDE:** Visual Studio
- **Banco de Dados:** SQL Server

# Funcionalidades

## Funcionários
*Funções:*
- Criar Funcionário
- Deletar Funcionário
- Listar Funcionário por Id
- Listar Funcionários
- Inativar Funcionário
- Editar Funcionário

## Pagamentos
*Funções:*
- Listar Pagamentos
- Listar Pagamento por Id
- Editar Pagamentos
- Deletar Pagamentos

## Chamados
*Funções:*
- Listar Chamados
- Listar Chamado por Id
- Criar Chamado
- Deletar Chamado
- Resolver Chamado

## Logs

Criação de um arquivo txt que contenha a data da execução de cada função do projeto.
![Logs 1](https://raw.githubusercontent.com/vitorluisz/APIFuncionarios/master/APIFuncionarios/img/Screenshot_207.png)

# Projeto
O projeto é feito na Arquitetura em Camadas, para organizar as responsabilidades em camadas diferentes, para facilitar a reutilização de código, e a organização do projeto.
## Controllers
Pasta onde ficam os controladores, que gerenciam o fluxo e o manupulação dos dados.
## Models
Models é a pasta onde é definido os objetos que carregam os dados necessários para o projeto.
## Service
Contêm a lógica de negócios, separando as responsabilidades do controller.
## Dto
É usado para transferir dados entre camadas, evitando a exposição direta dos Models.
## Outros
- **DataContext:** Onde é feita a conexão com o servidor do Banco de Dados do SQL Server.
- **Migrations:** Criada pelo Entity Framework, onde foi feita a criação automática do Banco de Dados e das tabelas.
- **Properties:** Configurações de inicalização, criada automaticamente.
- **Logs:** Configuração da classe estática de logs.
- **Enums:** Classes para lista de propriedades.
- **img:** Imagens do projeto.
- **Program.cs** Classe main em que inicia o projeto, em que contém as confugurações básicas nessárias para a aplicação web, além da configuração do banco, e dos serviços.
- **appsettings.json** Dados de configuração do ambiente, criado automaticamente pelo Visual Studio.

# Como executar o projeto
```bash
# No terminal ou prompt de comando, clone o repositório
git clone https://https://github.com/vitorluisz/APIFuncionarios
```
Obs: não contém o arquivo appsettings.json, será necessário copiar ele de outro projeto ASP.NET Core Web API, e apontar para o seu servidor local.

# Autor

Vitor Luis Zampronha

https://www.linkedin.com/in/vitor-zampronha
