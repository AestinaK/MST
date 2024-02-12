using api_fetch.Data;
using api_fetch.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_fetch.Areas.Api.Controller;

public class RolesController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly ApplicationDbContext _context;

    public RolesController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet("/Api/Roles/GetRoles")]
    public ActionResult<IEnumerable<Roles>> GetRoles()
    {
        return Ok();
        // try
        // {
        //     var roles = _context.roles.ToList();
        //     return Ok(roles);
        // }
        // catch (Exception e)
        // {
        //     return BadRequest(e);
        // }
    }
}