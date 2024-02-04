using App.Base.Dto;

namespace api_fetch.Provider.Interface;

public interface IUserProvider
{
    bool IsLoggedIn();
    long? GetCurrentUserId();
    SessionUser GetCurrentUser();
}