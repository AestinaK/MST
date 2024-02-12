using api_fetch.Data;
using Microsoft.AspNetCore.Mvc;

namespace api_fetch.Areas.Api.Controller;

public class RoleIdController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly ApplicationDbContext _context;

    public RoleIdController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IActionResult> GetRoleById(long roleId)
    {
        return Ok();
        // try
        // {
        //     var roles = await _context.roles.FindAsync(roleId);
        //     var res = new
        //     {
        //         Id = roles.Id,
        //         Name = roles.Name
        //     };
        //
        //     return Ok(roles);
        // }
        // catch (Exception e)
        // {
        //     return BadRequest(e);
        // }
    }
}