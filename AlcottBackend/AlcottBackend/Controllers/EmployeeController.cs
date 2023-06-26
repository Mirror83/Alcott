using AlcottBackend.ClientData;
using AlcottBackend.Models;
using AlcottBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlcottBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeService _service;
    public EmployeeController(EmployeeService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<Employee> GetEmployees()
    {
        return _service.GetEmployees();
    }

    [HttpPost("register")]
    [Authorize(Roles = "Admin")]
    public ActionResult<Employee> RegisterEmployee(EmployeeRegisterRequest request)
    {
        try
        { 
            var employee = _service.Register(request);
            return Created(nameof(GetEmployees), employee);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("login")]
    public ActionResult<string> Login(EmployeeLoginRequest request)
    {
        try
        {
            var token = _service.Login(request);
            return Ok(token);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);

        }
    }



}

