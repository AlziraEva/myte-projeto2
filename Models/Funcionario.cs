using System.ComponentModel.DataAnnotations;

namespace myte.Models
{
    public class Funcionario
    {
        //Definir as propriedades
        [Required]
        public string? Nome { get; set; }
        [Required]
        public string? Sobrenome { get; set; }
        [Required]
        public DateTime DataDeNascimento { get; set; }
        [Required]
        [RegularExpression("[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9])+\\.+[a-zA-Z]{2,6}$")]
        public string? Email { get; set; }

        //[Required] a senha precisa ser required, esta comentado so temporariamente
        public string? Password { get; set; }

        [Required]
        public DateTime DataDeContratacao { get; set; }

        [Required]
        public string? Genero { get; set;}
        [Required]
        public string? Senioridade { get; set; }
        [Required]
        public string? Cargo { get; set; }
        [Required]
        public string? Departamento { get; set;}
        [Required]
        public string? Acesso { get; set; }

        /*// Adicione a foto do funcionário
        public byte[]? Foto { get; set; }*/
    }
}
