using Microsoft.AspNetCore.Mvc;

namespace WebAppAuthorization.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
