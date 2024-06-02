using System.Text.RegularExpressions;

namespace Lab3.API.Helper;

public class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object value)
    {
        // Slugify value
        return value == null ? null : Regex.Replace(value!.ToString()!, "([a-z])([A-Z])", "$1-$2").ToLower();
    }
}

public class KebabcaseParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object value)
    {
        return value == null ? null : Regex.Replace(value!.ToString()!, "([a-z])([A-Z])", "$1-$2").ToLower();
    }
}
