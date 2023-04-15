using System.ComponentModel.DataAnnotations;

namespace WebAppAuthorization.ViewModels;

public class UserSignInViewModel
{
	[Required]
	[DataType(DataType.EmailAddress)]
	public string Email { get; set; } = null!;

	[Required]
	[DataType(DataType.Password)]
	public string Password { get; set; } = null!;

	public bool RememberMe { get; set; }
}
