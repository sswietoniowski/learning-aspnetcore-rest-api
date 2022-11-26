namespace mvc.Configurations.Extensions;

public static class WebApplicationBuilderConfigureAutoMapperExtension
{
    public static WebApplicationBuilder ConfigureAutoMapper(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return builder;
    }
}