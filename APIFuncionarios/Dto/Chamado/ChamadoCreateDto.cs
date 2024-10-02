using APIFuncionarios.Enums;
using APIFuncionarios.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIFuncionarios.Dto.Chamado
{
    public class ChamadoCreateDto
    {
        [ForeignKey("FuncionarioPedinte")]
        public int IdFuncionarioPedinte { get; set; }
        public string? Título { get; set; }
        public string? Detalhes { get; set; }
    }
}
