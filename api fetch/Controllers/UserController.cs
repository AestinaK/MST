using api_fetch.Data;
using api_fetch.Models;
using api_fetch.ViewModel;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace api_fetch.Controllers
{

	public class UserController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly INotyfService _notyfService;

		public UserController(ApplicationDbContext context,
			INotyfService notyfService)
		{
			_context = context;
			_notyfService = notyfService;
		}
		[HttpGet]
		public IActionResult Register()
		{
			var vm = new UserAddVm();
			return View(vm);
		}
		[HttpPost]
		public IActionResult Register(UserAddVm vm)
		{
			try
			{
				var user = new User()
				{
					Name = vm.UserName,
					Email = vm.Email,
					Phone = vm.Phone,
					Password = Crypter.Crypter.Crypt(vm.Password),
				};
				_context.users.Add(user);
				_context.SaveChanges();
				_notyfService.Success("User Added!");
				
			}catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return RedirectToAction(nameof(Register));
		}
	}
}
