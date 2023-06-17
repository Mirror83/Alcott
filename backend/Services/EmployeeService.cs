using AlcottBackend.Models;
using AlcottBackend.Data;
using AlcottBackend.ClientData;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AlcottBackend.Services;

public class EmployeeService
{
    private readonly DatabaseContext _context;
    private readonly IConfiguration _config;
    public EmployeeService(DatabaseContext context, IConfiguration configuration)
    {
        _context = context;
        _config = configuration;
    }

    public Employee AddEmployee(ClientEmployee clientEmployee)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(clientEmployee.Password);
        var employee = new Employee { Name = clientEmployee.Name, PasswordHash = passwordHash, Role = clientEmployee.Role };
        _context.Add(employee);
        _context.SaveChanges();

        return employee;
    }

    public IEnumerable<Employee> GetEmployees()
    {
        return _context.Employees.ToList();
    }

    public string Login(ClientEmployee clientEmployee)
    {
        var employee = _context.Employees
        .AsNoTracking()
        .FirstOrDefault(employee => employee.Name == clientEmployee.Name);
        if (employee is null) throw new ArgumentException("Invalid employee");

        if (BCrypt.Net.BCrypt.Verify(clientEmployee.Password, employee.PasswordHash) == false)
            throw new ArgumentException("Invalid employee credentials");

        string token = CreateToken(clientEmployee);

        return token;

    }

    // TODO
    private string CreateToken(ClientEmployee clientEmployee)
    {
        throw new NotImplementedException();
    }

}