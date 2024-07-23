using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AdvancedAPI.Filters;

/// <summary>
/// Lower case filteer will convert the url paths to lowercase.
/// </summary>
public class LowercaseDocumentFilter : IDocumentFilter
{
    /// <summary>
    /// Applies the lowercase convertion.
    /// </summary>
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        Dictionary<string, OpenApiPathItem> paths = swaggerDoc.Paths.ToDictionary(
            path => path.Key.ToLowerInvariant(),
            path => path.Value);

        swaggerDoc.Paths.Clear();

        foreach (KeyValuePair<string, OpenApiPathItem> path in paths)
        {
            swaggerDoc.Paths.Add(path.Key, path.Value);
        }
    }
}