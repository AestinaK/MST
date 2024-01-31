using api_fetch.Data;
using api_fetch.Manager;
using api_fetch.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_fetch.Controllers
{
    [AllowAnonymous]
	public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;
		private readonly IAuthManager _authManager;

		public AuthController(ApplicationDbContext context,
            IAuthManager authManager) {
            _context = context;
			_authManager = authManager;
		}
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm vm)
        {
            try
            {
				var result = await _authManager.Login(vm.UserName, vm.Password);
				if (result.Success)
					return RedirectToAction("Index", "Home");

				ModelState.AddModelError(nameof(vm.Password), result.Errors.FirstOrDefault()!);
				vm.Password = "";
				return View(vm);
			}catch (Exception ex)
            {
                throw new(ex.Message);
            }

        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
