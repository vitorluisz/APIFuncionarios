using APIFuncionarios.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIFuncionarios.Dto.Chamado
{
    public class ChamadoResolverDto
    {
        public int IdChamado { get; set; }
        public int IdFuncionarioRecebedor { get; set; }
        public bool Finalizado { get; set; } = true;
        public DateTime DataDeFinalização { get; set; } = DateTime.Now;
        public string? Comentarios { get; set; }
    }
}
