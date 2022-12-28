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
public class EmployeeController : ControllerBase
{
    private readonly AppDbContext _context;

    public EmployeeController(AppDbContext context)
    {
        _context = context;
    }
    // GET: api/Employee
    [HttpGet]
    public async Task<IEnumerable<Employee>> Get()
        => await _context.Employee.Include("Position").Include("Department").ToListAsync();

    // GET: api/Employee/5
    [HttpGet("{id}", Name = "Get")]
    public async Task<Employee> Get(Guid id)
        => await _context.Employee.FindAsync(id);

    // POST: api/Employee
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Employee employee)
    {
        if (ModelState.IsValid)
        {
            employee.EmployeeId = Guid.NewGuid();
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();
            return Created("", employee);
        }
        return BadRequest(ModelState);
    }

    // PUT: api/Employee/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE: api/Employee/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var employee = await _context.Employee.FindAsync(id);
        if(employee is not null)
        {
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return Ok();
        }
        return BadRequest();
    }
}
