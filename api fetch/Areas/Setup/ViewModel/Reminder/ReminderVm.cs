using App.Base.Dropdown;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace api_fetch.Areas.Setup.ViewModel.Reminder;

public class ReminderVm
{
    public long CategoryId { get; set; }
    public DateTime DueDate { get; set; }
    public string Description { get; set; }

    public List<DropdownDto> Categories { get; set; }

    public SelectList GetCategoryList() =>
        new SelectList(Categories, nameof(DropdownDto.Id), nameof(DropdownDto.Name), CategoryId);

}