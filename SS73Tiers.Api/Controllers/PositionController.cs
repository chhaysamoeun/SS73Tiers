using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SS73Tiers.Api.Data;
using SS73Tiers.Api.Models;

namespace SS73Tiers.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PositionController : ControllerBase
{
    private readonly AppDbContext _context;
    public PositionController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<List<Position>> Get()
    {
        return await _context.Position.ToListAsync();
    }
    [HttpPost]
    public async Task<IActionResult> Post(Position position)
    {
        if(ModelState.IsValid)
        {
            position.PositionId = Guid.NewGuid();
            _context.Position.Add(position);
            await _context.SaveChangesAsync();
            return Ok(position);
        }
        else
        {
            return BadRequest();
        }
    }
}
