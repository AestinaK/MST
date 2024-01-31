using api_fetch.Data;
using api_fetch.ValueObject;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace api_fetch.Manager
{
	public class AuthManager : IAuthManager
	{
		private readonly ApplicationDbContext _context;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public AuthManager(ApplicationDbContext context,
			IHttpContextAccessor httpContextAccessor) {
			_context = context;
			_httpContextAccessor = httpContextAccessor;
		}
		public async Task<AuthResult> Login(string username, string password)
		{
			var user = _context.users.FirstOrDefault(x => x.Name == username);
			var result = new AuthResult();
			if (user == null)
			{
				result.Success = false;
				result.Errors.Add("User not found");
				return result;
			}
			if(!Crypter.Crypter.Verify(password, user.Password))
			{
				result.Success = false;
				result.Errors.Add("Invalid Password");
				return result;
			}
			var httpContext = _httpContextAccessor.HttpContext;
			var claims = new List<Claim>
			{
				new("Id",user.Id.ToString())
			};
			var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
			await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
			result.Success = true;
			return result;
		}
	}
}
