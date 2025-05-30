namespace Leitstern.Helpers;
public class _
{
    public static object? Leitstern(object? input = null)
    {
        dynamic? output = input;
        if (output == null)
        {
            output = new System.Dynamic.ExpandoObject();
        }
        output._Leitstern = new
        {
            NavigationContext = new
            {
                Items = new[]
                {
                    new { Label = "Home", Link = "/" },
                    new { Label = "Examples", Link = "/examples" },
                }
            }
        };
        return output;
    }
}