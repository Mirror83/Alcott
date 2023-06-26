﻿namespace AlcottBackend.ClientData;

public class EmployeeRegisterRequest
{
    public required string Name { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    public required string Role { get; set; }
}

