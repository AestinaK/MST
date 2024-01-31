using api_fetch.ViewModel;
using App.User.Dto;
using App.User.Service.Interface;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_fetch.Controllers
{
	[AllowAnonymous]
	public class UserController : Controller
	{
		private readonly INotyfService _notyfService;
		private readonly IUserService _userService;

		public UserController(INotyfService notyfService,
			IUserService userService)
		{
			_notyfService = notyfService;
			_userService = userService;
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
				var user = new CreateUserDto()
				{
					UserName = vm.UserName,
					Email = vm.Email,
					Phone = vm.Phone,
					Password = vm.Password,
				};
				_userService.CreateUser(user);
				_notyfService.Success("User Added!");
				
			}catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return RedirectToAction(nameof(Register));
		}
	}
}
