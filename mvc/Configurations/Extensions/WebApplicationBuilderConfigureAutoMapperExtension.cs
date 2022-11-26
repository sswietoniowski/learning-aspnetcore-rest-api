namespace mvc.Configurations.Extensions;

public static class WebApplicationBuilderConfigureAutoMapperExtension
{
    public static void ConfigureAutoMapper(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}