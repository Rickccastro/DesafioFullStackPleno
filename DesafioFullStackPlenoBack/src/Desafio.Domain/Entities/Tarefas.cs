using Desafio.Domain.Enums;

namespace Desafio.Domain.Entities;
internal class Tarefas
{
    public long Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public long ResponsavelId { get; set; }  
    public Usuario Responsavel { get; set; } = null!;
}
