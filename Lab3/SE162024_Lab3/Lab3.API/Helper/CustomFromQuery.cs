using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Lab3.API.Helper;

public class CustomFromQueryAttribute : FromQueryAttribute
{

    public CustomFromQueryAttribute(string name)
    {
        Name = name.ToSnakeCase();
    }
}

public static class ObjectExtensions
{
    public static string ToSnakeCase(this string o) => Regex.Replace(o, @"(\w)([A-Z])", "$1-$2").ToLower();
}