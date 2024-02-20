using App.Base.DataContext.Interface;
using App.Setup.Dto;
using App.Setup.Model;
using App.Setup.Service.Interface;

namespace App.Setup.Service;

public class ReminderService : IReminderService
{
    private readonly IUow _uow;

    public ReminderService(IUow uow)
    {
        _uow = uow;
    }

    public async Task<Reminder> Create(ReminderDto dto)
    {
        var reminder = new Reminder();
        reminder.CategoryId = dto.CategoryId;
        reminder.Description = dto.Description;
        reminder.DueDate = dto.DueDate;
        reminder.IsCompleted = false;

        await _uow.CreateAsync(reminder);
        await _uow.CommitAsync();
        return reminder;
    }
}