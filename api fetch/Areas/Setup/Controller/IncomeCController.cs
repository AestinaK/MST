using Microsoft.AspNetCore.Mvc;

namespace api_fetch.Areas.Setup.Controller;

[Area("setup")]
public class IncomeCController : Microsoft.AspNetCore.Mvc.Controller
{
    
    [HttpGet]
    // GET
    public IActionResult Add()
    {
        return View();
    }
}