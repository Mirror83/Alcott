using AlcottBackend.Data;
using AlcottBackend.Services;

var builder = WebApplication.CreateBuilder(args);
var viteDevServerUrl = "http://localhost:5173";
var AllowDevServerPolicy = "_allowDevServerPolicy";

// Add services to the container.
builder.Services.AddSqlite<DatabaseContext>("Data Source=AlcottBackend.db");
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowDevServerPolicy, policy =>
    {
        policy.WithOrigins(viteDevServerUrl);
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// This enables CORS for all endpoints
app.UseCors(AllowDevServerPolicy);

app.UseAuthorization();

app.MapControllers();

// Call the CreateDBIfNotExists extension method
app.CreateDbIfNotExists();

app.Run();
