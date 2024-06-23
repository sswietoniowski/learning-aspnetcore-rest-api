namespace mvc.Configurations.Extensions;

public static class WebApplicationUseEndpointsExtension
{
    public static WebApplication UseEndpoints(this WebApplication app)
    {
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        return app;
    }
}