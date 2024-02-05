using DateConverter.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api_fetch.ViewComponents;

public class DateInputViewComponent : ViewComponent
{
    private readonly INepaliDateConverter _nepaliDateConverter;

    public DateInputViewComponent(INepaliDateConverter nepaliDateConverter)
    {
        _nepaliDateConverter = nepaliDateConverter;
    }
    public IViewComponentResult Invoke(string name, DateTime? value, bool required = true, string id = "", bool isReadonly = false)
    {
        if (value.HasValue && value.Value == DateTime.MinValue)
        {
            value = null;
        }
        if (required && !value.HasValue)
        {
            value = DateTime.UtcNow;
        }

        var nepaliValue = "";
        if (value.HasValue)
        {
            nepaliValue = _nepaliDateConverter.GetBsDateFromAdDate(value.Value);
        }
        return View(new DateInputVm()
        {
            Name = name,
            Required = required,
            Value = nepaliValue,
            EnglishValue = value.HasValue ? value.Value.ToString("yyyy-MM-dd"): "",
            ElmId = id,
            Readonly = isReadonly
        });
    }
}
public class DateInputVm
{
    public string Name { get; set; }
    public string Value { get; set; }
    public string EnglishValue { get; set; }
    public bool Required { get; set; }
    public string ElmId {get;set;}
    public bool  Readonly { get; set; }   
}