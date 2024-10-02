using APIFuncionarios.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIFuncionarios.Model
{
    public class ChamadoModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("FuncionarioPedinte")]
        public int IdFuncionarioPedinte { get; set; }
        public string? NomeFuncionarioPedinte { get; set; }
        [ForeignKey("FuncionarioRecebedor")]
        public int IdFuncionarioRecebedor { get; set; }
        public string? NomeFuncionarioRecebedor { get; set; }
        public DepartamentoEnum Departamento { get; set; }
        public string? Título { get; set; }
        public string? Detalhes { get; set; }
        public bool Finalizado { get; set; } = false;
        public DateTime DataDeCriacao { get; set; } = DateTime.Now;
        public DateTime DataDeFinalização { get; set; }
        public string? Comentarios { get; set; }
    }
}
