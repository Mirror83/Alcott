using Microsoft.AspNetCore.Mvc;
using AlcottBackend.Services;
using AlcottBackend.Models;
using AlcottBackend.ClientData;

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
    public ActionResult<Employee> Register(ClientEmployee clientEmployee)
    {
        try
        {
            return _service.AddEmployee(clientEmployee);

        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("login")]
    public ActionResult<string> Login(ClientEmployee clientEmployee)
    {
        try
        {
            return Ok(_service.Login(clientEmployee));
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }


}