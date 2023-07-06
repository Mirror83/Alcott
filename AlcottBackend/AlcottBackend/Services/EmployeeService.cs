using AlcottBackend.ClientData;
using AlcottBackend.Data;
using AlcottBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AlcottBackend.Services;

public class EmployeeService
{
    private readonly DatabaseContext _context;
    private readonly IConfiguration _config;
    public EmployeeService(DatabaseContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    public IEnumerable<Employee> GetEmployees()
    {
        return _context.Employees.AsNoTracking().ToList();
    }

    /// <summary>
    /// Adds an employee to the database.
    /// Assumes that the client employee is valid
    /// </summary>
    /// <param name="request">Represents the body of the POST request responsible for adding a customer</param>
    public Employee Register(EmployeeRegisterRequest request)
    {
        var employee = new Employee
        {
            Name = request.Name,
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Role = request.Role,
        };
        _context.Employees.Add(employee);
        _context.SaveChanges();

        return employee;
    }

    public Employee? GetById(int id)
    {
        return _context.Employees
            .AsNoTracking()
            .SingleOrDefault(e => e.Id == id);
    }

    public Employee? GetByName(string name)
    {
        return _context.Employees
            .AsNoTracking()
            .SingleOrDefault(e => e.Name == name);
    }

    public EmployeeLoginResponse Login(EmployeeLoginRequest request)
    {
        var employee = GetByName(request.Name);

        if (employee is null || !BCrypt.Net.BCrypt.Verify(request.Password, employee.PasswordHash))
        {
            throw new ArgumentException("Invalid name or password");
        }

        var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, employee.Name),
                new Claim(ClaimTypes.Role, employee.Role)
            };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_config["AppSettings:Key"]!)
            );

        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: cred,
            expires: DateTime.Now.AddDays(1)
            );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return new EmployeeLoginResponse { Token = jwt, EmployeeName = employee.Name };

    }

    public int? GetIdFromName(string name)
    {
        var employee = _context.Employees.
            AsNoTracking()
            .SingleOrDefault(e => e.Name == name);

        return employee?.Id;
    }
}
