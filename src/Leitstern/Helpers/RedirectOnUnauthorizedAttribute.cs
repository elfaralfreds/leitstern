using System;

namespace Leitstern.Helpers;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class RedirectOnUnauthorizedAttribute : Attribute
{
    public string Path { get; }

    public RedirectOnUnauthorizedAttribute(string path)
    {
        Path = path;
    }
}
