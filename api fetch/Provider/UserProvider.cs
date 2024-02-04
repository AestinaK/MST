using System.Security.Claims;
using api_fetch.Provider.Interface;
using App.Base.Dto;
using App.User.Repository.Interface;

namespace api_fetch.Provider;

public class UserProvider : IUserProvider
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IUserRepository _userRepo;

    public UserProvider(IHttpContextAccessor contextAccessor,
        IUserRepository userRepo)
    {
        _contextAccessor = contextAccessor;
        _userRepo = userRepo;
    }

    public bool IsLoggedIn()=>
        GetCurrentUserId() > 0;

    public long? GetCurrentUserId()
    {
        var sessionUser = GetCurrentUser();
        return sessionUser?.Id;
    }

    public SessionUser GetCurrentUser()
    {
        var parsedUserId = ExtractUserIdFromCookie();
        if (parsedUserId == null) return null;
        var user = _userRepo.Find(parsedUserId.Value);
        if (user == null) throw new Exception("Invalid operation , please contact software vendor");
        var sessionUser = new SessionUser();
        sessionUser.Id = user.Id;
        sessionUser.Name = user.Name;
        sessionUser.Email = user.Email;
        sessionUser.Phone = user.Phone;
        return sessionUser;
    }

    private long? ExtractUserIdFromCookie()
    {
        var userId = _contextAccessor.HttpContext?.User.FindFirstValue("Id");
        if (string.IsNullOrEmpty(userId)) return null;
        var parsedUserId = Convert.ToInt64(userId);
        return parsedUserId;
    }
}