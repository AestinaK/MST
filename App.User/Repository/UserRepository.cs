using App.Base.GenericRepository;
using App.User.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace App.User.Repository;

public class UserRepository : GenericRepository<Model.User>, IUserRepository
{
    public UserRepository(DbContext context) : base(context)
    {
    }
}