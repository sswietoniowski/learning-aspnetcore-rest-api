namespace mvc.Configurations.Extensions;

public static class WebApplicationUseEndpointsExtension
{
    public static void UseEndpoints(this WebApplication app)
    {
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}