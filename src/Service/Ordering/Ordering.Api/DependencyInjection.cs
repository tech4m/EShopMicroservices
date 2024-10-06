namespace Ordering.Api;

public static class DependencyInjection
{
    //before building the application
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddCarter();
        return services;
    }

    //After building the applciation
    public static WebApplication UseApiServices(this WebApplication app)
    {
        app.MapCarter();
        return app;
    }
}
