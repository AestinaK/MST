using api_fetch.ValueObject;

namespace api_fetch.Manager
{
	public interface IAuthManager
	{
		Task<AuthResult> Login(string username, string password);
	}
}
