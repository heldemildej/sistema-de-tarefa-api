using System.ComponentModel.DataAnnotations;

namespace SistemaDeTarefas.DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(255, ErrorMessage = "O nome pode ter no máximo 255 caracter.")]
        public string? Nome { get; set; }


        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O formato de email é inválido")]
        [StringLength(150, ErrorMessage = "O email pode ter no máximo 150 caracter. ")]
        public string? Email { get; set; }
    }
}
