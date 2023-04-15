using Microsoft.AspNetCore.Identity;
using WebAppAuthorization.Contexts;
using WebAppAuthorization.Models.Entities;
using WebAppAuthorization.ViewModels;

namespace WebAppAuthorization.Services;

public class AuthService
{
	private readonly UserManager<IdentityUser> _userManager;
	private readonly SignInManager<IdentityUser> _signInManager;
	private readonly IdentityContext _identityContext;

	public AuthService(UserManager<IdentityUser> userManager, IdentityContext identityContext, SignInManager<IdentityUser> signInManager)
	{
		_userManager = userManager;
		_identityContext = identityContext;
		_signInManager = signInManager;
	}

	public async Task<bool> SignUpAsync(UserSignUpViewModel model)
	{
		try
		{
			IdentityUser identityUser = model;

			await _userManager.CreateAsync(identityUser, model.Password);

			UserProfileEntity userProfileEntity = model;
			userProfileEntity.UserId = identityUser.Id;

			_identityContext.UserProfiles.Add(userProfileEntity);
			await _identityContext.SaveChangesAsync();

			return true;
		}
		catch { return false; }
	}

	public async Task<bool> SignInAsync(UserSignInViewModel model)
	{
		try
		{
			var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

			return result.Succeeded;
		}
		catch
		{
			return false;
		}
	}


}
