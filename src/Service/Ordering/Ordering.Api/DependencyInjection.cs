using BuildingBlocks.Exceptions.Handler;

namespace Ordering.Api;

public static class DependencyInjection
{
    //before building the application
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddCarter(); 
        var assembly = typeof(Program).Assembly;
        services.AddCarter();

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(assembly);
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            config.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });

        services.AddValidatorsFromAssembly(assembly);


        //services.AddHealthChecks()
        //    .AddNpgSql(builder.Configuration.GetConnectionString("Database")!);

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddExceptionHandler<CustomExceptionHandler>();

        return services;
    }

    //After building the applciation
    public static WebApplication UseApiServices(this WebApplication app)
    { 
        app.MapCarter();
        app.UseExceptionHandler(options => { });
        return app;
    }
}
