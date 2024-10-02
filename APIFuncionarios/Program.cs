using APIFuncionarios.DataContext;
using APIFuncionarios.Service.ChamadoService;
using APIFuncionarios.Service.FuncionarioService;
using APIFuncionarios.Service.PagamentosService;
using Microsoft.EntityFrameworkCore;

namespace APIFuncionarios
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IFuncionarioInterface,FuncionarioService>();
            builder.Services.AddScoped<IPagamentosInterface, PagamentosService>();
            builder.Services.AddScoped<IChamadoInterface, ChamadoService>();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            }
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}