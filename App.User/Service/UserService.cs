using App.Base.DataContext.Interface;
using App.User.Dto;
using App.User.Service.Interface;

namespace App.User.Service;

public class UserService :IUserService
{
    private readonly IUow _uow;

    public UserService(IUow uow)
    {
        _uow = uow;
    }

    public async Task<Model.User> CreateUser(CreateUserDto dto)
    {
        var user = new Model.User()
        {
            Name = dto.UserName,
            Email = dto.Email,
            Phone = dto.Phone,
            Password = Crypter.Crypter.Crypt(dto.Password)
        };
        await _uow.CreateAsync(user);
       await _uow.CommitAsync();
        return user;
    }
}