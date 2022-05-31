namespace Microsoft.AspNetCore.Builder;

using BlazorCA.Server;
using Microsoft.OpenApi.Writers;
using Swashbuckle.AspNetCore.Swagger;

public static class SwaggerGeneratorExtension
{
    public static IApplicationBuilder GenerateSwaggerSchema(this IApplicationBuilder app)
    {
        var provider = app.ApplicationServices.GetRequiredService<ISwaggerProvider>();
        var swaggerDoc = provider.GetSwagger("v1");

        using var txtWriter = new StringWriter();
        swaggerDoc.SerializeAsV2(new OpenApiJsonWriter(txtWriter));
        var result = txtWriter?.ToString();

        File.WriteAllText($"{ProjectSourcePath.Value}swagger.json", result);

        return app;
    }

}
