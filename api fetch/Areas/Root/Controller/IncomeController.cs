using Microsoft.AspNetCore.Mvc;

namespace api_fetch.Areas.Root.Controller;

[Area("root")]
public class IncomeController : Microsoft.AspNetCore.Mvc.Controller
{
    // GET
    public IActionResult Add()
    {
        return View();
    }
}