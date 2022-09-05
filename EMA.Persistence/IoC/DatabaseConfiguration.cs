namespace EMA.Persistence.IoC;

public static class DatabaseConfiguration
{
    public static void AddDatabaseConfiguration(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<DbContext, ApplicationDbContext>();

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(connectionString: configuration.GetConnectionString(name: "Sqlite")
                ?? throw new NullReferenceException(message: "Connection string is empty."));

        },
        contextLifetime: ServiceLifetime.Singleton);
    }
}