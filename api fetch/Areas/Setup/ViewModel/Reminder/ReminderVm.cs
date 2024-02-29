using App.Base.Dropdown;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace api_fetch.Areas.Setup.ViewModel.Reminder;

public class ReminderVm
{
    public long CategoryId { get; set; }
    public DateTime DueDate { get; set; } = DateTime.Today;
    public string Description { get; set; }

    public List<DropdownDto> Categories { get; set; }

    public SelectList GetCategoryList() =>
        new SelectList(Categories, nameof(DropdownDto.Id), nameof(DropdownDto.Name), CategoryId);

    public List<ReminderInfoVm> Reminders { get; set; }

}

public class ReminderInfoVm
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
}