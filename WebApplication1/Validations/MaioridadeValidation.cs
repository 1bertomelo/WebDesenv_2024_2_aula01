using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Validations
{
	public class MaioridadeValidation : ValidationAttribute
	{
		protected override ValidationResult? IsValid(Object? value, ValidationContext validationContext)
		{
			if (value == null)
			{
				return new ValidationResult(ErrorMessage);
			}

			int idade = (int)value;

			return idade >= 18 ? ValidationResult.Success : new  ValidationResult(ErrorMessage);
		}
	}
}
