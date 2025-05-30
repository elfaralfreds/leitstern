using System;

namespace FastDatastar.Helpers;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class RedirectOnUnauthorizedAttribute : Attribute
{
    public string Path { get; }

    public RedirectOnUnauthorizedAttribute()
    {
    }

    public RedirectOnUnauthorizedAttribute(string path)
    {
        Path = path;
    }
}
