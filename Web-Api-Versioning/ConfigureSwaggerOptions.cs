using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Web_Api_Versioning
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider ApiVersionDescriptionProvider;
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            ApiVersionDescriptionProvider = apiVersionDescriptionProvider;
        }

       

        public void Configure(string? name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var kvp in ApiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(kvp.GroupName, CreateVersionInfo(kvp));
            }
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription kvp)
        {
            var info = new OpenApiInfo
            {
                Title = "your api version",
                Version = kvp.ApiVersion.ToString()

            };
            return info;
        }
    }
}
