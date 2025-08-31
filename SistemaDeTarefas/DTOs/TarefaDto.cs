using System.ComponentModel.DataAnnotations;
using SistemaDeTarefas.Enums;

namespace SistemaDeTarefas.DTOs
{
    public class TarefaDto
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(255, ErrorMessage = "O nome pode ter no máximo 255 caracter.")]
        public string? Nome { get; set; }


        [StringLength(1000, ErrorMessage = "A descrição pode ter no maxímo 1000 caracter.")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O status da tarefa é obrigatório.")]
        public StatusTarefa Status { get; set; }


        // ---- Relação com o usuário -----
        public int UsuarioId { get; set; }
    }
}
