namespace myte.Models
{
	public class RegistroHoras
	{
		public int FuncionarioId { get; set; }
		public Funcionario Funcionario { get; set; } // Referência ao modelo Funcionario

		public string CodigoWBS { get; set; }
		public Wbs WBS { get; set; } // Referência ao modelo WBS

		public DateTime Data { get; set; }
		public int HorasTrabalhadas { get; set; }
	}

}
