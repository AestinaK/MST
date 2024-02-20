using App.Setup.Dto;
using App.Setup.Model;

namespace App.Setup.Service.Interface;

public interface IReminderService
{
    Task<Reminder> Create(ReminderDto dto);
}