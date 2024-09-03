using System.ComponentModel.DataAnnotations;
using WebApplication1.Validations;

namespace WebApplication1.Models
{
	public class NovoAluno
	{
		[Required(ErrorMessage = "Obrigatório")]
		[MaxLength(10, ErrorMessage = "Maximo 10 letras ")]
		public string nome { get; set; }
		[Required(ErrorMessage = "Obrigatório")]
		[EmailAddress(ErrorMessage = "Email invalido")]
		public string email { get; set; }
		[Required(ErrorMessage = "Obrigatório")]

		public string telefone { get; set; }
		[Required(ErrorMessage = "Obrigatório")]
		public string cpf { get; set; }
		[MaioridadeValidation( ErrorMessage = "Erro idade")]
		public int idade { get; set; }

    }
}
