using AlcottBackend.Data;
using AlcottBackend.Services;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var allowDevServerPolicy = "_AllowDevServerPolicy";
var viteServerDevUrl = "http://localhost:5173";

// Add services to the container.

builder.Services.AddSqlite<DatabaseContext>("Data source=AlcottBackend.db");
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Key"]!)),
        ValidateAudience = false,
        ValidateIssuer = false
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(allowDevServerPolicy, policy =>
    {
        policy.AllowAnyMethod();
        policy.WithOrigins(viteServerDevUrl);
        policy.AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor(); // To read claims
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<SaleService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<ReportService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(allowDevServerPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.CreateDbIfNotExists();

app.Run();
