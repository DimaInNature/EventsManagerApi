namespace EMA.Persistence.IoC;

public static class DatabaseConfiguration
{
    public static void AddDatabaseConfiguration(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DbContext, ApplicationDbContext>();

        services.AddDbContextPool<ApplicationDbContext>(options =>
        {
            options.UseSqlite(connectionString: configuration.GetConnectionString(name: "Sqlite")
                ?? throw new NullReferenceException(message: "Connection string is empty."));
        });
    }
}