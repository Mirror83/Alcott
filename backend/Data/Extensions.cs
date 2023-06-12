namespace AlcottBackend.Data;


public static class Extensions
{
    public static void CreateDbIfNotExists(this IHost host)
    {
        using (IServiceScope scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            DatabaseContext context = services.GetRequiredService<DatabaseContext>();
            context.Database.EnsureCreated();
            DbInitializer.Initialize(context);
        }
    }
}