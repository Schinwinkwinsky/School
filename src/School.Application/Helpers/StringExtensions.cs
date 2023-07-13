namespace School.Application.Helpers;

public static class StringExtensions
{
    public static string Capitalize(this string value)
    {
        return value.Substring(0, 1).ToUpper() + value.Substring(1);
    }
}
