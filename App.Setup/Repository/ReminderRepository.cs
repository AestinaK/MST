using App.Base.GenericRepository;
using App.Setup.Model;
using App.Setup.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace App.Setup.Repository;

public class ReminderRepository : GenericRepository<Reminder>,IReminderRepository

{
    public ReminderRepository(DbContext context) : base(context)
    {
    }
}