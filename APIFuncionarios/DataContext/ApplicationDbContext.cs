using APIFuncionarios.Model;
using Microsoft.EntityFrameworkCore;

namespace APIFuncionarios.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<FuncionarioModel> Funcionarios { get; set; }
        public DbSet<PagamentosModel> Pagamentos { get; set; }

    }
}
