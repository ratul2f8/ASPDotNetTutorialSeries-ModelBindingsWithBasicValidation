using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace model_binding_tut.Models
{
	public class Variant4Model
	{
		[Required]
		[NotNull]
		[MinLength(3)]
		public string name { get; set; }

		[Required]
		[NotNull]
		[EmailAddress]
		public string email { get; set; }
	}
}
