using API.Data;
using API.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController:ControllerBase
{
    private readonly DataContext _context;
  public UserController(DataContext context)
  {
    this._context=context;
  }
  [HttpGet]
  public async Task< ActionResult<IEnumerable<ApplicationUser>>> GetUsers()
  {
    var users= await _context.Users.ToListAsync();

    return users;

  }

  [HttpGet("{id}")]
  public async Task<ActionResult<ApplicationUser>> GetUser(int id)
  {
    return await _context.Users.FindAsync(id);
  }


}
