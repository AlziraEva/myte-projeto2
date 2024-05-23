namespace myte.Models
{
    public class Funcionario
    {
        //Definir as propriedades
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string? Email { get; set; }
        public DateTime DataDeContratacao { get; set; }  
              
        public string? Genero { get; set;}
        public string? Senioridade { get; set; }
        public string? Cargo { get; set; }
        public string? Departamento { get; set;}       
        
        public string? Acesso { get; set; }

        // Adicione a foto do funcionário
        public byte[]? Foto { get; set; }
    }
}
