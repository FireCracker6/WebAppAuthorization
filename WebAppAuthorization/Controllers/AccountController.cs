using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppAuthorization.Services;
using WebAppAuthorization.ViewModels;

namespace WebAppAuthorization.Controllers
{
	public class AccountController : Controller
	{

		private readonly AuthService _auth;

		public AccountController(AuthService auth)
		{
			_auth = auth;
		}

		
		public IActionResult SignUp()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> SignUp(UserSignUpViewModel model)
		{
			if (ModelState.IsValid)
			{
				
				if (await _auth.SignUpAsync(model))
					return RedirectToAction("Index");

				ModelState.AddModelError("", "A user with the same email already exists");
			}
			return View(model);
		}


		public IActionResult SignIn()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignIn(UserSignInViewModel model)
		{
			if (ModelState.IsValid)
			{

				if (await _auth.SignInAsync(model))
					return RedirectToAction("Index");

				ModelState.AddModelError("", "Incorrect email or password.");
			}
			return View(model);
		}



		[Authorize]
		public IActionResult Index()
		{
			return View();
		}



	}


}
