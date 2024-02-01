using App.User.Dto;

namespace App.User.Service.Interface;

public interface IUserService
{
    Task<Model.User> CreateUser(CreateUserDto dto);
}